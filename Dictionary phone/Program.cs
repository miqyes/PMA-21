namespace Task9;

class Program
{
    static void AddFromKeyboard(Dictionary<string, Characteristics> phones)
    {
        Console.Write("How many phones you want to add: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\nPhone " + (i + 1));

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Memory (GB): ");
            int memory = int.Parse(Console.ReadLine());

            Console.Write("Color: ");
            string color = Console.ReadLine();

            Console.Write("Battery (mAh): ");
            double battery = double.Parse(Console.ReadLine());

            Console.Write("Price: ");
            int price = int.Parse(Console.ReadLine());

            phones.Add(
                model,
                new Characteristics(memory, color, battery, price)
            );
        }
    }

    static void AddFromFile(Dictionary<string, Characteristics> phones)
    {
        string[] lines = File.ReadAllLines("phones.txt");

        foreach (string line in lines)
        {
            string[] data = line.Split(';');

            string model = data[0];
            int memory = int.Parse(data[1]);
            string color = data[2];
            double battery = double.Parse(data[3]);
            int price = int.Parse(data[4]);

            phones.Add(
                model,
                new Characteristics(memory, color, battery, price)
            );
        }
    }

    static void ShowPhones(Dictionary<string, Characteristics> phones)
    {
        foreach (var phone in phones)
        {
            Console.Write("Model: " + phone.Key + " | " + phone.Value);
        }
    }

    static void Main()
    {
        Dictionary<string, Characteristics> phones = new Dictionary<string, Characteristics>();

        Console.WriteLine("1 - Enter phones");
        Console.WriteLine("2 - Input from file");
        Console.Write("Your choice: ");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            AddFromKeyboard(phones);
        }
        else if (choice == 2)
        {
            AddFromFile(phones);
        }
        else
        {
            Console.WriteLine("Wrong choice.");
            return;
        }

        Console.WriteLine("\nList of phone:");
        ShowPhones(phones);

        Console.Write("\nModel phohe whose you want to change price: ");
        string model = Console.ReadLine();

        if (phones.ContainsKey(model))
        {
            Console.Write("Enter new price: ");
            int newPrice = int.Parse(Console.ReadLine());

            Characteristics phone = phones[model];
            phone.Price = newPrice;
            phones[model] = phone;
            Console.WriteLine("Price is changed!");
        }
        else
        {
            Console.WriteLine("No exist such phone.");
        }

        Console.WriteLine("\nAfter change:");
        ShowPhones(phones);

        Console.Write("\nModel phohe whose you want to delete: ");
        model = Console.ReadLine();

        if (phones.Remove(model))
        {
            Console.WriteLine("Phone is deleted!");
        }
        else
        {
            Console.WriteLine("No exist such phone.");
        }

        Console.WriteLine("\nAfter delete:");
        ShowPhones(phones);
    }
}