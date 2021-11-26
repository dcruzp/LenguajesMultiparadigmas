
# assignar una matriz
matrix = [[10, 1, 3],
          [7,  5, 7],
          [11, 34, 13]]
 
# Transpuesta usando list comprehension
trans = [[i[j] for i in matrix] for j in range(len(matrix))]
 

for i in trans:
    print(i)