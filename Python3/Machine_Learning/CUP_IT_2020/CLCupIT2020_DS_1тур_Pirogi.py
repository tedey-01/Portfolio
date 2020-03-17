import pandas as pd
import pickle
from sklearn.preprocessing import StandardScaler
from warnings import simplefilter
simplefilter(action='ignore', category=FutureWarning)

def converter(df):
    # Усредняемые признаки
    mean_feats =['cif_id','gi_smooth_3m', 'cc_balance', 'ml_balance', 'pl_balance','td_volume', 'ca_volume', 'sa_volume',
             'mf_volume', 'dc_cash_spend_v', 'cc_cash_spend_v', 'dc_pos_spend_v', 'cc_pos_spend_v',
             'rc_session_qnt_cur_mon', 'cur_qnt_sms', 'salary']
    # Датафрейм с усреднёнными данными по каждому пользователю
    mean_feats_df = df[mean_feats].groupby('cif_id').mean()

    #Выбор последней актуальной заприси по каждому пользователю
    grouped = df.sort_values('dlk_cob_date').groupby(['cif_id'], as_index = False)
    new_06m_df = grouped.apply(lambda x: x.iloc[-1])


    new_06m_df.index = new_06m_df['cif_id']
    new_06m_df.index.names = ['index']

    #конечное преобразование данных
    new_06m_df[mean_feats[1:]] = mean_feats_df.loc[:]

    #Удаление лишних столбцов
    X = new_06m_df
    X.index = X['cif_id']
    X.drop(['cif_id', 'dlk_cob_date'], axis= 1, inplace = True)
    return X




def main(filename):

    #загрузка данных
    df_test = pd.read_csv('CUP_IT_test_data.csv', skiprows=133)

    #удаление лишних и неактуальных признаков.
    useless_feats = ['cur_quantity_pl', 'cur_quantity_mort', 'cur_quantity_mf', 'standalone_payroll_dc_f',
                     'dc_cash_spend_c', 'cc_cash_spend_c', 'dc_pos_spend_c', 'cc_pos_spend_c',
                     'cu_education_level', 'cu_empl_area', 'cu_empl_level', 'cu_empl_cur_dur_m',
                     'cl_balance', 'cu_eduaction_level', 'rank']
    df_test.drop(useless_feats, axis=1, inplace=True)


    #заполнение пропусков
    df_test = df_test.fillna(0)
    ca_volume_median = df_test['ca_volume'].median()
    df_test['ca_volume'] = df_test['ca_volume'].fillna(ca_volume_median)

    #преобразование котегориальных признаков
    df_test = pd.concat([df_test, pd.get_dummies(df_test['big_city'], prefix='big_city'),
                         pd.get_dummies(df_test['cu_gender'], prefix='cu_gender'),
                         pd.get_dummies(df_test['payroll_f'], prefix='payroll_f'),
                         pd.get_dummies(df_test['ca_f'], prefix='ca_f'),
                         pd.get_dummies(df_test['standalone_dc_f'], prefix='standalone_dc_f'),
                         pd.get_dummies(df_test['is_married'], prefix='is_married')], axis=1)

    df_test.drop(['big_city', 'cu_gender', 'payroll_f', 'ca_f', 'standalone_dc_f', 'is_married'], axis=1, inplace=True)


    X_test = converter(df_test)


    #стандартизация данных
    scaler = StandardScaler()
    X_all_test_scaled = scaler.fit_transform(X_test)

    #Загрузка обученной модели логистической регрессии и получение прогноза оттока
    logit = pickle.load(open(filename, 'rb'))
    valid_predict = logit.predict_proba(X_all_test_scaled)

    #преобразование прогноза вероятности оттока в целевой вектор
    results = pd.DataFrame(X_test['gi_smooth_3m'])
    results['koef'] = valid_predict[:, 1]

    results['cltv'] = results['gi_smooth_3m'] * results['koef'] * 6

    #запись в файл
    results['cltv'].to_csv('CUP_IT_predictions.csv')





if __name__ == '__main__':
    filename = 'logit_model.sav'
    main(filename)