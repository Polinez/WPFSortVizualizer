using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WirtualizacjaAlgorytmowSortowania
{

    public partial class VisualizationWindow : Window
    {
        //list of numbers to sort
        List<int> numList = MainWindow.NumbersList;

        //number of comparisons
        int comparisons = 0;

        //bool for the pause button && extra functionallity
        bool isPaused;

        //current array of numbers (the one being shown)
        public int[] arr;

        //currently highlighted indexes
        int[] selectedArr;

        //all sorting steps (arrays of numbers)
        List<int[]> sortHistory;

        //all highlighted indexes during the sorting steps
        List<int[]> selectedHistory;

        //timer that we'll use when drawing the array
        DispatcherTimer timer;

        public VisualizationWindow()
        {
            InitializeComponent();
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //adding the initial array to the history
            arr = new int[numList.Count];
            for (int i = 0; i < numList.Count; i++)
            {
                arr[i] = numList[i];
            }
            //initialize everything
            if (timer != null)
            {
                timer.Stop();
            }
            isPaused = false;
            comparisons = 0;
            selectedHistory = new List<int[]>();
            sortHistory = new List<int[]>();

            switch (AlgBox.SelectedIndex)
            {
                case 0:
                    algName.Text = "Quick Sort";
                    memUsage.Text = "O(log n)";
                    avgComplexity.Text = "O(n log n)";
                    QuickSort(0, arr.Length);
                    DrawHistory();

                    break;
                case 1:
                    algName.Text = "Bubble Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n^2)";
                    BubbleSort();
                    DrawHistory();

                    break;
                case 2:
                    algName.Text = "Insertion Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n^2)";
                    InsertionSort();
                    DrawHistory();

                    break;
                case 3:
                    algName.Text = "Selection Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n^2)";
                    SelectionSort();
                    DrawHistory();

                    break;
                case 4:
                    algName.Text = "Merge Sort";
                    memUsage.Text = "O(n)";
                    avgComplexity.Text = "O(n log n)";
                    MergeSort(0, arr.Length);
                    DrawHistory();

                    break;
                case 5:
                    algName.Text = "Heap Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n log n)";
                    HeapSort();
                    DrawHistory();

                    break;
                default:
                    MessageBox.Show("You need to select an algorithm.");
                    break;
            }
            numCount.Text = numList.Count.ToString();
            numCompersion.Text = comparisons.ToString();



        }

        public void AddHistorySnap()
        {
            int[] historySnap = new int[arr.Length];
            arr.CopyTo(historySnap, 0);
            sortHistory.Add(historySnap);
            selectedHistory.Add(selectedArr);
        }

        void DrawNumbers(int[] arr, int[] selectedHistory)
        {
            canv.Children.Clear();

            int howMany = (int)arr.Length;
            double size = canv.ActualWidth / howMany;

            for (int i = 0; i < howMany; i++)
            {
                Rectangle rect = new Rectangle();
                Canvas.SetLeft(rect, size * i);
                Canvas.SetBottom(rect, 0);
                rect.Width = size;
                rect.Height = (canv.ActualHeight - 5) / arr.Max() * arr[i];
                if (selectedHistory != null && selectedHistory.Contains(i))
                {
                    rect.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    rect.Fill = new SolidColorBrush(Colors.White);
                }
                canv.Children.Add(rect);
            }
        }

        void DrawHistory()
        {
            int counter = 0;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                arr = sortHistory[counter];
                selectedArr = selectedHistory[counter];
                DrawNumbers(sortHistory[counter], selectedHistory[counter]);
                counter++;
                if (counter < sortHistory.Count)
                {
                    timer.Start();
                }
                else
                {
                    isPaused = true;
                    timer = null;

                }
            };
            timer.Start();
        }





        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPaused)
            {
                if (timer != null)
                {
                    timer.Start();
                }
                pauseButton.Content = "Pause";
                isPaused = false;
            }
            else
            {
                if (timer != null)
                {
                    timer.Stop();
                }
                pauseButton.Content = "Play";
                isPaused = true;
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        //Algorytmy
        int[] MergeSort(int startI, int endI)
        {
            int length = endI - startI;
            if (length == 1)
            {

                return new int[] { arr[startI] };
            }
            int[] A = MergeSort(startI, startI + length / 2);
            int[] B = MergeSort(startI + length / 2, endI);
            int[] AB = new int[A.Length + B.Length];
            int iA = 0;
            int iB = 0;

            for (int i = 0; i < AB.Length; i++)
            {


                comparisons++;
                if (iB < B.Length && (iA == A.Length || B[iB] < A[iA]))
                {
                    comparisons++;
                    if (iA != A.Length)
                    {
                        comparisons++;
                    }
                    AB[i] = B[iB];
                    arr[startI + i] = B[iB];
                    iB++;
                }
                else
                {
                    if (iB < B.Length)
                    {
                        comparisons += 2;
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

        void InsertionSort()
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int curr = i;
                while (curr - 1 >= 0 && arr[curr - 1] > arr[curr])
                {


                    comparisons += 2;
                    int oldIValue = arr[curr];
                    arr[curr] = arr[curr - 1];
                    arr[curr - 1] = oldIValue;
                    curr--;
                }

                comparisons++;
                if (curr - 1 >= 0)
                {
                    comparisons++;
                }

                selectedArr = new int[] { curr };
                AddHistorySnap();
            }
        }

        void QuickSort(int startI, int endI)
        {
            comparisons++;
            if (endI - startI < 1)
                return;

            int pI = endI - 1;

            int i = startI;
            int j = startI;

            while (j < endI - 1)
            {
                comparisons++;

                if (arr[j] <= arr[pI])
                {
                    comparisons++;

                    int oldJ = arr[j];
                    arr[j] = arr[i];
                    arr[i] = oldJ;
                    i++;
                    selectedArr = new int[] { j, i };
                    AddHistorySnap();
                }
                j++;
            }
            comparisons++;

            int oldI = arr[i];
            arr[i] = arr[pI];
            arr[pI] = oldI;
            pI = i;


            selectedArr = new int[] { pI, i };
            AddHistorySnap();

            QuickSort(startI, pI);
            QuickSort(pI + 1, endI);
        }

        void BubbleSort()
        {
            for (int i = arr.Length; i >= 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int oldJ = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = oldJ;


                    }
                    comparisons++;
                }
                selectedArr = new int[] { i };
                AddHistorySnap();

            }
        }

        void SelectionSort()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minI = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minI] > arr[j])
                    {
                        minI = j;
                    }

                    comparisons++;
                }
                int oldI = arr[i];
                arr[i] = arr[minI];
                arr[minI] = oldI;

                selectedArr = new int[] { i };
                AddHistorySnap();

            }
        }

        void HeapSort()
        {

            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(i, arr.Length);
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int oldI = arr[i];
                arr[i] = arr[0];
                arr[0] = oldI;

                Heapify(0, i);
            }

            selectedArr = new int[] { arr.Length - 1 };

            AddHistorySnap();

            void Heapify(int i, int topI)
            {
                int maxI = i;
                int leftChildI = i * 2 + 1;
                int rightChildI = i * 2 + 2;

                comparisons++;
                if (leftChildI < topI)
                {

                    comparisons++;
                    if (arr[leftChildI] > arr[maxI])
                        maxI = leftChildI;
                }

                comparisons++;
                if (rightChildI < topI)
                {

                    comparisons++;
                    if (arr[rightChildI] > arr[maxI])
                        maxI = rightChildI;
                }

                comparisons++;
                if (maxI != i)
                {
                    int oldI = arr[i];
                    arr[i] = arr[maxI];
                    arr[maxI] = oldI;



                    selectedArr = new int[] { i };
                    AddHistorySnap();
                    Heapify(maxI, topI);
                }
            }
        }



    }
}
