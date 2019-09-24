from django.db import models
from django.shortcuts import reverse

from django.utils.text import slugify #спец функуия для генерации слагов
from time import time

#генерирует  слаг
def gen_slug(s):
    new_slug = slugify(s, allow_unicode = True)
    return new_slug + '-' + str(int(time()))


class Post(models.Model):
    title = models.CharField(max_length=150, db_index=True)
    slug = models.SlugField(max_length=150, blank=True,  unique=True)
    body = models.TextField(blank=True, db_index=True)
    date_pub = models.DateTimeField(auto_now_add=True)
    tags = models.ManyToManyField('Tag', blank=True, related_name='posts')
    #related_name отвечает за свойство которое появится у экз класса Tag

    # передаёт слаг экземпляра поста методу get класса PostDetail
    def get_absolute_url(self):
        return reverse('post_detail_url', kwargs={'slug': self.slug})


    def get_update_url(self):
        return reverse('post_update_url', kwargs={'slug': self.slug})


    def save(self, *args, **kwargs):
        if not self.id:
            self.slug = gen_slug(self.title)
        super().save(*args, **kwargs)


    def get_delete_url(self):
        return reverse('post_delete_url', kwargs={'slug': self.slug})


    def __str__(self):
        return '{}'.format(self.title)

# (поле ordering) Отвечает за сортировку постов в таблице  Posts
    class Meta:
        ordering = ['-date_pub']

class Tag(models.Model):
    title = models.CharField(max_length = 50)
    slug = models.SlugField(max_length = 50, unique = True)

    # передаёт слаг экземпляра тега методу get класса TagDetail
    def get_absolute_url(self):
        return reverse('tag_detail_url', kwargs={'slug': self.slug })

    def get_update_url(self):
        return reverse('tag_update_url', kwargs={'slug': self.slug})

    def get_delete_url(self):
        return reverse('tag_delete_url', kwargs={'slug': self.slug})

    def __str__(self):
        return '{}'.format(self.title)

    class Meta:
        ordering = ['title']

# Create your models here.
