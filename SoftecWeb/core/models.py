from django.db import models
from django.db.models.signals import post_save
from django.dispatch import receiver

class Pos(models.Model):
    'POS'
    pos_name = models.CharField(max_length=255, null=False, blank=False)
    version = models.CharField(max_length=255, null=True, blank=True)
    notes = models.TextField()

    def __str__(self):
        return self.pos_name


class Customer(models.Model):
    'Customer'
    name = models.CharField(max_length=255, null=False, blank=False)
    notes = models.TextField()

    def __str__(self):
        return this.name


class Phone(models.Model):
    'Phone'
    number = models.CharField(max_length=255, null=False, blank=False)
    owner = models.ForeignKey(Customer)

    def __str__(self):
        return self.number


class Email(models.Model):
    'Email'
    email = models.CharField(max_length=255, null=False, blank=False)
    owner = models.ForeignKey(Customer)

    def __str__(self):
        return this.email


class Restaurant(models.Model):
    'Restaurant'
    name = models.CharField(max_length=255, null=False, blank=False)
    city = models.CharField(max_length=255, null=True, blank=True)
    state = models.CharField(max_length=255, null=True, blank=True)
    country = models.CharField(max_length=255, null=True, blank=True)
    address = models.CharField(max_length=255, null=True, blank=True)
    eAutomateID = models.CharField(max_length=255, null=True, blank=True)
    notes = models.TextField()
    pos = models.ForeignKey(Pos)

    def __str__(self):
        return '%s (%s)' % (self.name, self.eAutomateID)


class Computer(models.Model):
    'Computer'
    name = models.CharField(max_length=255, null=False, blank=False)
    serial_number = models.CharField(max_length=255, null=True, blank=True)
    notes = models.TextField()
    restaurant = models.ForeignKey(Restaurant)

    def __str__(self):
        return '%s | %s' % (self.restaurant.name, self.serial_number)



# @receiver(post_save, sender=Restaurant)
# def set_eAutomate_ID(sender, **kwargs):
#     if kwargs['created']:
#         instance = kwargs['instance']
#         split_name = instance.name.split(' ')

#         prefix = ''
#         if len(split_name) == 1: # name has one word
#             prefix = split_name[0][0:2].upper() # first 2 characters of the only word
#         else: # name has two or more words
#             prefix = split_name[-2][0].upper() # first character of the first word
#             prefix += split_name[-1][0].upper() # second character of the second word

#         suffix = str(instance.id).zfill(2)

#         instance.eAutomateID = prefix + suffix
#         instance.save()



