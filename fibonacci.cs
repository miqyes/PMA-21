using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna1
{
     class fibonacci
    {
     public static List<int> recursive(List<int> list,int count)
        {
            if (count <= 2)
            {
                return list;
            }
            list.Add(list[list.Count-1] + list[list.Count-2]);
            return recursive(list, count - 1);
        }
        public static List<int> limitFibonacci(List<int> list, int limit)
        {
            if (list.Count <= 2)
            {
                return list;
            }
            int nextValue = list[list.Count - 1] + list[list.Count - 2];
            if (nextValue > limit)
            {
                return list;
            }
            list.Add(nextValue);
            return limitFibonacci(list, limit);
        }
    }
}
