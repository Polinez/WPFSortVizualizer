namespace WirtualizacjaAlgorytmowSortowania.Algorithms
{
    internal class MergeSortAlgorithm : ISortAlgorithm
    {
        public void Sort(int[] arr, ref int comparisons, ref int[] selectedArr, Action AddHistorySnap, Action DrawHistory)
        {
            int localComparisons = comparisons;

            MergeSort(0, arr.Length, ref selectedArr);

            int[] MergeSort(int startI, int endI, ref int[] selectedArr)
            {
                int length = endI - startI;
                if (length == 1)
                {
                    selectedArr = new int[] { startI };
                    AddHistorySnap();
                    return new int[] { arr[startI] };
                }
                int[] A = MergeSort(startI, startI + length / 2, ref selectedArr);
                int[] B = MergeSort(startI + length / 2, endI, ref selectedArr);
                int[] AB = new int[A.Length + B.Length];
                int iA = 0;
                int iB = 0;

                for (int i = 0; i < AB.Length; i++)
                {
                    localComparisons++;
                    if (iB < B.Length && (iA == A.Length || B[iB] < A[iA]))
                    {
                        localComparisons++;
                        if (iA != A.Length)
                        {
                            localComparisons++;
                        }
                        AB[i] = B[iB];
                        arr[startI + i] = B[iB];
                        iB++;
                    }
                    else
                    {
                        if (iB < B.Length)
                        {
                            localComparisons += 2;
                        }
                        AB[i] = A[iA];
                        arr[startI + i] = A[iA];
                        iA++;
                    }
                    selectedArr = new int[] { startI + i };
                    AddHistorySnap();
                }

                return AB;
            }

            comparisons = localComparisons; // Aktualizacja wartości comparisons po zakończeniu sortowania
        }

    }
}