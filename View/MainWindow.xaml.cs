using SAMS.ViewModels;
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

namespace SAMS.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModelLocator.MainWindowViewModel;
        }


        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUserWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            USERS newUser = new USERS();
            window.DataContext = newUser;

            var result = window.ShowDialog();
            if (result == true)
            {
                ViewModelLocator.MainWindowViewModel.AddNewUser(newUser);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (CmbUsers.SelectedItem != null)
            {
                var userWindow = new SemesterSelectWindow();
                userWindow.Owner = this;
                userWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                this.Hide();
                userWindow.ShowDialog();
            }
        }

        private void BtnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (CmbUsers.SelectedItem != null)
            {
                ViewModelLocator.MainWindowViewModel.RemoveUser();
            }
        }

    }
}
