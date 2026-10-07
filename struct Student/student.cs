namespace Task8;

struct Student
{
    public string Name { get; set; }
    public string Surname{ get; set;  }
    public string Birthday{ get; set; }
    public int[] Points{ get; set; }


    public bool Talon()
    {
        foreach (var a in Points)
        {
            if (a < 51)
                return true;
        }

        return false;
    }


    public override string ToString()
    {
        string result = $"This is {Surname} {Name} {Birthday}. And my points: ";
        foreach (var a in Points)
        {
            result += a + " ";
        }

        if (Talon())
            result += "Unfortunately, I have Talon";
        else
            result += "Fortunately, I haven't Talon";
        return result;
    }
}