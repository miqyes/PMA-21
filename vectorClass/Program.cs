namespace  VectorClass
{
	class Program
	{
		static void Main()
		{
			double[] firstVector;
			double[] secondVector;
			
			try
			{
				firstVector = FileOperations.ReadFromFile("firstvector.txt");
				secondVector = FileOperations.ReadFromFile("secondvector.txt");
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Error: cannot find file!");
				return;
			}

			if (firstVector.Length != secondVector.Length)
			{
				Console.WriteLine("Error: the number of coordinates in your vector must be the same");
				return;
			}

			Vector vector = new Vector(firstVector, secondVector); 
			
			var add = vector.Add();
			var sub = vector.Sub();
			var mult =vector.Mult();

			string divResult;
			
			try
			{
				var div = vector.Div();
				divResult = "(" + string.Join(",", firstVector) + ")" + "/" + "(" + string.Join(",", secondVector) +
				            ")" + "=" + "(" + string.Join(",", div) + ")";
			}
			catch(DivideByZeroException)
			{
				divResult = "Error: you cannot divide by zero!";
			}
			
			string addResult = "(" + string.Join(",", firstVector) + ")" + "+" + "(" + string.Join(",", secondVector) +
			                   ")" + "=" + "(" + string.Join(",", add) + ")";
			string subResult = "(" + string.Join(",", firstVector) + ")" + "-" + "(" + string.Join(",", secondVector) +
			                   ")" + "=" + "(" + string.Join(",", sub) + ")";
			string multResult = "(" + string.Join(",", firstVector) + ")" + "*" + "(" + string.Join(",", secondVector) +
			                    ")" + "=" + "(" + string.Join(",", mult) + ")";
			string[] result = { addResult, subResult, multResult, divResult };
			File.WriteAllLines("output.txt", result);
		}
	}
}
