# -*- coding: utf-8 -*-
# Generated by Django 1.11 on 2017-06-13 21:29
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('core', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='computer',
            name='name',
            field=models.CharField(default='', max_length=255),
            preserve_default=False,
        ),
        migrations.AlterField(
            model_name='computer',
            name='serial_number',
            field=models.CharField(blank=True, max_length=255, null=True),
        ),
    ]
