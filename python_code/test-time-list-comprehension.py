import time
 
# definamos la función a implementar usando ciclo for  

def for_loop(n):
    result = []
    for i in range(n):
        result.append(i**2)
    return result
 
 
# definamos la función a implementar usando list comprehension
def list_comprehension(n):
    return [i**2 for i in range(n)]
 
 

 
# Calcular el tiempo que toma for_loop()
begin = time.time()
for_loop(10**6)
end = time.time()
 
# Mostrar el tiempo que tomó for_loop()
print('Time taken for_loop:',round(end-begin,2))
 
# Calcular el tiempo que toma lis_comprehension()
begin = time.time()
a = list_comprehension(10**6)
end = time.time()
 
# Mostrar el tiempo que tomó list_comprehension()
print('Time taken for list_comprehension:',round(end-begin,2))
