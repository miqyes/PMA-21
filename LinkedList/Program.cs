namespace arrayList;

class Program
{
    static void printList<T>(ArrayList<T> list)
    {
        Console.WriteLine("Елементи: ");
        for (int i = 0; i < list.Size; i++)
        {
            Console.Write($"{list[i]} ");
        }

        Console.WriteLine(" ");
    }

    static void Main()
    {
            ArrayList<int> myArrayList = new ArrayList<int>(5);
            myArrayList.add(2);
            myArrayList.add(5);
            myArrayList.add(8);
            myArrayList.add(10);
            myArrayList.add(4);
            printList(myArrayList);
            Console.WriteLine("Збільшення ArrayList");
            myArrayList.add(7);
            printList(myArrayList);
            try
            {
                Console.WriteLine("Вставлення за індексом ");
                myArrayList.insertByIndex(2, 52);
                printList(myArrayList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }

            try
            {
                Console.WriteLine("Видалення за значенням ");
                myArrayList.delete(6);
                printList(myArrayList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }
            try
            {
                Console.WriteLine("Видалення за індексом ");
                myArrayList.deleteByIndex(2);
                printList(myArrayList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }

            try
            {
                Console.WriteLine(" Доступ за індексом ");
                Console.WriteLine($"{myArrayList[1]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }
            Console.WriteLine(" Clear ");
            myArrayList.clear();
            printList(myArrayList);
        }
    }
