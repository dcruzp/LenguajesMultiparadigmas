### Python

El concepto funciones como ciudadanos de primera clase manda que las funciones son tratados como ciudadanos de primera clase: almacenadas en variables o es una estructura de datos, pasadas o devueltas como variables por una función.
Se dice que en un lenguaje las funciones son de primera clase (o que son "objetos de primera clase") cuando se pueden tratar como cualquier otro valor del lenguaje, es decir, cuando se pueden almacenar en variables, pasar como parámetro y devolver desde funciones, sin ningún tratamiento especial. 
Funciones de primera clase: si una función se puede asignar a una variable o pasar como objeto/variable a otra función, esa función se llama como función de primera clase.

Las funciones como ciudadanos de primera ninvel significan que puedes pasar funciones como otros objetos. Eso significa que puede asignar funciones a variables, puede pasarlas como argumentos, puede almacenarlas en estructuras de datos más grandes, definirlas dentro de otra función y también devolverlas desde otra función, como cualquier otro objeto. 
Esto se logra en Python porque las funciones no son más que objetos. Tiene tantos parámetros / métodos los cuales puedes  inspeccionar usando el método dir ().
Entonces las funciones en Python son objects de tipo.

Veamos las ventajas de que las funciones sean objetos.

**Asignar funciones a variables:**

Digamos que defino un método greet como este:
```Python
def greet(name):
    print("Hello " + name)

greet("World")                ## => "Hello World"
greet("Universe")                ## => "Hello Universe"
```

Pero como _greet_ es un objeto de tipo función, puedo asignarlo a una variable  a la que llamo _say_hello_:
```Python
say_hello = greet
```
Ahora _say_hello_ es un objeto de tipo función, lo que significa que puedo llamarlo como _greet_:

```Python
say_hello("Earth")                         ## => "Hello Earth"
say_hello("Mars")                         ## => "Hello Mars"
```

Esto se puede hacer debido a que las funciones son ciudadanos de primera clase(first class citizens).


**Pasando funciones comom argumentos:**

En Python puedes pasar funciones como argumentos de otras funciones

Supongamos que tenemos una función _call_func_ que se define :

```Python
def call_func(x, func):
    """recieve a function and execute it and return result"""
    return func(x)

```
_call_func_ es una función que solo devuelve el valor de _func(x)_


Definamos dos funciones simples :
```Python
def square(x): return x * x
def cube(x): return x * x * x
```

Ahora pasemos estas funciones a _call_func_ 

```Python
res = call_func(6, do_square)   # passing function to another function
print(res)
res = call_func(5, do_cube)
print(res)
```
*Almacenando funciones en otras estructuras de datos:*

También puedes almacenar funciones en otras structuras de datos como listas, diccioarios, etc

Definamos una lista llamada _operations_ que almacene la función previamente definiada _square_ y _cube_:

```Python
operations = [square, cube]
```
Y luego vamos a llamar a estas funciones con los índices de la lista:

```Python
print(operations[0](3)) ##=> 9
print(operations[1](7)) ##=>343
```

## List comprehension 

Uno de los aspectos más distintivos de Python son las list y las list comprehension feature, que pueden usarse en una línea de código construir funcionalidades poderosas.

Las list comprehension se utilizan para crear  nuevas listas a partir de otros iterables como tuplas, strings, lists,etc. 

**List comprehension Python Sintax:**

``` Python
newList = [ expression(element) for element in oldList if condition ] 
```

Ventajas de las List comprehension:
* Más eficiente en tiempo y espacio que los ciclos(loops)
* Requiere menos líneas de código
* Transforma una declaración iterativa en una fórmula

**List Comprehensions vs Ciclos For:**

Hay varias formas de recorrer una lista en Python. Sin embargo el enfoque más común es usar el ciclo for.

Veamos el siguiente ejemplo:
   
```Python
# Lista vacía
List = []
 
# Enfoque tradicional al iterar
for c in 'ComputerScience':
    List.append(c)
 
# imprimir la lista
print(List)
```


