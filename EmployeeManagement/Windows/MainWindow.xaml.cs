using EmployeeManagement.Pages;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
using System.Xml;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // отследить изменения ширины всего окна
            this.SizeChanged += OnWindowSizeChanged;
          
        }
        #region HederStyle
        // отследить изменения ширины всего окна
        void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    nameBorder.BorderThickness = new Thickness(7);
                    labelMaxmin.Content = "❐";
                }
                else
                {
                    nameBorder.BorderThickness = new Thickness(2, 1, 2, 2);
                    labelMaxmin.Content = "☐";
                }
            }

        }
        // обрабатывает наведение на кнопку
        private void header_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                border.Background = Brushes.Red;
            else
            {
                border.Background = Brushes.Gray;
                border.Opacity = 0.7;
            }
        }
        // обрабатывает: мыша покидает кнопку
        private void header_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Color.FromRgb(71, 74, 81));
        }
        // обрабатывает нажатие на кнопку
        private void header_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                border.Background = Brushes.LightPink;
            else
            {
                border.Background = Brushes.Gray;
                border.Opacity = 1;
            }
        }
        // управение действием кнопок: закрыть, на весь экран, маленькое окно, свернуть на панель задач
        private void header_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                this.Close();
            else if (border.Name == "maxmin")
            {
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Maximized;
            }
            else
                this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажата кнопка в хедере");
        }
        #endregion

        #region GroupBoxMaiStyleBorder-Button

        private void borderEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Color.FromRgb(71, 74, 81));
        }

        private void borderLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
        }

        #endregion

        #region MenuClik
        private void borderClik(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            string borderName = border.Name;

            switch (borderName)
            {
                case "btnProfile":
                    mainFrame.NavigationService.Navigate(new ProfilePage());
                    groupBoxMainFrame.Header = "Профиль";
                    break;
                case "btnListEmployees":
                    mainFrame.NavigationService.Navigate(new EmployeesPage());
                    groupBoxMainFrame.Header = "Сотрудники";
                    break;
                case "btnSchedule":
                    mainFrame.NavigationService.Navigate(new SchedulePage());
                    groupBoxMainFrame.Header = "Расписание";
                    break;
                case "btnEvent":
                    mainFrame.NavigationService.Navigate(new EventPage());
                    groupBoxMainFrame.Header = "События";
                    break;
            }
        }
        #endregion
    }
}