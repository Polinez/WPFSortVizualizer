namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class SelectionSortAlgorithm : ISortAlgorithm
    {
        public void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = 0; i < arr.Count; i++)
            {
                int minI = i;
                for (int j = i + 1; j < arr.Count; j++)
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

                selectedArr = new List<int> { i };
                AddHistorySnap();
            }

            comparisons = localComparisons;
        }

    }
}
