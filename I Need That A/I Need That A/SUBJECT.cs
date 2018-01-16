using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_That_A
{
    public class SUBJECT
    {
        private string _subjectCode;
        private string _description;
        private string _schedule;
        private string _schoolyear;
        private int _units;
        private int _grade;
        private int _semID;
        private int _subjectID;
        private double _prelimPercent;
        private double _midtermPercent;
        private double _prefiPercent;

        public double PrefiPercent
        {
            get { return _prefiPercent; }
            set { _prefiPercent = value; }
        }


        public double MidtermPercent
        {
            get { return _midtermPercent; }
            set { _midtermPercent = value; }
        }

        public double PrelimPercent
        {
            get { return _prelimPercent; }
            set { _prelimPercent = value; }
        }

        public int SubjectID
        {
            get { return _subjectID; }
            set { _subjectID = value; }
        }

        public string SubjectCode
        {
            get { return _subjectCode; }
            set { _subjectCode = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Schedule
        {
            get { return _schedule; }
            set { _schedule = value; }
        }

        public string Schoolyear
        {
            get { return _schoolyear; }
            set { _schoolyear = value; }
        }

        public int Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public int SemID
        {
            get { return _semID; }
            set { _semID = value; }
        }
    }
}
