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


