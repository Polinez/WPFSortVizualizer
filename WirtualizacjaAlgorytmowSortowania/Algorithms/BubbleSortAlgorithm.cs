namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    public class BubbleSortAlgorithm : ISortAlgorithm
    {
        public void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = arr.Count - 1; i >= 0; i--)
            {
                bool swapped = false;

                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                    localComparisons++;
                }

                if (!swapped)
                    break;

                selectedArr = new List<int>() { i };
                AddHistorySnap();
            }

            comparisons = localComparisons;
        }
    }
}
