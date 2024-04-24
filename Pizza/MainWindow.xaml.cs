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

namespace Pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int sum = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string value)
            {
                sum += Convert.ToInt32(value);
                UpdateSum(sender, e);
            }
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string value)
            {
                sum -= Convert.ToInt32(value);
                UpdateSum(sender, e);
            } 
        }

        private void UpdateSum(object sender, RoutedEventArgs e)
        {
            // Update sum display or perform any other action
            sumTextBlock.Text = $"Végösszeg: {sum}";
        }

    }
}
