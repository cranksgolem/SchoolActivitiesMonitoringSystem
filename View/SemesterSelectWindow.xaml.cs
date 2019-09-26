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
using System.Windows.Shapes;

namespace SAMS.View
{
    /// <summary>
    /// Interaction logic for SemesterSelectWindow.xaml
    /// </summary>
    public partial class SemesterSelectWindow : Window
    {
        public SemesterSelectWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModelLocator.SemesterSelectViewModel;
            ViewModelLocator.SemesterSelectViewModel.PuclibGetAndDisplaySemesters();
        }

        MainWindow _mainWindow = new MainWindow();

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();
            this.Hide();
        }

        private void BtnOpenAddSemester_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSemesterWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            SEMESTER newSemester = new SEMESTER();
            window.DataContext = newSemester;

            var result = window.ShowDialog();
            if (result == true)
            {
                ViewModelLocator.SemesterSelectViewModel.AddNewSemester(newSemester);
            }
        }

        private void BtnRemoveSemester_Click(object sender, RoutedEventArgs e)
        {
            if (LbListSemester.SelectedItem != null)
            {
                ViewModelLocator.SemesterSelectViewModel.RemoveSemester();
            }
        }

        private void BtnEnterSemester_Click(object sender, RoutedEventArgs e)
        {

            if (LbListSemester.SelectedItem != null)
            {
                var newWindow = new Menu();
                newWindow.Owner = this;
                newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                this.Hide();
                newWindow.ShowDialog();   
            }
        }

        private void LbListSemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbListSemester.SelectedItem != null)
            {
                ViewModelLocator.SemesterSelectViewModel.SelectedSemester = LbListSemester.SelectedItem as SEMESTER;
            }
        }
    }
}
