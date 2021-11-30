from typing import List


a = 5
b = 1.2
cadena = "CPU"
elems = [1,3,4]


print(type(a))
print(type(b))
print(type(cadena))
print(type(elems))


def loopListType():

    for i in ['hello', 1, (1,2), [1,2,4,5,6]]:
        print(type(i))


loopListType()