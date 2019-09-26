using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS
{
    public class USERS
    {
        private int _userID;
        private string _user;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public USERS()
        {

        }

        public USERS(int id, string user)
        {
            UserID = id;
            User = user;
        }

        public override string ToString()
        {
            return User;
        }

    }
}
