# Python <img src="./images/python1.jpeg" style="zoom:20%;" />



# a. Funciones como ciudadanos de primer nivel en Python


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

# Comparando con Haskell:

En Haskell las funciones son  tratadas como ciudadanos de primera clase. Esto significa que las funciones pueden almacenarse en estructura de datos , pasarse como argumento a otras funciones y devolverse como resultado.

Ejemplo1:

La función mymap: toma como argumentos una función y una lista y devuelve como resultado la
lista que contiene la evaluación de la función en cada uno de los elementos de la lista de entrada.

```Haskell
mymap :: (a -> b) -> [a] -> [b]
mymap _ [] = []
mymap f (x:xs) = f x : mymap f xs
```

Definamos otra función sencilla para probabr mymapp:
```
doble :: Num a => a -> a
doble x = x *2
```

```
*Main> mymap doble [1,2,3,4,5]
[2,4,6,8,10]
```

# b. List comprehension en Python

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

# Comparación con Haskell:

Haskell tiene una notación llamada list comprehension que es muy conveniente para describir ciertos tipos de listas. 
Las sintaxis básica de una list comprehension en Haskell es:
```
[expr | qualifier, qualifier, ...]
```
Genera una lista donde los elementos donde los elementos sean de la forma expr, de manera que los elementos cumplan las condiciones en los qualifiers.

`expression`: puede ser cualquier expresión válida de Haskell

`qualifiers`: puede tener 3 formas diferentes : `generators`, `filters`, `local definitions`


Generator Qualifiers:
Genera un número de elementos que se pueden usar en la parte de expression de la list comprehension.

Sintaxis:
```
pattern <- list_expr
```
Ejemplo1:
```
Prelude> [n|n<-[1..5]]
[1,2,3,4,5]
```

Ejemplo2:
```
Prelude> [(n,n*n) | n<-[1..3]]
[(1,1),(2,4),(3,9)]
```

**Filter Qualifiers:**

Un filter es una expresión booleana que remueve elementos que de otro modo se habrían incluido en la list comprehension. A menudo usamo un `generator` para para producir una secuencia de elementos y un `filter` para eliminar los elementos que no son necesarios.

Ejemplo1:

```
Prelude> [n*n | n<-[1..10], even n]
[4,16,36,64,100]
```
 Ejemplo2:
```
 Prelude> [(n,n*n) | n<-[1..3], n <n*n]
[(2,4),(3,9)]
```

**Local Definitions:**

Podemos definir una variable local dentro de la list comprehension

Ejemplo1:
```
Prelude> [n*n | let n = 2]
[4]
```

Ejemplo2:
```
Prelude> [k*n | k <- [5,10..50],let n = 2]
[10,20,30,40,50,60,70,80,90,100]
```

**Otros ejemlos de List comprehension en Haskell:**

```Haskell
triads :: (Num c, Eq c, Enum c) => c -> [(c, c, c)]
triads n = [ (x,y,z) | x <- [1..n], y <- [1..n], z <- [1..n], x^2 + y ^2 == z^2]
```

```
*Main> triads 5
[(3,4,5),(4,3,5)]
*Main> triads 10
[(3,4,5),(4,3,5),(6,8,10),(8,6,10)]
```

# c. Capacidades de pattern matching en Python


Antes de Python `3.10` no existía algo como los switch case en Python para hacer pattern matching. Se podía usar diccionarios para internar simular en algunos casos la correspondencia con algún patrón

**Structural Pattern Matching en Python 3.10:**

El structural pattern matching en Python puede ser usado como una simple declaración switch, pero es capaz de mucho más. 

Tomemos el caso simple switch case. A continuación se muestra un fragmento de código que hace switch en un solo valor. Probándolo con los valores en un ciclo 1, 2, 3, 4.

```Python
for thing in [1,2,3,4]:
    match thing:
        case 1:
            print("thing is 1")
        case 2:
            print("thing is 2")
        case 3:
            print("thing is 3")
        case _:
            print("thing is not 1, 2 or 3")
```

Lo primero que se nota es lo limpio de la sintaxis. Comienza por el keyword `match` seguido por el nombre de la variable. Entonces hay una lista de casos que comienzan con el keyword `case` y van seguidos del valor que coincide. Esto no es muy diferente a la declaración switch/case en otros lenguajes. 

Si no match nadie entonces el caso default, designadao por `_` es ejecutado, pero a diferencia de C, por ejemplo , después que el código para un caso en particular es ejecutado , el control salta al final del match statement.

