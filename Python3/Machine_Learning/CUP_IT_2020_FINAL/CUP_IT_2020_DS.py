import pandas as pd
import numpy as np
import math
from sklearn.linear_model import LinearRegression
import pickle


class Regressor():
    def __init__(self, learned_model, sector_feats):
        self.xgb = learned_model
        self.sector_feats = sector_feats

    def init_data(self, data):
        self.data = data

    def min_long(self, x):
        latitude = self.data.loc[x]['place_latitude']
        longitude = self.data.loc[x]['place_longitude']
        self.sector_feats['sub_latitude'] = self.sector_feats['place_latitude'].apply(lambda x1: (x1 - latitude) ** 2)
        self.sector_feats['sub_longitude'] = self.sector_feats['place_longitude'].apply(
            lambda x1: (x1 - longitude) ** 2)
        self.sector_feats['rez'] = self.sector_feats['sub_latitude'] + self.sector_feats['sub_longitude']
        rez = self.sector_feats.sort_values('rez').index[0]
        return rez

    def processing(self):
        self.data['ind'] = self.data.index
        self.data['sector_1'] = self.data['ind'].apply(self.min_long)
        self.sector_feats['sector_1'] = self.sector_feats.index
        self.data = self.data.merge(self.sector_feats[['sector_1', 'mean_feat', 'min_feat', 'max_feat', 'mode_feat']],
                                    on='sector_1', how='left')
        self.data.drop(['sector_1', 'ind'], axis=1, inplace=True)

    def create_time_feats(self):
        self.data['time_start'] = pd.to_datetime(self.data['time_start'])
        self.data['year'] = self.data['time_start'].apply(lambda x: x.year)
        self.data['month'] = self.data['time_start'].apply(lambda x: x.month)
        self.data['week_day'] = self.data['time_start'].apply(lambda x: x.isoweekday())
        self.data['day'] = self.data['time_start'].apply(lambda x: x.day)
        self.data['hour'] = self.data['time_start'].apply(lambda x: x.hour)

    def predicting(self):
        self.data.drop('time_start', axis=1, inplace=True)
        return self.xgb.predict(self.data)


def main():
    test_data = pd.read_csv('test.csv', sep = ';')
    filename = 'lr_model.sav'
    regressor = pickle.load(open(filename, 'rb'))
    regressor.init_data(test_data)
    regressor.create_time_feats()
    regressor.processing()
    pred = regressor.predicting()
    pd.DataFrame(pred).to_csv('CUP_IT_2020_DS_predictions.csv')
    print(pred.shape)


if __name__ == '__main__':
    main()