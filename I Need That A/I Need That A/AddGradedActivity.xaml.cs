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
    /// Interaction logic for AddGradedActivity.xaml
    /// </summary>
    public partial class AddGradedActivity : Window
    {
        public AddGradedActivity()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxName.Text != "" && TbxScore.Text != "" && TbxTotalItems.Text != "")
            {
                if (Convert.ToDouble(TbxScore.Text) > Convert.ToDouble(TbxTotalItems.Text))
                {
                    MessageBox.Show("Score can't be greater than the number of items!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void TbxTotalItems_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string text = TbxTotalItems.Text;
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

                    TbxTotalItems.Text = newText;
                }

                else
                {
                    TbxTotalItems.Text = "";
                }

                if (TbxTotalItems.Text != "" && TbxScore.Text != "" && Convert.ToDouble(TbxTotalItems.Text) != 0 && Convert.ToDouble(TbxScore.Text) != 0)
                {
                    double percentScore = (((Convert.ToDouble(TbxScore.Text)) / (Convert.ToDouble(TbxTotalItems.Text))) * 100) * ((100 - (ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base)) / 100) + ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base;
                    TblPercentScore.Text = percentScore.ToString();
                }

                else if (TbxTotalItems.Text != "" && TbxScore.Text != "" && Convert.ToDouble(TbxTotalItems.Text) != 0 && Convert.ToDouble(TbxScore.Text) == 0)
                {
                    TblPercentScore.Text = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base.ToString();
                }
            }

            catch (Exception)
            {
                string text = TbxTotalItems.Text;
                int textLength = text.Length;
                if (textLength >= 1)
                {
                    string newText = "";

                    for (int x = 0; x < textLength ; x++)
                    {
                        if (Char.IsNumber(text[x]) == true || text[x] == '.')
                        {
                            newText = newText + text[x];
                        }
                    }

                    TbxTotalItems.Text = newText;
                }

                else
                {
                    TbxTotalItems.Text = "";
                }
            }
        }

        private void TbxScore_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string text = TbxScore.Text;
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

                    TbxScore.Text = newText;
                }

                else
                {
                    TbxScore.Text = "";
                }

                if (TbxTotalItems.Text != "" && TbxScore.Text != "" && Convert.ToDouble(TbxTotalItems.Text) != 0 && Convert.ToDouble(TbxScore.Text) != 0)
                {
                    double percentScore = (((Convert.ToDouble(TbxScore.Text)) / (Convert.ToDouble(TbxTotalItems.Text))) * 100) * ((100 - (ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base)) / 100) + ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base;
                    TblPercentScore.Text = percentScore.ToString();
                }

                else if (TbxTotalItems.Text != "" && TbxScore.Text != "" && Convert.ToDouble(TbxTotalItems.Text) != 0 && Convert.ToDouble(TbxScore.Text) == 0)
                {
                    TblPercentScore.Text = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base.ToString();
                }
            }

            catch (Exception)
            {
                string text = TbxScore.Text;
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

                    TbxScore.Text = newText;
                }

                else
                {
                    TbxScore.Text = "";
                }
            }
        }
    }
}
