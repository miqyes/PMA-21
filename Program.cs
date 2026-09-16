using System;
using System.Collections.Generic;

namespace TaskOne;

public class Fibonachi {
    public static List<int> FibCalculate(List<int> list, int count) {
        if (count <= 2) {
            return list;
        }

        list.Add(list[list.Count - 1] + list[list.Count - 2]);
        return FibCalculate(list, count - 1);
    }

    public static List<int> LimitFib(List<int> list, int limit) { 
        if (list.Count < 2) {
            return list;
        }

        int nextValue = list[list.Count - 1] + list[list.Count - 2];
        if (nextValue > limit) {
            return list;
        }

        list.Add(nextValue);
        return LimitFib(list, limit);
    }
}
