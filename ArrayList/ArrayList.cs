namespace Task6;

public class ArrayList<T>
{
    T[] _data;
    int _count;

    public ArrayList()
    {
        _data = new T[0];
        _count = 0;
    }

    public ArrayList(int capacity)
    {
        _data = new T[capacity];
        _count = 0;
    }


    public ArrayList(params T[] array)
    {
        _data = array.Select(element => element).ToArray();
        _count = array.Length;
    }

     public ArrayList<T> Copy(ArrayList<T> ex)
    {
        if (ex == null)
            return new ArrayList<T>(1);
        int capacity = (int)(1.5 * ex._data.Length + 1);
        ArrayList<T> res = new ArrayList<T>(capacity);
        res._data = Enumerable.Range(0, capacity).Select(i => i < ex._count ? ex._data[i] : default(T)).ToArray();
        res._count = ex._count;
        return res;
    }
    public void Resize()
    {
        if (_count >= _data.Length / 2)
            throw new Exception("Sorry,we can't reduce");
        int capacity = (int)(0.67 * _data.Length + 1);
        _data = Enumerable.Range(0, capacity).Select(i => i < _count ? _data[i] : default(T)).ToArray();
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
                _data = _data.Select((x, index) => index>=i && index<_count-1 ? _data[index + 1] : x).ToArray();
                _count--;
                i--;
            }
        }
    }

    public void Clear()
    {
        _data = new T[0];
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

        if (_count <= index || index < 0)
            throw new Exception("List have less element than your index number or you enter signed number");
        _data = _data.Select((x, indx) => indx >= index && indx < _count - 1 ? _data[indx + 1] : x).ToArray();
        _data[index] = number;
        _count++;
    }

    public void DeleteIndx(int index)
    {
        if (index < 0 || index >= _count)
            throw new Exception("Doesn’t exist such element");
        _data = _data.Select((x, i) => i >= index && i < _count - 1 ? _data[i + 1] : x).ToArray();
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
            int now = _count;
            foreach (T a in _data.Take(_count))
            {
                result += now == 1 ? $"{a}" : $"{a} ; ";
                now--;
            }
        }

        return result;
    }
}