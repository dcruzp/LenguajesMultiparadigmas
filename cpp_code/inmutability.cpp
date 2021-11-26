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
