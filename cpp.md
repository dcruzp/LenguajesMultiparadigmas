# .cpp

- ## Funciones como ciudadanos de primer nivel

    En _C++_ se puede afirmar que las funciones son ciudadanos de primer nivel pues cumplen todas las condiciones. Pueden ser almacenadas en variables, pasadas como argumentos a otras funciones y retornar llamados a estas dentro de otras funciones, todo esto haciendo uso de **punteros a funciones** como se muestra a continuación:

    ```cpp
    #include <iostream>
    #include <functional>
    #include <tuple>

    using namespace std;

    int product(int, int);
    int add(int, int);

    int main(int argc, char const *argv[]) {
        //\\// Inferencia de tipos con auto, uso de lambda y retornando el llamado a una funcion dentro de la expresion lambda (que es otra funcion).
        auto apply_arth_func = [] (int (*func)(int, int), int val1, int val2) { return (*func)(val1, val2); }; //

        //\\// Asignando funciones a variables.
        int (*mul)(int, int) = product;
        int (*sum)(int, int) = add;

        cout << apply_arth_func(product, 2, 3)<< endl;
        cout << apply_arth_func(add, 1, -5)<< endl;

        return 0;
    }

    int product(int val1, int val2) {
       return val1*val2;
    }

    int add(int val1, int val2) {
        return val1+val2;
    }
    ```

    **output**

    ```
    6
    -4
    ```

    Creamos 2 funciones `product()` y `add()`, luego en el main almacenamos en una variable _apply_arth_func_ una función (una expresión lambda en este caso) que recibe como parámetros:

    - una función (operación aritmética) que recibe 2 enteros y devuelve 1 entero.
    - los 2 enteros a los cuales les vamos a aplicar dicha función.
  
    <br>
    Esta se encarga de aplicar dicha función sea cual sea, siempre que cumpla con las restricciones de tipo, a los restantes argumentos.
    
    <br>
- ## List Comprehension

  _C++_ por ahora no ofrece esta herramienta, sin embargo sería posible implementar algo parecido utilizando templates.


- ## Capacidades de pattern matching

    _C++_ posee capacidades de pattern matching, nos referimos a las instrucciones `switch` `case` y a una biblioteca desarrollada por Michael Park que está disponible para _C++17_ y que está propuesta para introducirse a partir de _C++23_. El problema es que en _C++_ solo podemos hacer uso del `switch` `case` si el argumento de la instrucción `switch` es un `int` o un valor de tipo `enum`, por lo que haría falta hacer algún tipo de conversión si uno quisiera usar esta herramienta y los datos no cumplen con estas restricciones, como mostramos en el ejemplo a continuación:

    ```cpp
    #include <iostream>

    using namespace std;

    enum type_string {int_string, int_ptr_string, char_string};

    string what_type(type_string type);

    int main(int argc, char const *argv[]) {
        int a = 5;

        string name = typeid(a).name();
        type_string type = name == "i" ? int_string : name == "Pi" ? int_ptr_string : char_string;

        cout << what_type(type) << "\n\n";

        return 0;
    }

    string what_type(type_string type) {
        switch (type) {

        case int_string:
            return "This is an integer";
            break;

        case int_ptr_string:
            return "This is a pointer to an integer";
            break;

        default:
            return "This is a char";
        }
    }

    ```

    **output**

    ```
    This is an integer
    ```

    Acá lo que hicimos es usando el método `typeid()` y luego el método `name()` nos quedamos con un `string` que identifica el tipo de la variable a, que como sabemos es de tipo `int`. Luego guardamos en una variable de tipo `type_string` (el enum que definimos) un valor determinado según el string que identifica al tipo de la variable, que está almacenado en **name**, y luego llamamos al método `what_type()` que se encarga de usar pattern matching para imprimir un texto específico según el valor que reciba como argumento.

    Por otro lado usando la biblioteca de Michael Park podemos hacer cosas más cercanas al pattern matching de lenguajes como _Haskell_, _Rust_, _Scala_, _Swift_, etc.

    ```cpp
    void test_pattrn_match() {
        using namespace mpark::patterns;
        for (int i = 1; i <= 100; ++i) {
            match(i % 3, i % 5)(
                pattern(0, 0) = [] { std::printf("No divisible por 3 ni por 5\n"); },
                pattern(0, _) = [] { std::printf("Divisible por 5\n"); },
                pattern(_, 0) = [] { std::printf("Divisible por 3\n"); },
                pattern(_, _) = [i] { std::printf("Divisible por ambos i = %d\n", i); });
        }
    }

    int factorial(int n) {
        using namespace mpark::patterns;
        return match(n)(pattern(0) = [] { return 1; },
                        //      ^ expression
                        pattern(_) = [n] { return n * factorial(n - 1); });
    }


    void is_same(int lhs, int rhs) {
    using namespace mpark::patterns;
    IDENTIFIERS(x, y);
    match(lhs, rhs)(
         pattern(x, x) = [](auto) { std::cout << "same\n"; },
         //      ^  ^ binding identifier (repeated)
         pattern(x, y) = [](auto, auto) { std::cout << "diff\n"; }
         //      ^  ^ binding identifier
      );
    }

    is_same(101, 101);  // prints: "same"
    is_same(101, 202);  // prints: "diff"
    ```

    Se puede observar en los métodos operadores como el `_`, que se utilizan para indicar que no importa lo que tenga el patrón en ese lugar, se va a ejecutar determinada acción. Se puede obersvar además que se hace uso de expresiones lambdas.

