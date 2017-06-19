from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, JsonResponse, Http404
from django.views.decorators.csrf import csrf_exempt
from core.models import DataItem, Restaurant, GlobalPassword


from werkzeug.security import generate_password_hash, \
     check_password_hash


# Create your views here.
def index(request):
    'index'
    return HttpResponse('hello, world')

from pprint import pprint

def check_password(password):
    'Return true if this unhashed password matches one of the stored hashed passwords'
    for global_password in GlobalPassword.objects.all():
        if check_password_hash(global_password.hashed_password, password):
            return True

    return False

@csrf_exempt
def provide_data_items(request):
    'Provide data items'
    response_map = {
        'authorized': False,
        'data': []
    }

    if request.method == 'POST':
        restaurant_id = request.POST.get('restaurant-id', None)
        restaurant_id = int(restaurant_id)
        password = request.POST.get('password', '')

        if restaurant_id:
            restaurant = get_object_or_404(Restaurant, pk=restaurant_id)

            if check_password(password):
                data_items = DataItem.objects.filter(restaurant=restaurant)
                response_map['authorized'] = True
            else:
                data_items = DataItem.objects.filter(restaurant=restaurant, protected=False)

            for data_item in data_items:
                obj = {
                    'key': data_item.key,
                    'value': data_item.value,
                    'protected': data_item.protected
                }
                response_map['data'].append(obj)

            return JsonResponse(response_map, safe=False)

    raise Http404



