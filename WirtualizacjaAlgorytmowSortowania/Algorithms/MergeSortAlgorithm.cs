namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class MergeSortAlgorithm : ISortAlgorithm
    {
        public void Sort(List<int> arr, ref int comparisons, ref List<int> selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            MergeSort(0, arr.Count, ref selectedArr);

            List<int> MergeSort(int startI, int endI, ref List<int> selectedArr)
            {
                int length = endI - startI;
                if (length == 1)
                {
                    selectedArr = new List<int>() { startI };
                    AddHistorySnap();
                    return new List<int>() { arr[startI] };
                }
                List<int> A = MergeSort(startI, startI + length / 2, ref selectedArr);
                List<int> B = MergeSort(startI + length / 2, endI, ref selectedArr);
                List<int> AB = new List<int>(A.Count + B.Count);
                int iA = 0;
                int iB = 0;

                for (int i = 0; i < A.Count + B.Count; i++)
                {
                    localComparisons++;
                    if (iB < B.Count && (iA == A.Count || B[iB] < A[iA]))
                    {
                        localComparisons++;
                        if (iA != A.Count)
                        {
                            localComparisons++;
                        }
                        AB.Add(B[iB]);
                        arr[startI + i] = B[iB];
                        iB++;
                    }
                    else
                    {
                        if (iB < B.Count)
                        {
                            localComparisons += 2;
                        }
                        AB.Add(A[iA]);
                        arr[startI + i] = A[iA];
                        iA++;
                    }
                    selectedArr = new List<int>() { startI + i };
                    AddHistorySnap();
                }

                return AB;
            }

            comparisons = localComparisons;
        }

    }
}