- ## Inferencia de tipos
  
  _C++_ posee inferencia de tipos, hay 2 keywords específicamente para esto, aunque no son exactamente lo mismo, nos referimos a `auto` y 
  `decltype`, ambas incluídas desde _C++11_.

  - `auto` viene siendo lo que uno esperaría encontrarse en cualquier otro lenguaje como C# con `var`, o en Python que viene por defecto, es una palabra clave que se poner delante de un identificador al declarar una variable y que indica que el tipo de esa variable se va a inferir directamente de lo que retorne la expresión que se encuentra a la derecha del operador =
  
  - `decltype` es un keyword que se usa de la siguiente forma decltype(_identifier_) y que se podría decir extrae el tipo de una entidad, función o expresión determinada que se le pasa como argumento.

  A Continuación mostramos el código que usamos para probar ambos casos:

  ```cpp
    #include <iostream>
    #include <tuple>

    using namespace std;

    int main(int argc, char const *argv[]) {
        auto tuple1 = make_tuple(5, true, 'c');
        decltype(tuple1) tuple2 = make_tuple(10, false, '$');

        return 0;
    }
  ```

  En el caso de `auto`:

  ![Auto](/images/auto_cpp.png)

  En el caso de `decltype`:

  ![Decltype](/images/decltype_cpp.png)

- ## Tuplas

  _C++_ tiene soporte para tuplas, es necesario importar la librería **tuple**, y está desde _C++11_. Está implementado utilizando **clases** y **templates**. Una tupla es básicamente un **template**.
  A continuación mostramos algunas de sus características:

  ```cpp
    #include <iostream>
    #include <tuple>

    using namespace std;

    int main(int argc, char const *argv[]) {
        tuple<int, int, int> three = make_tuple(3, 4, 5);

        cout << get<0>(three) << endl;
        cout << get<1>(three) << endl;
        cout << get<2>(three) <<  "\n\n";

        get<0>(three) = 10000;
        cout << get<0>(three) << "\n\n";
        return 0;
    }
  ```

  **output**

    ```
    3
    4
    5

    10000
    ```

    Una tupla podemos crearla usando el método make_tuple(_item1_, _item2_,..., _itemn_) y asignándoselo a una variable de tipo
    `tuple` señalando entre angulares cada elemento y el tipo de cada uno estos en la tupla como se muestra en el código. 
    
    También es válido:

    ```cpp
    tuple<int, int, int> three = tuple<int, int, int>{3, 4, 5};
    ```

