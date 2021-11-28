newtype Terna a b c = Terna (a,b,c)  deriving (Eq,Show) 

instance (Num a,Num b, Num c) => Num (Terna a b c) where
    Terna (a,b,c) + Terna (d,e,f) = Terna (a+d,b+e,c+f)
    Terna (a,b,c) - Terna (d,e,f) = Terna (a-d,b-e,c-f)
    Terna (a,b,c) * Terna (d,e,f) = Terna (a*d,b*e,c*f)
    abs (Terna (a,b,c)) = Terna(abs a, abs b, abs c)
    signum (Terna (a,b,c)) = Terna(signum a, signum b, signum c)
    fromInteger i = Terna (fromInteger i, fromInteger i, fromInteger i)
    