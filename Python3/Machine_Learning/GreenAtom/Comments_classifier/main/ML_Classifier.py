from sklearn.linear_model import LogisticRegression
from sklearn.feature_extraction.text import TfidfVectorizer
from bs4 import BeautifulSoup
import numpy as np
import re


class Classifier():
    def __init__(self, model, tf_idf_vectorizer):
        self.logit = model
        self.tf_idf_vectorizer = tf_idf_vectorizer


    def strip_html(self, text):
        soup = BeautifulSoup(text, 'html.parser')
        return soup.get_text()

    # Удаление квадратных скобок
    def remove_square_brackets(self, text):
        return re.sub('\[[^]]*\]', '', text)

    # Общая чистка
    def clean_text(self, text):
        text = self.strip_html(text)
        text = self.remove_square_brackets(text)
        return text

    # Глубокая чистка
    def deep_cleaning(self, text, remove_digits=True):
        pattern = r'[^a-zA-z0-9\s]'
        text = re.sub(pattern, '', text)
        return text


    def processing (self, text):
        text = self.clean_text(text)
        text = self.deep_cleaning(text)
        text_vec = self.tf_idf_vectorizer.transform([text,])
        score = int(self.logit.predict(text_vec))
        tone = 1*np.sign(score-5)
        return (tone, score)

