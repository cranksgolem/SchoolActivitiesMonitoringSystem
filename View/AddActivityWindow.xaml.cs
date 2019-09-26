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
using static I_Need_That_A.ACTIVITY;

namespace SAMS.View
{
    /// <summary>
    /// Interaction logic for AddActivityWindow.xaml
    /// </summary>
    public partial class AddActivityWindow : Window
    {
        public AddActivityWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxName.Text != "" || TblPercentage.Text != "")
            {
                if (ViewModelLocator.SelectedSubjectViewModel.GetTotalPercentage(ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod) + Convert.ToDouble(TblPercentage.Text) > 100)
                {
                    MessageBox.Show("Total percentage of grading components will exceed 100% with the new value entered. Please recheck your entry.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                { 
                    DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Please make sure to fill in every field!", "Empty Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                ViewModelLocator.SelectedSubjectViewModel.GetAndDisplayActivities();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
