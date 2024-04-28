using System.Windows;

namespace WirtualizacjaAlgorytmowSortowania
{
    public partial class VisualizationWindow : Window
    {
        private List<int> numList = MainWindow.NumbersList;
        public VisualizationWindow()
        {
            InitializeComponent();


        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            switch (AlgBox.SelectedIndex)
            {

                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    MessageBox.Show("You need to select an algorithm.");
                    break;
            }
            numCount.Text = MainWindow.numSliderValue.ToString();

        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Sorting stopped.");
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
