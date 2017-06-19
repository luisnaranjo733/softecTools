from django.contrib import admin
from django.contrib.admin import AdminSite

from .models import (Pos, Restaurant, Computer, Customer, Phone, Email, RestaurantFile, GlobalPasword)
# Register your models here.

class PosAdmin(admin.ModelAdmin):
    list_display = [
        'pos_name',
        'version'
    ]


class ComputerInline(admin.StackedInline):
    model = Computer
    extra = 0

class RestaurantFileInline(admin.TabularInline):
    model = RestaurantFile
    extra = 0

class RestaurantAdmin(admin.ModelAdmin):
    list_display = [
        'name',
        'city',
        'state',
        'eAutomateID',
        'pos'
    ]

    list_filter = (
        'name',
        'city',
        'pos__pos_name',
        'state',
    )

    search_fields = [
        'name',
        'city',
        'eAutomateID'
    ]

    inlines = [ComputerInline, RestaurantFileInline]


class ComputerAdmin(admin.ModelAdmin):
    list_display = [
        'name',
        'serial_number',
        'restaurant'

    ]

    list_filter = (
        'restaurant__eAutomateID',
    )

    search_fields = [
        'serial_number',
        'restaurant__name',
        'restaurant__eAutomateID'
    ]

class PhoneInline(admin.TabularInline):
    model = Phone
    extra = 0

class EmaliInline(admin.StackedInline):
    model = Email
    extra = 0

class CustomerAdmin(admin.ModelAdmin):
    inlines = [PhoneInline, EmaliInline]
    search_fields = [
        'name',
    ]


class MyAdminSite(AdminSite):
    site_header = 'Softec administration'
    site_title = 'Softec Web'
    site_url = None

admin_site = MyAdminSite(name='softecadmin')

admin_site.register(Pos, PosAdmin)
admin_site.register(Restaurant, RestaurantAdmin)
admin_site.register(Computer, ComputerAdmin)
admin_site.register(Customer, CustomerAdmin)
admin_site.register(GlobalPasword)