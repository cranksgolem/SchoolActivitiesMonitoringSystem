using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SelectedClassWindow.xaml
    /// </summary>
    public partial class SelectedClassWindow : Window
    {
        public bool backToClassList = true;

        public SelectedClassWindow()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\Database1.mdf");
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Activity, Percentage From [ACTIVITY]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);

            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prelim;

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                GradingComponent newGC = new GradingComponent();

                newGC.Name = dt.Rows[x]["Activity"].ToString();
                newGC.PercentEffectOnTotalGrade = Convert.ToDouble(dt.Rows[x]["Percentage"]);

                ViewModelLocator.StartMenuViewModel.AddComponent(newGC);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (backToClassList == true)
            {
                var window = new ClassWindow();
                window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;
                window.Show();
                this.Hide();
            }

            if (backToClassList == false)
            {
                var window = new GradesWindow();
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester;
                window.Show();
                this.Hide();
            }
        }

        private void BtnChangePercentEffectPrelim_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prelim;
            ViewModelLocator.StartMenuViewModel.ChangePercentEffect();
            ViewModelLocator.StartMenuViewModel.GetDecimalEffect();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void BtnAddComponent_Click(object sender, RoutedEventArgs e)
        {
            LvPrelimComponents.SelectedItem = null;
            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prelim;
            ViewModelLocator.StartMenuViewModel.AddNewComponent();
            ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
            ViewModelLocator.StartMenuViewModel.GetLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void LvPrelimComponents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prelim;
                ViewModelLocator.StartMenuViewModel.OpenGradingComponent();
            }
        }

        private void LvPrelimComponents_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                LvPrelimComponents.SelectedItem = null;
            }
        }

        private void BtnRemoveComponent_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prelim;
                ViewModelLocator.StartMenuViewModel.RemoveComponent();
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrelimComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prelim;
                ViewModelLocator.StartMenuViewModel.EditComponent();
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                ViewModelLocator.StartMenuViewModel.GetComponentFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetConvertedGrade();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnChangePercentEffectMidterm_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Midterm;
            ViewModelLocator.StartMenuViewModel.ChangePercentEffect();
            ViewModelLocator.StartMenuViewModel.GetDecimalEffect();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void BtnAddComponentMidterm_Click(object sender, RoutedEventArgs e)
        {
            LvMidtermComponents.SelectedItem = null;
            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Midterm;
            ViewModelLocator.StartMenuViewModel.AddNewComponent();
            ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
            ViewModelLocator.StartMenuViewModel.GetLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void BtnEditMidterm_Click(object sender, RoutedEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Midterm;
                ViewModelLocator.StartMenuViewModel.EditComponent();
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                ViewModelLocator.StartMenuViewModel.GetComponentFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetConvertedGrade();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnRemoveComponentMidterm_Click(object sender, RoutedEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Midterm;
                ViewModelLocator.StartMenuViewModel.RemoveComponent();
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void LvMidtermComponents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Midterm;
                ViewModelLocator.StartMenuViewModel.OpenGradingComponent();
            }
        }

        private void LvMidtermComponents_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LvMidtermComponents.SelectedItem != null)
            {
                LvMidtermComponents.SelectedItem = null;
            }
        }

        private void BtnAddComponentPrefinal_Click(object sender, RoutedEventArgs e)
        {
            LvPrefinalComponents.SelectedItem = null;
            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prefi;
            ViewModelLocator.StartMenuViewModel.AddNewComponent();
            ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
            ViewModelLocator.StartMenuViewModel.GetLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void BtnChangePercentEffectPrefinal_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prefi;
            ViewModelLocator.StartMenuViewModel.ChangePercentEffect();
            ViewModelLocator.StartMenuViewModel.GetDecimalEffect();
            ViewModelLocator.StartMenuViewModel.GetFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
            ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
            ViewModelLocator.StartMenuViewModel.GetQPIComponent();
            ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
        }

        private void BtnEditPrefinal_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prefi;
                ViewModelLocator.StartMenuViewModel.EditComponent();
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                ViewModelLocator.StartMenuViewModel.GetComponentFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetConvertedGrade();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnRemoveComponentPrefinal_Click(object sender, RoutedEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prefi;
                ViewModelLocator.StartMenuViewModel.RemoveComponent();
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                ViewModelLocator.StartMenuViewModel.GetGradingPeriodGrade();
                ViewModelLocator.StartMenuViewModel.GetLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassFinalGrade();
                ViewModelLocator.StartMenuViewModel.GetClassLetterGrade();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void LvPrefinalComponents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass.Prefi;
                ViewModelLocator.StartMenuViewModel.OpenGradingComponent();
            }
        }

        private void LvPrefinalComponents_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LvPrefinalComponents.SelectedItem != null)
            {
                LvPrefinalComponents.SelectedItem = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new NotesWindow();
            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass;

            window.Show();
            this.Hide();
        }    
    }
}
