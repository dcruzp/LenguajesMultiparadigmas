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