Los switch statement son un caso simple de pattern matching pero Python 3.10 lleva esto un poco más lejos.

Observemos el siguiente código:

```Python
for thing in [[1,2],[9,10],[1,2,3],[1],[0,0,0,0,0]]:
    match thing:
        case [x]:
            print(f"single value: {x}")
        case [x,y]:
            print(f"two values: {x} and {y}")
        case [x,y,z]:
            print(f"three values: {x}, {y} and {z}")       
        case _:
            print("too many values")
```

Es una declaración `match` en un ciclo de nuevo pero esta vez la lista de valores por los que el ciclo itera son listas también. Las declaraciones `case` intentan matchear con esas listas. el primer `case` hace match con una lista de un solo elemento, el segundo con una lista de dos elementos , el tercero con una lista de tres elementos. El último caso es el default. Pero hace más que eso también vinculan los valores que han matcheado con los identificadores en los `case` statement. Por ejemplo  la primera lista es [1,2] y matchea con el segundo case [x,y]. Entonces en el código que se ejecuta los identificadores `x` y `y` toman los valores 1 y 2, respectivamente.

Podemos también matcher patrones que incluyan valores por ejemplo:

```Python
for thing in [[1,2],[9,10],[3,4],[1,2,3],[1],[0,0,0,0,0]]:
    match thing:
        case [x]:
            print(f"single value: {x}")
        case [1,y]:
            print(f"two values: 1 and {y}")
        case [x,10]:
            print(f"two values: {x} and 10")
        case [x,y]:
            print(f"two values: {x} and {y}")
        case [x,y,z]:
            print(f"three values: {x}, {y} and {z}")       
        case _:
            print("too many values")
```


Factorial usando structural pattern matching:

```Python
def factorial(n):
    match n:
        case 0 | 1:
            return 1
        case _:
            return n * factorial(n - 1)
```

**Uso de Or patterns:**

El símbolo `|` combina los patrones como alternativas . 
Por ejemplo:

```Python
match command.split():
    ... # Other cases
    case ["north"] | ["go", "north"]:
        current_room = current_room.neighbor("north")
    case ["get", obj] | ["pick", "up", obj] | ["pick", obj, "up"]:
        ... # Code for picking up the given object
```
Esto es llamado or pattern y producirá el resultado esperado. Los patrones se evaluan de izquierda a derecha. Esto puede ser relevante para saber que está vinculado si coincide más de una alternativa. 

**Match sub-patrones:**

```Python
match command.split():
    case ["go", ("north" | "south" | "east" | "west")]:
        current_room = current_room.neighbor(...)
        # how do I know which direction to go?
```

Este código es una simple rama y verifica que la palabra después de go es realmente una dirección. 
Pero el código que mueve al player necesita saber cual fue elegido y no tiene forma de hacerlo. Lo que necesitamos es un pattern que se comporte como el or pattern pero al mismo tiempo haga una captura. Podemos hacer esto con el **as pattern**:

```Python
match command.split():
    case ["go", ("north" | "south" | "east" | "west") as direction]:
        current_room = current_room.neighbor(direction)
```

El **as pattern** matchea con cualquier patrón que esté en su lado izquierdo, pero también vincula el valor a un nombre.


**Agregando condiciones a nuestros patrones:**

Para agregar condiciones podemos usar las `guards`. 
La sintaxis de las `guards` consiste en el keyword
`if` seguido de cualquier expresión
 
Ejemplo:

```Python
match command.split():
    case ["go", direction] if direction in current_room.exits:
        current_room = current_room.neighbor(direction)
    case ["go", _]:
        print("Sorry, you can't go that way")
```

La guard no es parte del patrón, es parte del case. Esta solo verifica si el patrón coincide. Si el patrón matchea y la condición es true, se ejecuta el body del case normalmente. Si el patrón coincide pero la condición es false el match statement procede a verificar el próximo case.



**Comparación con Haskell:**

En Haskell una función puede definirse mediantes un conjunto de ecuaciones utilizando el pattern matching, en la que se usa una secuencia de expresiones sintácticas llamadas patrones para seleccionar de entre una secuencia de resultados del mismo tipo.
La definición de una función de esta forma es la siguiente:

```
f <patrón1> = <expresión1>
f <patrón2> = <expresión2>
...
f <patrónk> = <expresiónk>

```

donde en cada ecuación se especifica un patrón determinado así como la expresión que
debe ser evaluada si se verifica la presencia de dicho patrón en los argumentos de entrada
de la función.

