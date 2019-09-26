using SAMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace SAMS.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        SemesterSelectWindow _semSelectWindow = new SemesterSelectWindow();

        private void BtnClassMenu_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SubjectsListWindow();
            newWindow.Owner = this;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.Hide();
            newWindow.ShowDialog();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _semSelectWindow.Show();
            this.Hide();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnGradesWindow_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new GradesWindow();
            newWindow.Owner = this;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.Hide();
            newWindow.ShowDialog();
        }
    }
}
