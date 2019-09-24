from django.shortcuts import render
from django.http import HttpResponse
from django.shortcuts import redirect

def redirect_blog(request):
    return redirect('posts_list_url', permanent=True)

# def hello(request):
#     return HttpResponse('<h1>Hello World</h1>')
