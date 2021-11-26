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
using System.Text.RegularExpressions;

namespace sortowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool locked = false;
        List<int> d = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            buttonSort.Click += sort;
            buttonLoad.Click += loadFile;
            textBoxInput.TextChanged += updateDisplay;
            textBoxInputIter.TextChanged += TextBoxInputIter_TextChanged;

            updateDisplay(null,null);

        }

        private void TextBoxInputIter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(textBoxInputIter.Text, out _) )
            {
                textBoxInputIter.Background = Brushes.Red;
                locked = true;
                return;
            }
            if (int.Parse(textBoxInputIter.Text) <= 0)
            {
                textBoxInputIter.Background = Brushes.Red;
                locked = true;
                return;
            }
            locked = false;
            textBoxInputIter.Background = null;
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
            TimeSpan min_time = new TimeSpan(0), time_sum = new TimeSpan(0), max_time = new TimeSpan(0);
            if (locked)
                return;

            for(int i = 0; i < int.Parse(textBoxInputIter.Text); i++)
            {
                DateTime START = DateTime.Now;
                switch (sortSelect.SelectedIndex)
                {
                    case 0:
                        d = sorting.quick(d);
                        break;
                    case 1:
                        d = sorting.bubble(d);
                        break;
                    case 2:
                        d = sorting.inserting(d);
                        break;
                    case 3:
                        d = sorting.heapSort(d, d.Count);
                        break;
                    case 4:
                        d = sorting.MergeSort(d, 0, d.Count);
                        break;
                }
                TimeSpan timeDiff = DateTime.Now - START;

                if(timeDiff < min_time || min_time == new TimeSpan(0))
                {
                    min_time = timeDiff;
                    minTime.Content = min_time.ToString();
                }

                if (timeDiff > max_time || max_time == new TimeSpan(0))
                {
                    max_time = timeDiff;
                    maxTime.Content = max_time.ToString();
                }

                time_sum += timeDiff;

            }
            avgTime.Content = (time_sum / int.Parse(textBoxInputIter.Text)).ToString();



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
                    locked = true;
                    return;
                }
                locked = false;
                
                d.Add(int.Parse(letter));
            }
            textBoxInput.Background = null;

        }
    }
}
