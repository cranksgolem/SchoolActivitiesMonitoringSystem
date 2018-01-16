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
    /// Interaction logic for ToDoListWindow.xaml
    /// </summary>
    public partial class ToDoListWindow : Window
    {
        Activity SelectedActivity;
        public ToDoListWindow()
        {
            InitializeComponent();
        }

        private void BtnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.AddActivity();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainUserWindow();
            window.Show();
            this.Close();
        }

        private void BtnFinishActivity_Click(object sender, RoutedEventArgs e)
        {
            //Button button = (Button)sender;
            //Activity SelectedActivity = new Activity();

            //for (int x = 0; x < ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoList.Count; x++)
            //{
            //    if (ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoList[x].Description == button.Tag.ToString())
            //    {
            //        SelectedActivity = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoList[x];
            //        break;
            //    }
            //}

            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoListHistory.Add(SelectedActivity);
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoList.Remove(SelectedActivity);
        }

        private void BtnOpenActivityHistory_Click(object sender, RoutedEventArgs e)
        {
            var window = new ToDoListHistoryWindow();
            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;

            window.Show();
            this.Hide();
        }

        private void BtnRemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            //if (LvToDoList.SelectedItem != null)
            //{
            //    ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ToDoList.Remove(LvToDoList.SelectedItem as Activity);
            //}
        }

        private void MIUrgency_Click(object sender, RoutedEventArgs e)
        {
            //MIImportance.IsChecked = false;
            //MIImportanceDescend.IsChecked = false;
            //MIUrgencyDescend.IsChecked = false;
            //MIUrgency.IsCheckable = true;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortUrgencyToDoList();
        }

        private void MIImportance_Click(object sender, RoutedEventArgs e)
        {
            //MIUrgencyDescend.IsChecked = false;
            //MIImportanceDescend.IsChecked = false;
            //MIUrgency.IsChecked = false;
            //MIImportance.IsChecked = true;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortImportanceToDoList();
        }

        private void MIUrgencyDescend_Click(object sender, RoutedEventArgs e)
        {
            //MIUrgencyDescend.IsChecked = true;
            //MIImportanceDescend.IsChecked = false;
            //MIUrgency.IsChecked = false;
            //MIImportance.IsChecked = false;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortUrgencyToDoList2();
        }

        private void MIImportanceDescend_Click(object sender, RoutedEventArgs e)
        {
            //MIUrgencyDescend.IsChecked = false;
            //MIImportanceDescend.IsChecked = true;
            //MIUrgency.IsChecked = false;
            //MIImportance.IsChecked = false;
            //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SortImportanceToDoListAscending();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.EditActivity();
        }
    }
}
