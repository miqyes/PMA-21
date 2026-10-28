using System;
using System.Collections.Generic;
using System.IO;

namespace vector
{

    class Vector
    {
        private List<float> vector;

        public Vector(List<float> number)
        {
            vector = number;
        }

        public float this[int i]
        {
            get { return vector[i]; }
        }


        public int Length
        {
            get { return vector.Count; }
        }

        public static Vector productVector(Vector first, Vector second)
        {
            if (first.Length != second.Length)
            {
                throw new Exception("Vector lengths do not match");
            }
            List<float> vectorProduct = new List<float>();
            for (int i = 0; i < first.Length; i++)
            {
                vectorProduct.Add(first[i] * second[i]);
            }

            return new Vector(vectorProduct);
        }

        public Vector sumVector(Vector second)
        {
            if (this.Length != second.Length)
            {
                throw new Exception("Vector lengths do not match");
            }
            List<float> vectorSum = new List<float>();
            
            
            
            for (int i = 0; i < this.Length; i++)
            {
                if (i==0)
                {
                    vectorSum.Add(this.vector[i] + second[second.Length - 1]);
                    
                }
                else if (i == this.Length - 1)
                {
                    vectorSum.Add(this.vector[i] + second[0]);
                }
                else
                {
                    vectorSum.Add(this.vector[i] + second[i]);
                }


               
            }

            return new Vector(vectorSum);
        }

        public static Vector differenceVector(Vector first, Vector second)
        {
            if (first.Length != second.Length)
            {
                throw new Exception("Vector lengths do not match");
            }
            List<float> vectorDifference = new List<float>();
            for (int i = 0; i < first.Length; i++)
            {
                vectorDifference.Add(first[i] - second[i]);
            }

            return new Vector(vectorDifference);
        }

        public static Vector divisionVector(Vector first, Vector second)
        {
            if (first.Length != second.Length)
            {
                throw new Exception("Vector lengths do not match");
            }
            List<float> vectorDivision = new List<float>();
            for (int i = 0; i < first.Length; i++)
            {
                if (second[i] == 0)
                {
                    throw new Exception("Divivsion by zero is not allowed");
                }
                vectorDivision.Add(first[i] / second[i]);
            }

            return new Vector(vectorDivision);
        }

        public static string GetStringFromVector(Vector v)
        {
            List<string> items = new List<string>();
            for (int i = 0; i < v.Length; i++)
            {
                items.Add(v[i].ToString());
            }
            return string.Join(", ", items);
        }
    }
}