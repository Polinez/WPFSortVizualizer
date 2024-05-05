namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class InsertionSortAlgorithm : ISortAlgorithm
    {
        public void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = 1; i < arr.Count; i++)
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

                selectedArr = new List<int> { curr };
                AddHistorySnap();
            }

            comparisons = localComparisons;
        }

    }
}
