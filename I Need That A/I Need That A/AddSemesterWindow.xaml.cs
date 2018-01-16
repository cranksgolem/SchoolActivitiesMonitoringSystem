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
    /// Interaction logic for AddSemesterWindow.xaml
    /// </summary>
    public partial class AddSemesterWindow : Window
    {
        public AddSemesterWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxName.Text != "" && TbxUnits.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
                con.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("INSERT INTO [SEMESTER] (Semester_Name, Max_Units, Schoolyear, UserID) VALUES (@Semester_Name, @Max_Units, @Schoolyear, @UserID)", con);
                command.Parameters.AddWithValue("@Semester_Name", TbxName.Text);
                command.Parameters.AddWithValue("@Max_Units", TbxUnits.Text);
                command.Parameters.AddWithValue("@Schoolyear", TbxSchoolYear.Text);
                command.Parameters.AddWithValue("@UserID", ViewModelLocator.StartMenuViewModel.SelectedUser.UserID);
                command.ExecuteNonQuery();
                con.Close();
                DialogResult = true;
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
    }
}
