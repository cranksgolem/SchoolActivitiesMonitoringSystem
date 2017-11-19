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
    /// Interaction logic for AddGradingComponentWindow.xaml
    /// </summary>
    public partial class AddGradingComponentWindow : Window
    {
        double percentTotal = 0;

        public AddGradingComponentWindow()
        {
            InitializeComponent();
            CmbGradingType.ItemsSource = Enum.GetValues(typeof(GradingType));

            if (TblPercentage.Text != "0" && ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent != null)
            {
                percentTotal = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal - ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.PercentEffectOnTotalGrade;
            }

            else
            {
                percentTotal = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxName.Text != "" && CmbGradingType.SelectedItem != null && TblBase.Text != "" && TblPercentage.Text != "")
            {
                if (percentTotal + Convert.ToDouble(TblPercentage.Text) > 100)
                {
                    MessageBox.Show("Grading components percentage total will exceed 100%! Please recheck your components' percentage values.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else
                {
                    DialogResult = true;
                }
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TblPercentage_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TblPercentage.Text;
            int textLength = text.Length;
            if (textLength >= 1)
            {
                string newText = "";
            
                for (int x = 0; x < textLength; x++)
                {
                    if (Char.IsNumber(text[x]) == true || text[x] == '.')
                    {
                        newText = newText + text[x];
                    }
                }
            
                TblPercentage.Text = newText;
            }
            
            else
            {
                TblPercentage.Text = "";
            }         
        }

        private void TblBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TblBase.Text;
            int textLength = text.Length;
            if (textLength >= 1)
            {
                string newText = "";

                for (int x = 0; x < textLength; x++)
                {
                    if (Char.IsNumber(text[x]) == true || text[x] == '.')
                    {
                        newText = newText + text[x];
                    }
                }

                TblBase.Text = newText;
            }

            else
            {
                TblBase.Text = "";
            }
        }
    }
}
