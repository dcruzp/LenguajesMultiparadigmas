
-- Factorial 

factorial :: (Eq p, Num p) => p -> p
factorial 0 = 1
factorial n = n * factorial (n-1)

-- AND LOGIC
miAnd:: Bool -> Bool -> Bool
miAnd True True = True
miAnd True False = False
miAnd False True = False
miAnd False False = False

-- Suma todos los elementos de una lista

sumaLista :: Num a => [a] -> a
sumaLista [] = 0
sumaLista (x:xs) = x + sumaLista xs


primerelemento :: Show a => [a] -> String
primerelemento [] = "Lista vacía"
primerelemento lista@(x:xs) = "El primer elemento de " ++ show lista ++" es " ++ show x
