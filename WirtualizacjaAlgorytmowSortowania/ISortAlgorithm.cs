namespace WirtualizacjaAlgorytmowSortowania
{
    public interface ISortAlgorithm
    {
        void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory);
    }
}
