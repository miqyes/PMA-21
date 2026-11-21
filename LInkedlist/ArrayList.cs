using System;

public class ArrayList<T>
{
    private T[] Items;
    private int Count;

    public ArrayList(int InitialCapacity = 4)
    {
        Items = new T[InitialCapacity];
        Count = 0;
    }
    public int GetCount()
    {
        return Count;
    }

    private void Resize()
    {
        int OldCapacity = Items.Length;
        int NewCapacity = (int)(OldCapacity * 1.5) + 1;
        T[] NewItems = new T[NewCapacity];

        for(int Index=0; Index < Count; Index++)
        {
            NewItems[Index] = Items[Index];
        }
        Items = NewItems;
    }

    public void Add(T Value)
    {
        if (Count == Items.Length)
        {
            Resize();
        }
        Items[Count] = Value;
        Count++;
    }

    public void Insert(int Index, T Value)
    {
        if (Index < 0 || Index > Count)
        {
            Console.WriteLine("Invalid index!");
            return;
        }
        if (Count == Items.Length)
        {
            Resize();
        }
        for(int Current = Count; Current > Index; Current--)
        {
            Items[Current] = Items[Current - 1];
        }
        Items[Index] = Value;
        Count++;
    }

    public bool Remove(T Value)
    {
        int FoundIndex = -1;
        for(int Index = 0; Index < Count; Index++)
        {
            if (object.Equals(Items[Index], Value))
            {
                FoundIndex = Index;
                break;
            }
        }
        if (FoundIndex == -1)
        {
            return false;
        }
        for(int Current = FoundIndex; Current < Count - 1; Current++)
        {
            Items[Current] = Items[Current + 1];
        }
        Count--;
        return true;
    }

    public void Clear()
    {
        Count = 0;
    }

    public void Print()
    {
        if (Count == 0)
        {
            Console.WriteLine("The list is empty!");
            return;
        }
        for(int Index = 0; Index < Count; Index++)
        {
            Console.Write(Items[Index] + " ");
        }
        Console.WriteLine();
    }
}