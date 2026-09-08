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

result = []
result.append(num1)
result.append(num2)

for i in range(steps - 2):
    next_num = result[-1] + result[-2]
    result.append(next_num)

out_text = ""
for i in range(len(result)):
    out_text = out_text + str(result[i])
    if i != len(result) - 1:
        out_text = out_text + ","

file_out = open('output.txt', 'w')
file_out.write(out_text)
file_out.close()