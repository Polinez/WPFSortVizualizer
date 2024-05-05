using System;

namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    public class QuickSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] arr, ref int comparisons, ref int[] selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            QuickSort(0, arr.Length, ref selectedArr);

            void QuickSort(int startI, int endI, ref int[] selectedArr)
            {
                localComparisons++;

                if (endI - startI < 1)
                    return;

                int pI = endI - 1;

                int i = startI;
                int j = startI;

                while (j < endI - 1)
                {
                    localComparisons++;

                    if (arr[j] <= arr[pI])
                    {
                        localComparisons++;

                        int oldJ = arr[j];
                        arr[j] = arr[i];
                        arr[i] = oldJ;
                        i++;
                        selectedArr = new int[] { j, i }; // Aktualizacja referencji
                        AddHistorySnap();
                    }
                    j++;
                }
                localComparisons++;

                int oldI = arr[i];
                arr[i] = arr[pI];
                arr[pI] = oldI;
                pI = i;

                selectedArr = new int[] { pI, i }; // Aktualizacja referencji
                AddHistorySnap();

                QuickSort(startI, pI, ref selectedArr);
                QuickSort(pI + 1, endI, ref selectedArr);
            }

            comparisons = localComparisons; // Aktualizacja wartości comparisons po zakończeniu sortowania
        }

    }
}
