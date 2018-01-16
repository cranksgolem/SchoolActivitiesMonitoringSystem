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
    /// Interaction logic for ToDoListHistoryWindow.xaml
    /// </summary>
    public partial class ToDoListHistoryWindow : Window
    {
        public ToDoListHistoryWindow()
        {
            InitializeComponent();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ToDoListWindow();
            window.Owner = this;

            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;
            window.Show();
            this.Hide();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoListHistory.Clear();
        }

        private void MIUrgency_Click(object sender, RoutedEventArgs e)
        {
            //MIImportance.IsChecked = false;
            //MIImportanceDescend.IsChecked = false;
            //MIUrgencyDescend.IsChecked = false;
            //MIUrgency.IsCheckable = true;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortUrgencyToDoListHistory();
        }

        private void MIImportance_Click(object sender, RoutedEventArgs e)
        {
            //MIUrgencyDescend.IsChecked = false;
            //MIImportanceDescend.IsChecked = false;
            //MIUrgency.IsChecked = false;
            //MIImportance.IsChecked = true;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortImportanceToDoListHistory();
        }

        private void MIUrgencyDescend_Click(object sender, RoutedEventArgs e)
        {
            //MIUrgencyDescend.IsChecked = true;
            //MIImportanceDescend.IsChecked = false;
            //MIUrgency.IsChecked = false;
            //MIImportance.IsChecked = false;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortUrgencyToDoList2History();
        }

        private void MIImportanceDescend_Click(object sender, RoutedEventArgs e)
        {
            //MIUrgencyDescend.IsChecked = false;
            //MIImportanceDescend.IsChecked = true;
            //MIUrgency.IsChecked = false;
            //MIImportance.IsChecked = false;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortImportanceToDoListAscendingHistory();
        }
    }
}