Cuando se aplica una función definida de esta forma a sus argumentos de entrada, se
realiza un proceso en el que se verifica si existe una correspondencia entre los
argumentos pasados a la función y los patrones definidos en cada ecuación. De esta
forma se determina cuál es la ecuación que se debe seleccionar y, por tanto, qué
expresión evaluar.

Esta comprobación se realiza en el orden en que fueron definidos los patrones: primero
con patrón1, luego con patrón2 y así sucesivamente hasta que algún patrón
coincida, en cuyo caso la expresión correspondiente es evaluada y devuelta.

La correspondencia de patrones puede hacerse sobre variables y cualquier tipo de dato
definido: números, caracteres, listas, tuplas, etc

**Pattern matching sobre constantes numéricas y variables:**

```Haskell
factorial :: (Eq p, Num p) => p -> p
factorial 0 = 1
factorial n = n * factorial (n-1)
```

**Patrones sobre tipo Bool:**

```Haskell
miAnd:: Bool -> Bool -> Bool
miAnd True True = True
miAnd True False = False
miAnd False True = False
miAnd False False = False
```

Patrón anónimo:

La definición anterior puede simplificarse,  combinando las últimas tres ecuaciones en una que retorna
False independientemente de los valores que tengan los argumentos. Esto puede hacerse usando el
patrón anónimo _ que se ajusta a cualquier valor:

```Haskell
miAnd True True = True
miAnd _ _ = False

```

**Pattern matching sobre listas en Haskell:**

Se define la función sumaLista, que devuelve la suma de los elementos de una lista. Se utiliza el
patrón de lista (x:xs) para referirse a una lista que tiene al menos un elemento.


```Haskell
sumaLista :: Num a => [a] -> a
sumaLista [] = 0
sumaLista (x:xs) = x + sumaLista xs
```

```
*Main> sumaLista [1,2,3,4,5]
15
```

**Pattern matching sobre tuplas en Haskell:**

La función sumaVectores, que toma dos vectores de 2 dimensiones como argumentos en forma de
tuplas y devuelve el vector que resulta de sumar sus componentes separadamente, se puede definir de
la siguiente forma:

```Haskell
sumaVectores :: (Num a, Num b) => (b,a) -> (b,a) -> (b,a)
sumaVectores a b = (fst a + fst b, snd a + snd b)

```

Sin embargo, usando   pattern matching sobre tuplas, esta puede definirse de una forma
más elegante:

```
sumaVectores (x1,y1) (x2,y2) = (x1 + x2, y1 + y2)

```

Patrones con nombre:

Es posible dar nombre a todo un patrón poniendo un nombre y el símbolo @ delante de este, por
ejemplo, `xs@(x:y:ys)`.

Este patrón es equivalente a `(x:y:ys)`, pero permite acceder rápidamente a toda la lista a través de
su nombre xs en lugar de repetir en el cuerpo de la función el patrón `(x:y:ys)`.

```Haskell
primerelemento :: Show a => [a] -> String
primerelemento [] = "Lista vacía"
primerelemento lista@(x:xs) = "El primer elemento de " ++ show lista ++" es " ++ show x

```

```
*Main> primerelemento [1,2,3,4]
"El primer elemento de [1,2,3,4] es 1"
```

# d. Inferencia de tipos en Python



La inferencia de tipos es la deducción automática de los tipos de datos de expresiones específicas en un lenguaje de programación. Implica analizar un programa y luego inferir los diferentes tipos de algunas o todas las expresiones en ese programa para que el programador no necesite ingresar y definir explícitamente tipos de datos cada vez que se usan variables en el programa.

Dadas las características de Python como lenguaje dinámico, tiene inferencia de tipos por defecto.

Veamos algunos ejemplos:

```Python
a = 5
b = 1.2
cadena = "CPU"
elems = [1,3,4]


print(type(a))
print(type(b))
print(type(cadena))
print(type(elems))
```

**Output:**

```
<class 'int'>
<class 'float'>
<class 'str'>
<class 'list'>
```

```Python
 for i in ['hello', 1, (1,2), [1,2,4,5,6]]:
        print(type(i))
```

**Output:**

```
<class 'int'>
<class 'float'>
<class 'str'>
<class 'list'>
<class 'str'>
<class 'int'>
<class 'tuple'>
<class 'list'>
```

**Comparación con Haskell:**

Haskell trae inferencia de tipos por defecto, no hace falta usar ningún keyword para usarla.

Veamos algunos ejemplos:

Definamos la siguiente función simple que dado un número de entrada le suma 2 :

 
```Haskell
suma2 x =  x+2
```

