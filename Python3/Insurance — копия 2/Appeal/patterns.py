from .models import *
import re

def compare(snils):
    patterns=[
        r'\d{4} \d{8}',
        r'\d{4} \d{6}',
        r'\d{4}-\d{6}-\d{2}',
        r'\d{2}-\d{2} \d{4}-\d{2}',
        r'\d{2}-\d{6}-\d{4}',
        r'\d{4}-\d{6}'
    ]
    pattern = r''
    for el in patterns:
        if re.search (el, snils):
            pattern=el
            break
    print('pat= ', pattern)
    if pattern:
        same_queries=Customers.objects.filter(policy_number__iregex = pattern)

        if len(same_queries):
            pair=same_queries[0].company, same_queries[0].type_of_insurance
            return pair
        return
    return
