
namespace UNI
{
    public class Vector
    {
        private double[] vf;
        private double[] vs;
        private int size;

        public Vector(double[] vfarr, double[] vsarr)
        {
            vf = vfarr;
            vs = vsarr; 
            size = Math.Min(vf.Length, vs.Length);
        }

        public bool checksize()
        {
            if (vf.Length != vs.Length)
            {
                Console.WriteLine("Sizes does not match");
                return false;
            }
            else
            {
                return true;
            }
        }

        public string[] calculate()
        {
            double[] add = new double[size];
            double[] sub = new double[size];
            double[] mul = new double[size];
            double[] div = new double[size];

            for (int i = 0; i < size; i++)
            {
                add[i] = vf[i] + vs[i];
                sub[i] = vf[i] - vs[i];
                mul[i] = vf[i] * vs[i];
                div[i] = vf[i] / vs[i];
                if (vs[i] != 0)
                {
                    div[i] = vf[i] / vs[i];
                }
                else
                {
                    Console.WriteLine("Div on 0!Error!");
                }
            }

            string addi = $"({string.Join(",", vf)})+({string.Join(",", vs)})=({string.Join(",", add)})";
            string subi = $"({string.Join(",", vf)})-({string.Join(",", vs)})=({string.Join(",", sub)})";
            string muli = $"({string.Join(",", vf)})*({string.Join(",", vs)})=({string.Join(",", mul)})";
            string divi = $"({string.Join(",", vf)})/({string.Join(",", vs)})=({string.Join(",", div)})";

            string[] results = { addi, subi, muli, divi };
            return results;
        }
    }
}
