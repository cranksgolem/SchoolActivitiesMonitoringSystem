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
    /// Interaction logic for SemesterSelectWindow.xaml
    /// </summary>
    public partial class SemesterSelectWindow : Window
    {
        public SemesterSelectWindow()
        {
            InitializeComponent();
        }

        MainWindow _mainWindow = new MainWindow();

        private void BtnOpenAddSemester_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddSemesterWindow();
            newWindow.Owner = this;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            Semester newSemester = new Semester();
            newWindow.DataContext = newSemester;

            var result = newWindow.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.ListSemester.Add(newSemester);
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();
            Hide();
        }

        private void BtnRemoveSemester_Click(object sender, RoutedEventArgs e)
        {
            if (LbListSemester.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.RemoveSemester();
            }
        }

        private void BtnEnterSemester_Click(object sender, RoutedEventArgs e)
        {
            if (LbListSemester.SelectedItem != null)
            {
                var newWindow = new MainUserWindow();
                newWindow.Owner = this;
                newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                newWindow.Show();
                this.Hide();
            }
        }
    }
}
