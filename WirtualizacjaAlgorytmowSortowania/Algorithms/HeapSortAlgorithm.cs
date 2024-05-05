namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class HeapSortAlgorithm : ISortAlgorithm
    {
        public void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            for (int i = arr.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(i, arr.Count, ref selectedArr);
            }

            for (int i = arr.Count - 1; i >= 0; i--)
            {
                int oldI = arr[i];
                arr[i] = arr[0];
                arr[0] = oldI;

                Heapify(0, i, ref selectedArr);
            }

            selectedArr = new List<int>() { arr.Count - 1 };
            AddHistorySnap();

            void Heapify(int i, int topI, ref List<int> selectedArr)
            {
                int maxI = i;
                int leftChildI = i * 2 + 1;
                int rightChildI = i * 2 + 2;

                localComparisons++;
                if (leftChildI < topI && arr[leftChildI] > arr[maxI])
                {
                    maxI = leftChildI;
                }

                localComparisons++;
                if (rightChildI < topI && arr[rightChildI] > arr[maxI])
                {
                    maxI = rightChildI;
                }

                localComparisons++;
                if (maxI != i)
                {
                    int oldI = arr[i];
                    arr[i] = arr[maxI];
                    arr[maxI] = oldI;

                    selectedArr = new List<int>() { i };
                    AddHistorySnap();
                    Heapify(maxI, topI, ref selectedArr);
                }
            }

            comparisons = localComparisons;
        }
    }
