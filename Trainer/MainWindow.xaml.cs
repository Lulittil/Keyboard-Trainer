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
using System.Threading;

namespace Trainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string nachstr = "awds dwadgtrhu thhfh sed\n";
        string tempstyle;
        //var tempstyle;
        Style tempstylee;
        int kolvoprav;

        private int oshibki;

        public MainWindow()
        {
            InitializeComponent();
            //amp.Content = "&";
            this.KeyDown += MainWindow_KeyDown;

            stri.Text = nachstr;
            stri.IsReadOnly = true;
            game.IsReadOnly = true;
            stop.IsEnabled = false;
        }

        //private bool checkkey(KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Tab ||
        //        e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.RightShift 
        //        || e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl || e.Key == Key.System ||
        //        e.Key == Key.Oem1 || e.Key == Key.LWin || e.Key == Key.RWin|| e.Key == Key.Oem3||
        //        e.Key == Key.OemMinus|| e.Key == Key.OemPlus|| e.Key == Key.OemOpenBrackets||e.Key == Key.Oem5 
        //        || e.Key == Key.Oem6 || e.Key == Key.OemQuotes || e.Key == Key.OemComma || e.Key == Key.OemPeriod 
        //        || e.Key == Key.OemQuestion|| e.Key == Key.Space)
        //    {
        //        return false;
        //    }
        //    else return true;
        //}


        private bool checkback(KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.System)
            {
                return false;
            }
            return true;
        }

        private void checkText()
        {
            List<char> first = new List<char>();
            List<char> second = new List<char>();
            char[] b = stri.Text.ToCharArray();
            char[] a = game.Text.ToCharArray();
            //tempforfirst = game.Text;
            //tempforsecond = stri.Text;
            try
            {
                for (int i = 0; i < stri.Text.Length; i++)
                {
                    first.Add(b[i]);
                    second.Add(a[i]);
                    if (b[i] != a[i])
                    {
                        oshibki += 1;
                        Mark.Content = $"Marks: {oshibki}";
                        game.Foreground = Brushes.Red;
                    }
                    else
                    {
                        kolvoprav=i+1;
                        Kolvoprav.Content = $"Checks: {kolvoprav}";
                        game.Foreground = Brushes.Black;

                    }
                }
            }
            catch
            {

            }

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                game.Text += " ";
            }

            else if (e.Key == Key.Back )
            {
                
                    int x1 = game.Text.Length - 1;
                    game.Text = game.Text.Remove(x1);
                    Thread.Sleep(20);
                
                
                
            }
            else if (e.Key == Key.Enter)
            {
                if (start.IsEnabled == true)
                    startt();
                else endgame();
            }
            else
            {
                foreach (Button button in maGrid.Children)
                {
                    tempstylee = button.Style;
                    try
                    {
                        if (button.Name == e.Key.ToString() && checkback(e))
                        {
                            //MessageBox.Show("das");
                            button.Style = this.FindResource("pressKey") as Style;
                            game.Text += button.Content;
                            checkText();

                            return;
                        }
                        //MessageBox.Show(Convert.ToString(tempstyle));

                    }
                    catch
                    {
                        continue;
                    }
                    //button.Style= this.FindResource(tempstyle) as Style;
                }
            }

            ////MessageBox.Show(e.Key.ToString());
            //if (start.IsEnabled == false&&checkkey(e))
            //{
            //    game.Text +=e.Key.ToString();
            //}
            //else
            //{
            //    if(e.Key == Key.Enter)
            //    {
            //        game.Text = "";
            //        start.IsEnabled = true;
            //        stop.IsEnabled = false;
            //    }
            //    else if(e.Key == Key.Back)
            //    {
            //        int x1 =game.Text.Length - 1;
            //        game.Text = game.Text.Remove(x1);
            //    }
            //    else if (e.Key == Key.Space)
            //    {
            //        game.Text += " ";
            //    }
            //    else if (e.Key == Key.LeftShift)
            //    {

            //    }
            //}


        }

        private void startt()
        {
            start.IsEnabled = false;
            stop.IsEnabled = true;
            Tab.IsEnabled = false;
            Capital.IsEnabled = false;
            RightShift.IsEnabled = false;
            Sys0.IsEnabled = false;
            Sys1.IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//start
        {
            startt();
        }

        private void endgame()
        {
            game.Text = "";
            start.IsEnabled = true;
            stop.IsEnabled = false;
            Mark.Content = "Marks: ";
            oshibki = 0;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //stop
        {
            endgame();
        }

        private void finder(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Button button in maGrid.Children)
            {
                try
                {
                    if (button.Name == e.Key.ToString() && checkback(e))
                    {
                        button.Style = tempstylee;
                        return;
                    }
                    //MessageBox.Show(Convert.ToString(tempstyle));

                }
                catch
                {
                    continue;
                }
            }


            //private void Button_KeyUp(object sender, KeyEventArgs e)
            //{
            //    //if(e.Key==Key.)  textBox1.Text += string.Format("{0}", (sender as Button).Content);

            //    MessageBox.Show(e.Key.ToString());
            //}
        }
    }
}
