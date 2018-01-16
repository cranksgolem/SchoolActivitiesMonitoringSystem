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

            var semID = SemesterSelectWindow.selectedSemesterID;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Subject_Code, Description, Schedule, Units, Grade, SemID, Subject_ID, PrelimPercent, MidtermPercent, PrefiPercent   From [SUBJECT]", con);

            DataTable dt = new DataTable();
            sda2.Fill(dt);

            LbClassList.Items.Clear();
            TblMaxUnits.Text = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.MaxUnits.ToString();
            usedUnits = 0;

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (Convert.ToInt16(dt.Rows[x]["SemID"]) == semID)
                {
                    SUBJECT newClass = new SUBJECT();

                    newClass.Description = dt.Rows[x]["Description"].ToString();
                    newClass.Schedule = dt.Rows[x]["Schedule"].ToString();
                    newClass.Units = Convert.ToInt16(dt.Rows[x]["Units"]);
                    newClass.SubjectCode = dt.Rows[x]["Subject_Code"].ToString();
                    newClass.SubjectID = Convert.ToInt16(dt.Rows[x]["Subject_ID"]);
                    newClass.PrelimPercent = Convert.ToInt16(dt.Rows[x]["PrelimPercent"]);
                    newClass.MidtermPercent = Convert.ToInt16(dt.Rows[x]["MidtermPercent"]);
                    newClass.PrefiPercent = Convert.ToInt16(dt.Rows[x]["PrefiPercent"]);

                    LbClassList.Items.Add(newClass);
                    usedUnits += newClass.Units;
                }

            }
            TblUsedUnits.Text = usedUnits.ToString();
        }

        public static int usedUnits;
        public static SUBJECT selectedSubject;

        private void BtnAddClass_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddClassWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

        

            var result = window.ShowDialog();

            if (result == true)
            {
                var semID = SemesterSelectWindow.selectedSemesterID;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Subject_Code, Description, Schedule, Units, Grade, SemID, Subject_ID   From [SUBJECT]", con);

                DataTable dt = new DataTable();
                sda2.Fill(dt);

                LbClassList.Items.Clear();
                TblMaxUnits.Text = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.MaxUnits.ToString();
                usedUnits = 0;

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    if (Convert.ToInt16(dt.Rows[x]["SemID"]) == semID)
                    {
                        SUBJECT newClass = new SUBJECT();

                        newClass.Description = dt.Rows[x]["Description"].ToString();
                        newClass.Schedule = dt.Rows[x]["Schedule"].ToString();
                        newClass.Units = Convert.ToInt16(dt.Rows[x]["Units"]);
                        newClass.SubjectCode = dt.Rows[x]["Subject_Code"].ToString();
                        newClass.SubjectID = Convert.ToInt16(dt.Rows[x]["Subject_ID"]);
                        newClass.PrelimPercent = Convert.ToInt16(dt.Rows[x]["PrelimPercent"]);
                        newClass.MidtermPercent = Convert.ToInt16(dt.Rows[x]["MidtermPercent"]);
                        newClass.PrefiPercent = Convert.ToInt16(dt.Rows[x]["PrefiPercent"]);

                        LbClassList.Items.Add(newClass);
                        usedUnits += newClass.Units;
                    }

                }
                TblUsedUnits.Text = usedUnits.ToString();

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
                //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.ListClasses.Remove(ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedClass);
                //ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.NumberClass -= 1;
                //ViewModelLocator.StartMenuViewModel.GetSemesterTotalUsedUnits();
                //ViewModelLocator.StartMenuViewModel.GetQPIComponent();
                //ViewModelLocator.StartMenuViewModel.GetSemesterQPI();
            }
        }

        private void BtnEnterClass_Click(object sender, RoutedEventArgs e)
        {
            if (LbClassList.SelectedItem != null)
            {
                selectedSubject = LbClassList.SelectedItem as SUBJECT;
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
