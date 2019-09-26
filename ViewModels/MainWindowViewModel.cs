using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS.ViewModels
{
    public class MainWindowViewModel
    {
        private ObservableCollection<USERS> _listUsers = new ObservableCollection<USERS>();

        public USERS SelectedUser { get; set; }
        public ObservableCollection<USERS> ListUsers
        {
            get { return _listUsers; }
            set { _listUsers = value; }
        }

        public MainWindowViewModel()
        {
            GetAndDisplayUsers();
        }

        public void PublicGetAndDisplayUsers()
        {
            GetAndDisplayUsers();
        }

        public void AddNewUser(USERS newUser)
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlCommand command = new SqlCommand("INSERT INTO [USERS] (User_Name) VALUES (@User_Name)", con);
            command.Parameters.AddWithValue("@User_Name", newUser.User);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplayUsers();
        }

        public void RemoveUser( )
        {
            SqlConnection con = GeneralMethods.ConnectToDatabase();

            SqlCommand command = new SqlCommand("DELETE FROM [USERS] WHERE UserID=@userID", con);
            command.Parameters.AddWithValue("@userID", SelectedUser.UserID);
            command.ExecuteNonQuery();
            con.Close();

            GetAndDisplayUsers();
        }

        private void GetAndDisplayUsers()
        {
            ListUsers.Clear();

            SqlConnection con = GeneralMethods.ConnectToDatabase();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT User_Name, UserID From [USERS]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                USERS newUser = new USERS();

                newUser.UserID = Convert.ToInt16(dt.Rows[x]["UserID"]);
                newUser.User = dt.Rows[x]["User_Name"].ToString();

                ListUsers.Add(newUser);
            }
        }
    }
}
