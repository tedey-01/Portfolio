from django.shortcuts import render
from django.http import HttpResponse

from .models import *
from .patterns import compare
import re


class AnswerPage:
    chosen_services = []

    @classmethod
    def start_page(cls,request):
        cls.chosen_services =[]
        company_list = Customers.company_list()
        services_list = Service.service_list()

        env = {'company_key': company_list, 'service_key': services_list}

        return render(request, 'appeal/base_appeal.html', context = env)


    @classmethod
    def answer_page(cls, request):
        resp_form = {}
        resp_form['snils'] = request.GET.get('snils_line', '')
        resp_form['company_line'] = request.GET.get('company_line', '')
        resp_form['service_line'] = request.GET.get('service_line', '')

        company_list = Customers.company_list()
        services_list = Service.service_list()


        if 'add' in request.GET:
            cls.chosen_services.append(request.GET.get('service_line', ''))
            print()
            print(cls.chosen_services)
            for el in request.GET:
                if el.startswith('delete'):
                    print (el)
                    cls.chosen_services.remove(el[7:])

            env = {
                'service_key': services_list,
                'resp_form_key' : resp_form,
                'chosen_services': set(cls.chosen_services)
                }
            return render(request, 'appeal/adding_services.html', context = env)

        else :
            cls.chosen_services.append(request.GET.get('service_line', ''))

        if not Customers.check_snils(resp_form['snils']):
            return render(request, 'appeal/fail.html')

        pair = compare(resp_form['snils'])
        if  not resp_form['company_line']:
            resp_form['company_line']=pair[0]

        all_available, all_unavailable = services_status(resp_form['snils'])
        available = all_available.intersection(cls.chosen_services)
        unavailable = all_unavailable.intersection(cls.chosen_services)
        unknown = set(cls.chosen_services).difference(available).difference(unavailable)

        env = {
            'company_key': company_list,
            'service_key': services_status,
            'resp_form_key' : resp_form,
            'available': available,
            'unavailable': unavailable,
            'unknown': unknown
            }

        return render(request, 'appeal/answer_appeal.html', context = env)


def services_status(snils):
    user =  Customers.objects.get(policy_number__exact=snils)
    available = set([el.service for el in user.services.all() ])
    unavailable  = (set(Service.service_list())).difference(available)

    return available, unavailable
