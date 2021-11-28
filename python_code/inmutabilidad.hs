
data Person a = Person{firstname:: String  , lastname::String} deriving(Show)


changeLastName :: Person a1 -> String -> Person a2
changeLastName person newLastname = person
  { lastname = newLastname }