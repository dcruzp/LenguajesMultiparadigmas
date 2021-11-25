# Seminario 12. Características funcionales en lenguajes Multi-paradigma 

[TOC]



### Capacidades de pattern matching en C# 

Pattern matching en C# proporciona una sintaxis mas concisa para probar expresiones y tomar medidas cuando una expresión coincide. La expresión `is` admite pattern matching para probar una expresión y declarar condicionalmente una nueva variable al resultado de esa  expresión. La expresión `switch` permite realizar acciones basadas en el primer patrón coincidente de una expresión. Estas dos expresiones brindan un rico vocabulario de patrones.

##### Null Checks 

Uno de los escenarios mas comunes de los pattern matching es verificar que los valores no son `null`.  Tu puedes chequear y convertir un tipo que acepta valores `null` en su tipo subyacente mientras prueba el valor nulo 

```c#
int? maybe = 12;

if (maybe is int number)
{
    Console.WriteLine($"The nullable int 'maybe' has the value {number}");
}
else
{
    Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
}
```

El código de arriba es un *declaration pattern* para chequear el tipo de la variable y asigna este a una nueva variable. La variable `number`  es solo accesible en el bloque `if` , si se trata de acceder  a esta variable en el bloque `else` o después del `if` este va a generar un error en tiempo de compilación. Debido a que no esta usando el operador `==`, este patrón funciona cuando un tipo sobrecarga el operador `==`. Eso lo convierte en una forma ideal de verificar valores de referencia nulos, agregando el patrón `not`.

```c#
string? message = "This is not the null string";

if (message is not null)
{
    Console.WriteLine(message);
}
```

El `not` es un patrón lógico que retorna verdadero cuando el cuando el patrón negado no machea.



##### Type tests 

Otro uso común de *pattern matching* es chequear una variable para ver de que tipo es. El siguiente ejemplo chequea si una variable no es `null` e implementa la interfaz `IList<T>`. Si la implementa esta usa la propiedad `Count`  de `ICollection<T>` para encontrar el indice medio.  El  *pattern matching* no coincide con un valor nulo, independientemente del tipo en tiempo de compilación de la variable. El código siguiente protege contra `null`, ademas de protegerse contra un tipo que no implementa `IList` 



```c#
public static T MidPoint<T>(IEnumerable<T> sequence)
{
    if (sequence is IList<T> list)
    {
        return list[list.Count / 2];
    }
    else if (sequence is null)
    {
        throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
    }
    else
    {
        int halfLength = sequence.Count() / 2 - 1;
        if (halfLength < 0) halfLength = 0;
        return sequence.Skip(halfLength).First();
    }
}
```

Lo mismo se puede aplicar en una expresión `switch`  para comprobar que con múltiples tipos diferentes. 



##### Compare discrete values 

También se puede chequear una variable para encontrar si machea con un valor especifico. El siguiente código muestra un ejemplo donde se chequea un valor a través de todos los posibles valores declarados en una enumeración. 

```c#
public State PerformOperation(Operation command) =>
   command switch
   {
       Operation.SystemTest => RunDiagnostics(),
       Operation.Start => StartSystem(),
       Operation.Stop => StopSystem(),
       Operation.Reset => ResetToReady(),
       _ => throw new ArgumentException("Invalid enum value for command", nameof(command)),
   };
```

El ejemplo anterior muestra un método de envió basado en el valor de una enumeración. El caso final `_` es un `discard pattern` que machea todos los valores. Este  maneja cualquier error en la condicion donde el valor no machea con ninguno de los valores del `enum`.  Si se omite esa parte del bloque `switch` el compilador avisara que no se  puede manajar una respuesta para todas la posibles entradas.  En tiempo de ejecucion la expresion `switch` lanza una excepcion si el objeto que se examina no coincide con ninguno de los casos del `switch`. Se podria usar constantes numericas en lugar de de un conjunto de valores `enum` . Se puede usar tecnicas similares para valores de constantes de string que representan el comando 

```c#
public State PerformOperation(string command) =>
   command switch
   {
       "SystemTest" => RunDiagnostics(),
       "Start" => StartSystem(),
       "Stop" => StopSystem(),
       "Reset" => ResetToReady(),
       _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
   };
```

 El ejemplo anterior muestra el mismo algoritmo pero usando valores string en lugar de un `enum` . En todos esos ejemplos *discard pattern* asegura que se cubren todas las entradas posibles.  El compilador asegura que cada posible entrada es manejada. 



##### Relational patterns 

Tu puedes usar *relational patterns* para probar como se compara un valor con las constantes.  Por ejemplo el siguiente codigo retorna el estado del agua basada en la temperatura en Fahrenheit: 

