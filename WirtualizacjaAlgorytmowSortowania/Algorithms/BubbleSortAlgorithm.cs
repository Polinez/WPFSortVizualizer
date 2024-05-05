namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    public class BubbleSortAlgorithm : ISortAlgorithm
    {
        public void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = arr.Count; i >= 0; i--)
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
                selectedArr = new List<int>() { i };
                AddHistorySnap();
            }

            comparisons = localComparisons;
        }
    }
}