Como vemos no definamos el tipo.

Usando :t en el ghci intentemos obtener el tipo :

```
*Main> :t suma2
suma2 :: Num a => a -> a
```

Veamos otro ejemplo:

```Haskell
cumplen2 p xs = length [x | x <- xs , p x ] == length xs
```

Usando :t en el ghci intentemos obtener el tipo :

```
*Main> :t cumplen2 
cumplen2 :: (a -> Bool) -> [a] -> Bool
```



# e. Tuplas en Python:

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

# Comparación con Haskell:
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

 # f. Redefinición de operadores en Python


Sobrecargar el operador significa 
**Operadores binarios:**

Sobrecargar un operador significa dar un significado extendido más allá de su significa operacional predefinido. Por ejemplo en Python el operador `+` es usado sumas dos enteros así como para concatenar dos cadenas o mezclar dos listas. Esto se puede hacer porque el operador `+` está sobrecargado por la clase `int` y la clase `str`.

En `Python` podemos sobrecargar todos los operadores existentes pero no podemos crear uno nuevo. Para realizar la sobrecarga de operadores, Python proporciona alguna función especial o `función mágica` que se invoca automáticamente cuando se asocia con ese operador en particular. Por ejemplo, cuando usamos el operador `+`, el método mágico `__add__` se invoca de forma automática en donde la operación para el operador `+` ha 
sido definida.
Cuando usamos un operador en tipos de definidos por el usuario, automáticamente se invoca una función especial o función mágica asociada con ese operador. Cambiar el comportamiento del operador es tan sencillo como cambiar el comportamiento del método o función. Defines métodos en tus clases y los operadores funcionan de acuerdo al comportamiento definido en esos métodos. Cuando usamos el operador `+`, el método mágico `__add__` es invocado automáticamente en donde el operador `+` es definido. Allí, al cambiar el código de este método mágico, podemos darle un significado extra al opperador `+`.


**Lista de operadores con los métodos mágicos para redefinirlos en Python:**


operador | magic method 
--------|----------
  \+	|  \_\_add\_\_(self, other)  
  –	    | __sub\_\_(self, other)
 /	    | \_\_truediv__(self, other)  
 //	    |\_\_floordiv__(self, other)
 %	    | \_\_mod__(self, other)
 %	    | \_\_mod__(self, other)
 **	    | \_\_pow__(self, other)
 \>>	| \_\_rshift__(self, other)
 <<	    | \_\_lshift__(self, other)
 &	    | \_\_and__(self, other)
 \|	    | \_\_or__(self, other)
 ^	    | \_\_xor__(self, other)

 **Operadores de Comparación:**

operador | magic method 
--------|----------
<       |	\_\_LT__(SELF, OTHER)
\>	    |   \_\_GT__(SELF, OTHER)
<=	    |   \_\_LE__(SELF, OTHER)
\>=	    |   \_\_GE__(SELF, OTHER)
==	    |   \_\_EQ__(SELF, OTHER)
!=	    |   \_\_NE__(SELF, OTHER)

**Operadores de asignación:**
operador | magic method 
--------|----------
-=	|   \_\_ISUB__(SELF, OTHER)
+=	|   \_\_IADD__(SELF, OTHER)
*=	|   \_\_IMUL__(SELF, OTHER)
/=	|   \_\_IDIV__(SELF, OTHER)
//=	|   \_\_IFLOORDIV__(SELF, OTHER)
%=	|   \_\_IMOD__(SELF, OTHER)
**=	|   \_\_IPOW__(SELF, OTHER)
\>>=|   \_\_IRSHIFT__(SELF, OTHER)
<<=	|   \_\_ILSHIFT__(SELF, OTHER)
&=	|   \_\_IAND__(SELF, OTHER)
|=	|   \_\_IOR__(SELF, OTHER)
^=	|   \_\_IXOR__(SELF, OTHER)

**Operadores unarios:**

operador | magic method 
--------|----------
–	    |   \_\_NEG__(SELF, OTHER)
\+	    |   \_\_POS__(SELF, OTHER)
~	    |   \_\_INVERT__(SELF, OTHER)


Ejemplo1:

Definamos la siguiente clase para representar números complejos y las operaciones suma y resta entre estos.

```Python
class ComplexNumer:

    def __init__(self, a, b):
      self.a = a
      self.b = b

    def __add__(self, other: 'ComplexNumer'):
        return ComplexNumer(self.a +other.a, self.b + other.b)

    def __sub__(self, other: 'ComplexNumer'):
        return ComplexNumer(self.a - other.a, self.b - other.b)
 

    def __str__(self):
        return f"{self.a} + {self.b}i"
```

