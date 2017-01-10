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
        double firstValue;
        double secondValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_number_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (string)(sender as Button).Content;

            equation_box.Text = buttonText;
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_CE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_divide_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_multiply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_minus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_plus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_equal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_dot_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_plus_minus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
