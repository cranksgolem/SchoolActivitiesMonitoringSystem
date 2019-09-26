using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_That_A
{
    public class ACTIVITY
    {
        private int _activityID;
        private string _activity;
        private double _percentage;
        private int _subjectID;
        private string _gradingPeriod;
        private double _grade;
        private string _gradingType;

        public string GradingType
        {
            get { return _gradingType; }
            set { _gradingType = value; }
        }

        public double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public string GradingPeriod
        {
            get { return _gradingPeriod; }
            set { _gradingPeriod = value; }
        }

        public int ActivityID
        {
            get { return _activityID; }
            set { _activityID = value; }
        }

        public string Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }

        public double Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }

        public int SubjectID
        {
            get { return _subjectID; }
            set { _subjectID = value; }
        }

        public ACTIVITY()
        {
                
        }

        public enum GradingTypee
        {
            RawScore,
            PercentAverage
        }
    }
}
