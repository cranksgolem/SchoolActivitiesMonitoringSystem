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
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public NotesWindow()
        {
            InitializeComponent();
        }

        private void BtnAddNote_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.AddNote();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            var window = new SelectedClassWindow();
            window.backToClassList = true;
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass;
            window.Show();
            this.Hide();
        }

        private void BtnRemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            if (LbListNotes.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.RemoveNote();
            }
        }
    }
}
