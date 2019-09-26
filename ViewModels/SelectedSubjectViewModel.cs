using I_Need_That_A;
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
    public class SelectedSubjectViewModel : INotifyPropertyChanged
    {
        private double _prelimPercent;
        private double _midtermPercent;
        private double _prefiPercent;
        private double _prelimPercentToDecimal;
        private double _midtermPercentToDecimal;
        private double _prefiPercentToDecimal;
        private ObservableCollection<ACTIVITY> _prelimListActivity = new ObservableCollection<ACTIVITY>();
        private ObservableCollection<ACTIVITY> _midtermListActivity = new ObservableCollection<ACTIVITY>();
        private ObservableCollection<ACTIVITY> _prefiListActivity = new ObservableCollection<ACTIVITY>();
        public ACTIVITY SelectedActivity { get; set; }
        public bool IsEdit { get; set; }
        private string _subjectName;
        private double _prelimComponentsPercentTotal;
        private double _midtermComponentsPercentTotal;
        private double _prefiComponentsPercentTotal;
        private double _prelimGrade;
        private double _midtermGrade;
        private double _prefiGrade;
        private string _prelimLetterGrade;
        private string _midtermLetterGrade;
        private string _prefiLetterGrade;
        private double _prelimConvertedGrade;
        private double _midtermConvertedGrade;
        private double _prefiConvertedGrade;
        private double _finalGrade;
        private string _finalLetterGrade;

        public string FinalLetterGrade
        {
            get { return _finalLetterGrade; }
            set
            {
                _finalLetterGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FinalLetterGrade"));
            }
        }

        public double FinalGrade
        {
            get { return _finalGrade; }
            set
            {
                _finalGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FinalGrade"));
            }
        }

        public double PrefiConvertedGrade
        {
            get { return _prefiConvertedGrade; }
            set
            {
                _prefiConvertedGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrefiConvertedGrade"));
            }
        }

        public double MidtermConvertedGrade
        {
            get { return _midtermConvertedGrade; }
            set
            {
                _midtermConvertedGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MidtermConvertedGrade"));
            }
        }

        public double PrelimConvertedGrade
        {
            get { return _prelimConvertedGrade; }
            set
            {
                _prelimConvertedGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrelimConvertedGrade"));
            }
        }

        public double PrefiPercentToDecimal
        {
            get { return _prefiPercentToDecimal; }
            set
            {
                _prefiPercentToDecimal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrefiPercentToDecimal"));
            }
        }

        public double MidtermPercentToDecimal
        {
            get { return _midtermPercentToDecimal; }
            set
            {
                _midtermPercentToDecimal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MidtermPercentToDecimal"));
            }
        }

        public double PrelimPercentToDecimal
        {
            get { return _prelimPercentToDecimal; }
            set
            {
                _prelimPercentToDecimal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrelimPercentToDecimal"));
            }
        }

        public string PrefiLetterGrade
        {
            get { return _prefiLetterGrade; }
            set
            {
                _prefiLetterGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrefiLetterGrade"));
            }
        }

        public string MidtermLetterGrade
        {
            get { return _midtermLetterGrade; }
            set
            {
                _midtermLetterGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MidtermLetterGrade"));
            }
        }

        public string PrelimLetterGrade
        {
            get { return _prelimLetterGrade; }
            set
            {
                _prelimLetterGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrelimLetterGrade"));
            }
        }

        public double PrefiGrade
        {
            get { return _prefiGrade; }
            set
            {
                _prefiGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrefiGrade"));
            }
        }

        public double MidtermGrade
        {
            get { return _midtermGrade; }
            set
            {
                _midtermGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MidtermGrade"));
            }
        }

        public double PrelimGrade
        {
            get { return _prelimGrade; }
            set
            {
                _prelimGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrelimGrade"));
            }
        }

        public double PrefiComponentsPercentTotal
        {
            get { return _prefiComponentsPercentTotal; }
            set
            {
                _prefiComponentsPercentTotal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrefiComponentsPercentTotal"));
            }
        }

        public double MidtermComponentsPercentTotal
        {
            get { return _midtermComponentsPercentTotal; }
            set
            {
                _midtermComponentsPercentTotal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MidtermComponentsPercentTotal"));
            }
        }

        public double PrelimComponentsPercentTotal
        {
            get { return _prelimComponentsPercentTotal; }
            set
            {
                _prelimComponentsPercentTotal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrelimComponentsPercentTotal"));
            }
        }

        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SubjectName"));
            }
        }

        public ObservableCollection<ACTIVITY> PrelimListActivity
        {
            get { return _prelimListActivity; }
            set { _prelimListActivity = value; }
        }

        public ObservableCollection<ACTIVITY> MidtermListActivity
        {
            get { return _midtermListActivity; }
            set { _midtermListActivity = value; }
        }

        public ObservableCollection<ACTIVITY> PrefiListActivity
        {
            get { return _prefiListActivity; }
            set { _prefiListActivity = value; }
        }

        public double PrelimPercent
        {
            get { return _prelimPercent; }
            set
            {
                _prelimPercent = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrelimPercent"));
            }
        }

        public double MidtermPercent
        {
            get { return _midtermPercent; }
            set
            {
                _midtermPercent = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MidtermPercent"));
            }
        }
        public double PrefiPercent
        {
            get { return _prefiPercent; }
            set
            {
                _prefiPercent = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrefiPercent"));
            }
        }

        public int SelectedGradingPeriod { get; set; }

        public void SetPercentages()
        {
            PrelimPercent = ViewModelLocator.SubjectsListViewModel.SelectedSubject.PrelimPercent;
            MidtermPercent = ViewModelLocator.SubjectsListViewModel.SelectedSubject.MidtermPercent;
            PrefiPercent = ViewModelLocator.SubjectsListViewModel.SelectedSubject.PrefiPercent;

            PrelimPercentToDecimal = PrelimPercent / 100;
            MidtermPercentToDecimal = MidtermPercent / 100;
            PrefiPercentToDecimal = PrefiPercent / 100;
        }

        public void ComputeConvertedGrades()
        {
            if (PrelimComponentsPercentTotal == 100)
            {
                PrelimConvertedGrade = PrelimGrade * PrelimPercentToDecimal;
            }
            else
            {
                PrelimConvertedGrade = 0;
            }

            if (MidtermComponentsPercentTotal == 100)
            {
                MidtermConvertedGrade = MidtermGrade * MidtermPercentToDecimal;
            }
            else
            {
                MidtermConvertedGrade = 0;
            }

            if (PrefiComponentsPercentTotal == 100)
            {
                PrefiConvertedGrade = PrefiGrade * PrefiPercentToDecimal;
            }
            else
            {
                PrefiConvertedGrade = 0;
            }

            FinalGrade = PrelimConvertedGrade + MidtermConvertedGrade + PrefiConvertedGrade;

            if (FinalGrade <= 71.49)
            {
                FinalLetterGrade = "F";
            }

            else if (FinalGrade > 71.49 && FinalGrade <= 75.49)
            {
                FinalLetterGrade = "D";
            }

            else if (FinalGrade > 75.49 && FinalGrade <= 79.49)
            {
                FinalLetterGrade = "C";
            }

            else if (FinalGrade > 79.49 && FinalGrade <= 83.49)
            {
                FinalLetterGrade = "C+";
            }

            else if (FinalGrade > 83.49 && FinalGrade <= 87.49)
            {
                FinalLetterGrade = "B";
            }

            else if (FinalGrade > 87.49 && FinalGrade <= 91.49)
            {
                FinalLetterGrade = "B+";
            }

            else if (FinalGrade > 91.49)
            {
                FinalLetterGrade = "A";
            }

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SUBJECT] SET Grade=@Grade WHERE Subject_ID=@Subject_ID", con);
            command.Parameters.AddWithValue("@Grade", FinalGrade);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();
            
        }

        public void GetAndDisplayActivities()
        {
            PrelimComponentsPercentTotal = 0;
            MidtermComponentsPercentTotal = 0;
            PrefiComponentsPercentTotal = 0;
            PrelimGrade = 0;
            MidtermGrade = 0;
            PrefiGrade = 0;
            PrelimListActivity.Clear();
            MidtermListActivity.Clear();
            PrefiListActivity.Clear();
            SubjectName = ViewModelLocator.SubjectsListViewModel.SelectedSubject.Description;

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [ACTIVITY] WHERE Subject_ID='" + ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID + "'", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                ACTIVITY newActivity = new ACTIVITY();

                newActivity.ActivityID = Convert.ToInt16(dt.Rows[x]["ActivityID"]);
                newActivity.Activity = dt.Rows[x]["Activity"].ToString();
                newActivity.Grade = Convert.ToDouble(dt.Rows[x]["Grade"]);
                newActivity.GradingPeriod = dt.Rows[x]["Grading_Period"].ToString();
                newActivity.Percentage = Convert.ToDouble(dt.Rows[x]["Percentage"]);
                newActivity.SubjectID = Convert.ToInt16(dt.Rows[x]["Subject_ID"]);

                if (newActivity.GradingPeriod == "Prelim")
                {
                    PrelimListActivity.Add(newActivity);
                    PrelimComponentsPercentTotal += newActivity.Percentage;
                    PrelimGrade += newActivity.Grade;
                }

                if (newActivity.GradingPeriod == "Midterm")
                {
                    MidtermListActivity.Add(newActivity);
                    MidtermComponentsPercentTotal += newActivity.Percentage;
                    MidtermGrade += newActivity.Grade;
                }

                if (newActivity.GradingPeriod == "Prefi")
                {
                    PrefiListActivity.Add(newActivity);
                    PrefiComponentsPercentTotal += newActivity.Percentage;
                    PrefiGrade += newActivity.Grade;
                }
            }

            GetLetterGrade();
            ComputeConvertedGrades();
        }

        public double GetTotalPercentage(int indicator)
        {
            double totalPercentage = 0;
            if (indicator == 0)
            {
                for (int x = 0; x < PrelimListActivity.Count; x++)
                {
                    if (IsEdit == true && PrelimListActivity[x].ActivityID != SelectedActivity.ActivityID)
                    {
                        totalPercentage += PrelimListActivity[x].Percentage;
                    }
                    else if (IsEdit == false)
                    {
                        totalPercentage += PrelimListActivity[x].Percentage;
                    }
                }
            }

            else if (indicator == 1)
            {
                for (int x = 0; x < MidtermListActivity.Count; x++)
                {
                    if (IsEdit == true && MidtermListActivity[x].ActivityID != SelectedActivity.ActivityID)
                    {
                        totalPercentage += MidtermListActivity[x].Percentage;
                    }
                    else if (IsEdit == false)
                    {
                        totalPercentage += MidtermListActivity[x].Percentage;
                    }
                }
            }

            else if (indicator == 2)
            {
                for (int x = 0; x < PrefiListActivity.Count; x++)
                {
                    if (IsEdit == true && PrefiListActivity[x].ActivityID != SelectedActivity.ActivityID)
                    {
                        totalPercentage += PrefiListActivity[x].Percentage;
                    }
                    else if (IsEdit == false)
                    {
                        totalPercentage += PrefiListActivity[x].Percentage;
                    }
                }
            }

            return totalPercentage;
        }

        public void ChangePrelimPercent(double newPercent)
        {
            PrelimPercent = newPercent;

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SUBJECT] SET PrelimPercent=@PrelimPercent WHERE Subject_ID=@Subject_ID", con);
            command.Parameters.AddWithValue("@PrelimPercent", newPercent);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();

            PrelimPercentToDecimal = PrelimPercent / 100;
            GetAndDisplayActivities();
        }

        public void ChangeMidtermPercent(double newPercent)
        {
            MidtermPercent = newPercent;

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SUBJECT] SET MidtermPercent=@MidtermPercent WHERE Subject_ID=@Subject_ID", con);
            command.Parameters.AddWithValue("@MidtermPercent", newPercent);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();

            MidtermPercentToDecimal = MidtermPercent / 100;
            GetAndDisplayActivities();
        }

        public void ChangePrefiPercent(double newPercent)
        {
            PrefiPercent = newPercent;

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SUBJECT] SET PrefiPercent=@PrefiPercent WHERE Subject_ID=@Subject_ID", con);
            command.Parameters.AddWithValue("@PrefiPercent", newPercent);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();

            PrefiPercentToDecimal = PrefiPercent / 100;
            GetAndDisplayActivities();
        }

        public void EditActivity(ACTIVITY changedActivity)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [ACTIVITY] SET Activity=@Activity, Percentage=@Percentage WHERE ActivityID=@ActivityID", con);
            command.Parameters.AddWithValue("@Activity", changedActivity.Activity);
            command.Parameters.AddWithValue("@Percentage", changedActivity.Percentage);
            command.Parameters.AddWithValue("@ActivityID", ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.ActivityID);
            command.ExecuteNonQuery();
            con.Close();

            ViewModelLocator.ScoresListViewModel.ComputeConvertedGrade();
            GetAndDisplayActivities();
        }

        public void RemoveActivity()
        {
            if (SelectedActivity != null && (SelectedGradingPeriod == 0 && SelectedActivity.GradingPeriod == "Prelim") || (SelectedGradingPeriod == 1 && SelectedActivity.GradingPeriod == "Midterm") || (SelectedGradingPeriod == 2 && SelectedActivity.GradingPeriod == "Prefi"))
            {
                SqlConnection con = GeneralMethods.ConnectToDatabase();
                SqlCommand command = new SqlCommand("DELETE FROM [ACTIVITY] WHERE ActivityID=@ActivityID", con);
                command.Parameters.AddWithValue("@ActivityID", SelectedActivity.ActivityID);
                command.ExecuteNonQuery();
                con.Close();

                GetAndDisplayActivities();
            }
        }

        public void AddActivity(ACTIVITY newActivity)
        {
            string gradingPeriod = "";

            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 0)
            {
                gradingPeriod = "Prelim";
            }

            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 1)
            {
                gradingPeriod = "Midterm";
            }

            if (ViewModelLocator.SelectedSubjectViewModel.SelectedGradingPeriod == 2)
            {
                gradingPeriod = "Prefi";
            }

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("INSERT INTO [ACTIVITY] (Activity, Percentage, Subject_ID, Grading_Period, Grade) VALUES (@Activity, @Percentage, @Subject_ID, @Grading_Period, @Grade)", con);
            command.Parameters.AddWithValue("@Activity", newActivity.Activity);
            command.Parameters.AddWithValue("@Percentage", newActivity.Percentage);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.Parameters.AddWithValue("@Grading_Period", gradingPeriod);
            command.Parameters.AddWithValue("@Grade", 0);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplayActivities();
        }

        public void GetLetterGrade()
        {
            if (PrelimComponentsPercentTotal == 100)
            {
                if (PrelimGrade <= 71.49)
                {
                    PrelimLetterGrade = "F";
                }

                else if (PrelimGrade > 71.49 && PrelimGrade <= 75.49)
                {
                    PrelimLetterGrade = "D";
                }

                else if (PrelimGrade > 75.49 && PrelimGrade <= 79.49)
                {
                    PrelimLetterGrade = "C";
                }

                else if (PrelimGrade > 79.49 && PrelimGrade <= 83.49)
                {
                    PrelimLetterGrade = "C+";
                }

                else if (PrelimGrade > 83.49 && PrelimGrade <= 87.49)
                {
                    PrelimLetterGrade = "B";
                }

                else if (PrelimGrade > 87.49 && PrelimGrade <= 91.49)
                {
                    PrelimLetterGrade = "B+";
                }

                else if (PrelimGrade > 91.49)
                {
                    PrelimLetterGrade = "A";
                }
            }
            else
            {
                PrelimLetterGrade = "-";
            }

            if (MidtermComponentsPercentTotal == 100)
            {
                if (MidtermGrade <= 71.49)
                {
                    MidtermLetterGrade = "F";
                }

                else if (MidtermGrade > 71.49 && MidtermGrade <= 75.49)
                {
                    MidtermLetterGrade = "D";
                }

                else if (MidtermGrade > 75.49 && MidtermGrade <= 79.49)
                {
                    MidtermLetterGrade = "C";
                }

                else if (MidtermGrade > 79.49 && MidtermGrade <= 83.49)
                {
                    MidtermLetterGrade = "C+";
                }

                else if (MidtermGrade > 83.49 && MidtermGrade <= 87.49)
                {
                    MidtermLetterGrade = "B";
                }

                else if (MidtermGrade > 87.49 && MidtermGrade <= 91.49)
                {
                    MidtermLetterGrade = "B+";
                }

                else if (MidtermGrade > 91.49)
                {
                    MidtermLetterGrade = "A";
                }
            }
            else
            {
                MidtermLetterGrade = "-";
            }

            if (PrefiComponentsPercentTotal == 100)
            {
                if (PrefiGrade <= 71.49)
                {
                    PrefiLetterGrade = "F";
                }

                else if (PrefiGrade > 71.49 && PrefiGrade <= 75.49)
                {
                    PrefiLetterGrade = "D";
                }

                else if (PrefiGrade > 75.49 && PrefiGrade <= 79.49)
                {
                    PrefiLetterGrade = "C";
                }

                else if (PrefiGrade > 79.49 && PrefiGrade <= 83.49)
                {
                    PrefiLetterGrade = "C+";
                }

                else if (PrefiGrade > 83.49 && PrefiGrade <= 87.49)
                {
                    PrefiLetterGrade = "B";
                }

                else if (PrefiGrade > 87.49 && PrefiGrade <= 91.49)
                {
                    PrefiLetterGrade = "B+";
                }

                else if (PrefiGrade > 91.49)
                {
                    PrefiLetterGrade = "A";
                }
            }
            else
            {
                PrefiLetterGrade = "-";
            }

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SUBJECT] SET PrelimLetterGrade=@PrelimLetterGrade, MidtermLetterGrade=@MidtermLetterGrade, PrefiLetterGrade=@PrefiLetterGrade WHERE Subject_ID=@Subject_ID", con);
            command.Parameters.AddWithValue("@PrelimLetterGrade", PrelimLetterGrade);
            command.Parameters.AddWithValue("@MidtermLetterGrade", MidtermLetterGrade);
            command.Parameters.AddWithValue("@PrefiLetterGrade", PrefiLetterGrade);
            command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void CopyComponents(string from, string to)
        {
            if (from == "prelim" && to == "both")
            {
                SqlConnection con = GeneralMethods.ConnectToDatabase();
                SqlCommand command = new SqlCommand("DELETE FROM [ACTIVITY] WHERE Subject_ID=@Subject_ID, Grading_Period=@Grading_Period", con);
                command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
                command.Parameters.AddWithValue("@Grading_Period", "midterm");
                command.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand command2 = new SqlCommand("DELETE FROM [ACTIVITY] WHERE Subject_ID=@Subject_ID, Grading_Period=@Grading_Period", con);
                command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
                command.Parameters.AddWithValue("@Grading_Period", "prefi");
                command.ExecuteNonQuery();
                con.Close();

                con.Open();

                for (int x = 0; x < PrelimListActivity.Count; x++)
                {
                    SqlCommand command3 = new SqlCommand("INSERT INTO [ACTIVITY] (Activity, Percentage, Subject_ID, Grading_Period, Grading_Type, Grade) VALUES (@Activity, @Percentage, @Subject_ID, @Grading_Period, @Grading_Type, @Grade)", con);
                    command.Parameters.AddWithValue("@Activity", PrelimListActivity[x].Activity);
                    command.Parameters.AddWithValue("@Percentage", PrelimListActivity[x].Percentage);
                    command.Parameters.AddWithValue("@Subject_ID", PrelimListActivity[x].SubjectID);
                    command.Parameters.AddWithValue("@Grading_Period", "midterm");
                    command.Parameters.AddWithValue("@Grade", 0);
                    command.ExecuteNonQuery();     
                }
                con.Close();

                con.Open();

                for (int x = 0; x < PrelimListActivity.Count; x++)
                {
                    SqlCommand command3 = new SqlCommand("INSERT INTO [ACTIVITY] (Activity, Percentage, Subject_ID, Grading_Period, Grading_Type, Grade) VALUES (@Activity, @Percentage, @Subject_ID, @Grading_Period, @Grading_Type, @Grade)", con);
                    command.Parameters.AddWithValue("@Activity", PrelimListActivity[x].Activity);
                    command.Parameters.AddWithValue("@Percentage", PrelimListActivity[x].Percentage);
                    command.Parameters.AddWithValue("@Subject_ID", PrelimListActivity[x].SubjectID);
                    command.Parameters.AddWithValue("@Grading_Period", "prefi");
                    command.Parameters.AddWithValue("@Grade", 0);
                    command.ExecuteNonQuery();
                }
                con.Close();

                GetAndDisplayActivities();
            }

            if (from == "prelim" && to == "midterm")
            {
                SqlConnection con = GeneralMethods.ConnectToDatabase();
                SqlCommand command = new SqlCommand("DELETE FROM [ACTIVITY] WHERE Subject_ID=@Subject_ID, Grading_Period=@Grading_Period", con);
                command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
                command.Parameters.AddWithValue("@Grading_Period", "midterm");
                command.ExecuteNonQuery();
                con.Close();

                con.Open();

                for (int x = 0; x < PrelimListActivity.Count; x++)
                {
                    SqlCommand command3 = new SqlCommand("INSERT INTO [ACTIVITY] (Activity, Percentage, Subject_ID, Grading_Period, Grading_Type, Grade) VALUES (@Activity, @Percentage, @Subject_ID, @Grading_Period, @Grading_Type, @Grade)", con);
                    command.Parameters.AddWithValue("@Activity", PrelimListActivity[x].Activity);
                    command.Parameters.AddWithValue("@Percentage", PrelimListActivity[x].Percentage);
                    command.Parameters.AddWithValue("@Subject_ID", PrelimListActivity[x].SubjectID);
                    command.Parameters.AddWithValue("@Grading_Period", "midterm");
                    command.Parameters.AddWithValue("@Grade", 0);
                    command.ExecuteNonQuery();
                }
                con.Close();

                GetAndDisplayActivities();
            }

            if (from == "prelim" && to == "prefi")
            {
                SqlConnection con = GeneralMethods.ConnectToDatabase();
                SqlCommand command = new SqlCommand("DELETE FROM [ACTIVITY] WHERE Subject_ID=@Subject_ID, Grading_Period=@Grading_Period", con);
                command.Parameters.AddWithValue("@Subject_ID", ViewModelLocator.SubjectsListViewModel.SelectedSubject.SubjectID);
                command.Parameters.AddWithValue("@Grading_Period", "prefi");
                command.ExecuteNonQuery();
                con.Close();

                con.Open();

                for (int x = 0; x < PrelimListActivity.Count; x++)
                {
                    SqlCommand command3 = new SqlCommand("INSERT INTO [ACTIVITY] (Activity, Percentage, Subject_ID, Grading_Period, Grading_Type, Grade) VALUES (@Activity, @Percentage, @Subject_ID, @Grading_Period, @Grading_Type, @Grade)", con);
                    command.Parameters.AddWithValue("@Activity", PrelimListActivity[x].Activity);
                    command.Parameters.AddWithValue("@Percentage", PrelimListActivity[x].Percentage);
                    command.Parameters.AddWithValue("@Subject_ID", PrelimListActivity[x].SubjectID);
                    command.Parameters.AddWithValue("@Grading_Period", "prefi");
                    command.Parameters.AddWithValue("@Grade", 0);
                    command.ExecuteNonQuery();
                }
                con.Close();

                GetAndDisplayActivities();
            }
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

        public SelectedSubjectViewModel()
        {
            
        }
    }
}
