using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS.ViewModels
{
    public class SubjectsListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SUBJECT> _listSubjects = new ObservableCollection<SUBJECT>();
        private int _usedUnits;

        public SUBJECT SelectedSubject { get; set; }
        public ObservableCollection<SUBJECT> ListSubjects
        {
            get { return _listSubjects; }
            set { _listSubjects = value; }
        }

        public int MaxUnits { get; set; }
        public int UsedUnits
        {
            get { return _usedUnits; }
            set { _usedUnits = value;
            OnPropertyChanged(new PropertyChangedEventArgs("UsedUnits"));
            }
        }

        public SubjectsListViewModel()
        {
            GetAndDisplaySubjects();
        }

        public void PublicGetAndDisplaySubjects()
        {
            GetAndDisplaySubjects();
        }

        public int ComputeMaxUnits()
        {
            int maxUnits = 0;

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [SUBJECT] WHERE SemID='" + ViewModelLocator.SemesterSelectViewModel.SelectedSemester.SemID + "'", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                maxUnits = maxUnits + Convert.ToInt16(dt.Rows[x]["Units"]);
            }

            return maxUnits;
        }

        public void AddNewSubject(SUBJECT newSubject)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("INSERT INTO [SUBJECT] (Subject_Code, Description, Schedule, Units, SemID, PrelimPercent, MidtermPercent, PrefiPercent, Base, Grade, PrelimLetterGrade, MidtermLetterGrade, PrefiLetterGrade) VALUES (@Subject_Code, @Description, @Schedule, @Units, @SemID, @PrelimPercent, @MidtermPercent, @PrefiPercent, @Base, @Grade, @PrelimLetterGrade, @MidtermLetterGrade, @PrefiLetterGrade)", con);
            command.Parameters.AddWithValue("@Subject_Code", newSubject.SubjectCode);
            command.Parameters.AddWithValue("@Description", newSubject.Description);
            command.Parameters.AddWithValue("@Schedule", newSubject.Schedule);
            command.Parameters.AddWithValue("@Units", newSubject.Units);
            command.Parameters.AddWithValue("@SemID", ViewModelLocator.SemesterSelectViewModel.SelectedSemester.SemID);
            command.Parameters.AddWithValue("@PrelimPercent", 0);
            command.Parameters.AddWithValue("@MidtermPercent", 0);
            command.Parameters.AddWithValue("@PrefiPercent", 0);
            command.Parameters.AddWithValue("@Grade", 0);
            command.Parameters.AddWithValue("@PrelimLetterGrade", "-");
            command.Parameters.AddWithValue("@MidtermLetterGrade", "-");
            command.Parameters.AddWithValue("@PrefiLetterGrade", "-");
            command.Parameters.AddWithValue("@Base", newSubject.Base);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplaySubjects();
        }

        public void DeleteSubject()
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("DELETE FROM [SUBJECT] WHERE Subject_ID=@SubjectID", con);
            command.Parameters.AddWithValue("@SubjectID", SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplaySubjects();
        }

        public void EditSubject(SUBJECT changedSubject)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SUBJECT] SET Subject_Code=@Subject_Code, Description=@Description, Schedule=@Schedule, Units=@Units, Base=@Base WHERE Subject_ID=@Subject_ID",  con);
            command.Parameters.AddWithValue("@Subject_Code", changedSubject.SubjectCode);
            command.Parameters.AddWithValue("@Description", changedSubject.Description);
            command.Parameters.AddWithValue("@Schedule", changedSubject.Schedule);
            command.Parameters.AddWithValue("@Units", changedSubject.Units);
            command.Parameters.AddWithValue("@Base", changedSubject.Base);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplaySubjects();
        }

        private void GetAndDisplaySubjects()
        {
            ListSubjects.Clear();

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [SUBJECT] WHERE SemID='" + ViewModelLocator.SemesterSelectViewModel.SelectedSemester.SemID + "'", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                SUBJECT newSubject = new SUBJECT();

                newSubject.Description = dt.Rows[x]["Description"].ToString();
                newSubject.PrelimPercent = Convert.ToDouble(dt.Rows[x]["PrelimPercent"]);
                newSubject.MidtermPercent = Convert.ToDouble(dt.Rows[x]["MidtermPercent"]);
                newSubject.PrefiPercent = Convert.ToDouble(dt.Rows[x]["PrefiPercent"]);
                newSubject.Schedule = dt.Rows[x]["Schedule"].ToString();
                newSubject.Units = Convert.ToInt16(dt.Rows[x]["Units"]);
                newSubject.SubjectCode = dt.Rows[x]["Subject_Code"].ToString();
                newSubject.SubjectID = Convert.ToInt16(dt.Rows[x]["Subject_ID"]);
                newSubject.SemID = Convert.ToInt16(dt.Rows[x]["SemID"]);
                newSubject.Base = Convert.ToDouble(dt.Rows[x]["Base"]);

                ListSubjects.Add(newSubject);
            }

            UsedUnits = ComputeMaxUnits();
            MaxUnits = ViewModelLocator.SemesterSelectViewModel.SelectedSemester.MaxUnits;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
