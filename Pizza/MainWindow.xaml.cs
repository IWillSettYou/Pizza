using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
        private List<string> order = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string value)
            {
                order.Add(radioButton.Name);
                sum += Convert.ToInt32(value);
                UpdateSum(sender, e);
            }
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Tag is string value)
            {
                order.Remove(radioButton.Name);
                sum -= Convert.ToInt32(value);
                UpdateSum(sender, e);
            } 
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkbox && checkbox.Tag is string value)
            {
                order.Add(checkbox.Name);
                sum += Convert.ToInt32(value);
                UpdateSum(sender, e);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkbox && checkbox.Tag is string value)
            {
                order.Remove(checkbox.Name);
                sum -= Convert.ToInt32(value);
                UpdateSum(sender, e);
            }
        }

        private async void Order_Submitted(object sender, RoutedEventArgs e)
        {
            order.Add(sum.ToString());
            string folderPath = @"..\..\order\";
            string filePath = System.IO.Path.Combine(folderPath, "order.csv");

            try
            {
                // Write list to CSV file
               WriteListToCsv(order, filePath);

                MessageBox.Show("CSV file saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void WriteListToCsv(List<string> stringList, string filePath)
        {
            
            StringBuilder csvContent = new StringBuilder();

            
            foreach (string item in stringList)
            {
                csvContent.AppendLine(item);
            }

            
            File.WriteAllText(filePath, csvContent.ToString());
        }
            private void UpdateSum(object sender, RoutedEventArgs e)
        {
            // Update sum 

            sumTextBlock.Text = $"Végösszeg: {sum}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
