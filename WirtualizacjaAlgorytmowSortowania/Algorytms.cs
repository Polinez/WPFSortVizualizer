namespace WirtualizacjaAlgorytmowSortowania
{
    public static class Algorytms
    {


        public static List<int> BubbleSort(List<int> arr) // bubble sort
        {
            List<int> BubbleList = arr;
            int n = BubbleList.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (BubbleList[j] > BubbleList[j + 1])
                    {
                        var tempVar = BubbleList[j];
                        BubbleList[j] = BubbleList[j + 1];
                        BubbleList[j + 1] = tempVar;
                    }
            return BubbleList;

        }

        public static List<int> MergeSort(List<int> arr) //merge sort 
        {
            if (arr.Count <= 1)
                return arr;

            int middle = arr.Count / 2;
            List<int> left = new List<int>(arr.GetRange(0, middle));
            List<int> right = new List<int>(arr.GetRange(middle, arr.Count - middle));

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }



        public static List<int> InsertionSort(List<int> arr)//insertion sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = key;
            }

            return arr;
        }

        public static void QuickSort(List<int> arr, int low, int high)//quick sort
        {

            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high);

                QuickSort(arr, low, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, high);
            }
        }

        public static int Partition(List<int> arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);

            return i + 1;
        }

        public static void Swap(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }




        public static List<int> SelectionSort(List<int> arr)//selection sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            return arr;
        }

        public static List<int> HeapSort(List<int> arr)//heap sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            BuildMaxHeap(arr, n);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                MaxHeapify(arr, i, 0);
            }

            return arr;
        }

        public static void BuildMaxHeap(List<int> arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, n, i);
            }
        }

        public static void MaxHeapify(List<int> arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                MaxHeapify(arr, n, largest);
            }
        }



    }
}