Ouput:
```
['C', 'o', 'm', 'p', 'u', 't', 'e', 'r', 'S', 'c', 'i', 'e', 'n', 'c', 'e']

```
 Esta es la manera tradicional para iterar por una lista, tupla, string, etc en Python. Ahora con list comprehension podemos hacer la misma tarea y hacemos que el programa sea más simple.


 List comprehension traduce el enfoque de una interación tradicional usando for en una fórmula simple, lo que las hace fáciles de usar. A continuación se muestra el enfoque parar iterar a través de una lista, string, tupla, etc utilizando list comprehension.

```Python
 # usando list comprehension para iterar a través de un ciclo
List = [character for character in 'ComputerScience']
 
# imprime en patalla List
print(List)
```
Ouput:
```
['C', 'o', 'm', 'p', 'u', 't', 'e', 'r', 'S', 'c', 'i', 'e', 'n', 'c', 'e']

```
 
**Más ejemplos:**

Obtener una lista con los enteros que están en [0,10):
```Python
d = [x for x in range(10)]

print(d)
```

Output:
```Python
[0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
```

Números pares hasta 100:
```Python
pares = [ x for x in range(100) if x%2 ==0]
print(pares)
```
Output:

```Python
[0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70, 72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98]
```

Las list comprehension son más eficientes tanto computacionalmente como en términos de espacio y tiempo de codificación que un ciclo for. Normalmente se escriben en una sola línea de código. 

El siguiente código muestra la diferencia entre ciclos for y list comprehension según el rendimiento:

```Python
import time
 
# definamos la función a implementar usando ciclo for  

def for_loop(n):
    result = []
    for i in range(n):
        result.append(i**2)
    return result
 
 
# definamos la función a implementar usando list comprehension
def list_comprehension(n):
    return [i**2 for i in range(n)]
 
 

 
# Calcular el tiempo que toma for_loop()
begin = time.time()
for_loop(10**6)
end = time.time()
 
# Mostrar el tiempo que tomó for_loop()
print('Time taken for_loop:',round(end-begin,2))
 
# Calcular el tiempo que toma lis_comprehension()
begin = time.time()
a = list_comprehension(10**6)
end = time.time()
 
# Mostrar el tiempo que tomó list_comprehension()
print('Time taken for list_comprehension:',round(end-begin,2))
```

Output:
```
Time taken for_loop: 0.26
Time taken for list_comprehension: 0.23
```
Se puede ver que las list comprehension son bastante más rápidas que los ciclos for.

**List comprehension anidadas:**

Las list comprehension anidadas no son más que una list comprehension dentro de otra list comprehension, bastante similar a los ciclos anidados.

A continuación un código con ciclos anidados:
```Python
#using nested for-loop

matrix = []
 
for i in range(3):
     
    # Append an empty sublist inside the list
    matrix.append([])
     
    for j in range(5):
        matrix[i].append(j)
         
print(matrix)
```

Output:
```
[[0, 1, 2, 3, 4], [0, 1, 2, 3, 4], [0, 1, 2, 3, 4]]
```

Si usamos list comprehesion anidadas se puede generar la misma salida menos líneas de código
```Python
# using nested list comprehension

matrix = [[j for j in range(5)] for i in range(3)]
 
print(matrix)
```
Output:
```
[[0, 1, 2, 3, 4], [0, 1, 2, 3, 4], [0, 1, 2, 3, 4]]
```
**List Comprehensions y Lambda:**

Las lambda expressions no son más que representaciones abreviadas de funciones en Python. Usar list comprehension con lambda expressions resulta una combinación bastante eficiente.

Por ejemplo:

Si queremos imprimir x * 10 si x es par y x * 5 si x es impar de 1 a 10:

```Python
n = [x() for x in [lambda x=x: x*10 if x%2 ==0 else x*5 for x in range(1, 11)]]
 
print(n)
```

Dada una cadena s devolver la lista de caracteres de esta en toggle case:

