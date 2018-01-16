using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            //if (TblPercentage.Text != "0" && ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent != null)
            //{
            //    percentTotal = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal - ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.PercentEffectOnTotalGrade;
            //}

            //else
            //{
            //    percentTotal = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal;
            //}
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxName.Text != "" && CmbGradingType.SelectedItem != null  && TblPercentage.Text != "")
            {
                if (SelectedClassWindow.totalPercentage + Convert.ToDouble(TblPercentage.Text) > 100)
                {
                    MessageBox.Show("Grading components percentage total will exceed 100%! Please recheck your components' percentage values.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
                    con.Open();
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("INSERT INTO [ACTIVITY] (Activity, Percentage, Subject_ID, Grading_Period, Grade, Grading_Type) VALUES (@Activity, @Percentage, @Subject_ID, @Grading_Period, @Grade, @Grading_Type)", con);
                    command.Parameters.AddWithValue("@Activity", TbxName.Text);
                    command.Parameters.AddWithValue("@Percentage", TblPercentage.Text);
                    command.Parameters.AddWithValue("@Subject_ID", ClassWindow.selectedSubject.SubjectID);              
                    command.Parameters.AddWithValue("@Grade", 0);
                    command.Parameters.AddWithValue("@Grading_Type", CmbGradingType.SelectedItem.ToString());

                    if (SelectedClassWindow.gradingPeriodSelect == 1)
                    {
                        command.Parameters.AddWithValue("@Grading_Period", "Prelim");
                    }

                    if (SelectedClassWindow.gradingPeriodSelect == 2)
                    {
                        command.Parameters.AddWithValue("@Grading_Period", "Midterm");
                    }

                    if (SelectedClassWindow.gradingPeriodSelect == 3)
                    {
                        command.Parameters.AddWithValue("@Grading_Period", "Prefi");
                    }

                    command.ExecuteNonQuery();
                    con.Close();
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

        //private void TblBase_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string text = TblBase.Text;
        //    int textLength = text.Length;
        //    if (textLength >= 1)
        //    {
        //        string newText = "";

        //        for (int x = 0; x < textLength; x++)
        //        {
        //            if (Char.IsNumber(text[x]) == true || text[x] == '.')
        //            {
        //                newText = newText + text[x];
        //            }
        //        }

        //        TblBase.Text = newText;
        //    }

        //    else
        //    {
        //        TblBase.Text = "";
        //    }
        //}
    }
}
