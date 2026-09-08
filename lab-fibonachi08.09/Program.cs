using System;
using System.Collections.Generic;
using System.IO;

namespace Fibonachi;

class Program
{
    static void Main()
    {
        StreamReader f1 = new StreamReader("input.txt");
        string data = f1.ReadToEnd();
        f1.Close();
        
        string[] tempParts = data.Split(',');
        
        List<int> myList = new List<int>();
        foreach (string item in tempParts)
        {
            myList.Add(int.Parse(item.Trim()));
        }
        
        StreamReader f2 = new StreamReader("steps.txt");
        string stepsText = f2.ReadToEnd();
        f2.Close();

        int steps = int.Parse(stepsText);
        
        int countSteps = steps - 2;
        if (countSteps < 0)
        {
            countSteps = 0; 
        }
        
        List<int> resultList = Fib(countSteps, myList);
        
        string res_str = "";
        for (int i = 0; i < resultList.Count; i++)
        {
            res_str = res_str + resultList[i];
            if (i < resultList.Count - 1)
            {
                res_str = res_str + ","; 
            }
        }
       
        StreamWriter f3 = new StreamWriter(@"C:\Users\User\RiderProjects\Fibonachi\Fibonachi\output.txt");
        f3.Write(res_str);
        f3.Close();
        
        Console.WriteLine("Done!");
    }

    static List<int> Fib(int count, List<int> lst)
    {
        if (count == 0)
        {
            return lst;
        }
        int last1 = lst[lst.Count - 1];
        int last2 = lst[lst.Count - 2];
        int sum = last1 + last2;
        
        lst.Add(sum);
        
        return Fib(count - 1, lst);
    }
}