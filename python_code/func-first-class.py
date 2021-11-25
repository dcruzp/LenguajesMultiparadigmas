def square(x): return x * x
def cube(x): return x * x * x

def call_func(x, func):
    """recieve a function and execute it and return result"""
    return func(x)

do_square = square     # assigning square function to a variable
do_cube = cube         # assigning cube function to a variable

res = call_func(6, do_square)   # passing function to another function
print(res)
res = call_func(5, do_cube)
print(res)

operations = [square, cube]

print(operations[0](3))
print(operations[1](7))
