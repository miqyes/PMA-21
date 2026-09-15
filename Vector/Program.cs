using System;
using System.IO;

namespace UNI
{
    class Program
    {
        static void Main()
        {
            string inpath="input.txt";
            if (File.Exists(inpath))
            {
                Console.WriteLine("Input file exists");
            }
            else
            {
                Console.WriteLine("Input file does not exist");
            }
            
            string[] lines=File.ReadAllLines("input.txt");
            
            double[] v1=lines[0].Split(',').Select(double.Parse).ToArray();
            double[] v2=lines[1].Split(',').Select(double.Parse).ToArray();
            
            int size = Math.Min(v1.Length, v2.Length);
            double[] add=new double[size];
            double[] sub=new double[size];
            double[] mul=new double[size];
            double[] div=new double[size];

            for (int i = 0; i < size; i++)
            {
                add[i] = v1[i]+v2[i];
                sub[i] = v1[i]-v2[i];
                mul[i] = v1[i]*v2[i];
                div[i] = v2[i] !=0 ? v1[i]/v2[i] : 0;
            }
            
            string Add=$"({string.Join(",",v1)})+({string.Join(",",v2)})=({string.Join(",",add)})";
            string Sub=$"({string.Join(",",v1)})-({string.Join(",",v2)})=({string.Join(",",sub)})";
            string Mul=$"({string.Join(",",v1)})*({string.Join(",",v2)})=({string.Join(",",mul)})";
            string Div=$"({string.Join(",",v1)})/({string.Join(",",v2)})=({string.Join(",",div)})";
            
            string[] results={Add,Sub,Mul,Div};
            File.WriteAllLines("output.txt",results);

            foreach (var line in results)
            {
                Console.WriteLine(line);
            }
        }
    }
}
