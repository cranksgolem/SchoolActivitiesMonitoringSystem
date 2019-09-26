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
    public class GradesWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SUBJECT> _listSubjects = new ObservableCollection<SUBJECT>();
        private double _qpi;

        public double QPI
        {
            get { return _qpi; }
            set
            {
                _qpi = value;
                OnPropertyChanged(new PropertyChangedEventArgs("QPI"));
            }
        }

        public ObservableCollection<SUBJECT> ListSubjects
        {
            get { return _listSubjects; }
            set { _listSubjects = value; }
        }

        public void ComputeQPI()
        {
            double totalRawScore = 0;
            double totalUnits = 0;

            for (int x = 0; x < ListSubjects.Count; x++)
            {
                double numericalEquivalent = 0;

                if (ListSubjects[x].FinalLetterGrade == "A")
                {
                    numericalEquivalent = 4;
                }

                else if (ListSubjects[x].FinalLetterGrade == "B+")
                {
                    numericalEquivalent = 3.5;
                }

                else if (ListSubjects[x].FinalLetterGrade == "B")
                {
                    numericalEquivalent = 3;
                }

                else if (ListSubjects[x].FinalLetterGrade == "C+")
                {
                    numericalEquivalent = 2.5;
                }

                else if (ListSubjects[x].FinalLetterGrade == "C")
                {
                    numericalEquivalent = 2;
                }

                else if (ListSubjects[x].FinalLetterGrade == "D")
                {
                    numericalEquivalent = 1;
                }

                else if (ListSubjects[x].FinalLetterGrade == "F")
                {
                    numericalEquivalent = 0;
                }

                totalUnits = totalUnits + ListSubjects[x].Units;

                double addToRawScore = numericalEquivalent * (ListSubjects[x].Units);

                totalRawScore = totalRawScore + addToRawScore;
            }

            QPI = totalRawScore / totalUnits;
        }

        public void GetAndDisplayGrades()
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
                newSubject.Grade = Convert.ToDouble(dt.Rows[x]["Grade"]);
                newSubject.PrelimLetterGrade = dt.Rows[x]["PrelimLetterGrade"].ToString();
                newSubject.MidtermLetterGrade = dt.Rows[x]["MidtermLetterGrade"].ToString();
                newSubject.PrefiLetterGrade = dt.Rows[x]["PrefiLetterGrade"].ToString();
                newSubject.Units = Convert.ToInt16(dt.Rows[x]["Units"]);

                if (newSubject.Grade <= 71.49)
                {
                    newSubject.FinalLetterGrade = "F";
                }

                else if (newSubject.Grade > 71.49 && newSubject.Grade <= 75.49)
                {
                    newSubject.FinalLetterGrade = "D";
                }

                else if (newSubject.Grade > 75.49 && newSubject.Grade <= 79.49)
                {
                    newSubject.FinalLetterGrade = "C";
                }

                else if (newSubject.Grade > 79.49 && newSubject.Grade <= 83.49)
                {
                    newSubject.FinalLetterGrade = "C+";
                }

                else if (newSubject.Grade > 83.49 && newSubject.Grade <= 87.49)
                {
                    newSubject.FinalLetterGrade = "B";
                }

                else if (newSubject.Grade > 87.49 && newSubject.Grade <= 91.49)
                {
                    newSubject.FinalLetterGrade = "B+";
                }

                else if (newSubject.Grade > 91.49)
                {
                    newSubject.FinalLetterGrade = "A";
                }

                ListSubjects.Add(newSubject);
            }

            ComputeQPI();
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
