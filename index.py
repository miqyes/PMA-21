file_in = open('input.txt', 'r')
text_in = file_in.read()
file_in.close()
file_steps = open('steps.txt', 'r')
text_steps = file_steps.read()
file_steps.close()
parts = text_in.split(',')
num1 = int(parts[0])
num2 = int(parts[1])
steps = int(text_steps)

def make_fib(a, b, k):
    if k <= 0:
        return []
    next_n = a + b
    return [next_n] + make_fib(b, next_n, k - 1)

result = [num1, num2] + make_fib(num1, num2, steps - 2)

out_text = ""
for i in range(len(result)):
    out_text = out_text + str(result[i])
    if i != len(result) - 1:
        out_text = out_text + ","

file_out = open('output.txt', 'w')
file_out.write(out_text)
file_out.close()
