using System.Windows;
using System.Windows.Input;

namespace WirtualizacjaAlgorytmowSortowania
{
    public partial class MainWindow : Window
    {
        public static List<int> NumbersList { get; set; }
        public static int numSliderValue { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                numSliderValue = (int)numSlider.Value;
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
            if (!string.IsNullOrEmpty(numbersString.Text))
            {
                string NumText = numbersString.Text;
                NumText.Trim(',', ' ');
                string[] numbersTab = NumText.Split(',', ' ');
                if (numbersTab.Length < 2)
                {
                    throw new Exception("No numbers to sort, it neet to be more than 1 number");
                }

                NumbersList = new List<int>();
                for (int i = 0; i < numbersTab.Length; i++)
                {
                    if (int.TryParse(numbersTab[i], out int number))
                    {
                        NumbersList.Add(number);
                    }
                    else
                    {
                        throw new FormatException("Invalid number format");
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                NumbersList = new List<int>();
                for (int i = 0; i < (int)numSlider.Value; i++)
                {
                    NumbersList.Add(rnd.Next(0, 100));
                }
            }
        }


    }
}