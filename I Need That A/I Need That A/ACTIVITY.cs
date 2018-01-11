using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_That_A
{
    class ACTIVITY
    {
        private int _activityID;
        private string _activity;
        private int _percentage;
        private int _subjectCode;

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

        public int Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }

        public int SubjectCode
        {
            get { return _subjectCode; }
            set { _subjectCode = value; }
        }
    }
}
