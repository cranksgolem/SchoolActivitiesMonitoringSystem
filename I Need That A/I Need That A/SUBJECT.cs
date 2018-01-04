using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_That_A
{
    class SUBJECT
    {
        private int _subjectCode;
        private string _description;
        private string _schedule;
        private string _schoolyear;
        private int _units;
        private int _grade;
        private int _semID;

        public int SubjectCode
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
