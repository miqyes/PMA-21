namespace LinkedList;

class Program
{

    static void printList<T>(LinkedList<T> list)
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
            LinkedList<int> myLinkedList = new LinkedList<int>();
            myLinkedList.add(2);
            myLinkedList.add(5);
            myLinkedList.add(8);
            myLinkedList.add(10);
            myLinkedList.add(4);
            myLinkedList.add(7);
            printList(myLinkedList);
            try
            {
                Console.WriteLine("Вставлення за індексом ");
                myLinkedList.insertByIndex(2, 52);
                printList(myLinkedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }

            try
            {
                Console.WriteLine("Видалення за значенням ");
                myLinkedList.delete(6);
                printList(myLinkedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }
            try
            {
                Console.WriteLine("Видалення за індексом ");
                myLinkedList.deleteByIndex(2);
                printList(myLinkedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }

            try
            {
                Console.WriteLine(" Доступ за індексом ");
                Console.WriteLine($"{myLinkedList[1]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Помилка : {ex.Message}");
            }
            Console.WriteLine(" Clear ");
            myLinkedList.clear();
            printList(myLinkedList);
        }
    }

