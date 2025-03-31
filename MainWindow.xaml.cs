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

namespace LoginApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button != selectedButton)
            {
                button.Background = new SolidColorBrush(Colors.LightGray);
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button != selectedButton)
            {
                button.Background = new SolidColorBrush(Colors.White);
            }
        }

        private void Button_MouseLeaveBlue(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B71C1C"));
            }
        }

        public static bool loginPermission = false;
        private Button selectedButton = null;

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Password;

            if (selectedButton == null)
            {
                MessageBox.Show("You forgot to choose your permission level~");
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("What!? Make sure you filled out your Username and Password!");
                return;
            }

            if (username == "admin" && password == "123")
            {
                menu newWindow = new menu();
                newWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ooopsie, no user found. Try 'admin' with '123'!");
            }
        }

        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            SelectButton(sender as Button);
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            SelectButton(sender as Button);
        }

        private void btnAutoTeam_Click(object sender, RoutedEventArgs e)
        {
            SelectButton(sender as Button);
        }

        private void SelectButton(Button button)
        {
            if (selectedButton != null)
            {
                selectedButton.Background = new SolidColorBrush(Colors.White);
            }

            selectedButton = button;
            selectedButton.Background = new SolidColorBrush(Colors.Gray);
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Just a joke, you cannot change your password. Try contact your boss to get the permission~");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}