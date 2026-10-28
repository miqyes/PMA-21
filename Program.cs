namespace Vector
{
    class Program
    {
        static void Main()
        {
            List<float> vectorFirst;
            List<float> vectorSecond;
            List<float> vectorThird = new List<float>();
            const string RESULT_FILE = "vectorresult.txt";


            //using key word
            string vectorNumbersFirst = File.ReadAllText("vectorfirst.txt");
            List<string> vectorNumbersFirstList = vectorNumbersFirst.Split(',').ToList();
            try
            {
                //linq
                vectorFirst = vectorNumbersFirstList.Select(float.Parse).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string vectorNumbersSecond = File.ReadAllText("vectorsecond.txt");
            List<string> vectorNumbersSecondList = vectorNumbersSecond.Split(',').ToList();
            try
            {
                vectorSecond = vectorNumbersSecondList.Select(float.Parse).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            { 
                MathOperation.productVector(vectorFirst, vectorSecond);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            
            string vectorResult = string.Join("; ", vectorThird);
            File.WriteAllText(RESULT_FILE, string.Format("{0}: ({1})\n", "Product Vector", vectorResult));
            
            try
            {
                vectorThird = MathOperation.sumVector(vectorFirst, vectorSecond);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            vectorResult = string.Join("; ", vectorThird);
            File.AppendAllText(RESULT_FILE, string.Format("{0}: ({1})\n", "Sum Vector", vectorResult));

            try
            {
                vectorThird = MathOperation.differenceVector(vectorFirst, vectorSecond);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            vectorResult = string.Join(";", vectorThird);
            File.AppendAllText(RESULT_FILE, string.Format("{0}: ({1})\n", "Difference Vector", vectorResult));

            try
            {
                vectorThird = MathOperation.divisionVector(vectorFirst, vectorSecond);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            

            vectorResult = string.Join("; ", vectorThird);
            File.AppendAllText(RESULT_FILE, string.Format("{0}: ({1})\n", "Division Vector", vectorResult));
        }
    }
}