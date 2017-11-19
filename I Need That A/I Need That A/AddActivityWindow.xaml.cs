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
    /// Interaction logic for AddActivityWindow.xaml
    /// </summary>
    public partial class AddActivityWindow : Window
    {
        public AddActivityWindow()
        {
            InitializeComponent();

            CmbImportance.Items.Add("1");
            CmbImportance.Items.Add("2");
            CmbImportance.Items.Add("3");
            CmbImportance.Items.Add("4");
            CmbImportance.Items.Add("5");

            CmbType.ItemsSource = Enum.GetValues(typeof(ActivityType));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxDescription.Text != "")
            {
                DialogResult = true;
            }

            else
            {
                MessageBox.Show("Please make sure to fill in every field!", "Empty Field", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            DpDeadline.SelectedDate = DateTime.Now;
        }
    }
}
