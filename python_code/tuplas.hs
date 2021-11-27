

moreonereturn :: Integral a => a -> (a, a)
moreonereturn x | even x   = (2*x, 3*x)
                | otherwise = (x*x, x+x)

