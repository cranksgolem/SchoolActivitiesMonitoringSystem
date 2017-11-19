using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Need_That_A
{
    public class UserWindowViewModel
    {
        public UserWindowViewModel()
        {

        }
    }

    [Serializable()]
    public class StartMenuViewModel
    {
        private ObservableCollection<User> _listUsers = new ObservableCollection<User>();
        private List<User> _saveListUsers = new List<User>();

        public List<User> SaveListUsers
        {
            get { return _saveListUsers; }
            set { _saveListUsers = value; }
        }

        public ObservableCollection<User> ListUsers
        {
            get { return _listUsers; }
            set { _listUsers = value; }
        }

        public StartMenuViewModel()
        {
            //ListUsers.Add(new User("Kim Vinson"));
            //ListUsers[0].ListSemester.Add(new Semester("First Semester", 28));
            //ListUsers[0].ListSemester[0].ListClasses.Add(new Class("Programming 3", 5, "TTh", "1", "00", "4", "00", TimeScheduleType.PM, "Dexielito Badilles"));
            //ListUsers[0].ListSemester[0].NumberClass += 1;
            //ListUsers[0].ListSemester[0].UsedUnits += 5;

            //ListUsers[0].ListSemester[0].ListClasses.Add(new Class("English 3", 10, "TTh", "1", "00", "4", "00", TimeScheduleType.PM, "Dexielito Badilles"));
            //ListUsers[0].ListSemester[0].NumberClass += 1;
            //ListUsers[0].ListSemester[0].UsedUnits += 10;

            //ListUsers[0].ListSemester[0].ListClasses.Add(new Class("Physics 3", 7, "TTh", "1", "00", "4", "00", TimeScheduleType.PM, "Dexielito Badilles"));
            //ListUsers[0].ListSemester[0].NumberClass += 1;
            //ListUsers[0].ListSemester[0].UsedUnits += 7;

            //ListUsers[0].ListSemester[0].ListClasses.Add(new Class("Psych", 6, "TTh", "1", "00", "4", "00", TimeScheduleType.PM, "Dexielito Badilles"));
            //ListUsers[0].ListSemester[0].NumberClass += 1;
            //ListUsers[0].ListSemester[0].UsedUnits += 6;

            IFormatter formatter = new BinaryFormatter();

            Stream fileStream = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"UserCollection.bin", FileMode.OpenOrCreate);

            try
            {
                SaveListUsers = (List<User>)formatter.Deserialize(fileStream);

                for (int x = 0; x < SaveListUsers.Count; x++)
                {
                    ListUsers.Add(SaveListUsers[x]);
                }
            }

            catch (Exception)
            {

            }

            fileStream.Close();
        }

        public void SaveData()
        {
            try
            {
                SaveListUsers.Clear();

                for (int x = 0; x < ListUsers.Count; x++)
                {
                    SaveListUsers.Add(ListUsers[x]);
                }

                IFormatter formatter = new BinaryFormatter();

                Stream fileStream = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"UserCollection.bin", FileMode.Create);

                formatter.Serialize(fileStream, SaveListUsers);
                fileStream.Close();
            }

            catch (Exception)
            {

            }
        }

        public void RemoveSemester()
        {
            SelectedUser.ListSemester.Remove(SelectedUser.SelectedSemester);
        }

        public void ChangePercentEffect()
        {
            var window = new ChangePercentEffectOnTotalGradeWindow();

            double oldValue = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.PercentEffectOnFinalGrade;

            window.DataContext = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod;

            var result = window.ShowDialog();
            
            if (result == true)
            {
                if (SelectedUser.SelectedSemester.SelectedClass.Prefi.PercentEffectOnFinalGrade + SelectedUser.SelectedSemester.SelectedClass.Prelim.PercentEffectOnFinalGrade + SelectedUser.SelectedSemester.SelectedClass.Midterm.PercentEffectOnFinalGrade - SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.PercentEffectOnFinalGrade + NewPercentEffect > 100)
                {
                    MessageBox.Show("Grading periods' total percentage will exceed 100%! Please recheck your values.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.PercentEffectOnFinalGrade = NewPercentEffect;
                }
            }
        }

        public void GetSemesterTotalUsedUnits()
        {
            SelectedUser.SelectedSemester.UsedUnits = 0;

            for (int x = 0; x < SelectedUser.SelectedSemester.ListClasses.Count; x++)
            {
                SelectedUser.SelectedSemester.UsedUnits += SelectedUser.SelectedSemester.ListClasses[x].Units;
            }
        }

        public void EditGradedActivity()
        {
            var window = new AddGradedActivity();

            window.DataContext = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity;
            GradedActivity uneditedActivity = new GradedActivity();

            uneditedActivity.ActivityName = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.ActivityName;
            uneditedActivity.PercentScore = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.PercentScore;
            uneditedActivity.Score = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.Score;
            uneditedActivity.TotalItems = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.TotalItems;

            var result = window.ShowDialog();

            if (result == false)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.ActivityName = uneditedActivity.ActivityName;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.PercentScore = uneditedActivity.PercentScore;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.Score = uneditedActivity.Score;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity.TotalItems = uneditedActivity.TotalItems;
            }
        }

        public void GetClassFinalGrade()
        {
            if (SelectedUser.SelectedSemester.SelectedClass.Prefi.FinalGrade != 0 && SelectedUser.SelectedSemester.SelectedClass.Prelim.FinalGrade != 0 && SelectedUser.SelectedSemester.SelectedClass.Midterm.FinalGrade != 0 && SelectedUser.SelectedSemester.SelectedClass.Prelim.PercentEffectOnFinalGrade + SelectedUser.SelectedSemester.SelectedClass.Midterm.PercentEffectOnFinalGrade + SelectedUser.SelectedSemester.SelectedClass.Prefi.PercentEffectOnFinalGrade == 100)
            {
                SelectedUser.SelectedSemester.SelectedClass.FinalGrade = SelectedUser.SelectedSemester.SelectedClass.Prelim.FinalGrade + SelectedUser.SelectedSemester.SelectedClass.Midterm.FinalGrade + SelectedUser.SelectedSemester.SelectedClass.Prefi.FinalGrade;
            }

            else
            {
                SelectedUser.SelectedSemester.SelectedClass.FinalGrade = 0;
            }
        }

        public void AddNote()
        {
            var window = new AddNotesWindow();

            Notes newNote = new Notes();
            window.DataContext = newNote;

            var result = window.ShowDialog();

            if (result == true)
            {
                SelectedUser.SelectedSemester.SelectedClass.ListNotes.Add(newNote);
            }
        }

        public void RemoveNote()
        {
            SelectedUser.SelectedSemester.SelectedClass.ListNotes.Remove(SelectedUser.SelectedSemester.SelectedClass.SelectedNote);
        }

        public void EditClass()
        {
            var window = new AddClassWindow();
            window.DataContext = SelectedUser.SelectedSemester.SelectedClass;

            Class uneditedClass = new Class();

            uneditedClass.DaySchedule = SelectedUser.SelectedSemester.SelectedClass.DaySchedule;
            uneditedClass.Name = SelectedUser.SelectedSemester.SelectedClass.Name;
            uneditedClass.Professor = SelectedUser.SelectedSemester.SelectedClass.Professor;
            uneditedClass.TimeScheduleFromHour = SelectedUser.SelectedSemester.SelectedClass.TimeScheduleFromHour;
            uneditedClass.TimeScheduleFromMinute = SelectedUser.SelectedSemester.SelectedClass.TimeScheduleFromMinute;
            uneditedClass.TimeScheduleToHour = SelectedUser.SelectedSemester.SelectedClass.TimeScheduleToHour;
            uneditedClass.TimeScheduleToMinute = SelectedUser.SelectedSemester.SelectedClass.TimeScheduleToMinute;
            uneditedClass.TimeScheduleType = SelectedUser.SelectedSemester.SelectedClass.TimeScheduleType;
            uneditedClass.Units = SelectedUser.SelectedSemester.SelectedClass.Units;

            SelectedUser.SelectedSemester.UsedUnits -= uneditedClass.Units;

            var result = window.ShowDialog();

            if (result == false)
            {
                SelectedUser.SelectedSemester.SelectedClass.DaySchedule = uneditedClass.DaySchedule;
                SelectedUser.SelectedSemester.SelectedClass.Name = uneditedClass.Name;
                SelectedUser.SelectedSemester.SelectedClass.Professor = uneditedClass.Professor;
                SelectedUser.SelectedSemester.SelectedClass.TimeScheduleFromHour = uneditedClass.TimeScheduleFromHour;
                SelectedUser.SelectedSemester.SelectedClass.TimeScheduleFromMinute = uneditedClass.TimeScheduleFromMinute;
                SelectedUser.SelectedSemester.SelectedClass.TimeScheduleToHour = uneditedClass.TimeScheduleToHour;
                SelectedUser.SelectedSemester.SelectedClass.TimeScheduleToMinute = uneditedClass.TimeScheduleToMinute;
                SelectedUser.SelectedSemester.SelectedClass.TimeScheduleType = uneditedClass.TimeScheduleType;
                SelectedUser.SelectedSemester.SelectedClass.Units = uneditedClass.Units;
            }
        }

        public void GetClassLetterGrade()
        {
            if (SelectedUser.SelectedSemester.SelectedClass.FinalGrade  != 0)
            {
                double grade = SelectedUser.SelectedSemester.SelectedClass.FinalGrade;

                if (grade <= 100 && grade >= 91.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "A";
                }

                if (grade <= 91.49 && grade >= 87.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "B+";
                }

                if (grade <= 87.49 && grade >= 83.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "B";
                }

                if (grade <= 83.49 && grade >= 79.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "C+";
                }

                if (grade <= 79.49 && grade >= 75.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "C";
                }

                if (grade <= 75.49 && grade >= 71.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "D";
                }

                if (grade <= 71.49)
                {
                    SelectedUser.SelectedSemester.SelectedClass.LetterGrade = "F";
                }
            }

            SelectedUser.SelectedSemester.SelectedClass.PrelimLetterGrade = SelectedUser.SelectedSemester.SelectedClass.Prelim.LetterGrade;
            SelectedUser.SelectedSemester.SelectedClass.MidtermLetterGrade = SelectedUser.SelectedSemester.SelectedClass.Midterm.LetterGrade;
            SelectedUser.SelectedSemester.SelectedClass.PrefiLetterGrade = SelectedUser.SelectedSemester.SelectedClass.Prefi.LetterGrade;
        }

        public void GetSemesterQPI()
        {
            if (SelectedUser.SelectedSemester.UsedUnits == SelectedUser.SelectedSemester.RequiredUnits)
            {
                double totalQPIComponent = 0;

                for (int x = 0; x < SelectedUser.SelectedSemester.ListClasses.Count ; x++)
                {
                    totalQPIComponent += SelectedUser.SelectedSemester.ListClasses[x].QPIComponent;
                }

                SelectedUser.SelectedSemester.QPI = totalQPIComponent / SelectedUser.SelectedSemester.RequiredUnits;
            }
        }

        public void GetQPIComponent()
        {
            if (SelectedUser.SelectedSemester.SelectedClass != null)
            {
                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "A")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 4 * SelectedUser.SelectedSemester.SelectedClass.Units;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "B+")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 3.5 * SelectedUser.SelectedSemester.SelectedClass.Units;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "B")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 3 * SelectedUser.SelectedSemester.SelectedClass.Units;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "C+")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 2.5 * SelectedUser.SelectedSemester.SelectedClass.Units;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "C")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 2 * SelectedUser.SelectedSemester.SelectedClass.Units;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "D")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 1 * SelectedUser.SelectedSemester.SelectedClass.Units;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.LetterGrade == "F")
                {
                    SelectedUser.SelectedSemester.SelectedClass.QPIComponent = 0;
                }
            }
        }

        public void GetDecimalEffect()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.DecimalEffectOnFinalGrade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.PercentEffectOnFinalGrade / 100; 
        }

        public void GetFinalGrade()
        {
            if (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.DecimalEffectOnFinalGrade != 0 && SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingPeriodGrade != 0)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.FinalGrade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingPeriodGrade * SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.DecimalEffectOnFinalGrade;
            }
        }

        public void GetLetterGrade()
        {
            if (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal == 100)
            {
                double grade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingPeriodGrade;

                if (grade <= 100 && grade >= 91.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "A";
                }

                if (grade <= 91.49 && grade >= 87.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "B+";
                }

                if (grade <= 87.49 && grade >= 83.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "B";
                }

                if (grade <= 83.49 && grade >= 79.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "C+";
                }

                if (grade <= 79.49 && grade >= 75.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "C";
                }

                if (grade <= 75.49 && grade >= 71.50)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "D";
                }

                if (grade <= 71.49)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.LetterGrade = "F";
                }
            }
        }

        public void AddNewComponent()
        {
            var window = new AddGradingComponentWindow();

            GradingComponent newGradingComponent = new GradingComponent();
            window.DataContext = newGradingComponent;

            var result = window.ShowDialog();

            if (result == true)
            {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.ListGradingComponents.Add(newGradingComponent);
            }
        }

        public void EditComponent()
        {
            var window = new AddGradingComponentWindow();

            GradingComponent uneditedGradingComponent = new GradingComponent();

            uneditedGradingComponent.ActivityTotalItems = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalItems;
            uneditedGradingComponent.ActivityTotalScorePercentage = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScorePercentage;
            uneditedGradingComponent.ActivityTotalScoreRaw = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScoreRaw;
            uneditedGradingComponent.Base = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base;
            uneditedGradingComponent.ConvertedGrade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ConvertedGrade;
            uneditedGradingComponent.FinalGrade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade;
            uneditedGradingComponent.GradingType = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.GradingType;
            uneditedGradingComponent.ListActivities = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities;
            uneditedGradingComponent.Name = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Name;
            uneditedGradingComponent.PercentEffectOnTotalGrade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.PercentEffectOnTotalGrade;

            window.DataContext = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent;

            var result = window.ShowDialog();

            if (result == true)
            {
                ViewModelLocator.StartMenuViewModel.GetGradingComponentsPercentTotal();
                if (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal > 100)
                {
                    MessageBox.Show("Grading components percentage total will exceed 100%! Please recheck your components' percentage values.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalItems = uneditedGradingComponent.ActivityTotalItems;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScorePercentage = uneditedGradingComponent.ActivityTotalScorePercentage;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScoreRaw = uneditedGradingComponent.ActivityTotalScoreRaw;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base = uneditedGradingComponent.Base;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ConvertedGrade = uneditedGradingComponent.ConvertedGrade;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade = uneditedGradingComponent.FinalGrade;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.GradingType = uneditedGradingComponent.GradingType;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities = uneditedGradingComponent.ListActivities;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Name = uneditedGradingComponent.Name;
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.PercentEffectOnTotalGrade = uneditedGradingComponent.PercentEffectOnTotalGrade;
                }
            }

            if (result == false)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalItems = uneditedGradingComponent.ActivityTotalItems;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScorePercentage = uneditedGradingComponent.ActivityTotalScorePercentage;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScoreRaw = uneditedGradingComponent.ActivityTotalScoreRaw;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base = uneditedGradingComponent.Base;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ConvertedGrade = uneditedGradingComponent.ConvertedGrade;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade = uneditedGradingComponent.FinalGrade;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.GradingType = uneditedGradingComponent.GradingType;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities = uneditedGradingComponent.ListActivities;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Name = uneditedGradingComponent.Name;
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.PercentEffectOnTotalGrade = uneditedGradingComponent.PercentEffectOnTotalGrade;
            }
        }

        public void RemoveComponent()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.ListGradingComponents.Remove(SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent);
        }

        public void RemoveGradedActivity()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Remove(SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.SelectedActivity);
        }

        public void GetTotalItemsActivity()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalItems = 0;

            for (int x = 0; x < SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Count; x++)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalItems += SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities[x].TotalItems;
            }
        }

        public void GetTotalScoreActivity()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScoreRaw = 0;

            for (int x = 0; x < SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Count; x++)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScoreRaw += SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities[x].Score;
            }
        }

        public void GetComponentFinalGrade()
        {
            if (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Count != 0)
            {
                if (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.GradingType == GradingType.RawScore)
                {
                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade = ((SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalScoreRaw / SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ActivityTotalItems) * 100) * ((100 - SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base) / 100) + SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.Base;
                }

                if (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.GradingType == GradingType.PercentAverage)
                {
                    double totalPercentage = 0;

                    for (int x = 0; x < SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Count; x++)
                    {
                        totalPercentage += SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities[x].PercentScore;
                    }

                    SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade = totalPercentage / SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Count;
                }
            }

            else
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade = 0;
            }
        }

        public void GetGradingComponentsPercentTotal()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal = 0;

            for (int x = 0; x < SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.ListGradingComponents.Count; x++)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingComponentsPercentTotal += SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.ListGradingComponents[x].PercentEffectOnTotalGrade;
            }
        }

        public void GetGradingPeriodGrade()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingPeriodGrade = 0;

            for (int x = 0; x < SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.ListGradingComponents.Count; x++)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.GradingPeriodGrade += SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.ListGradingComponents[x].ConvertedGrade;
            }
        }

        public void GetConvertedGrade()
        {
            SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ConvertedGrade = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.FinalGrade * (SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.PercentEffectOnTotalGrade / 100);
        }

        public void AddNewGradedActivity()
        {
            var window = new AddGradedActivity();

            GradedActivity newActivity = new GradedActivity();
            window.DataContext = newActivity;

            var result = window.ShowDialog();

            if (result == true)
            {
                SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent.ListActivities.Add(newActivity);
            }
        }

        public void OpenGradingComponent()
        {
            var window = new ComponentWindow();

            window.DataContext = SelectedUser.SelectedSemester.SelectedClass.SelectedGradingPeriod.SelectedGradingComponent;
            window.Show();
        }

        public void AddActivity()
        {
            var window = new AddActivityWindow();

            Activity newActivity = new Activity();
            window.DataContext = newActivity;

            var result = window.ShowDialog();

            if (result == true)
            {
                SelectedUser.SelectedSemester.ToDoList.Add(newActivity);
            }
        }

        public void EditActivity()
        {
            var window = new AddActivityWindow();

            Activity uneditedActivity = new Activity();

            uneditedActivity.Deadline = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Deadline;
            uneditedActivity.Description = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Description;
            uneditedActivity.Importance = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Importance;
            uneditedActivity.Type = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Type;

            window.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity;

            var result = window.ShowDialog();

            if (result == false)
            {
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Deadline = uneditedActivity.Deadline;
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Description = uneditedActivity.Description;
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Importance = uneditedActivity.Importance;
                ViewModelLocator.StartMenuViewModel.SelectedUser.SelectedSemester.SelectedActivity.Type = uneditedActivity.Type;
            }
        }

        public double NewPercentEffect { get; set; }
        public User SelectedUser { get; set; }
    }

    public static class ViewModelLocator
    {
        private static UserWindowViewModel _userWindowViewModel;
        private static StartMenuViewModel _startMenuViewModel;

        public static UserWindowViewModel UserWindowViewModel
        {
            get
            {
                if (_userWindowViewModel == null)
                {
                    _userWindowViewModel = new UserWindowViewModel();
                }
                return _userWindowViewModel;
            }
        }

        public static StartMenuViewModel StartMenuViewModel
        {
            get 
            {
                if (_startMenuViewModel == null)
                {
                    _startMenuViewModel = new StartMenuViewModel();
                }
                return _startMenuViewModel;
            }
        }
    }
}
