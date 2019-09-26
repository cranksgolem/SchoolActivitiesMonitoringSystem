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
    /// Interaction logic for AddScoreWindow.xaml
    /// </summary>
    public partial class AddScoreWindow : Window
    {
        public AddScoreWindow()
        {
            InitializeComponent();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxScore.Text != "" && TbxTotalItems.Text != "" && DpDate.SelectedDate != null)
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
                ViewModelLocator.ScoresListViewModel.GetAndDisplayScores();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            ViewModelLocator.ScoresListViewModel.GetAndDisplayScores();
        }

        private void TbxTotalItems_TextChanged(object sender, TextChangedEventArgs e)
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
        }

        private void TbxScore_TextChanged(object sender, TextChangedEventArgs e)
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
        }

        private void DpDate_Initialized(object sender, EventArgs e)
        {
            
        }
    }
}
