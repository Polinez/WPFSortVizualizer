namespace WirtualizacjaAlgorytmowSortowania
{
    public class Algorytms
    {
        public List<float> BubbleSort(List<float> arr) // bubble sort
        {
            List<float> BubbleList = arr;
            var n = BubbleList.Count;
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

        public static List<float> MergeSort(List<float> arr) //merge sort 
        {
            if (arr.Count <= 1)
                return arr;

            int middle = arr.Count / 2;
            List<float> left = new List<float>(arr.GetRange(0, middle));
            List<float> right = new List<float>(arr.GetRange(middle, arr.Count - middle));

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static List<float> Merge(List<float> left, List<float> right)
        {
            List<float> result = new List<float>();

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

        public static List<float> BucketSort(List<float> arr) //bucket sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            List<float>[] buckets = new List<float>[n];

            // Inicjalizacja kubełków
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<float>();
            }

            // Rozłożenie elementów do odpowiednich kubełków
            foreach (float num in arr)
            {
                int bucketIndex = (int)(num * n);
                buckets[bucketIndex].Add(num);
            }

            // Sortowanie kubełków i scalanie ich
            List<float> sortedList = new List<float>();
            foreach (List<float> bucket in buckets)
            {
                bucket.Sort();
                sortedList.AddRange(bucket);
            }

            return sortedList;
        }

        public static List<float> InsertionSort(List<float> arr)//insertion sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            for (int i = 1; i < n; i++)
            {
                float key = arr[i];
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

        public static void QuickSort(List<float> arr, int low, int high)//quick sort
        {
            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high);

                QuickSort(arr, low, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, high);
            }
        }

        public static int Partition(List<float> arr, int low, int high)
        {
            float pivot = arr[high];
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

        public static void Swap(List<float> arr, int i, int j)
        {
            float temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


        public static List<float> CountingSort(List<float> arr)//counting sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            // Znajdowanie wartości maksymalnej i minimalnej
            float maxVal = arr[0];
            float minVal = arr[0];
            foreach (float num in arr)
            {
                if (num > maxVal)
                    maxVal = num;
                if (num < minVal)
                    minVal = num;
            }

            // Inicjalizacja tablicy pomocniczej
            int range = (int)(maxVal - minVal) + 1;
            int[] count = new int[range];

            // Zliczanie wystąpień każdej wartości
            foreach (float num in arr)
            {
                count[(int)(num - minVal)]++;
            }

            // Odtwarzanie posortowanej listy
            List<float> sortedList = new List<float>();
            for (int i = 0; i < range; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    sortedList.Add(i + minVal);
                }
            }

            return sortedList;
        }

        public static List<float> SelectionSort(List<float> arr)//selection sort
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
                    float temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            return arr;
        }

        public static List<float> HeapSort(List<float> arr)//heap sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            BuildMaxHeap(arr, n);

            for (int i = n - 1; i > 0; i--)
            {
                float temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                MaxHeapify(arr, i, 0);
            }

            return arr;
        }

        public static void BuildMaxHeap(List<float> arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, n, i);
            }
        }

        public static void MaxHeapify(List<float> arr, int n, int i)
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
                float temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                MaxHeapify(arr, n, largest);
            }
        }

        public static List<float> RadixSort(List<float> arr)//radix sort
        {
            int n = arr.Count;
            if (n <= 1)
                return arr;

            // Konwertowanie liczb zmiennoprzecinkowych na ciągi znaków
            List<string> strList = new List<string>();
            foreach (float num in arr)
            {
                strList.Add(num.ToString());
            }

            // Ustalanie maksymalnej długości ciągu znaków
            int maxLength = 0;
            foreach (string str in strList)
            {
                maxLength = Math.Max(maxLength, str.Length);
            }

            // Wypełnianie krótszych ciągów zerami
            foreach (string str in strList)
            {
                while (str.Length < maxLength)
                {
                    strList[strList.IndexOf(str)] = "0" + str;
                }
            }

            // Sortowanie po kolejnych cyfrach w każdej pozycji
            for (int i = maxLength - 1; i >= 0; i--)
            {
                CountingSortByDigit(strList, i);
            }

            // Konwertowanie z powrotem na liczby zmiennoprzecinkowe
            List<float> sortedList = new List<float>();
            foreach (string str in strList)
            {
                sortedList.Add(float.Parse(str));
            }

            return sortedList;
        }

        public static void CountingSortByDigit(List<string> arr, int digitIndex)
        {
            int range = 10; // Cyfry od 0 do 9
            int n = arr.Count;

            // Inicjalizacja tablicy pomocniczej
            List<string>[] count = new List<string>[range];
            for (int i = 0; i < range; i++)
            {
                count[i] = new List<string>();
            }

            // Zliczanie wystąpień każdej cyfry
            foreach (string str in arr)
            {
                int digit = str[digitIndex] - '0';
                count[digit].Add(str);
            }

            // Odtwarzanie posortowanej listy
            List<string> sortedList = new List<string>();
            foreach (List<string> bucket in count)
            {
                sortedList.AddRange(bucket);
            }

            // Aktualizacja oryginalnej listy
            for (int i = 0; i < n; i++)
            {
                arr[i] = sortedList[i];
            }
        }

    }
}