- ## Redefinición de operadores
  
  _C++_ soporta sobrecarga de operadores o redefinición de operadores, aunque hay varias restricciones:

  - Los operadores `::` (resolución de scope), `.` (acceso a miembro), `.*` (acceso a miembros a través de un punter), y `?:` (condicional ternario) no pueden ser redefinidos.
  - No pueden ser creados operadores como `**`, `<>`, or `&|`.
  - No es posible cambiar la precedencia, el agrupamiento o el número de operandos de los operadores.  
  - La sobrecarga del operador `->` debe devolver ya sea un puntero como tal, o devolver un objeto para el cual el operador `->` este redefinido.
  - Las sobrecaras de los operadores `&&` y `||` pierden la evaluación de corto circuito.

  Para ilustrar la sobrecarga usaremos el siguiente código que tiene una restricción adicional para el operador `<<`, y es que este debe ser definido fuera de la clase usando el keyword `friend`, pues toma el tipo definido por el usuario como el operando a la derecha del operador.

  ```cpp
    #include <iostream>

    using namespace std;

    class my_pair {
    private:
        int item1;
        int item2;

    public:
        my_pair(int item1, int item2) {
            this->item1 = item1;
            this->item2 = item2;
        };

        my_pair operator+ (const my_pair &pair_item) {
            return my_pair(this->item1 + pair_item.item1, this->item2 + pair_item.item2);
        }

        friend ostream& operator<<(ostream &os, const my_pair &pair_item);
    };

    ostream & operator <<(ostream &os, const my_pair &pair_item) {
        os << '(' << pair_item.item1 << ',' << pair_item.item2 << ')' << endl;
        return os;
    } 

    int main(int argc, char const *argv[]){
        auto pair1 = my_pair(3, 5);
        auto pair2 = my_pair(1, 2);

        cout << pair1 + pair2 << endl;
        return 0;
    }

  ```

  **output**

    ```
    (4,7)
    ```

    Creamos una clase **my_pair**, que es básicamente una tupla y le redefinimos los operadores `+` y `<<`, para que sumara y se comportara de la manera especificada al imprimirla usando `cout`.

- ## Inmutabilidad
  
  _C++_ tiene herramientas para la inmutabilidad, y que son particularmente útiles si se usan correctamente, pues facilitan la escritura de un código más legible y a la vez si por algún motivo modificamos algún objeto que sea inmutable porque así lo definimos nosotros, nos alerte con un error de compilación que algo está mal con nuestro código, estos keywords son muy usados cuando estamos usando threading o paralelismo en nuestro programa y . Las palabras claves en _C++_ para esto son `const` y `constexpr`, la última introducida a partir _C++11_. A continuación mostramos un ejemplo usando `const`:

  Puntero mutable, contenido inmutable

  ![const1](/images/const1.png)


  Puntero inmutable, contenido mutable

  ![const2](/images/const2.png)


  Puntero inmutable, contenido inmutable

  ![const3](/images/const3.png)
  

  Existe sin embargo, un keyword que es `mutable` que permite modificar ciertas variables por ejemplo un campo de un objeto, si a pesar de haber creado una instancia de este objeto que sea constante, en la definición de ese campo en el objeto ese campo tiene el keyword `mutable` delante como se muesta en el ejemplo a continuación:

  ```cpp
    #include <iostream>

    using namespace std;

    struct Immutable{
        mutable int val{12};
        void can_not_modify() const {
            val = 13;
        }
    };


    int main(int argc, char const *argv[]){

        // //\\// Es posible modificar el contenedor, o sea el puntero, pero no el contenido.
        // const char* cStr1 = "inmutable containee";
        // cStr1++;
        // *cStr1 = 'd';

        // //\\// Es posible modificar el contenido, pero no el contenedor.
        // char* const cStr2 = "inmutable container";
        // cStr2[0] = 'd'; 
        // cStr2++;

        // //\\// No es posible modificar el contenido ni el contenedor.
        // const char* const cStr3 = "inmutable container and containee";
        // cStr3[0] = 'd'; 
        // cStr3++;


        //\\// Es posible modificar un campo de un objeto si este está marcado como mutable, a pesar de que el objeto esté declarado como const
        const Immutable immu;
        cout << "val: " << immu.val << endl;
        immu.can_not_modify();
        cout << "val: " << immu.val << endl;

        return 0;
    }
    
  ```

  En el caso de `constexpr` se usa para valores que pueden ser computados en tiempo de compilación, y ofrecen una forma de inicializar variables de forma segura en caso de que se este utilizando threading o paralelismo en el programa.

