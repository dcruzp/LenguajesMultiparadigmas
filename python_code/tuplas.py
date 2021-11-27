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

def exampleConcat():
    t1 = ('this', 'world', 'game')
    t2 = ('bit', 'code', 'terminal')
    t3 = t1 + t2
    print(t3)

def repeticion():
    tupla = ('Python',)*5
    print(tupla)

def testInmutableTupla():
    #code to test that tuples are immutable
    tupla = (-8, 1, 12, 3)
    tupla[1] = 2
    print(tupla)

conParen()
sinParen()
empty()
tupOneElem()
NestedTule()
exampleConcat()
repeticion()

testInmutableTupla()