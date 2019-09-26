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
    /// Interaction logic for SubjectsListWindow.xaml
    /// </summary>
    public partial class SubjectsListWindow : Window
    {
        public SubjectsListWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModelLocator.SubjectsListViewModel;
            ViewModelLocator.SubjectsListViewModel.PublicGetAndDisplaySubjects();
        }
        Menu _menu = new Menu();
        private void TextBlock_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Mouse.SetCursor(Cursors.Hand);
        }

        private void BtnAddClass_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSubjectWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            SUBJECT newSubject = new SUBJECT();
            window.DataContext = newSubject;

            var result = window.ShowDialog();
            if (result == true)
            {
                ViewModelLocator.SubjectsListViewModel.AddNewSubject(newSubject);
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _menu.Show();
            this.Hide();
        }

        private void BtnRemoveClass_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.SubjectsListViewModel.DeleteSubject();
        }

        private void BtnEnterClass_Click(object sender, RoutedEventArgs e)
        {
            if (LbClassList.SelectedItem != null)
            {
                var newWindow = new SelectedSubjectWindow();
                newWindow.Owner = this;
                newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                this.Hide();
                newWindow.ShowDialog();
            }
        }

        private void LbClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbClassList.SelectedItem != null)
            {
                ViewModelLocator.SubjectsListViewModel.SelectedSubject = LbClassList.SelectedItem as SUBJECT;
            }
        }

        private void BtnEditClass_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSubjectWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            SUBJECT changedSubject = ViewModelLocator.SubjectsListViewModel.SelectedSubject as SUBJECT;
            window.DataContext = changedSubject;

            var result = window.ShowDialog();
            if (result == true)
            {
                ViewModelLocator.SubjectsListViewModel.EditSubject(changedSubject);
            }
        }
    }
}
