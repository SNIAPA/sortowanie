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
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
namespace sortowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> d = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            buttonSort.Click += sort;
            buttonLoad.Click += loadFile;
            textBoxInput.TextChanged += updateDisplay;

            updateDisplay(null,null);

        }

        private void loadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            if(fileDialog.FileName.Length > 0)
                textBoxInput.Text = File.ReadAllText(fileDialog.FileName);
            
            

        }


        private void sort(object sender, RoutedEventArgs e)
        {
            DateTime START = DateTime.Now;
            d = sorting.quick(d);
            timeDiff.Content = (DateTime.Now - START);

            string ans = "";
            foreach(int num in d)
            {
                Debug.WriteLine(num);
                ans += num.ToString()+" ";
            }

            textBoxInput.Text = ans;
            
        }


        private void updateDisplay(object sender, RoutedEventArgs e)
        {
            string input = textBoxInput.Text;

            d = new List<int>();

            foreach (string letter in input.Trim().Split(" "))
            {
                if (letter == null)
                    continue;


                if (!int.TryParse(letter, out _))
                {
                    textBoxInput.Background = Brushes.Red;

                    return;
                }
                
                d.Add(int.Parse(letter));
            }
            textBoxInput.Background = null;

        }
    }
}
