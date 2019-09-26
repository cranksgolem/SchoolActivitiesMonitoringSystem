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
    /// Interaction logic for GradesWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        public GradesWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModelLocator.GradesWindowViewModel;
            ViewModelLocator.GradesWindowViewModel.GetAndDisplayGrades();
        }

        Menu _menu = new Menu();

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            _menu.Show();
            this.Hide();
        }

        private void LvListGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LvListGrades.SelectedItem = null;
        }
    }
}
