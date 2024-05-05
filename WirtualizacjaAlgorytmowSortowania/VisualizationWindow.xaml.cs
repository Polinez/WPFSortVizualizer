using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using WirtualizacjaAlgorytmowSortowania.Algorithms;

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


            ISortAlgorithm algorithm=null;
            switch (AlgBox.SelectedIndex)
            {
                case 0:
                    algName.Text = "Quick Sort";
                    memUsage.Text = "O(log n)";
                    avgComplexity.Text = "O(n log n)";
                    algorithm = new QuickSortAlgorithm();
                    break;
                case 1:
                    algName.Text = "Bubble Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n^2)";
                    algorithm=new BubbleSortAlgorithm();
                    break;
                case 2:
                    algName.Text = "Insertion Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n^2)";
                    algorithm=new InsertionSortAlgorithm();
                    break;
                case 3:
                    algName.Text = "Selection Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n^2)";
                    algorithm = new SelectionSortAlgorithm();
                    break;
                case 4:
                    algName.Text = "Merge Sort";
                    memUsage.Text = "O(n)";
                    avgComplexity.Text = "O(n log n)";
                    algorithm = new MergeSortAlgorithm();
                    break;
                case 5:
                    algName.Text = "Heap Sort";
                    memUsage.Text = "O(1)";
                    avgComplexity.Text = "O(n log n)";
                    algorithm = new HeapSortAlgorithm();
                    break;
                default:
                    MessageBox.Show("You need to select an algorithm.");
                    break;
            }

            algorithm.Sort(arr, ref comparisons, ref selectedArr, AddHistorySnap, DrawHistory);
            DrawHistory();
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

    }
}
