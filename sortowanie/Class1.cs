using System;
using System.Collections.Generic;
using System.Text;

namespace sortowanie
{
    static class sorting
    {
        static public List<int> sort1(List<int> d)
        {
            for (int i = 1; i < d.Count; i++)
            {
                int temp = d[i];
                int j;
                for (j = i - 1; j >= 0 && d[j] > temp; j--)
                {
                    d[j + 1] = d[j];
                }

                d[j + 1] = temp;

            }
            return d;
        }
    }
}
