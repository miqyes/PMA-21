namespace ConsoleApp;

public class Fibonacci
{
   public static List<int> FibonacciCount(List<int> numbers, int stepcount)
    {
        if (numbers.Count >= stepcount)
        {
            return numbers; 
        }
        
        int newElement = numbers[^1] + numbers[^2];
        numbers.Add(newElement);
        return FibonacciCount(numbers, stepcount);
        
    }

    public static List<int> FibonacciLimit(List<int> numbers, int stepcount)
    {
        int newElement = numbers[^1] + numbers[^2];
        if (newElement > stepcount)
        {
            return numbers;
        }
        
        numbers.Add(newElement);
        return FibonacciLimit(numbers, stepcount);

    }

}
