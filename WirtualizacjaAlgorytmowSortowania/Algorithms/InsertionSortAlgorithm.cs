using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class InsertionSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] arr, ref int comparisons, ref int[] selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = 1; i < arr.Length; i++)
            {
                int curr = i;
                while (curr - 1 >= 0 && arr[curr - 1] > arr[curr])
                {
                    localComparisons += 2;
                    int oldIValue = arr[curr];
                    arr[curr] = arr[curr - 1];
                    arr[curr - 1] = oldIValue;
                    curr--;
                }

                localComparisons++;
                if (curr - 1 >= 0)
                {
                    localComparisons++;
                }

                selectedArr = new int[] { curr };
                AddHistorySnap();
            }

            comparisons = localComparisons; // Aktualizacja wartości comparisons po zakończeniu sortowania
        }

    }
}
