# cadena = 'Hello world!'
# tupla = (1,2)
# tupla[0] = 5
# cadena[1] ='3'


def tuplasInmutabilidad():
    tupla = (1,4,5)
    tupla[1] = 2
    print(tupla)

def stringsInmutabiliad():
    cadena = 'Inmutability in Python'
    cadena[1] = 'a'
    print(cadena)

def frozenSetInmutabiliad():
    elems = [1,4,5,6,8]
    froz = frozenset(elems)
    froz[0] = 2
    print(froz)



# frozenSetInmutabiliad()
a = int(5)
# a = (1,2)
# a = (2,4)

class MyImmutable(tuple):

    def __new__(cls, a, b):
        return tuple.__new__(cls, (a, b))

    @property
    def a(self):
        return self[0]

    @property
    def b(self):
        return self[1]

    def __str__(self):
        return f"->MyImmutable {self.a}, {self.b}<-"

    def __setattr__(self, *ignored):
        raise NotImplementedError

    def __delattr__(self, *ignored):
        raise NotImplementedError

a = MyImmutable(1,2)
a[0] = 2
print(a[0])