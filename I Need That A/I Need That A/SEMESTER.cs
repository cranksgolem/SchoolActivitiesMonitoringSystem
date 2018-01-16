using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_That_A
{
    public class SEMESTER
    {
        private int _semID;
        private string _semesterName;
        private int _maxUnits;
        private float _qpi;
        private string _schoolyear;
        private int _userID;

        public int SemID
        {
            get { return _semID; }
            set { _semID = value; }
        }

        public string SemesterName
        {
            get { return _semesterName; }
            set { _semesterName = value; }
        }

        public int MaxUnits
        {
            get { return _maxUnits; }
            set { _maxUnits = value; }
        }

        public float QPI
        {
            get { return _qpi; }
            set { _qpi = value; }
        }

        public string Schoolyear
        {
            get { return _schoolyear; }
            set { _schoolyear = value; }
        }

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public SEMESTER()
        {

        }

        public SUBJECT SelectedClass { get; set; }
    }
}
