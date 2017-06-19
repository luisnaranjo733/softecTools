from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
from django.views.decorators.csrf import csrf_exempt
from core.models import DataItem


from werkzeug.security import generate_password_hash, \
     check_password_hash


# Create your views here.
def index(request):
    'index'
    return HttpResponse('hello, world')

from pprint import pprint

@csrf_exempt
def provide_data_items(request):
    'Provide data items'
    if request.method == 'POST':
        restaurant_id = request.POST.get('restaurant-id', None)
        password = request.POST.get('password', '')

        # data_items = DataItem.objects.filter()

    data_items_map = {
        'key1': 'value1',
        'key2': 'value2'
    }
    return JsonResponse(data_items_map)

