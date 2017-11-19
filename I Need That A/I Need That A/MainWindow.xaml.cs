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

namespace I_Need_That_A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.StartMenuViewModel;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (CmbUsers.SelectedItem != null)
            {
                var userWindow = new SemesterSelectWindow();
                userWindow.Owner = this;
                userWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                userWindow.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser;
                this.Hide();
                userWindow.ShowDialog();
            }
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewUserWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            User newUser = new User();
            window.DataContext = newUser;

            var result = window.ShowDialog();
            if (result == true)
            {
                ViewModelLocator.StartMenuViewModel.ListUsers.Add(newUser);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
