
def example1():
    n = [x() for x in [lambda x=x: x*10 if x%2 ==0 else x*5 for x in range(1, 11)]]
    print(n)

def example2():
    # toggle case

    # Inicializar el  string
    string = 'Python'

 
    # Toggle case de cada caracter de entrada
    toggle = lambda s: [chr(ord(c)^32) for c in s ]
    # Imprimir la lista
    print(toggle(string))

example2()