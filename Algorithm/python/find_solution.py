from itertools import permutations

def find_solution(target):
    if not (1<= target <=9):
        return "Invalid target:target must be between 1 and 9"
    solutions = []
    digits = list(range(1,10))
    for combination in permutations(digits, 4):
        for opt1 in ['+','-']:
            for opt2 in ['+','-']:
                for opt3 in ['+','-']:
                    expression = f'{combination[0]} {opt1} {combination[1]} {opt2} {combination[2]} {opt3} {combination[3]}'
                    result = eval(expression)
                    if result == target:
                        solutions.append(f'{expression}= {target}')
    if solutions:
        return solutions
    else:
        return "No solution found"

target = 9
solutions= find_solution(target)
for solution in solutions:
    print(solution)