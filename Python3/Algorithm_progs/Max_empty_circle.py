import matplotlib.pyplot as plt
import numpy as np
esp1 = 0.00001
esp2 = 0.00001
points = [(2,4), (3,1), (5,5), (5,8), (7,5), (9,3), (10, 7), (11, 4)]


def dist2 (x1, y1, x2, y2):
    return (x1-x2)*(x1-x2) + (y1-y2)*(y1-y2)


q = {'fx': 0, 'fy': 0}


def check(r, q, x1, y1, x2, y2):
    if np.abs(x1 - x2) < esp1 and np.abs(y1 - y2) < esp1:
        q['fx'] = (x1 + x2)/2
        q['fy'] = (y1 + y2)/2
        rez = False
        return rez
    c1 = True; c2 = True; c3 = True; c4 = True;
    for xi, yi in points:
        d1 = dist2(x1, y1, xi, yi) <= r * r
        d2 = dist2(x1, y2, xi, yi) <= r * r
        d3 = dist2(x2, y1, xi, yi) <= r * r
        d4 = dist2(x2, y2, xi, yi) <= r * r
        if d1 and d2 and d3 and d4:
            rez = True
            return rez
        c1 = c1 and not d1
        c2 = c2 and not d2
        c3 = c3 and not d3
        c4 = c4 and not d4
    if c1:
        q['fx'] = x1
        q['fy'] = y1
        rez = False
        return rez
    if c2:
        q['fx'] = x1
        q['fy'] = y2
        rez = False
        return rez
    if c3:
        q['fx'] = x2
        q['fy'] = y1
        rez = False
        return rez
    if c4:
        q['fx'] = x2
        q['fy'] = y2
        rez = False
        return rez
    rez = check(r, q, x1, y1, (x1+x2)/2, (y1+y2)/2) and check(r, q, (x1+x2)/2, y1, x2, (y1+y2)/2) and check(r, q, x1, (y1+y2)/2, (x1+x2)/2, y2) and check(r, q, (x1+x2)/2, (y1+y2)/2, x2, y2)
    return rez


xr = 12
yr = 10
lb = 0
if xr < yr:
    rb = xr
else:
    rb = yr
while np.abs(lb - rb) > esp2:
    r = (lb + rb)/2
    if check(r, q,  0+r, 0+r, xr-r, yr-r):
        rb = r
    else:
        lb = r

for xi, yi in points:
    plt.plot(xi, yi, 'x', color='red')
plt.plot(q['fx'], q['fy'], '.', color='blue')
#plt.plot([0, yr], [xr, yr])
plt.plot(xr, yr, '', color='green')
plt.plot(0, 0, '', color='green')

axes = plt.gca()
axes.set_aspect("equal")
circle2 = plt.Circle((q['fx'], q['fy']), radius=r, fill=False, color="g")
axes.add_patch(circle2)
#plt.plot(q['fx'], q['fy'], '.', color='g')
plt.show()
print(q, r)