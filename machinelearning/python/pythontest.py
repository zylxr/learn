import datetime

a = ["a","b","c"]
name = "fred"
print(f"his name is {name!r}")
print(f"result:{12.345678:2.6}")
today = datetime.datetime(year=2024, month=9, day=9)
print(f"{today=:%B %d %Y}{name=:20}")
print(f"list a container {"".join(a)}")
print(id(a))

#惰性求值
class Alias:
    def __init__(self, value):
        self.__value = value
    @property
    def value(self):
        return self.__value
alias_instance = Alias(5)
print(alias_instance.value)

type Alias1 = 1/0
Alias1.__value__
# Traceback (most recent call last):
#   File "<stdin>", line 1, in <module>
#   File "<stdin>", line 1, in Alias
# ZeroDivisionError: division by zero

def func[T: 1/0]():pass
T = func.__type_params__[0]
T.__bound__

# Traceback (most recent call last):
#   File "<stdin>", line 1, in <module>
#   File "<stdin>", line 1, in T
# ZeroDivisionError: division by zero

# 此处的异常只有在类型别名的 __value__ 属性或类型变量的 __bound__ 属性被访问时才会被引发。
