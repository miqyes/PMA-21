namespace vectorClasss
{
    public class Vector
    {

        public float[] arr;
        
        public Vector(Vector other)
        {
            arr = new float[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i]=other.arr[i];
            }
        }

        public Vector(string line)
        {
            string[] parts = line.Split(' ');
            arr = new float[parts.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]=float.Parse(parts[i]);
            }

        }

        
        public Vector Add(Vector Ad)
        {
            Vector v = new Vector(this);
            for (int i = 0; i < arr.Length; i++)
            {
                v.arr[i] = arr[i] + Ad.arr[i]; 
            }
            
            return v;
        }

        public Vector Sub(Vector S)
        {
            Vector v = new Vector(this);
            for (int i = 0; i < arr.Length; i++)
            {
                v.arr[i] = arr[i] - S.arr[i]; 
            }

            return v;
            
        }

        public Vector Multiply(Vector M)
        {
            Vector v = new Vector(this);
            for (int i = 0; i < arr.Length; i++)
            {
                v.arr[i] = arr[i] * M.arr[i];
            }

            return v;
            
        }

        public Vector Divide(Vector D)
        {
            Vector v = new Vector(this);
            for (int i = 0; i < arr.Length; i++)
            {
                if (D.arr[i]==0)
                {
                    File.WriteAllText("resultV.txt", "ERROR");
                    Environment.Exit(0);
                }

                v.arr[i] = arr[i] / D.arr[i];
            }
            
            return v;
        }

        public string Print()
        {
            return "(" + string.Join(" ; ", arr) + ")";
        }
        
    }
}   