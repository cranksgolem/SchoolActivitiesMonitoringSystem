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
    /// Interaction logic for ChangePercentEffectOnTotalGradeWindow.xaml
    /// </summary>
    public partial class ChangePercentEffectOnTotalGradeWindow : Window
    {
        public ChangePercentEffectOnTotalGradeWindow()
        {
            InitializeComponent();
            SpNewValue.DataContext = ViewModelLocator.StartMenuViewModel;
            ViewModelLocator.StartMenuViewModel.NewPercentEffect = 0;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