```c#
string WaterState(int tempInFahrenheit) =>
    tempInFahrenheit switch
    {
        (> 32) and (< 212) => "liquid",
        < 32 => "solid",
        > 212 => "gas",
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
    };
```

 El código anterior también muestra el *logical pattern* `and` para chequear que ambas condicionales se complen . Las dos sentecias  finales del `switch` dan salida a las dos posibles entradas que quedaban por asignar. Sin esas dos asignaciones el compilador avisaria que tu logica no cubre todas las entradas posibles. 

El código anterior también muestra otra importante característica que provee el compilador para las expresiones de *pattern matching*: El compilador te avisa si no se tratan todos los casos para todas las posibles entradas. Otra forma de de escribir la misma expresion puede ser: 

```c#
string WaterState2(int tempInFahrenheit) =>
    tempInFahrenheit switch
    {
        < 32 => "solid",
        32 => "solid/liquid transition",
        < 212 => "liquid",
        212 => "liquid / gas transition",
        _ => "gas",
};
```

La importancia de que el compilador valida si a todas las posibles entradas son procesadas radica en posibles Excepciones del programa, refractorizacion y reordenamiento del codigo. 

##### Multiple inputs 

Se pueden escribir partrones que examinan multiples  propiedades de un objeto. Considera el siguiente *Order* `record` 

```c#
public record Order (int Item, decimal Cost); 
```

El siguiente codigo examina el numero de articulos y el valor de pedido para calcular un precio con descuento: 

```c#
public decimal CalculateDiscount(Order order) =>
    order switch
    {
        (Items: > 10, Cost: > 1000.00m) => 0.10m,
        (Items: > 5, Cost: > 500.00m) => 0.05m,
        Order { Cost: > 250.00m } => 0.02m,
        null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
        var someObject => 0m,
    };
```

Los primeros dos casos examinan dos propiedades del Order. La tercera examina solo el costo, la siguiente chequean el `null` y el final machea cualquier otra valor. Si el tipo Order define un metodo apropiado `Decontruct` tu puedes omitir la propiedad llamada del patron y usar la deconstruccion para examinar las propiedades: 

```c#
public decimal CalculateDiscount(Order order) =>
    order switch
    {
        ( > 10,  > 1000.00m) => 0.10m,
        ( > 5, > 50.00m) => 0.05m,
        Order { Cost: > 250.00m } => 0.02m,
        null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
        var someObject => 0m,
    };
```

El codigo anterior muestra la *positional pattern* donde las propiedades son decontruidas por la expersion 



### List comprehension en C# 

Una List Comprehension en C# es un tipo de notacion en el que el programador puede describir las propiedades que los miembros de un conjunto debe reunir. Is usualmente usado para crear un conjunto basado en otro ya existente aplicando algun tipo de combinacion. 

Con la aparición de C# 3.0 y de .Net Framework 3.5, aparecio la notacion *List Comprehension* basada en `Linkq` . El siguiente ejemplo muestra como formar un conjunto de números pares en el rango del 0 al 10.

```c#
IEnumerable<int> numbers = Enumerable.Range(0, 10);
var evens = from num in numbers where num % 2 == 0 select num;
```

Esto nos va a dar a retornar un objeto `evens` que es una lista que contiene a todos los números pares del 0 al 10  , `0 2 4 6 8 ` 

Las *querys expression* en C# 3 en adelante son azúcar sintáctica sobre la nomenclatura del código de C# normal. Aunque las expresiones de consultas generalmente terminan llamando a métodos de extencion (No tienen que hacerlo y al compilador no le importa, pero generalmente si). Hay varias cosas que se pueden hacer con las colecciones que no estan disponibles en las expresiones de consulta de C#, pero son compatibles con las llamadas a métodos, por lo que vale la pena conocer ambos tipos de sintaxis.

```c#
List<Foo> fooList = new List<Foo>();
IEnumerable<string> extract = from foo in fooList where foo.Bar > 10 select foo.Name.ToUpper();
```

es preprocesado en: 

```c#
List<Foo> fooList = new List<Foo>();
IEnumerable<string> extract = fooList.Where(foo => foo.Bar > 10)
                                     .Select(foo => foo.Name.ToUpper());
```

Si se quieren hacer filtros basados en el indice del valor en la colección original se puede usar una sobrecarga apropiada de `Where` que no es posible en las *query expression*  

```c#
List<Foo> fooList = new List<Foo>();
IEnumerable<string> extract = fooList.Where((foo, index) => foo.Bar > 10 + index)
                                     .Select(foo => foo.Name.ToUpper());
```



