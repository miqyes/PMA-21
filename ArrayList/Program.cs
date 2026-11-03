namespace ArrayList
{
    class Program
    {

        
        static void Main()
        { 
            MyArrList<char> list = new MyArrList<char>();
            list.Add('a');
            list.Add('b');
            list.Add('c');
            list.Add('d');
            
            
            list.Output(list);

            try
            {
                list.DeleteByIndex(0);
                list.Output(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            try
            {
                list.Insert('f', 2);
                list.Output(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            list.Add('r');
            list.Add('s');
            list.Output(list);

            try
            {
                list.DeleteByElement('d');
                list.Output(list);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            list.Clear();
            list.Output(list);

            list.Add('x');
            list.Output(list);
            
        }

    }

}
