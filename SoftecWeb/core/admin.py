from django.contrib import admin
from .models import (Pos, Restaurant, Computer, Customer, Phone, Email)
# Register your models here.

class PosAdmin(admin.ModelAdmin):
    pass


class ComputerInline(admin.StackedInline):
    model = Computer
    extra = 0


class RestaurantAdmin(admin.ModelAdmin):
    list_display = [
        'name',
        'city',
        'eAutomateID',
        'pos'
    ]

    list_filter = (
        'name',
        'city',
        'pos__pos_name'
    )

    search_fields = [
        'name',
        'city',
        'eAutomateID'
    ]

    inlines = [ComputerInline, ]


class ComputerAdmin(admin.ModelAdmin):
    list_display = [
        'name',
        'serial_number',
        'restaurant'

    ]

    list_filter = (
        'restaurant__eAutomateID',
    )


class CustomerAdmin(admin.ModelAdmin):
    pass


class PhoneAdmin(admin.ModelAdmin):
    pass


class EmailAdmin(admin.ModelAdmin):
    pass


admin.site.register(Pos, PosAdmin)
admin.site.register(Restaurant, RestaurantAdmin)
admin.site.register(Computer, ComputerAdmin)
admin.site.register(Customer, CustomerAdmin)
admin.site.register(Phone, PhoneAdmin)
admin.site.register(Email, EmailAdmin)