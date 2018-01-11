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

namespace I_Need_That_A
{
    /// <summary>
    /// Interaction logic for MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        public MainUserWindow()
        {
            InitializeComponent();

        }

        SemesterSelectWindow _semWindow = new SemesterSelectWindow();

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _semWindow.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser;
            _semWindow.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnClassMenu_Click(object sender, RoutedEventArgs e)
        {
            var window = new ClassWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;
            window.Show();
            this.Hide();
        }

        private void BtnGradesWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new GradesWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;
            window.Show();
            this.Hide();
        }

        private void BtnToDoListWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new ToDoListWindow();
            window.Owner = this;

            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;
            window.Show();
            this.Hide();
        }

    }
}
