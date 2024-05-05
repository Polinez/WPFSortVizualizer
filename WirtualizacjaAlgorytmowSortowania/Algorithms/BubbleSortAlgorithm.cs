using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    public class BubbleSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] arr, ref int comparisons, ref int[] selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;


            for (int i = arr.Length; i >= 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int oldJ = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = oldJ;


                    }
                    localComparisons++;
                }
                selectedArr = new int[] { i };
                AddHistorySnap();

            }

            comparisons = localComparisons; // Aktualizacja wartości comparisons po zakończeniu sortowania

        }
    }
}
