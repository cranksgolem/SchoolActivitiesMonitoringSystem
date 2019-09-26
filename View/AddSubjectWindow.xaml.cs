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
using static SAMS.SUBJECT;

namespace SAMS.View
{
    /// <summary>
    /// Interaction logic for AddSubjectWindow.xaml
    /// </summary>
    public partial class AddSubjectWindow : Window
    {
        public AddSubjectWindow()
        {
            InitializeComponent();
            CmbTimeSchedType.ItemsSource = Enum.GetValues(typeof(TimeScheduleType));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxSubjectCode.Text != "" && TbxUnits.Text != "" && TbxDaySched.Text != "" && TbxTimeSchedFromHour.Text != "" && TbxTimeSchedFromMinute.Text != "" && TbxTimeSchedToHour.Text != "" && TbxTimeSchedToMinute.Text != "" && CmbTimeSchedType.SelectedItem != null && TbxDescription.Text != "")
            {
                if (Convert.ToInt16(TbxTimeSchedFromHour.Text) > 12 || Convert.ToInt16(TbxTimeSchedToHour.Text) > 12 || Convert.ToInt16(TbxTimeSchedFromMinute.Text) > 59 || Convert.ToInt16(TbxTimeSchedToMinute.Text) > 59)
                {
                    MessageBox.Show("Invalid time input! No such time exists.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ViewModelLocator.SubjectsListViewModel.PublicGetAndDisplaySubjects();
                }

                else if (TbxTimeSchedFromHour.Text.Length > 2 || TbxTimeSchedToHour.Text.Length > 2 || TbxTimeSchedFromMinute.Text.Length > 2 || TbxTimeSchedToMinute.Text.Length > 2)
                {
                    MessageBox.Show("Invalid time format! Please follow the format 00:00", "Invalid Time Format", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ViewModelLocator.SubjectsListViewModel.PublicGetAndDisplaySubjects();
                }

                else if (ViewModelLocator.SubjectsListViewModel.ComputeMaxUnits() + Convert.ToDouble(TbxUnits.Text) > ViewModelLocator.SemesterSelectViewModel.SelectedSemester.MaxUnits)
                {
                    MessageBox.Show("Not enough available units!", "Insufficient Available Units", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ViewModelLocator.SubjectsListViewModel.PublicGetAndDisplaySubjects();
                }

                else
                {
                    (DataContext as SUBJECT).Schedule = TbxTimeSchedFromHour.Text + ":" + TbxTimeSchedFromMinute.Text + " - " + TbxTimeSchedToHour.Text + ":" + TbxTimeSchedToMinute.Text + CmbTimeSchedType.SelectedItem.ToString() + " " + TbxDaySched.Text;
                    DialogResult = true;
                }
            }

            else
            {
                MessageBox.Show("Please make sure to fill in every field!", "Empty Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                ViewModelLocator.SubjectsListViewModel.PublicGetAndDisplaySubjects();
            }
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            ViewModelLocator.SubjectsListViewModel.PublicGetAndDisplaySubjects();
        }

        private void TbxBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbxBase.Text;
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

                TbxBase.Text = newText;
            }

            if (textLength == 3)
            {
                string textReplace = TbxBase.Text;
                TbxBase.Text = text.Substring(0, 2);
            }
        }
    }
}
