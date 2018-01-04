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
    /// Interaction logic for ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        public ClassWindow()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\Database1.mdf");
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Description, Schedule, Units From [SUBJECT]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                Class newClass = new Class();

                newClass.Name = dt.Rows[x]["Description"].ToString();
                newClass.DaySchedule = dt.Rows[x]["Schedule"].ToString();
                newClass.Units = Convert.ToDouble(dt.Rows[x]["Units"]);

                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ListClasses.Add(newClass);
            }
        }

        private void BtnAddClass_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddClassWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            Class newClass = new Class();
            window.DataContext = newClass;

            var result = window.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ListClasses.Add(newClass);
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.NumberClass += 1;
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }

            ViewModelLocator.StartMenuViewModel.GetSemesterTotalUsedUnits();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainUserWindow();
            window.Show();
            this.Close();
        }

        private void BtnRemoveClass_Click(object sender, RoutedEventArgs e)
        {
            if (LbClassList.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ListClasses.Remove(ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass);
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.NumberClass -= 1;
                ViewModelLocator.StartMenuViewModel.GetSemesterTotalUsedUnits();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnEnterClass_Click(object sender, RoutedEventArgs e)
        {
            if (LbClassList.SelectedItem != null)
            {
                var window = new SelectedClassWindow();
                window.backToClassList = true;
                window.Owner = this;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass;
                window.Show();
                this.Hide();
            }
        }

        private void BtnEditClass_Click(object sender, RoutedEventArgs e)
        {
            if (LbClassList.SelectedItem != null)
            {
                ViewModelLocator.StartMenuViewModel.EditClass();
                ViewModelLocator.StartMenuViewModel.GetSemesterTotalUsedUnits();
                ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void TextBlock_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Mouse.SetCursor(Cursors.Hand);
        }
    }
}