```Python
# toggle case

# Inicializar el  string
string = 'Python'

# Toggle case de cada caracter de entrada
toggle = lambda s: [chr(ord(c)^32) for c in s ]
# Imprimir la lista
print(toggle(string))
```

Output:
```
['p', 'Y', 'T', 'H', 'O', 'N']
```

**List Comprehension condicionales:**

También podemos agregar declaraciones condicionales a las list comprehension. Podemos crear una list usando range(), operadores etc, y aplicar algunas condiciones a la lista usand if statement.

*Ejemplo1:*

Mostrar el cuadrado de los números pares de 1 a 10:
```Python
# Obtener una lisa con los cuadrados de los números pares desde 1 hasta 10
squares = [n**2 for n in range(1, 11) if n%2==0]
 
# imprimir la list de cuadrados
print(squares)
```

*Output*:

```
[4, 16, 36, 64, 100]
```


**Más ejemplos de list comprehensions:**

Obtener la transpuesta de una matriz:

```Python

# assignar una matriz
matrix = [[10, 1, 3],
          [7,  5, 7],
          [11, 34, 13]]
 
# Transpuesta usando list comprehension
trans = [[i[j] for i in matrix] for j in range(len(matrix))]
 

for i in trans:
    print(i)
```
Output:
```
[10, 7, 11]
[1, 5, 34]
[3, 7, 13]
```

Puntos importantes de las list comprehension en Python:
* La list comprehension son un medio eficaz de describir y construir listas basadas en listas actuales
* Generalmente las list comprehension son una forma más liviana para crear listas que la forma estándar con funciones y ciclos.
* Cada list comprehension puede ser reescrita en un ciclo for, ero en el contexto de interpretación de listas, no se puede reescribir cada bucle for.
  
# Tuplas:

Las tuplas en Python son una colección de objetos separados por , . Las tuplas en Python o tuples son muy similares a las listas, pero con dos diferencias. Son inmutables, lo que significa que no pueden ser modificadas una vez declaradas, y en vez de inicializarse con corchetes se hace con (). 

**Crear una tupla en Python:**

Con paréntesis:
```Python
tupla = (1, 2, 3, 4, 5) 
print(tupla) #(1, 2, 3, 4 ,5)
```
Output:
```Python
(1, 2, 3, 4, 5)
```

Sin paréntesis:

```Python
tupla = 1, 2, 3, 4, 5
print(tupla) #(1, 2, 3, 4 ,5)
```
Output:
```Python
(1, 2, 3, 4, 5)
```

Tupla vacía:
```Python
# An empty tuple
empty_tuple = ()
print (empty_tuple)
```
Output:
```
()
```

Tupla de un solo elemento:
```Python
tupla = (1,)
print(tupla)
print(type(tupla))
```

Output:
```
(1,)
<class 'tuple'>
```

Tuplas anidadas:

En Python se pueden crear tuplas que contengas otras tuplas como elementos de estas.

**Ejemplo:**

```Python
# Code for creating nested tuples
tuple1 = (0, 1, 2, 3, 4)
tuple2 = ('Python', 'C++', 'C#', 'F#', 'Haskell')
tuple3 = (tuple1, tuple2)
print(tuple3)
```

Output:
```
((0, 1, 2, 3, 4), ('Python', 'C++', 'C#', 'F#', 'Haskell'))
```

**Acceder a un elemento de la tupla:**
Para acceder al valor de un elemento de la tupla se usan los corchetes con el índice del elemento que se desea obtener su valor.

```Python
tupla = (1, 2, 3)
print(tupla[1])
```

Output:
```
2
```
**Concatenación de Tuplas:**
```Python
t1 = ('this', 'world', 'game')
t2 = ('bit', 'code', 'terminal')
t3 = t1 + t2
print(t3)
```
Output:
```
('this', 'world', 'game', 'bit', 'code', 'terminal')
```

**Crear tupla con repetición:**

Ejemplo:

```
tupla = ('Python',)*5
print(tupla)
```
Output:
```
('Python', 'Python', 'Python', 'Python', 'Python')
```

**Código para testear que las tuplas en Python son inmutables:**

