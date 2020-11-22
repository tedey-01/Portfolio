from django.shortcuts import render
from .forms import UserForm
from .ML_Classifier import Classifier
import joblib
from sklearn.linear_model import LogisticRegression

tf_idf_vec = joblib.load('tf_idf_vec.pkl')
model = joblib.load('model.pkl')
clf = Classifier(model, tf_idf_vec)



def index(request):
    return render(request, 'main/index.html')


def write_review(request):
    submitbutton = request.POST.get("submit")
    print(submitbutton)

    result = ''
    review = ''

    form = UserForm(request.POST or None )
    if form.is_valid():
        review = form.cleaned_data.get("review")
        tmp = clf.processing(review)
        result = {'tone':'positive' if tmp[0] > 0 else 'negative', 'score': tmp[1]}

    context = {'form': form, 'review': review, 'result': result, 'submitbutton': submitbutton}
    return render(request, 'main/review.html', context)