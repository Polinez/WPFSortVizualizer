using System.Windows;


namespace WirtualizacjaAlgorytmowSortowania
{
    public partial class VisualizationWindow : Window
    {

        public VisualizationWindow()
        {
            InitializeComponent();


        }



        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
