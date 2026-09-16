

namespace UNI
{
    class Program
    {
        static void Main()
        {
            const string inpath="input.txt";
            if (File.Exists(inpath))
            {
                Console.WriteLine("Input file exists");
            }
            else
            {
                Console.WriteLine("Input file does not exist");
            }
            
            string[] lines=File.ReadAllLines(inpath);
            
            double[] vf=lines[0].Split(',').Select(double.Parse).ToArray();
            double[] vs=lines[1].Split(',').Select(double.Parse).ToArray();
            
            int size = Math.Min(vf.Length, vs.Length);
            if (vf.Length != vs.Length)
            {
                Console.WriteLine("Sizes does not match");
                return;
            }
            
            double[] add=new double[size];
            double[] sub=new double[size];
            double[] mul=new double[size];
            double[] div=new double[size];

            for (int i = 0; i < size; i++)
            {
                add[i] = vf[i]+vs[i];
                sub[i] = vf[i]-vs[i];
                mul[i] = vf[i]*vs[i]; 
                div[i] = vf[i]/vs[i];
             if (vf[i] != 0)
             {
                 div[i] = vf[i]/vs[i];  
             }
             else
             {
                 Console.WriteLine("Div on 0!Error!");
             }
            }
            
            string addi=$"({string.Join(",",vf)})+({string.Join(",",vs)})=({string.Join(",",add)})";
            string subi=$"({string.Join(",",vf)})-({string.Join(",",vs)})=({string.Join(",",sub)})";
            string muli=$"({string.Join(",",vf)})*({string.Join(",",vs)})=({string.Join(",",mul)})";
            string divi=$"({string.Join(",",vf)})/({string.Join(",",vs)})=({string.Join(",",div)})";
            
            string[] results={addi,subi,muli,divi};
            File.WriteAllLines("output.txt",results);
        }
    }
}
