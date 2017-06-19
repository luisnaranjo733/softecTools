from django.conf.urls import url
from core import views



urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^data/$', views.provide_data_items, name='provide_data_items')
]