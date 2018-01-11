using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace I_Need_That_A
{
    [Serializable()]
    public class User
    {
        private string _name;
        private ObservableCollection<Semester> _listSemester = new ObservableCollection<Semester>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public User(string name)
        {
            Name = name;
        }

        public User()
        {

        }

        public ObservableCollection<Semester> ListSemester
        {
            get { return _listSemester; }
        }

        public override string ToString()
        {
            return Name;
        }

        public Semester SelectedSemester { get; set; }
    }

    [Serializable()]
    public class Semester : INotifyPropertyChanged
    {
        private string _name;
        private string _schoolyear;
        private ObservableCollection<Class> _listClasses = new ObservableCollection<Class>();
        private ObservableCollection<Activity> _listToDoList = new ObservableCollection<Activity>();
        private ObservableCollection<Activity> _listToDoListHistory = new ObservableCollection<Activity>();
        private double _requiredUnits;
        private double _usedUnits;
        private double _availableUnits;
        private double _qpi;
        private int _numberClasses;
        private ICollectionView _viewToDoList;
        private ICollectionView _viewToDoListHistory;

        public Class SelectedClass { get; set; }
       
        public Activity SelectedActivity { get; set; }

        public Semester(string name, int requiredUnits)
        {
            Name = name;
            RequiredUnits = requiredUnits;
            NumberClass = 0;
            _viewToDoList = CollectionViewSource.GetDefaultView(ToDoList);
            _viewToDoListHistory = CollectionViewSource.GetDefaultView(ToDoListHistory);
        }

        public ObservableCollection<Activity> ToDoList
        {
            get { return _listToDoList; }
            set { _listToDoList = value; }
        }

        public ObservableCollection<Activity> ToDoListHistory
        {
            get { return _listToDoListHistory; }
            set { _listToDoListHistory = value; }
        }

        public Semester()
        {
            NumberClass = 0;
            _viewToDoList = CollectionViewSource.GetDefaultView(ToDoList);
            _viewToDoListHistory = CollectionViewSource.GetDefaultView(ToDoListHistory);
        }

        public void SortImportanceToDoList()
        {
            _viewToDoList.SortDescriptions.Clear();
            _viewToDoList.SortDescriptions.Add(new SortDescription("Importance", ListSortDirection.Descending));
        }

        public void SortImportanceToDoListAscending()
        {
            _viewToDoList.SortDescriptions.Clear();
            _viewToDoList.SortDescriptions.Add(new SortDescription("Importance", ListSortDirection.Ascending));
        }

        public void SortUrgencyToDoList()
        {
            _viewToDoList.SortDescriptions.Clear();
            _viewToDoList.SortDescriptions.Add(new SortDescription("Deadline", ListSortDirection.Ascending));
        }

        public void SortUrgencyToDoList2()
        {
            _viewToDoList.SortDescriptions.Clear();
            _viewToDoList.SortDescriptions.Add(new SortDescription("Deadline", ListSortDirection.Descending));
        }

        public void SortImportanceToDoListHistory()
        {
            _viewToDoListHistory.SortDescriptions.Clear();
            _viewToDoListHistory.SortDescriptions.Add(new SortDescription("Importance", ListSortDirection.Descending));
        }

        public void SortImportanceToDoListAscendingHistory()
        {
            _viewToDoListHistory.SortDescriptions.Clear();
            _viewToDoListHistory.SortDescriptions.Add(new SortDescription("Importance", ListSortDirection.Ascending));
        }

        public void SortUrgencyToDoListHistory()
        {
            _viewToDoListHistory.SortDescriptions.Clear();
            _viewToDoListHistory.SortDescriptions.Add(new SortDescription("Deadline", ListSortDirection.Ascending));
        }

        public void SortUrgencyToDoList2History()
        {
            _viewToDoListHistory.SortDescriptions.Clear();
            _viewToDoListHistory.SortDescriptions.Add(new SortDescription("Deadline", ListSortDirection.Descending));
        }

        public double AvailableUnits
        {
            get { return _availableUnits; }
            set { _availableUnits = value; }
        }

        public int NumberClass
        {
            get { return _numberClasses; }
            set { _numberClasses = value;
            OnPropertyChanged(new PropertyChangedEventArgs("NumberClass"));
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        public string Schoolyear
        {
            get { return _schoolyear; }
            set
            {
                _schoolyear = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Schoolyear"));
            }
        }

        public double UsedUnits
        {
            get { return _usedUnits; }
            set { _usedUnits = value;
            OnPropertyChanged(new PropertyChangedEventArgs("UsedUnits"));
            }
        }

        public ObservableCollection<Class> ListClasses
        {
            get { return _listClasses; }
            set { _listClasses = value; }
        }

        public double RequiredUnits
        {
            get { return _requiredUnits; }
            set { _requiredUnits = value;
            OnPropertyChanged(new PropertyChangedEventArgs("RequiredUnits"));
            }
        }

        public double QPI
        {
            get { return _qpi; }
            set { _qpi = value;
            OnPropertyChanged(new PropertyChangedEventArgs("QPI"));
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
    }

    [Serializable()]
    public class ActivityGroup : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Name"));
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
    }

    [Serializable()]
    public class Class : ActivityGroup
    {
        private GradingPeriod _prelim = new GradingPeriod();
        private GradingPeriod _midterm = new GradingPeriod();
        private GradingPeriod _prefi = new GradingPeriod();
        private ObservableCollection<Notes> _listNotes = new ObservableCollection<Notes>();
        private double _units;
        private double _finalGrade;
        private string _prelimLetterGrade;
        private string _midtermLetterGrade;
        private string _prefiLetterGrade;
        private string _letterGrade;
        private string _daySchedule;
        private string _timeScheduleFromHour;
        private string _timeScheduleFromMinute;
        private string _timeScheduleToHour;
        private string _timeScheduleToMinute;
        private TimeScheduleType _timeScheduleType;
        private string _professor;
        private double _qpiComponent;

        public Notes SelectedNote { get; set; }

        public ObservableCollection<Notes> ListNotes
        {
            get { return _listNotes; }
            set { _listNotes = value; }
        }

        public double QPIComponent
        {
            get { return _qpiComponent; }
            set { _qpiComponent = value; }
        }

        public string PrelimLetterGrade
        {
            get { return _prelimLetterGrade; }
            set { _prelimLetterGrade = value; }
        }

        public string MidtermLetterGrade
        {
            get { return _midtermLetterGrade; }
            set { _midtermLetterGrade = value; }
        }

        public string PrefiLetterGrade
        {
            get { return _prefiLetterGrade; }
            set { _prefiLetterGrade = value; }
        }

        public GradingPeriod SelectedGradingPeriod { get; set; }

        public Class(string name, int units, string daySchedule, string timeScheduleFromHour, string timeScheduleFromMinute, string timeScheduleToHour, string timeScheduleToMinute, TimeScheduleType timeScheduleType, string professor)
        {
            Name = name;
            Units = units;
            DaySchedule = daySchedule;
            TimeScheduleFromHour = timeScheduleFromHour;
            TimeScheduleFromMinute = timeScheduleFromMinute;
            TimeScheduleToHour = timeScheduleToHour;
            TimeScheduleToMinute = timeScheduleToMinute;
            TimeScheduleType = timeScheduleType;
            Professor = professor;
        }

        public Class()
        {

        }

        public TimeScheduleType TimeScheduleType
        {
            get { return _timeScheduleType; }
            set { _timeScheduleType = value;
            OnPropertyChanged(new PropertyChangedEventArgs("TimeScheduleType"));
            }
        }

        public string Professor
        {
            get { return _professor; }
            set { _professor = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Professor"));
            }
        }

        public GradingPeriod Prelim
        {
            get { return _prelim; }
            set { _prelim = value; }
        }

        public GradingPeriod Midterm
        {
            get { return _midterm; }
            set { _midterm = value; }
        }

        public GradingPeriod Prefi
        {
            get { return _prefi; }
            set { _prefi = value; }
        }

        public string LetterGrade
        {
            get { return _letterGrade; }
            set { _letterGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("LetterGrade"));
            }
        }

        public double Units
        {
            get { return _units; }
            set { _units = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Units"));
            }
        }

        public double FinalGrade
        {
            get { return _finalGrade; }
            set { _finalGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("FinalGrade"));
            }
        }

        public string DaySchedule
        {
            get { return _daySchedule; }
            set { _daySchedule = value;
            OnPropertyChanged(new PropertyChangedEventArgs("DaySchedule"));
            }
        }

        public string TimeScheduleFromHour
        {
            get { return _timeScheduleFromHour; }
            set { _timeScheduleFromHour= value;
            OnPropertyChanged(new PropertyChangedEventArgs("TimeScheduleFromHour"));
            }
        }

        public string TimeScheduleToHour
        {
            get { return _timeScheduleToHour; }
            set { _timeScheduleToHour = value;
            OnPropertyChanged(new PropertyChangedEventArgs("TimeScheduleToHour"));
            }
        }

        public string TimeScheduleFromMinute
        {
            get { return _timeScheduleFromMinute; }
            set { _timeScheduleFromMinute = value;
            OnPropertyChanged(new PropertyChangedEventArgs("TimeScheduleFromMinute"));
            }
        }

        public string TimeScheduleToMinute
        {
            get { return _timeScheduleToMinute; }
            set { _timeScheduleToMinute = value;
            OnPropertyChanged(new PropertyChangedEventArgs("TimeScheduleToMinute"));
            }
        }     
    }

    [Serializable()]
    public class Activity : INotifyPropertyChanged 
    {
        private string _description;
        private DateTime _deadline;
        private int _importance;
        private ActivityType _type;
     

        public string Description
        {
            get { return _description; }
            set { _description = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Deadline"));
            }
        }

        public int Importance
        {
            get { return _importance; }
            set { _importance = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Importance"));
            }
        }

        public ActivityType Type
        {
            get { return _type; }
            set { _type = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Type"));
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
    }

    [Serializable()]
    public enum ActivityType
    {
        Academic,
        ExtraCurricular
    }

    [Serializable()]
    public class GradedActivity : INotifyPropertyChanged 
    {
        private string _activityName;
        private double _score;
        private double _totalItems;
        private double _percentScore;

        public double PercentScore
        {
            get { return _percentScore; }
            set { _percentScore = value;
            OnPropertyChanged(new PropertyChangedEventArgs("PercentScore"));
            }
        }

        public string ActivityName
        {
            get { return _activityName; }
            set { _activityName = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ActivityName"));
            }
        }

        public double TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value;
            OnPropertyChanged(new PropertyChangedEventArgs("TotalItems"));
            }
        }

        public double Score
        {
            get { return _score; }
            set { _score = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Score"));
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
    }

    [Serializable()]
    public class GradingComponent : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<GradedActivity> _listActvities = new ObservableCollection<GradedActivity>();
        private double _percentEffectOnTotalGrade;
        private double _activityTotalItems;
        private double _activityTotalScoreRaw;
        private int _activityTotalScorePercentage;
        private GradingType _gradingType;
        private double _finalGrade;
        private double _convertedGrade;
        private double _base;

        public double Base
        {
            get { return _base; }
            set { _base = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Base"));
            }
        }

        public double ConvertedGrade
        {
            get { return _convertedGrade; }
            set { _convertedGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ConvertedGrade"));
            }
        }

        public GradedActivity SelectedActivity { get; set; }

        public GradingComponent()
        {
            PercentEffectOnTotalGrade = 0;
            ActivityTotalItems = 0;
            ActivityTotalScoreRaw = 0;
            FinalGrade = 0;
        }

        public GradingType GradingType
        {
            get { return _gradingType; }
            set { _gradingType = value;
            OnPropertyChanged(new PropertyChangedEventArgs("GradingType"));
            }
        }

        public double FinalGrade
        {
            get { return _finalGrade; }
            set { _finalGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("FinalGrade"));
            }
        }

        public double PercentEffectOnTotalGrade
        {
            get { return _percentEffectOnTotalGrade; }
            set { _percentEffectOnTotalGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("PercentEffectOnTotalGrade"));
            }
        }

        public double ActivityTotalItems
        {
            get { return _activityTotalItems; }
            set { _activityTotalItems = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ActivityTotalItems"));
            }
        }

        public double ActivityTotalScoreRaw
        {
            get { return _activityTotalScoreRaw; }
            set { _activityTotalScoreRaw = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ActivityTotalScoreRaw"));
            }
        }

        public int ActivityTotalScorePercentage
        {
            get { return _activityTotalScorePercentage; }
            set { _activityTotalScorePercentage = value;
            OnPropertyChanged(new PropertyChangedEventArgs("ActivityTotalScorePercentage"));
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        public ObservableCollection<GradedActivity> ListActivities
        {
            get { return _listActvities; }
            set { _listActvities = value; }
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

    [Serializable()]
    public class Notes : INotifyPropertyChanged 
    {
        private string _note;

        public string Note
        {
            get { return _note; }
            set { _note = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Note"));
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
    }

    [Serializable()]
    public class GradingPeriod : INotifyPropertyChanged 
    {
        ObservableCollection<GradingComponent> _listGradingComponents = new ObservableCollection<GradingComponent>();
        private double _gradingPeriodGrade;
        private double _percentEffectOnFinalGrade;
        private double _decimalEffectOnFinalGrade;
        private double _gradingComponentsPercentTotal;
        private double _finalGrade;
        private string _letterGrade;

        public GradingComponent SelectedGradingComponent { get; set; }

        public GradingPeriod()
        {
            GradingPeriodGrade = 0;
            PercentEffectOnFinalGrade = 0;
            DecimalEffectOnFinalGrade = 0;
            GradingComponentsPercentTotal = 0;
            FinalGrade = 0;
            LetterGrade = "-";
        }

        public double DecimalEffectOnFinalGrade
        {
            get { return _decimalEffectOnFinalGrade; }
            set { _decimalEffectOnFinalGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("DecimalEffectOnFinalGrade"));
            }
        }

        public double GradingComponentsPercentTotal
        {
            get { return _gradingComponentsPercentTotal; }
            set { _gradingComponentsPercentTotal = value;
            OnPropertyChanged(new PropertyChangedEventArgs("GradingComponentsPercentTotal"));
            }
        }

        public string LetterGrade
        {
            get { return _letterGrade; }
            set { _letterGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("LetterGrade"));
            }
        }

        public double GradingPeriodPercentTotal
        {
            get { return _gradingComponentsPercentTotal; }
            set { _gradingComponentsPercentTotal = value;
            OnPropertyChanged(new PropertyChangedEventArgs("GradingPeriodPercentTotal"));
            }
        }

        public double PercentEffectOnFinalGrade
        {
            get { return _percentEffectOnFinalGrade; }
            set { _percentEffectOnFinalGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("PercentEffectOnFinalGrade"));
            }
        }

        public double FinalGrade
        {
            get { return _finalGrade; }
            set { _finalGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("FinalGrade"));
            }
        }

        public ObservableCollection<GradingComponent> ListGradingComponents
        {
            get { return _listGradingComponents; }
            set { _listGradingComponents = value; }
        }

        public double GradingPeriodGrade
        {
            get { return _gradingPeriodGrade; }
            set { _gradingPeriodGrade = value;
            OnPropertyChanged(new PropertyChangedEventArgs("GradingPeriodGrade"));
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
    }

    [Serializable()]
    public enum TimeScheduleType
    {
        AM,
        PM
    }

    [Serializable()]
    public enum GradingType
    {
        RawScore,
        PercentAverage
    }
}
