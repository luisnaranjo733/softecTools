# -*- coding: utf-8 -*-
# Generated by Django 1.10.6 on 2017-06-20 17:12
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('core', '0019_auto_20170619_1510'),
    ]

    operations = [
        migrations.AlterField(
            model_name='restaurant',
            name='eAutomateID',
            field=models.CharField(default=0, max_length=255, unique=True),
            preserve_default=False,
        ),
    ]