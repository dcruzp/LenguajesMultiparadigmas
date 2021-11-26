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
