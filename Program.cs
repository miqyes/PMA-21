

namespace UNI
{
    class Program
    {
        
        
        const string inpath = "input.txt";
        const string steppath = "steps.txt";
        
        static void Main()
        {
            string inpath = "input.txt";
            string steppath="steps.txt";
            if (File.Exists(inpath)&& File.Exists(steppath))
            {
                Console.WriteLine("Files exist");
            }
            else
            {
                Console.WriteLine("No files exist");
                return;
            }

            string[] values = File.ReadAllText(inpath).Trim().Split(',');
            
            string steps = File.ReadAllText(steppath).Trim();
            int stepCount = int.Parse(steps);

            var el = new List<int>();

            el = Fibonacci.GetFib(el, stepCount);

            string result = string.Join(",", el);
            File.WriteAllText("output.txt", result);

            Console.WriteLine(result);
        }
    }
}