using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS.ViewModels
{
    public class SemesterSelectViewModel
    {
        private ObservableCollection<SEMESTER> _listSemesters = new ObservableCollection<SEMESTER>();

        public SEMESTER SelectedSemester { get; set; }
        public ObservableCollection<SEMESTER> ListSemesters
        {
            get { return _listSemesters; }
            set { _listSemesters = value; }
        }

        public SemesterSelectViewModel()
        {
            GetAndDisplaySemesters();
        }

        public void PuclibGetAndDisplaySemesters()
        {
            GetAndDisplaySemesters();
        }

        private void GetAndDisplaySemesters()
        {
            ListSemesters.Clear();

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [SEMESTER] WHERE UserID='" + ViewModelLocator.MainWindowViewModel.SelectedUser.UserID +"'", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                SEMESTER newSemester = new SEMESTER();

                newSemester.SemesterName = dt.Rows[x]["Semester_Name"].ToString();
                newSemester.MaxUnits = Convert.ToInt16(dt.Rows[x]["Max_Units"]);
                newSemester.Schoolyear = dt.Rows[x]["Schoolyear"].ToString();
                newSemester.SemID = Convert.ToInt16(dt.Rows[x]["SemID"]);

                ListSemesters.Add(newSemester);
            }
        }

        public void AddNewSemester (SEMESTER newSemester)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("INSERT INTO [SEMESTER] (Semester_Name, Max_Units, Schoolyear, UserID) VALUES (@Semester_Name, @Max_Units, @Schoolyear, @UserID)", con);
            command.Parameters.AddWithValue("@Semester_Name", newSemester.SemesterName);
            command.Parameters.AddWithValue("@Max_Units", newSemester.MaxUnits);
            command.Parameters.AddWithValue("@Schoolyear", newSemester.Schoolyear);
            command.Parameters.AddWithValue("@UserID", ViewModelLocator.MainWindowViewModel.SelectedUser.UserID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplaySemesters();
        }

        public void RemoveSemester()
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("DELETE FROM [SEMESTER] WHERE SemID=@semID", con);
            command.Parameters.AddWithValue("@semID", SelectedSemester.SemID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplaySemesters();
        }
    }
}
