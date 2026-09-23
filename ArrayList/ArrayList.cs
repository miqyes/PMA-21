namespace Task6;

public class ArrayList<T>
{
    T[] _data;
    int _count;

    public ArrayList(int capacity)
    {
        _data = new T[capacity];
        _count = 0;
    }


    public ArrayList(params T[] array)
    {
        _data = new T[array.Length];
        for (int i = 0; i < array.Length; i++)
            _data[i] = array[i];
        _count = array.Length;
    }

    static public ArrayList<T> Copy(ArrayList<T> ex)
    {
        if (ex == null)
            return new ArrayList<T>(1);
        int capacity = (int)(1.5 * ex._data.Length + 1);
        ArrayList<T> res = new ArrayList<T>(capacity);
        for (int i = 0; i < ex._count; i++)
            res[i] = ex[i];
        res._count = ex._count;
        return res;
    }

    public T this[int i]
    {
        get { return _data[i]; }
        set { _data[i] = value; }
    }

    public void Add(T number)
    {
        if (_data.Length == _count)
        {
            ArrayList<T> temp = Copy(this);
            _data = temp._data;
        }

        _data[_count++] = number;
    }

    public void Delete(T number)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_data[i].Equals(number))
            {
                for (int j = i; j < _count - 1; j++)
                    _data[j] = _data[j + 1];
                _count--;
                i--;
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < _count; i++)
            _data[i] = default(T);
        _count = 0;
    }

    public T GetNumber(int index)
    {
        if (index < 0 || index >= _data.Length)
            throw new Exception("Doesn’t exist such element");
        return _data[index];
    }

    public void AddIndx(T number, int index)
    {
        if (_data.Length == _count)
        {
            ArrayList<T> temp = Copy(this);
            _data = temp._data;
        }

        if (_data.Length < index || index < 0)
            throw new Exception("Capacity is less than your index number or you enter signed number");
        for (int i = _count; i > index; i--)
            _data[i] = _data[i - 1];
        _data[index] = number;
        _count++;
    }

    public void DeleteIndx(int index)
    {
        if (index < 0 || index >= _count)
            throw new Exception("Doesn’t exist such element");
        for (int i = index; i < _count - 1; i++)
            _data[i] = _data[i + 1];
        _data[_count - 1] = default(T);
        _count--;
    }


    public override string ToString()
    {
        string result = $"ArrayList<{typeof(T).Name}>, Size: {_data.Length},Count: {_count},Elements: ";
        if (_count == 0)
            result += "none element";
        else
        {
            for (int i = 0; i < _data.Length; i++)
            {
                result += _data[i];
                if (i < _data.Length - 1)
                    result += ", ";
            }
        }

        return result;
    }
}