## Comparando con _Haskell_

   - Funciones como ciudadanos de primer nivel: En _Haskell_ las funciones por defecto son ciudadanos de primera clase y la sintaxis es bien sencilla para tratar con funciones como si fueran cualquier otro objeto, como se muestra a continuación:

        ```haskell
        fullfil :: (t -> Bool) -> [t] -> Bool
        fullfil p = foldr ((&&) . p) True
        ```

        Esta función verifica que todos los elementos de una lista determinada satisfagan un predicado determinado (otra función) que podemos pasarle como argumento.

        Aquí en _C++_ es cierto que podemos considerar a las funciones como ciudadanos de primera clase pero la sintaxis puede ser un poco complicada al principio.
    
   - List Comprehension: En _Haskell_ esta característica viene implementada por defecto y es muy útil pues nos permite crear listas
   de manera rápida, cómoda e incluso con condicionales dentro como se muesta en el siguiente ejemplo:

        ```haskell
        myIsPrime :: Integral a => a -> Bool
        myIsPrime x = all (\k -> mod x k /= 0) [2..x-1]

        myPrimes :: (Integral a, RealFrac a, Floating a) => a -> [a]
        myPrimes x = [z | z <- [2..x], myIsPrime z]
        ```

        Acá hay una función `myPrimes` que devuelve la lista de todos los primos menores o iguales que un número, y que utiliza la función `myPrime` para saber si un número es primo que está definida arriba

        Sin embargo _C++_ aún no cuenta con esta característica, aunque se cree que ya en _C++23_ la introduzcan pues ya en _C++20_ introdujeron los **ranges** que parecen van a facilitar su implemetación en futuras versiones.

   - Pattern matching: En _Haskell_ el pattern matching viene implementado por defecto y tiene varias formas, pero todas por detrás funcionan haciendo uso de la palabra clave `case`, hay pattern matching de funciones directamente y utilizando el operador | directamente dentro la definición de una función para controlar el flujo del código dependiendo de condiciones como se muestra en el siguiente ejemplo que consiste en la factorización en números primos y que muestras ambos casos de pattern matching:
  
        ```haskell
        factorize :: Integral a => a -> a -> [a]
        factorize _ 1 = [] 
        factorize d n 
            | d * d > n = [n]
            | n `mod` d == 0 = d : factorize d (n `div` d)
            | otherwise = factorize (d + 1) n

         primeFactors :: Integer -> [Integer]
         primeFactors = factorize 2
        ```

        C++ por su parte tiene pattern matching como mencionamos anteriormente pero no es tan útil como el de _Haskell_ pues se necesitan condiciones específicas para su uso como mencionamos previamente.

   - Inferencia de tipos: _Haskell_ trae inferencia de tipos por defecto no es necesario utilizar ninguna palabra clave. El hecho de poder deducir el tipo de una variable o de una expressión por las operaciones, funciones y argumentos que la componen es algo muy poderoso pues nos ahorra tiempo a la hora de declarar el tipo, pero esto puede no ser algo que queramos cuando hay expresiones muy complejas, a veces es mejor declarar explícitamente que una variable es de un tipo específico para hacer más legible el código. _C++_ por su parte también introdujo este concepto en su filosofía con los keywords `auto` y `decltype`.

   - Tuplas: Las tuplas existen en _Haskell_, y en _C++_ fueron introducidas en cierto momento como parte del lenguaje, en ambos casos el comportamiento es el mismo, tienen un tamaño inmutable y pueden almacenar distintos tipos de datos, la diferencia está al declarar una variable de tipo tupla. A continuación ejemplos de como declarar tuplas en haskell, así como los tipos de las tuplas:

        ```haskell
        -- tuple declaration
        (,) 1 2     -- equivalent to (1,2)
        (,,) 1 2 3  -- equivalent to (1,2,3)
        ("answer", 42, '?')

        -- tuple type declaration
        (String, Int, Char)
        ```

   - Redefinición de operadores: En _Haskell_ es posible redefinir operadores al igual que en _C++_ así que no tenemos mucho que decir al respecto, excepto que se redefinen para nuevos tipos de objetos definidos por el propio usuario.

        ```haskell
        instance Num Vector where
        (+) v1 v2 =3D zipWith (+) v1 v2
        (-) v1 v2 =3D zipWith (-) v1 v2
        ```

   - Inmutabilidad: En _Haskell_ todas las expresiones son inmutables, no pueden cambiar una vez se evalúan, esto hace más fácil refactorizar el código y entenderlo. Para modficar un objeto es la mayoría de las estructuras de datos tienen un método que toma el objeto y crea una copia de este. Sin embargo en _C++_ para tener este comportamiento tenemos que hacer uso explícito de los keywords
   `const` y `constexpr`.