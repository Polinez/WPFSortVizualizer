using System.Windows;
using System.Windows.Threading;

namespace WirtualizacjaAlgorytmowSortowania
{
    public partial class VisualizationWindow : Window
    {
        private List<float> numList = MainWindow.numbersList;

        private DispatcherTimer[] timers = new DispatcherTimer[9];
        private TimeSpan[] elapsedTimes = new TimeSpan[9];
        private bool[] isTimerRunning = new bool[9];
        public VisualizationWindow()
        {
            InitializeComponent();
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            for (int i = 0; i < timers.Length; i++)
            {
                timers[i] = new DispatcherTimer();
                timers[i].Interval = TimeSpan.FromSeconds(1);
                int index = i; // Capturing the index variable for the lambda expression
                timers[i].Tick += Timer_Tick;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // We need to find out which timer called this method
            DispatcherTimer timer = (DispatcherTimer)sender;
            int timerIndex = Array.IndexOf(timers, timer);

            if (isTimerRunning[timerIndex])
            {
                elapsedTimes[timerIndex] = elapsedTimes[timerIndex].Add(TimeSpan.FromSeconds(1));
                UpdateTimerText(timerIndex);
            }
        }

        private void UpdateTimerText(int timerIndex)
        {
            TimeSpan time = elapsedTimes[timerIndex];
            string formattedTime = time.ToString(@"hh\:mm\:ss");

            switch (timerIndex)
            {
                case 0:
                    timerBubble.Content = formattedTime;
                    break;
                case 1:
                    timerInsertion.Content = formattedTime;
                    break;
                case 2:
                    timerSelection.Content = formattedTime;
                    break;
                case 3:
                    timerMerge.Content = formattedTime;
                    break;
                case 4:
                    timerQuick.Content = formattedTime;
                    break;
                case 5:
                    timerHeap.Content = formattedTime;
                    break;
                case 6:
                    timerBucket.Content = formattedTime;
                    break;
                case 7:
                    timerCounting.Content = formattedTime;
                    break;
                case 8:
                    timerRadix.Content = formattedTime;
                    break;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < timers.Length; i++)
            {
                isTimerRunning[i] = true;
                timers[i].Start();
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < timers.Length; i++)
            {
                isTimerRunning[i] = false;
                timers[i].Stop();
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
