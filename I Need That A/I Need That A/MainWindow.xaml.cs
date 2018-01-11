using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace I_Need_That_A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.StartMenuViewModel;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT User_Name, UserID From [USERS]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

            CmbUsers.Items.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                USERS newUser = new USERS();

                newUser.UserID = Convert.ToInt16(dt.Rows[x]["UserID"]);
                newUser.User = dt.Rows[x]["User_Name"].ToString();

                CmbUsers.Items.Add(newUser);
            }
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (CmbUsers.SelectedItem != null)
            {
                var userWindow = new SemesterSelectWindow();
                userWindow.Owner = this;
                userWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                userWindow.DataContext = ViewModelLocator.StartMenuViewModel.SelectedUser;
                this.Hide();
                userWindow.ShowDialog();
            }
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddNewUserWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            USERS newUser = new USERS();
            window.DataContext = newUser;

            var result = window.ShowDialog();
            if (result == true)
            {
                CmbUsers.Items.Clear();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [USERS]", con);
                DataTable dt = new DataTable();
                sda2.Fill(dt);
                con.Close();

                CmbUsers.Items.Clear();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    USERS user = new USERS();

                    user.UserID = Convert.ToInt16(dt.Rows[x]["UserID"]);
                    user.User = dt.Rows[x]["User_Name"].ToString();

                    CmbUsers.Items.Add(user);
                }
            }

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
