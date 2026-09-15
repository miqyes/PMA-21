namespace lab2.vector;

class Program
{
    static void Main(string[] args)
    {
        string file="vector.txt";
        string[] lines = File.ReadAllLines(file);
        string[] v1= lines[0].Split(' ');
        string[] v2=lines[1].Split(' ');
        int[] a =  new int[v1.Length];
        int[] b = new int[v2.Length];
        if (a.Length != b.Length)
        {
            Console.WriteLine("Vectors are not equal");
            return;
        }
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = int.Parse(v1[i]);
        }

        for (int i=0; i < b.Length; i++)
        {
            b[i] = int.Parse(v2[i]);
            if (b[i] == 0)
            {
                Console.WriteLine("Vector b cannot be zero");
                return;
            }
                
        }
        int[] c=AddVectors(a,b);
        int[] s=SubtractionVectors(a,b);
        int[] m=MultiplicationVectors(a,b);
        double[] d=DivisionVectors(a,b);
        string[] vectors=Convertation(a,b,c,s,m,d);
       
        File.WriteAllText("Result.txt","Vectors:\na=(" + vectors[0] +")\nb=("+vectors[1]+")\nOperation\n("+
                                       vectors[0]+") + ("+vectors[1]+") = ("+vectors[2]+")\n("+
                                       vectors[0]+") - ("+vectors[1]+") = ("+vectors[3]+")\n("+
                                       vectors[0]+") * ("+vectors[1]+") = ("+vectors[4]+")\n("+
                                       vectors[0]+") / ("+vectors[1]+") = ("+vectors[5]+")\n");
    }

    public static int[] AddVectors(int[] a, int[] b)
    {
        int[] c = new int[a.Length];
        
        for (int i = 0; i < c.Length; i++)
        {
           c[i] = a[i] + b[i];
        }
        return c;
    }
    public static int[] SubtractionVectors(int[] a, int[] b)
    {
        int[] c = new int[a.Length];
        
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = a[i] - b[i];
        }
        return c;
    }
    public static int[] MultiplicationVectors(int[] a, int[] b)
    {
        int[] c = new int[a.Length];
        
        for (int i = 0; i < c.Length; i++)
        {
            c[i] = a[i] * b[i];
        }
        return c;
    }
    public static double[] DivisionVectors(int[] a, int[] b)
    {
        double[] c = new double[a.Length];
        
        for (int i = 0; i < c.Length; i++)
        {
            c[i] =(double)a[i] / b[i];
        }
        return c;
    }
    public static string[] Convertation(int[] a, int[] b, int[] c, int[] s, int[] m, double[] d)
    {
        string[] vectors = new string[6];
        vectors[0] = string.Join(" , ", a);
        vectors[1] = string.Join(" , ", b);
        vectors[2] = string.Join(" , ", c);
        vectors[3] = string.Join(" , ", s);
        vectors[4] = string.Join(" , ", m);
        vectors[5] = string.Join(" , ", d);
        
        return vectors;
    }
}
