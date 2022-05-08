using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Linq;

namespace LAB1_4sem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ChosenSymbol { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            plus.IsEnabled = false;
            minus.IsEnabled = false;
            mnozenie.IsEnabled = false;
            dzielenie.IsEnabled = false;
            click_dot.IsEnabled = false;
            rowna_sie.IsEnabled = false;

        }

        private float calculate_result(string symbol)
        {

            rowna_sie.IsEnabled = true;
            float result = 0;
            string leftNumber = text_box.Text.Split(symbol)[0];
            string rightNumber = text_box.Text.Split(symbol)[1];

            float trueLeftNumber = float.Parse(leftNumber);
            float trueRightNumber = float.Parse(rightNumber);
            if (symbol == "/")
            {
               result = trueLeftNumber / trueRightNumber;   
            }
            if (symbol == "+")
            {
                result = trueLeftNumber + trueRightNumber;
            }
            if (symbol == "-")
            {
                result = trueLeftNumber - trueRightNumber;
            }
            if (symbol == "*")
            {
                result = trueLeftNumber * trueRightNumber;
            }


            return result;
        }

        private void button_rowna_sie(object sender, RoutedEventArgs e)
        {

            float result = calculate_result(ChosenSymbol);

            text_box.Text = result.ToString();
            plus.IsEnabled = true;
            minus.IsEnabled = true;
            mnozenie.IsEnabled = true;
            dzielenie.IsEnabled = true;
            rowna_sie.IsEnabled = false;
            click_dot.IsEnabled = true;
            if (text_box.Text.Contains(","))
            {
                click_dot.IsEnabled = false;
            }
            if (float.IsInfinity(result))
            {
                text_box.Text = "Liczba poza zakresem";
                plus.IsEnabled = false;
                minus.IsEnabled = false;
                mnozenie.IsEnabled = false;
                dzielenie.IsEnabled = false;
                click_dot.IsEnabled = false;
                rowna_sie.IsEnabled = false;
                click_0.IsEnabled = false;
                click_1.IsEnabled = false;
                click_2.IsEnabled = false;
                click_3.IsEnabled = false;
                click_4.IsEnabled = false;
                click_5.IsEnabled = false;
                click_6.IsEnabled = false;
                click_7.IsEnabled = false;
                click_8.IsEnabled = false;
                click_9.IsEnabled = false;
            }
        }

        private void button_dzialanie(object sender, RoutedEventArgs e)
        {

            var symbol = sender as Button;
            ChosenSymbol = symbol.Content.ToString();


            text_box.Text += symbol.Content.ToString();
            plus.IsEnabled = false;
            minus.IsEnabled = false;
            mnozenie.IsEnabled = false;
            dzielenie.IsEnabled = false;
            click_dot.IsEnabled = false;
            rowna_sie.IsEnabled = false;

        }

        private void digit_button_click(object sender, RoutedEventArgs e)
        {
            plus.IsEnabled = true;
            minus.IsEnabled = true;
            mnozenie.IsEnabled = true;
            dzielenie.IsEnabled = true;
            click_dot.IsEnabled = true;
            var actions = new[] { "+", "-", "*", "/" };
            var numbers = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


            foreach (string action in actions)
            {
                if (text_box.Text.Contains(action))
                {
                    plus.IsEnabled = false;
                    minus.IsEnabled = false;
                    mnozenie.IsEnabled = false;
                    dzielenie.IsEnabled = false;
                    click_dot.IsEnabled = true;
                }
            }




            var tenmp = ChosenSymbol;
            var butt = sender as Button;

            text_box.Text += butt.Content.ToString();
            rowna_sie.IsEnabled = false;
            //var actions = new[] { "+", "-", "*", "/" };
            foreach (string action in actions)
            {
                if (text_box.Text.Contains(action))
                {

                    if (char.IsDigit(text_box.Text.Last()))
                    {
                        rowna_sie.IsEnabled = true;
                        click_dot.IsEnabled = true;
                    }

                }
            }
            if (text_box.Text.Contains(","))
            {
                foreach (string action in actions)
                {
                    if (text_box.Text.Contains(action))
                    {
                        rowna_sie.IsEnabled = true;
                        plus.IsEnabled = false;
                        minus.IsEnabled = false;
                        mnozenie.IsEnabled = false;
                        dzielenie.IsEnabled = false;
                    }
                }
                plus.IsEnabled = true;
                minus.IsEnabled = true;
                mnozenie.IsEnabled = true;
                dzielenie.IsEnabled = true;
                click_dot.IsEnabled = false;
                //var numbers = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                foreach (string number in numbers)
                {

                    if (text_box.Text.EndsWith(number))
                    {

                        foreach (string action in actions)
                        {
                            if (text_box.Text.Contains(action))
                            {
                                plus.IsEnabled = false;
                                minus.IsEnabled = false;
                                mnozenie.IsEnabled = false;
                                dzielenie.IsEnabled = false;
                                click_dot.IsEnabled = true;
                            }
                        }

                    }
                }

                foreach (string number in numbers)
                {
                    if (text_box.Text.EndsWith(number))
                    {
                        foreach (string action in actions)
                        {
                            if (text_box.Text.Contains(action))
                            {
                                string right = text_box.Text.Split(ChosenSymbol)[1];
                                if (right.Contains(","))
                                {
                                    click_dot.IsEnabled = false;
                                }

                            }
                        }

                    }
                }
            }

            if (ChosenSymbol == "/")
            {

                string[] splitted = text_box.Text.Split('/');
                if (splitted.Length > 1)
                {
                    if (float.TryParse(splitted[1], out float number))
                    {
                        if (number == 0)
                        {
                            rowna_sie.IsEnabled = false;
                        }

                    }
                }
            }
        }

        private void button_dot(object sender, RoutedEventArgs e)
        {
            var dot = sender as Button;
            text_box.Text += dot.Content.ToString();
            click_dot.IsEnabled = false;
            plus.IsEnabled = false;
            minus.IsEnabled = false;
            mnozenie.IsEnabled = false;
            dzielenie.IsEnabled = false;
            rowna_sie.IsEnabled = false;
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {

            text_box.Text = "";
            plus.IsEnabled = false;
            minus.IsEnabled = false;
            mnozenie.IsEnabled = false;
            dzielenie.IsEnabled = false;
            click_dot.IsEnabled = false;
            rowna_sie.IsEnabled = false;
            click_0.IsEnabled = true;
            click_1.IsEnabled = true;
            click_2.IsEnabled = true;
            click_3.IsEnabled = true;
            click_4.IsEnabled = true;
            click_5.IsEnabled = true;
            click_6.IsEnabled = true;
            click_7.IsEnabled = true;
            click_8.IsEnabled = true;
            click_9.IsEnabled = true;
        }
    }
}
