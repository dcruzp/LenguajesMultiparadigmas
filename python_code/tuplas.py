def conParen():
    tupla = (1, 2, 3, 4, 5)
    print(tupla)
    print(type(tupla))

def sinParen():
    tupla = 1, 2, 3, 4, 5
    print(tupla)
    print(type(tupla))

def empty():
    tupla = ()
    print(tupla)
    print(type(tupla))

def tupOneElem():
    tupla = (1,)
    print(tupla)
    print(type(tupla))

def NestedTule():
    # Code for creating nested tuples
    tuple1 = (0, 1, 2, 3, 4)
    tuple2 = ('Python', 'C++', 'C#', 'F#', 'Haskell')
    tuple3 = (tuple1, tuple2)
    print(tuple3)


conParen()
sinParen()
empty()
tupOneElem()
NestedTule()