﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security;

namespace wpf_password_app
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
               
            FileStream fs = new FileStream("master_pw.txt", FileMode.Create); StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.Write(pCreate_Box.Password); sw.Close(); fs.Close();

            Register.Visibility = Visibility.Visible; To_Log_In.Visibility = Visibility.Visible; Hello.Visibility = Visibility.Visible; select_text.Visibility = Visibility.Visible;

            pCreate.Visibility = Visibility.Hidden; pCreate_Box.Visibility = Visibility.Hidden; Create_Button.Visibility = Visibility.Hidden;

            MessageBox.Show("Password created successfully! Please Log in!", "Password Created", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            //Make everything visible
            pCreate.Visibility = Visibility.Visible; pCreate_Box.Visibility = Visibility.Visible; Create_Button.Visibility = Visibility.Visible;

            //make the others go 'vanish'

            Register.Visibility = Visibility.Hidden; To_Log_In.Visibility = Visibility.Hidden; Hello.Visibility = Visibility.Hidden; select_text.Visibility = Visibility.Hidden;

        }

        private void To_Log_In_Button_Click(object sender, RoutedEventArgs e)
        {
            pCreate_Box.Clear();

            //make the others go 'vanish'

            Register.Visibility = Visibility.Hidden; To_Log_In.Visibility = Visibility.Hidden; Hello.Visibility = Visibility.Hidden; select_text.Visibility = Visibility.Hidden;

            //Make everything visible
            pCreate_Box.Visibility = Visibility.Visible; Log_In_Text.Visibility = Visibility.Visible; Real_Log_In.Visibility = Visibility.Visible;
        }

        private void Actual_Log_In_Button(object sender, RoutedEventArgs e)
        {
            FileStream fs_log_in = new FileStream("master_pw.txt", FileMode.Open); StreamReader sr = new StreamReader(fs_log_in, Encoding.UTF8);

            string password_check = sr.ReadToEnd().ToString().TrimEnd(); sr.Close(); fs_log_in.Close();

            if (password_check == pCreate_Box.Password)
            {
                MessageBox.Show("Successfull Log In!", "Log In", MessageBoxButton.OK, MessageBoxImage.Information);

                //Ide fog jonni a fo program resz
            }
            else
            {
                pCreate_Box.Clear();
                MessageBox.Show("Wrong password. Try again!", "Log In", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        int db = 0;
        private void Delete_Sys(object sender, RoutedEventArgs e)
        {
            db++;

            if (db == 1)
            {
                MessageBox.Show("Azt hitted mi? Nyomd meg parszor...", "Delete", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            if(db == 10)
            {
                MessageBox.Show("Kitarto vagy! De a helyedben vigyaznek, barmi megtortenhet...", "Delete", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            if (db == 50)
            {
                MessageBox.Show("Utolso figyelmeztetes!", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}