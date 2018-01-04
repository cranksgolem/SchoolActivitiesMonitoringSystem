using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Need_That_A
{
    class SCORE
    {
        private int _id;
        private int _score;
        private DateTime _date;
        private int _items;
        private string _gradingPeriod;
        private int _activityID;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Items
        {
            get { return _items; }
            set { _items = value; }
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
    }
}
