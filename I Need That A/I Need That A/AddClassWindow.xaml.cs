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
    /// Interaction logic for AddClassWindow.xaml
    /// </summary>
    public partial class AddClassWindow : Window
    {
        public AddClassWindow()
        {
            InitializeComponent();
            CmbTimeSchedType.ItemsSource = Enum.GetValues(typeof(TimeScheduleType));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxClassName.Text != "" && TbxUnits.Text != "" && TbxDaySched.Text != "" && TbxTimeSchedFromHour.Text != "" && TbxTimeSchedFromMinute.Text != "" && TbxTimeSchedToHour.Text != "" && TbxTimeSchedToMinute.Text != "" && CmbTimeSchedType.SelectedItem != null && TbxProfessor.Text != "")
            {
                if (Convert.ToInt16(TbxTimeSchedFromHour.Text) > 12 || Convert.ToInt16(TbxTimeSchedToHour.Text) > 12 || Convert.ToInt16(TbxTimeSchedFromMinute.Text) > 59 || Convert.ToInt16(TbxTimeSchedToMinute.Text) > 59)
                {
                    MessageBox.Show("Invalid time input! No such time exists.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (TbxTimeSchedFromHour.Text.Length > 2 || TbxTimeSchedToHour.Text.Length > 2 || TbxTimeSchedFromMinute.Text.Length > 2 || TbxTimeSchedToMinute.Text.Length > 2)
                {
                    MessageBox.Show("Invalid time format! Please follow the format 00:00", "Invalid Time Format", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.UsedUnits + Convert.ToDouble(TbxUnits.Text) > ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.RequiredUnits)
                {
                    MessageBox.Show("Not enough available units!", "Insufficient Available Units", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TbxUnits_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxUnits.Text;
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

                TbxUnits.Text = newText;
            }
        }

        private void TbxTimeSchedFromHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxTimeSchedFromHour.Text;
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

                TbxTimeSchedFromHour.Text = newText;
            }

            if (textLength == 3)
            {
                string textReplace = TbxTimeSchedFromHour.Text;
                TbxTimeSchedFromHour.Text = text.Substring(0, 2);
            }
        }

        private void TbxTimeSchedFromMinute_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxTimeSchedFromMinute.Text;
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

                TbxTimeSchedFromMinute.Text = newText;
            }

            if (textLength == 3)
            {
                string textReplace = TbxTimeSchedFromMinute.Text;
                TbxTimeSchedFromMinute.Text = text.Substring(0, 2);
            }
        }

        private void TbxTimeSchedToHour_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxTimeSchedToHour.Text;
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

                TbxTimeSchedToHour.Text = newText;
            }

            if (textLength == 3)
            {
                string textReplace = TbxTimeSchedToHour.Text;
                TbxTimeSchedToHour.Text = text.Substring(0, 2);
            }
        }

        private void TbxTimeSchedToMinute_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxTimeSchedToMinute.Text;
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

                TbxTimeSchedToMinute.Text = newText;
            }

            if (textLength == 3)
            {
                string textReplace = TbxTimeSchedToMinute.Text;
                TbxTimeSchedToMinute.Text = text.Substring(0, 2);
            }
        }
    }
}
