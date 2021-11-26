#include <iostream>
#include <tuple>

using namespace std;

int main(int argc, char const *argv[]) {
    auto tuple1 = make_tuple(5, true, 'c');
    decltype(tuple1) tuple2 = make_tuple(10, false, '$');

    return 0;
}