```Python
#code to test that tuples are immutable
tupla = (-8, 1, 12, 3)
tupla[1] = 2
print(tupla)
```
Output:

```
tupla[1] = 2
TypeError: 'tuple' object does not support item assignment
```

**Slicing en Tuplas:**
 
 Podemos hacer slicing en listas de la forma que lo hacemos en strings o listas. Tuple slicing es básicamente usado para obtener un rango de items de esta. Para hacer el slicing en tuplas usamos el operador de slicing. El operador slicing es representado con las sintaxis [start:stop:step]. El step se puede omitir por defecto es 1.

 Ejemplo1:

```Python
tupla = (12, 3, 45, 4, 2.4, 2, 56, 90, 1)
print(tupla[1:3])
```

Output:
```
(3, 45)
```

**Ejemplo2 Si se omite star value por defecto comienza en el primer elemento:**

```Python
tupla = (12, 3, 45, 4, 2.4, 2, 56, 90, 1)
print(tupla[:4])
```

Output:
```
(12, 3, 45, 4)
```

**Ejemplo3 Si se omite el stop value por defecto termina en el último elemento:**

```Python
tupla = (12, 3, 45, 4, 2.4, 2, 56, 90, 1)
print(tupla[3:])
```

Output:
```
(4, 2.4, 2, 56, 90, 1)
```
**Ejemplo4 Si se omite el star y el stop value comienza en el primer elemento y términa en el último elemento:**

```Python
tupla = (12, 3, 45, 4, 2.4, 2, 56, 90, 1)
print(tupla[:])
```

Output:
```
(12, 3, 45, 4, 2.4, 2, 56, 90, 1)
```

**Ejemplo5 Imprimir del primer al último con un paso de 2:**

```Python
tupla = (12, 3, 45, 4, 2.4, 2, 56, 90, 1)
print(tupla[::2])
```

Output:
```
(12, 45, 2.4, 56, 1)
```

**Ejemplo6 Puedes usar índices negativos si quieres imprimir índices desde el final:**


```Python
tupla = (12, 3, 45, 4, 2.4, 2, 56, 90, 1)
print(tupla[-3:-1])
```

Output:
```
(56, 90)
```

**Eliminar una tupla:**

```Python
# Code for deleting a tuple
tupla = (0, 1)
del tupla
print(tupla)
```
Output:
```
UnboundLocalError: local variable 'tupla' referenced before assignment
```

__Haskell__:
En Haskell las tuplas se representan con paréntisis y cada elemento separado por comas similar a Python:
```Haskell
Prelude> let a = (4, 5, 6, 7)
Prelude> a
(4,5,6,7)
Prelude> :t a
a :: (Num a, Num b, Num c, Num d) => (a, b, c, d)

```

 Las tuplas en Haskell pueden contener distintos tipos al igual que en Python:

Haskell Code:
```Haskell
Prelude> let a = ("cat", 1, (1,2), "dog", 20.4)
Prelude> a
("cat",1,(1,2),"dog",20.4)
Prelude> :t a
a :: (Fractional e, Num b1, Num a, Num b2) =>
     ([Char], b1, (a, b2), [Char], e)

```

Python Code:
```Python
tupla = ("cat", 1, (1,2), "dog", 20.4)
print(tupla)
```
Output:
```
(1, 'lion', 'north', 'plane', 'move', 1.2)
```

En Haskell las tuplas se pueden usar si se quiere retornar más de un valor de una función. Algo que también se puede hacer en Python

Ejemplo:
```Haskell
moreonereturn :: Integral a => a -> (a, a)
moreonereturn x | even x   = (2*x, 3*x)
                | otherwise = (x*x, x+x)
```

Python:
```Python
def multOutput(n: int):
if n%2 == 0:
    return 2*n, 3*n
return n*n, n + n
```

Probemos para n = 5

Haskell Output:
```
*Main> moreonereturn 5
(25,10)
```
Python Output:
```Python
print(multOutput(5))
```
```
(25, 10)
```

