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

