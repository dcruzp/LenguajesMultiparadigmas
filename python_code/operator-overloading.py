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

def main():
    c1 = ComplexNumer(1, 2)
    c2 = ComplexNumer(4, 5)
    c3 = c1 + c2
    c4 = c1 - c2
    print(f"Suma: {c3}")
    print(f"Resta: {c4}")

if __name__ == '__main__':
    main()
 