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
    /// Interaction logic for ChangePercentageWindow.xaml
    /// </summary>
    public partial class ChangePercentageWindow : Window
    {
        public ChangePercentageWindow()
        {
            InitializeComponent();

            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 0)
            {
                TblOldValue.Text = ViewModelLocator.SelectedSubjectViewModel.PrelimPercent.ToString();
            }

            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 1)
            {
                TblOldValue.Text = ViewModelLocator.SelectedSubjectViewModel.MidtermPercent.ToString();
            }

            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 2)
            {
                TblOldValue.Text = ViewModelLocator.SelectedSubjectViewModel.PrefiPercent.ToString();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 0 && ViewModelLocator.SelectedSubjectViewModel.MidtermPercent + ViewModelLocator.SelectedSubjectViewModel.PrefiPercent + Convert.ToDouble(TbxNewValue.Text) > 100)
            {
                MessageBox.Show("Total percentage of grading periods will exceed 100% with the new value entered. Please recheck your entry.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 1 && ViewModelLocator.SelectedSubjectViewModel.PrelimPercent + ViewModelLocator.SelectedSubjectViewModel.PrefiPercent + Convert.ToDouble(TbxNewValue.Text) > 100)
            {
                MessageBox.Show("Total percentage of grading periods will exceed 100% with the new value entered. Please recheck your entry.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 2 && ViewModelLocator.SelectedSubjectViewModel.PrelimPercent + ViewModelLocator.SelectedSubjectViewModel.MidtermPercent + Convert.ToDouble(TbxNewValue.Text) > 100)
            {
                MessageBox.Show("Total percentage of grading periods will exceed 100% with the new value entered. Please recheck your entry.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 0)
                {
                    ViewModelLocator.SelectedSubjectViewModel.ChangePrelimPercent(Convert.ToDouble(TbxNewValue.Text));
                }

                if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 1)
                {
                    ViewModelLocator.SelectedSubjectViewModel.ChangeMidtermPercent(Convert.ToDouble(TbxNewValue.Text));
                }

                if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 2)
                {
                    ViewModelLocator.SelectedSubjectViewModel.ChangePrefiPercent(Convert.ToDouble(TbxNewValue.Text));
                }

                DialogResult = true;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void TbxNewValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxNewValue.Text;
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

                TbxNewValue.Text = newText;
            }

            else
            {
                TbxNewValue.Text = "";
            }
        }
    }
}
