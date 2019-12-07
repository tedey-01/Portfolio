from django.urls import path, include

from . import views

urlpatterns = [
    path('', views.AnswerPage.start_page, name = 'home'),
    path('answer/', views.AnswerPage.answer_page, name = 'answer'),
]
