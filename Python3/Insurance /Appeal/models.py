from django.db import models


class Service(models.Model):
    service = models.CharField(max_length = 100)


    @classmethod
    def service_list(cls):
        return list(lst.service  for lst  in Service.objects.all())

    def __str__(self):
        return '{}'.format(self.service)

class Customers(models.Model):
    policy_number = models.CharField(max_length = 30)
    type_of_insurance = models.CharField (max_length = 30)
    ending_date = models.DateField()
    company = models.CharField(max_length = 50)
    number = models.CharField(max_length = 12, default='84951234567')
    services =  models.ManyToManyField(Service, default = None)


    @classmethod
    def check_snils(cls, policy):
        if len(Customers.objects.filter(policy_number__exact= policy)):
            return True
        return False


    @classmethod
    def company_list(cls):
        companies =set(lst.company for lst  in Customers.objects.all())
        return companies

    def __str__(self):
        return '{}, {}'.format(self.policy_number, self.company)





# Create your models here.
