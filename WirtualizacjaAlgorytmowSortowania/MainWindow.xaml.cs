using System.Windows;
using System.Windows.Input;

namespace WirtualizacjaAlgorytmowSortowania
{
    public partial class MainWindow : Window
    {
        public static List<float> numbersList { get; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddToList();
            }
            catch (FormatException FEx)
            {
                MessageBox.Show(FEx.Message);
                return;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }


            VisualizationWindow visualizationWindow = new VisualizationWindow();
            this.Close();
            visualizationWindow.Show();

        }

        private void EnterDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSort_Click(sender, e);
            }
        }

        public void AddToList()
        {
            string NumText = numbersString.Text;
            NumText.Trim(',', ' ');
            string[] numbersTab = NumText.Split(',', ' ');
            if (numbersTab.Length < 2)
            {
                throw new Exception("No numbers to sort, it neet to be more than 1 number");
            }

            numbersList = new List<float>();
            foreach (string num in numbersTab)
            {
                if (float.TryParse(num, out float number))
                {
                    numbersList.Add(number);
                }
                else
                {
                    throw new FormatException("Invalid number format");
                }
            }

        }

    }
}