using System;
using System.Collections.Generic;
using System.Text;

namespace sortowanie
{
    static class sorting
    {
        static public List<int> bubble(List<int> d)
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

        static public List<int> quick(List<int> d, int left = -1, int right = -1)
        {
            if(left < 0)
            {
                left = 0;
            }
            if (right < 0)
            {
                right = d.Count-1;
            }
            int i = left;
            int j = right;
            int x = d[(left + right) / 2];
            do
            {
                while (d[i] < x)
                    i++;

                while (d[j] > x)
                    j--;

                if (i <= j)
                {
                    int temp = d[i];
                    d[i] = d[j];
                    d[j] = temp;

                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) quick(d, left, j);

            if (right > i) quick(d, i, right);
            return d;
        }
    }
}
