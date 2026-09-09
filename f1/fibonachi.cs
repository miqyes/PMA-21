namespace fibonachi;
class FibonachiTask
{
    public static List<int> fibonachi(int count,List<int>numbers)
    {
        if (count-2 <= 0)
            return numbers;
        numbers.Add(numbers[numbers.Count - 1] + numbers[numbers.Count - 2]);
        return fibonachi(count-1,numbers);
    }
    
    public static List<int> limit(int lim, List<int> numbers)
    {
    int next = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];

    if (next > lim)
        return numbers;

    numbers.Add(next);

    return limit(lim, numbers);
        }


    }
    




