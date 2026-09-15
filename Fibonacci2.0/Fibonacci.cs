using System.Collections.Generic;
namespace ConsoleApp1;

public class Fibonacci
{
    
    public static List<int> LimitedSeq(List <int> seq, int limit)
    {
        int newElement = seq[^1] + seq[^2];
        
        if (newElement > limit)
        {
            return seq;
        }
        
        seq.Add(newElement);
        return LimitedSeq(seq, limit);
        
    }

    public static List<int> StepsSeq(List<int> seq, int stepscount)
    {
        if (seq.Count >= stepscount)
        {
            return seq;
        }
        
        int newElement = seq[^1] + seq[^2];
        seq.Add(newElement);
        return StepsSeq(seq, stepscount);
    }
    
}