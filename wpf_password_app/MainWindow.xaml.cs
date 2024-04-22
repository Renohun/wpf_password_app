using System.Text;
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
using System.Windows.Automation.Provider;

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
            if(pCreate_Box.Password.Length < 5)
            {
                pCreate_Box.Clear();

                MessageBox.Show("The password was too short. It must be at least 6 charachters long", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (pCreate_Box.Password.Contains("#") || pCreate_Box.Password.Contains("$") || pCreate_Box.Password.Contains("&") || pCreate_Box.Password.Contains("%"))
                {
                    if (pCreate_Box.Password.Contains("0") || pCreate_Box.Password.Contains("1") || pCreate_Box.Password.Contains("2") || pCreate_Box.Password.Contains("3") || pCreate_Box.Password.Contains("4") || pCreate_Box.Password.Contains("5") || pCreate_Box.Password.Contains("6") || pCreate_Box.Password.Contains("7") || pCreate_Box.Password.Contains("8") || pCreate_Box.Password.Contains("9"))
                    {

                        string dir = @"C:\Temp\wpf_pw_app";

                        if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

                        string subdir = @"C:\Temp\wpf_pw_app\pws";

                        if (!Directory.Exists(subdir)) { Directory.CreateDirectory(subdir); }

                        FileStream fs = new FileStream(@"C:\\Temp\\wpf_pw_app\m_pw.txt", FileMode.Create); StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                        //shit password enrypction

                        List<int> list_ASCII = new List<int>();

                        for (int i = 0; i < pCreate_Box.Password.Length; i++)
                        {
                            list_ASCII.Add(Convert.ToInt32(pCreate_Box.Password[i]));
                        }

                        for (int i = 0; i < list_ASCII.Count; i++)
                        {
                            sw.Write(list_ASCII[i] * 6421);
                        }

                        sw.Close(); fs.Close();

                        Register.Visibility = Visibility.Visible; To_Log_In.Visibility = Visibility.Visible; Hello.Visibility = Visibility.Visible; select_text.Visibility = Visibility.Visible;

                        pCreate.Visibility = Visibility.Hidden; pCreate_Box.Visibility = Visibility.Hidden; Create_Button.Visibility = Visibility.Hidden;

                        MessageBox.Show("Password created successfully! Please Log in!", "Password Created", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        pCreate_Box.Clear(); MessageBox.Show("The password has to contain numbers", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    pCreate_Box.Clear(); MessageBox.Show("The password has to contain at least one of these special characters #, $, %, &;", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void To_Register_Button_Click(object sender, RoutedEventArgs e)
        {
            //Make everything visible
            pCreate.Visibility = Visibility.Visible; pCreate_Box.Visibility = Visibility.Visible; Create_Button.Visibility = Visibility.Visible;

            //Make the others go 'vanish'

            Register.Visibility = Visibility.Hidden; To_Log_In.Visibility = Visibility.Hidden; Hello.Visibility = Visibility.Hidden; select_text.Visibility = Visibility.Hidden;

        }

        private void To_Log_In_Button_Click(object sender, RoutedEventArgs e)
        {
            pCreate_Box.Clear();

            //Make the others go 'vanish'

            Register.Visibility = Visibility.Hidden; To_Log_In.Visibility = Visibility.Hidden; Hello.Visibility = Visibility.Hidden; select_text.Visibility = Visibility.Hidden;

            //Make everything visible
            pCreate_Box.Visibility = Visibility.Visible; Log_In_Text.Visibility = Visibility.Visible; Real_Log_In.Visibility = Visibility.Visible;
        }

        private void Actual_Log_In_Button(object sender, RoutedEventArgs e)
        {
            FileStream fs_log_in = new FileStream(@"C:\\Temp\\wpf_pw_app\\m_pw.txt", FileMode.Open); StreamReader sr = new StreamReader(fs_log_in, Encoding.UTF8);

            // shit password decryption

            string real_password = ""; string from_file = "";

            while (!sr.EndOfStream) { from_file = Convert.ToString(sr.ReadLine()); } from_file.TrimEnd();

            for (int i = 0; i < pCreate_Box.Password.Length; i++)
            {
                real_password += Convert.ToString(Convert.ToInt32(pCreate_Box.Password[i]) * 6421);
            }

            sr.Close(); fs_log_in.Close();

            if (from_file == real_password)
            {
                MessageBox.Show("Successfull Log In!", "Log In", MessageBoxButton.OK, MessageBoxImage.Information);
                    

                //NINCSEN RENDES DESIGN avagy normalis elrendezes

                pCreate_Box.Visibility = Visibility.Hidden; Log_In_Text.Visibility = Visibility.Hidden; Real_Log_In.Visibility = Visibility.Hidden;

                delete_1.Visibility = Visibility.Visible; delete_2.Visibility = Visibility.Visible; delete_3.Visibility = Visibility.Visible; delete_4.Visibility = Visibility.Visible;

                create_1.Visibility = Visibility.Visible; create_2.Visibility = Visibility.Visible; create_3.Visibility = Visibility.Visible; create_4.Visibility = Visibility.Visible;
                 
                box_1.Visibility = Visibility.Visible; box_2.Visibility = Visibility.Visible; box_3.Visibility = Visibility.Visible; box_4.Visibility = Visibility.Visible;

                show_1.Visibility = Visibility.Visible; show_2.Visibility = Visibility.Visible; show_3.Visibility = Visibility.Visible; show_4.Visibility = Visibility.Visible;
            }
            else
            {
                pCreate_Box.Clear();
                MessageBox.Show("Wrong password. Try again!", "Log In", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void delete_file(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Delete(@"C:\\Temp\\wpf_pw_app\\m_pw.txt");
            }
            catch(Exception) //erdekes, egy olyan kene ahol az ez alatt levo messageboxot megjeleniti ha a file nem letezik, de nem akarja, FileNotExceptionnal sem, mert jo lenne majd a kesobbi dolgokhoz
            {        
                MessageBox.Show("The File dosen't exists", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //delete buttons

        private void delete_pw_1(object sender, RoutedEventArgs e)
        {

        }
        private void delete_pw_2(object sender, RoutedEventArgs e)
        {

        }
        private void delete_pw_3(object sender, RoutedEventArgs e)
        {

        }
        private void delete_pw_4(object sender, RoutedEventArgs e)
        {

        }

        //create buttons

        private void create_bt_1(object sender, RoutedEventArgs e)
        {
            if (box_1.Password.Length < 5)
            {
                box_1.Clear();

                MessageBox.Show("The password was too short. It must be at least 6 charachters long", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (box_1.Password.Contains("#") || box_1.Password.Contains("$") || box_1.Password.Contains("&") || box_1.Password.Contains("%"))
                {
                    if (box_1.Password.Contains("0") || box_1.Password.Contains("1") || box_1.Password.Contains("2") || box_1.Password.Contains("3") || box_1.Password.Contains("4") || box_1.Password.Contains("5") || box_1.Password.Contains("6") || box_1.Password.Contains("7") || box_1.Password.Contains("8") || box_1.Password.Contains("9"))
                    {
                        FileStream fs = new FileStream(@"C:\\Temp\\wpf_pw_app\\pws\\pw_1.txt", FileMode.Create); StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                        //shit password enrypction

                        List<int> list_ASCII = new List<int>();

                        for (int i = 0; i < box_1.Password.Length; i++)
                        {
                            list_ASCII.Add(Convert.ToInt32(box_1.Password[i]));
                        }

                        for (int i = 0; i < list_ASCII.Count; i++)
                        {
                            sw.Write(list_ASCII[i] * 6421);
                        }

                        sw.Close(); fs.Close();

                        MessageBox.Show("Password created successfully! Please Log in!", "Password Created", MessageBoxButton.OK, MessageBoxImage.Information);

                        box_1.Clear();
                    }
                    else
                    {
                        box_1.Clear(); MessageBox.Show("The password has to contain numbers", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    box_1.Clear(); MessageBox.Show("The password has to contain at least one of these special characters #, $, %, &;", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void create_bt_2(object sender, RoutedEventArgs e)
        {
            if (box_2.Password.Length < 5)
            {
                box_2.Clear();

                MessageBox.Show("The password was too short. It must be at least 6 charachters long", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (box_2.Password.Contains("#") || box_2.Password.Contains("$") || box_2.Password.Contains("&") || box_2.Password.Contains("%"))
                {
                    if (box_2.Password.Contains("0") || box_2.Password.Contains("1") || box_2.Password.Contains("2") || box_2.Password.Contains("3") || box_2.Password.Contains("4") || box_2.Password.Contains("5") || box_2.Password.Contains("6") || box_2.Password.Contains("7") || box_2.Password.Contains("8") || box_2.Password.Contains("9"))
                    {
                        FileStream fs = new FileStream(@"C:\\Temp\\wpf_pw_app\\pws\\pw_2.txt", FileMode.Create); StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                        //shit password enrypction

                        List<int> list_ASCII = new List<int>();

                        for (int i = 0; i < box_2.Password.Length; i++)
                        {
                            list_ASCII.Add(Convert.ToInt32(box_2.Password[i]));
                        }

                        for (int i = 0; i < list_ASCII.Count; i++)
                        {
                            sw.Write(list_ASCII[i] * 6421);
                        }

                        sw.Close(); fs.Close();

                        MessageBox.Show("Password created successfully! Please Log in!", "Password Created", MessageBoxButton.OK, MessageBoxImage.Information);

                        box_2.Clear();
                    }
                    else
                    {
                        box_2.Clear(); MessageBox.Show("The password has to contain numbers", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    box_2.Clear(); MessageBox.Show("The password has to contain at least one of these special characters #, $, %, &;", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void create_bt_3(object sender, RoutedEventArgs e)
        {
            if (box_3.Password.Length < 5)
            {
                box_3.Clear();

                MessageBox.Show("The password was too short. It must be at least 6 charachters long", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (box_3.Password.Contains("#") || box_3.Password.Contains("$") || box_3.Password.Contains("&") || box_3.Password.Contains("%"))
                {
                    if (box_3.Password.Contains("0") || box_3.Password.Contains("1") || box_3.Password.Contains("2") || box_3.Password.Contains("3") || box_3.Password.Contains("4") || box_3.Password.Contains("5") || box_3.Password.Contains("6") || box_3.Password.Contains("7") || box_3.Password.Contains("8") || box_3.Password.Contains("9"))
                    {
                        FileStream fs = new FileStream(@"C:\\Temp\\wpf_pw_app\\pws\\pw_2.txt", FileMode.Create); StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                        //shit password enrypction

                        List<int> list_ASCII = new List<int>();

                        for (int i = 0; i < box_3.Password.Length; i++)
                        {
                            list_ASCII.Add(Convert.ToInt32(box_3.Password[i]));
                        }

                        for (int i = 0; i < list_ASCII.Count; i++)
                        {
                            sw.Write(list_ASCII[i] * 6421);
                        }

                        sw.Close(); fs.Close();

                        MessageBox.Show("Password created successfully! Please Log in!", "Password Created", MessageBoxButton.OK, MessageBoxImage.Information);

                        box_3.Clear();
                    }
                    else
                    {
                        box_3.Clear(); MessageBox.Show("The password has to contain numbers", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    box_3.Clear(); MessageBox.Show("The password has to contain at least one of these special characters #, $, %, &;", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void create_bt_4(object sender, RoutedEventArgs e)
        {
            {
                if (box_4.Password.Length < 5)
                {
                    box_4.Clear();

                    MessageBox.Show("The password was too short. It must be at least 6 charachters long", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (box_4.Password.Contains("#") || box_4.Password.Contains("$") || box_4.Password.Contains("&") || box_4.Password.Contains("%"))
                    {
                        if (box_4.Password.Contains("0") || box_4.Password.Contains("1") || box_4.Password.Contains("2") || box_4.Password.Contains("3") || box_4.Password.Contains("4") || box_4.Password.Contains("5") || box_4.Password.Contains("6") || box_4.Password.Contains("7") || box_4.Password.Contains("8") || box_4.Password.Contains("9"))
                        {
                            FileStream fs = new FileStream(@"C:\\Temp\\wpf_pw_app\\pws\\pw_2.txt", FileMode.Create); StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                            //shit password enrypction

                            List<int> list_ASCII = new List<int>();

                            for (int i = 0; i < box_4.Password.Length; i++)
                            {
                                list_ASCII.Add(Convert.ToInt32(box_4.Password[i]));
                            }

                            for (int i = 0; i < list_ASCII.Count; i++)
                            {
                                sw.Write(list_ASCII[i] * 6421);
                            }

                            sw.Close(); fs.Close();

                            MessageBox.Show("Password created successfully! Please Log in!", "Password Created", MessageBoxButton.OK, MessageBoxImage.Information);

                            box_4.Clear();
                        }
                        else
                        {
                            box_4.Clear(); MessageBox.Show("The password has to contain numbers", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        box_4.Clear(); MessageBox.Show("The password has to contain at least one of these special characters #, $, %, &;", "Register Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //show buttons

        private void show_bt_1(object sender, RoutedEventArgs e)
        {
            FileStream fs_show_1 = new FileStream(@"C:\\Temp\\wpf_pw_app\\pws\\pw_1.txt", FileMode.Open); StreamReader sr_show_1 = new StreamReader(fs_show_1, Encoding.Default);

            string pw_show = "";

            while(!sr_show_1.EndOfStream)
            {
                pw_show = sr_show_1.ReadLine().TrimEnd();
            }
        }
        private void show_bt_2(object sender, RoutedEventArgs e)
        {

        }
        private void show_bt_3(object sender, RoutedEventArgs e)
        {

        }
        private void show_bt_4(object sender, RoutedEventArgs e)
        {

        }
    }
}