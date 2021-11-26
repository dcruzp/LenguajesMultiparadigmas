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
