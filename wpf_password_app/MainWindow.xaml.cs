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
            FileStream fs_is_true = new FileStream("logged_in_once.txt", FileMode.Open); StreamReader sr_true = new StreamReader(fs_is_true, Encoding.UTF8);

            string is_true = sr_true.ReadToEnd().ToString();

            fs_is_true.Close(); sr_true.Close();

            Test.Text = "fajl: " + is_true + " tipusa: szar";


            if (is_true == "true")
            {
                FileStream fs_2 = new FileStream("master_password.txt", FileMode.Open); StreamReader sr = new StreamReader(fs_2, Encoding.UTF8);

                string password_in_file = sr.ReadToEnd();

                if (password_in_file == pCreate_Box.Password) 
                {
                    pCreate.Visibility = Visibility.Hidden; pCreate_Box.Visibility = Visibility.Hidden; pCreate_Button.Visibility = Visibility.Hidden; Footer_Text.Visibility = Visibility.Hidden;

                    MessageBox.Show("Nice log in", "password", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Wrong password! Try again!", "Password error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                if (pCreate_Box.Password == "")
                {
                    MessageBox.Show("Input was left empty. Please type a password in!", "No input", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    FileStream fs = new FileStream("master_password.txt", FileMode.Create);
                    StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);

                    writer.WriteLine(pCreate_Box.Password);

                    writer.Close(); fs.Close();

                    //minden eltunik es majd le lesz cserelve

                    pCreate.Visibility = Visibility.Hidden; pCreate_Box.Visibility = Visibility.Hidden; pCreate_Button.Visibility = Visibility.Hidden; Footer_Text.Visibility = Visibility.Hidden;

                    MessageBox.Show("Password was successfully created!", "Password created", MessageBoxButton.OK, MessageBoxImage.Information);

                    FileStream fs_true = new FileStream("logged_in_once.txt", FileMode.Open);
                    StreamWriter sw = new StreamWriter(fs_true, Encoding.UTF8);

                    sw.WriteLine("true"); sw.Close(); fs_true.Close();
                }
            }
        }
    }
}