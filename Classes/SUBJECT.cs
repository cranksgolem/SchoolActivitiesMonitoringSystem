using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS
{
    public class SUBJECT
    {
        private string _subjectCode;
        private string _description;
        private string _schedule;
        private int _units;
        private double _grade;
        private int _semID;
        private int _subjectID;
        private double _prelimPercent;
        private double _midtermPercent;
        private double _prefiPercent;
        private double _base;
        private string _prelimLetterGrade;
        private string _midtermLetterGrade;
        private string _prefiLetterGrade;
        private string _finalLetterGrade;

        public string FinalLetterGrade
        {
            get { return _finalLetterGrade; }
            set { _finalLetterGrade = value; }
        }

        public string PrefiLetterGrade
        {
            get { return _prefiLetterGrade; }
            set { _prefiLetterGrade = value; }
        }

        public string MidtermLetterGrade
        {
            get { return _midtermLetterGrade; }
            set { _midtermLetterGrade = value; }
        }

        public string PrelimLetterGrade
        {
            get { return _prelimLetterGrade; }
            set { _prelimLetterGrade = value; }
        }

        public double Base
        {
            get { return _base; }
            set { _base = value; }
        }

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

        public int Units
        {
            get { return _units; }
            set { _units = value; }
        }

        public double Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public int SemID
        {
            get { return _semID; }
            set { _semID = value; }
        }

        public enum TimeScheduleType
        {
            AM,
            PM
        }
    }
}
