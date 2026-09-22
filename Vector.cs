using System;

namespace labVec
{
    class Vector
    {
        public double[] Coords;
        public Vector(double[] coords)
        {
            Coords = coords;
        }

        public int GetSize()
        {
            return Coords.Length;
        }
        public bool hasZero()
        {
            for (int i = 0; i < Coords.Length; i++)
            {
                if (Coords[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return "(" + string.Join(", ", Coords) + ")";
        }
    }
}
