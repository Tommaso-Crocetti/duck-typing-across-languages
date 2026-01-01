# This file contains the AI-generated examples demonstrating the use of data descriptors


class C:
    @property
    def value(self):
        return 42

c = C()
# Hallucination of the AI, the following line won't execute
# c.value = 10  # triggers property's __set__ or raises


class NonNegative:
    def __init__(self):
        self.values = {}  # store per-instance values internally

    def __get__(self, obj, objtype=None):
        return self.values.get(id(obj), 0)  # fallback default

    def __set__(self, obj, value):
        if not isinstance(value, int) or value < 0:
            raise ValueError("must be non-negative")
        self.values[id(obj)] = value

class Account:
    balance = NonNegative()

a = Account()
a.balance = 50
print(a.balance)  # 50

# directly setting in __dict__ does not affect descriptor
a.__dict__['balance'] = -999    
print(a.balance)  # still 50