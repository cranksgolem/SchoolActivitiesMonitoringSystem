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
    public class ScoresListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SCORE> _listScores = new ObservableCollection<SCORE>();
        private double _totalItems;
        private double _totalScore;
        private double _grade;
        private double _convertedGrade;

        public double ConvertedGrade
        {
            get { return _convertedGrade; }
            set
            {
                _convertedGrade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConvertedGrade"));
            }
        }

        public double Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Grade"));
            }
        }

        public double TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TotalItems"));
            }
        }
        public double TotalScore
        {
            get { return _totalScore; }
            set
            {
                _totalScore = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TotalScore"));
            }
        }

        public ObservableCollection<SCORE> ListScores
        {
            get { return _listScores; }
            set { _listScores = value; }
        }

        public string ComponentName { get; set; }
        public SCORE SelectedScore { get; set; }

        public void AddNewScore(SCORE newScore)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("INSERT INTO [SCORE] (Score, Items, Date, ActivityID) VALUES (@Score, @Items, @Date, @ActivityID)", con);
            command.Parameters.AddWithValue("@Score", newScore.Score);
            command.Parameters.AddWithValue("@Items", newScore.Items);
            command.Parameters.AddWithValue("@Date", newScore.Date);
            command.Parameters.AddWithValue("@ActivityID", ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.ActivityID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplayScores();
        }

        public void ComputeTotalItemsAndScore()
        {
            TotalItems = 0;
            TotalScore = 0;

            for (int x = 0; x < ListScores.Count; x++)
            {
                TotalItems += ListScores[x].Items;
                TotalScore += ListScores[x].Score;
            }
        }

        public void ComputeGrade()
        {
            var bas = ViewModelLocator.SubjectsListViewModel.SelectedSubject.Base;
            double grade = TotalScore / TotalItems;
            grade = (grade * (100 - bas)) + bas;
            Grade = grade;
        }

        public double ComputeConvertedGrade()
        {
            if (ListScores.Count != 0)
            {
                ConvertedGrade = Grade * (ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.Percentage / 100);

                SqlConnection con = GeneralMethods.ConnectToDatabase();
                SqlCommand command = new SqlCommand("UPDATE [ACTIVITY] SET Grade=@Grade WHERE ActivityID=@ActivityID", con);
                command.Parameters.AddWithValue("@Grade", ConvertedGrade);
                command.Parameters.AddWithValue("@ActivityID", ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.ActivityID);
                command.ExecuteNonQuery();
                con.Close();

                ViewModelLocator.SelectedSubjectViewModel.GetAndDisplayActivities();

                return ConvertedGrade;
            }
            else
            {
                ConvertedGrade = 0;

                SqlConnection con = GeneralMethods.ConnectToDatabase();
                SqlCommand command = new SqlCommand("UPDATE [ACTIVITY] SET Grade=@Grade WHERE ActivityID=@ActivityID", con);
                command.Parameters.AddWithValue("@Grade", ConvertedGrade);
                command.Parameters.AddWithValue("@ActivityID", ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.ActivityID);
                command.ExecuteNonQuery();
                con.Close();

                ViewModelLocator.SelectedSubjectViewModel.GetAndDisplayActivities();

                return ConvertedGrade;
            }
        }

        public void EditScore(SCORE changedScore)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("UPDATE [SCORE] SET Score=@Score, Items=@Items, Date=@Date WHERE Id=@Id", con);
            command.Parameters.AddWithValue("@Score", changedScore.Score);
            command.Parameters.AddWithValue("@Items", changedScore.Items);
            command.Parameters.AddWithValue("@Date", changedScore.Date);
            command.Parameters.AddWithValue("@Id", ViewModelLocator.ScoresListViewModel.SelectedScore.ID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplayScores();
        }

        public void GetAndDisplayScores()
        {
            ListScores.Clear();
            ComponentName = ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.Activity;

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [SCORE] WHERE ActivityID='" + ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.ActivityID + "'", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                SCORE newScore = new SCORE();

                newScore.Date = Convert.ToDateTime(dt.Rows[x]["Date"]);
                newScore.Score = Convert.ToInt16(dt.Rows[x]["Score"]);
                newScore.Items = Convert.ToInt16(dt.Rows[x]["Items"]);
                newScore.ID = Convert.ToInt16(dt.Rows[x]["Id"]);

                ListScores.Add(newScore);
            }

            ComputeTotalItemsAndScore();
            ComputeGrade();
            if (ListScores.Count != 0)
            {
                ComputeConvertedGrade();
            }
            ViewModelLocator.SelectedSubjectViewModel.SelectedActivity.Grade = Grade;
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