Se podría hacer lo siguiente:

```Python
c1 = ComplexNumer(1, 2)
c2 = ComplexNumer(4, 5)
c3 = c1 + c2
c4 = c1 - c2
print(f"Suma: {c3}")
print(f"Resta: {c4}")
```

Output:
```
Suma: 5 + 7i
Resta: -3 + -3i
```

# Comparación con Haskell:

En Haskell también se puede hacer sobrecarga de operadores a tipos definidos usando type classes.

```Haskell
newtype Terna a b c = Terna (a,b,c)  deriving (Eq,Show) 

instance (Num a,Num b, Num c) => Num (Terna a b c) where
    Terna (a,b,c) + Terna (d,e,f) = Terna (a+d,b+e,c+f)
    Terna (a,b,c) - Terna (d,e,f) = Terna (a-d,b-e,c-f)
    Terna (a,b,c) * Terna (d,e,f) = Terna (a*d,b*e,c*f)
    abs (Terna (a,b,c)) = Terna(abs a, abs b, abs c)
    signum (Terna (a,b,c)) = Terna(signum a, signum b, signum c)
    fromInteger i = Terna (fromInteger i, fromInteger i, fromInteger i)
```

```
*Main> Terna(1,2,3) + Terna(4,5,6)
Terna (5,7,9)
```
```
*Main> Terna(1,2,3) - Terna(4,5,6)
Terna (-3,-3,-3)
```

```
*Main> Terna(1,2,3) - Terna(4,5,6)
Terna (-3,-3,-3)
```

# g. Inmutabilidad en Python:


La mutabililidad es una propiedad diferenciadora de los tipos de datos en Python que hacen un gran contraste con los otros tipos de datos. Tiendo a ser la capacidad de los tipos de datos que permiten que se modifiquen después de su creación, a lo que se puede extraer un valor y también extraer de él.
Por otro lado, también hay objetos que no siguen este principio y que son inalterables, sin permitir modificación después de su definición. Su estado no puede cambiar en absoluto tiende a representar un valor constante una vez inicializado. Por ejemplo, integer, string, float, Tuple, Frozen set.
Por lo tanto si alguna variable ha inicializado un valor correspondiente a cualquiera de estos tipos de datos inmutables, no se puede cambiar nunca.




**Strings son inmutables**


```Python
cadena = 'Inmutability in Python'
cadena[1] = 'a'
print(cadena)
```
**Error:**
```
cadena[1] = 'a'
TypeError: 'str' object does not support item assignment
```

**Las tuplas son inmutables:**

```Python
tupla = (1,4,5)
tupla[1] = 2
print(tupla)
```

**Error:**
```
tupla[1] = 2
TypeError: 'tuple' object does not support item assignment
```

**Los frozenset en Python son inmutables:**

```Python
elems = [1,4,5,6,8]
froz = frozenset(elems)
froz[0] = 2
print(froz)
```
**Error:**
```
froz[0] = 2
TypeError: 'frozenset' object does not support item assignment
```

**Creando tus propios tipos inmutables heredando de tuple:**

```Python
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
```

```Python
a = MyImmutable(1,2)
a[0] = 2
print(a[0])
```
**Error:**
```
    a[0] = 2
TypeError: 'MyImmutable' object does not support item assignment

```
**Comparación con Haskell:**

Las expresiones en Haskell son inmutables. No pueden cambiar después que son evaluados. La inmutabilidad hace que la refactorización sea mucho más fácil y que el código sea mucho más sencillo de razonar.
Para combiar un objeto la mayoría de las estructuras de datos proporcionan métodos que toman el objeto antiguo y crean una nueva copia.

```Haskell
data Person a = Person{firstname:: String  , lastname::String} deriving(Show)


changeLastName :: Person a1 -> String -> Person a2
changeLastName person newLastname = person
{ lastname = newLastname }
```

```
*Main> let p1 = Person{firstname="David", lastname="De Quesada"}
*Main> p1
Person {firstname = "David", lastname = "De Quesada"}
```
```
*Main> changeLastName p1 "Gonzalez"
Person {firstname = "David", lastname = "Gonzalez"}
```
Como se puede observar changeLastName no modifica el objeto p1 Person sino que crear un nuevo Person con los nuevos valores de firstname y lasname
```
*Main> p1
Person {firstname = "David", lastname = "De Quesada"}
```



