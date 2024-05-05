namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class SelectionSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] arr, ref int comparisons, ref int[] selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = 0; i < arr.Length; i++)
            {
                int minI = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minI] > arr[j])
                    {
                        minI = j;
                    }

                    localComparisons++;
                }
                int oldI = arr[i];
                arr[i] = arr[minI];
                arr[minI] = oldI;

                selectedArr = new int[] { i };
                AddHistorySnap();
            }

            comparisons = localComparisons; // Aktualizacja wartości comparisons po zakończeniu sortowania
        }

    }
}