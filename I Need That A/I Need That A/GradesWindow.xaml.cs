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
    /// Interaction logic for GradesWindow.xaml
    /// </summary>
    public partial class GradesWindow : Window
    {
        public GradesWindow()
        {
            InitializeComponent();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainUserWindow();
            window.Show();
            this.Close();
        }

        private void BtnEnterSemester_Click(object sender, RoutedEventArgs e)
        {
            var window = new SelectedClassWindow();
            window.backToClassList = false;
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.DataContext = LvListGrades.SelectedItem;
            window.Show();
            this.Hide();
        }
    }
}
