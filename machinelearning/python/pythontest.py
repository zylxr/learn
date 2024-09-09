import datetime

a = ["a","b","c"]
name = "fred"
print(f"his name is {name!r}")
print(f"result:{12.345678:2.6}")
today = datetime.datetime(year=2024, month=9, day=9)
print(f"{today=:%B %d %Y}{name=:20}")
print(f"list a container {"".join(a)}")
print(id(a))