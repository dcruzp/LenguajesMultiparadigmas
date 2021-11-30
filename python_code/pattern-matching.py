pattern = {"full": 10, "empty": 0, "medium": 5 }


def unpack(full, **_):
    return full 


print(unpack(**pattern))

