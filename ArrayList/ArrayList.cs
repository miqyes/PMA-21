using System;
namespace UNI;

public class ArrayList
{
    private double[] array;

    public int size
    {
        get;
        private set;
    }

    public ArrayList(int capacity)
    {
        size = 0;
        array = new double[capacity];
    }

    public void unic()
    {
        if (size < array.Length)
        {
            return;
        }

        int newcapacity = array.Length * 3 / 2 + 1;
        double[] newarray = new double[newcapacity];

        for (int i = 0; i < size; i++)
        {
            newarray[i]=array[i];
        }

        array = newarray;
    }

    public void add(double value)
    {
        unic();
        array[size] = value;
        size++;
    }

    public void delete(int i)
    {
        if (i < 0 || i >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(i), "No index like this");
        }

        for (int j = i; j < size-1; j++)
        {
            array[j] = array[j + 1];
        }

        size--;
    }

    public void addindex(int i,double value)
    {
        if (i < 0 || i > size)
        {
            throw new ArgumentOutOfRangeException(nameof(i), "No index like this");
        }
        unic();
        for (int j = size; j >i; j--)
        {
            array[j] = array[j - 1];
        }

        array[i] = value;
        size++;
    }

    public void clear()
    {
        size = 0;
    }

    public void print()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
