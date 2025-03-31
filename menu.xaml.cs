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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LoginApp
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
        private DispatcherTimer timer;
        public menu()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTimeTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UserInfoDateTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss | yyyy-MM-dd");
        }

        private Button selectedButton = null;
        private void SelectButton(Button button)
        {
            if (selectedButton != null)
            {
                selectedButton.Background = new SolidColorBrush(Colors.White);
            }

            selectedButton = button;
            selectedButton.Background = new SolidColorBrush(Colors.Gray);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button != selectedButton)
            {
                button.Background = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Button_MouseEnterRed(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button != selectedButton)
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c54949"));
            }
        }
        private void Button_MouseLeaveGray(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
                button.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void Button_MouseLeaveRed(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B71C1C"));
            }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void btnTeachingMenu_Click(object sender, RoutedEventArgs e)
        {
            Calculator newWindow = new Calculator();
            newWindow.Show();
      
        }
    }
}
