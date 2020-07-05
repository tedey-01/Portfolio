from django.urls import path
from . import views

urlpatterns = [
    path('', views.index, name = 'home'),
    path('write_review', views.write_review, name = 'review')
]