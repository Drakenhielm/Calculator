using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool onFirstValue = true;
        bool eraseValue = false;
        double firstValue = 0;
        double secondValue = 0;
        int fistValueNumOfDecimals = 0;
        int secondValueNumOfDecimals = 0;
        string _operator;

        public MainWindow()
        {
            InitializeComponent();
            value_box.Text = "0";
        }

        private void button_number_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (string)(sender as Button).Content;
            int buttonNumber = Int32.Parse(buttonText);

            if (value_box.Text == "0")
            {
                value_box.Text = "";
            }

            if (onFirstValue)
            {
                if (eraseValue)
                {
                    eraseValue = false;
                    firstValue = 0;
                    _operator = "";
                    value_box.Text = "";
                    fistValueNumOfDecimals = 0;
                }

                if (fistValueNumOfDecimals != 0)
                {
                    firstValue += (double)buttonNumber / Math.Pow(10, fistValueNumOfDecimals);
                    fistValueNumOfDecimals++;
                }
                else
                {
                    firstValue = firstValue * 10 + buttonNumber;
                }
                value_box.Text += buttonText;
            }
            else
            {
                if (eraseValue)
                {
                    eraseValue = false;
                    secondValue = 0;
                    secondValueNumOfDecimals = 0;
                    value_box.Text = "";
                }

                if (secondValueNumOfDecimals != 0)
                {
                    secondValue += (double)buttonNumber / Math.Pow(10, secondValueNumOfDecimals);
                    secondValueNumOfDecimals++;
                }
                else
                {
                    secondValue = secondValue * 10 + buttonNumber;
                }
                value_box.Text += buttonText;

            }
        }

        private void button_operator_Click(object sender, RoutedEventArgs e)
        {
            _operator = (string)(sender as Button).Content;
            if (onFirstValue)
            {
                eraseValue = true;
                secondValue = firstValue;
                onFirstValue = false;
            }
            equation_box.Text = firstValue + " " + _operator;
        }

        private void button_CE_Click(object sender, RoutedEventArgs e)
        {
            if (onFirstValue)
            {
                firstValue = 0;
                fistValueNumOfDecimals = 0;
            }
            else
            {
                secondValue = 0;
                secondValueNumOfDecimals = 0;
            }
            value_box.Text = "0";
        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            onFirstValue = true;
            firstValue = 0;
            secondValue = 0;
            fistValueNumOfDecimals = 0;
            secondValueNumOfDecimals = 0;
            _operator = "";
            value_box.Text = "0";
            equation_box.Text = "";
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            if (!eraseValue)
            {
                string text = value_box.Text;

                double tempValue;
                bool isDouble = double.TryParse(text, out tempValue);
                if (text != "0" || isDouble)
                {
                    text = text.Remove(text.Length - 1);

                    if (text == "")
                    {
                        text = "0";
                    }

                    if (onFirstValue)
                    {
                        if (fistValueNumOfDecimals != 0)
                        {
                            fistValueNumOfDecimals--;
                        }
                        firstValue = double.Parse(text);
                    }
                    else
                    {
                        if (secondValueNumOfDecimals != 0)
                        {
                            secondValueNumOfDecimals--;
                        }
                        secondValue = double.Parse(text);
                    }
                    value_box.Text = text;
                }
            }
        }

        private void button_equal_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;

            switch (_operator)
            {
                case "/":
                    if (secondValue == 0)
                    {
                        value_box.Text = "Division with zero is not allowed!";
                        onFirstValue = true;
                    }
                    else
                    {
                        result = firstValue / secondValue;
                        value_box.Text = "" + result;
                    }
                    eraseValue = true;
                    break;
                case "*":
                    result = firstValue * secondValue;
                    eraseValue = true;
                    value_box.Text = "" + result;
                    break;
                case "+":
                    result = firstValue + secondValue;
                    eraseValue = true;
                    value_box.Text = "" + result;
                    break;
                case "-":
                    result = firstValue - secondValue;
                    eraseValue = true;
                    value_box.Text = "" + result;
                    break;
                default:
                    result = firstValue;
                    value_box.Text = "" + result;
                    break;
            }

            firstValue = result;
            equation_box.Text = "";
            onFirstValue = true;
        }

        private void button_dot_Click(object sender, RoutedEventArgs e)
        {

            if (onFirstValue)
            {
                if (eraseValue)
                {
                    eraseValue = false;
                    firstValue = 0;
                    value_box.Text = "0";
                    fistValueNumOfDecimals = 0;
                }

                if (fistValueNumOfDecimals == 0)
                {
                    fistValueNumOfDecimals = 1;
                    value_box.Text += ",";
                }
            }
            else
            {

                if (eraseValue)
                {
                    eraseValue = false;
                    secondValue = 0;
                    value_box.Text = "0";
                    secondValueNumOfDecimals = 0;
                }

                if (secondValueNumOfDecimals == 0)
                {
                    secondValueNumOfDecimals = 1;
                    value_box.Text += ",";
                }
            }
        }

        private void button_plus_minus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
