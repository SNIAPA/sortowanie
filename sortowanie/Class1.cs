using System;
using System.Collections.Generic;
using System.Text;

namespace sortowanie
{
    static class sorting
    {
        static public List<int> inserting(List<int> d)
        {
            int i, key, j;
            for (i = 1; i < d.Count; i++)
            {
                key = d[i];
                j = i - 1;
                while (j >= 0 && d[j] > key)
                {
                    d[j + 1] = d[j];
                    j = j - 1;
                }
                d[j + 1] = key;
            }
            return d;
        }
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

        static private List<int> heapify(List<int> d, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && d[left] > d[largest])
                largest = left;

            if (right < n && d[right] > d[largest])
                largest = right;

            if (largest != i)
            {
                int temp = d[largest];
                d[largest] = d[i];
                d[i] = temp;
                heapify(d, n, largest);
            }
            return d;

        }

        public static List<int> heap(List<int> d, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(d, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = d[0];
                d[0] = d[i];
                d[i] = temp;

                heapify(d, i, 0);
            }
            return d;
        }

        private static List<int> merge(List<int> d, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = d[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = d[m + 1 + j];
            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    d[k] = L[i];
                    i++;
                }
                else
                {
                    d[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                d[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                d[k] = R[j];
                j++;
                k++;
            }
            return d;
        }

         public static List<int> merge_sort(List<int> d, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                merge_sort(d, l, m);
                merge_sort(d, m + 1, r);

                merge(d, l, m, r);
            }
            return d;
        }

    }
}
