using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace I_Need_That_A
{
    /// <summary>
    /// Interaction logic for AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        public AddNewUserWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxName.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vinson\Desktop\School\4th Year\ObjectOrientedProgramming\SchoolMonitoringSystem2\SchoolActivitiesMonitoringSystem-AddTables\I Need That A\I Need That A\Database.mdf");
                con.Open();
                SqlDataAdapter sda2 = new SqlDataAdapter();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("INSERT INTO [USERS] (User_Name) VALUES (@User_Name)", con);
                command.Parameters.AddWithValue("@User_Name", TbxName.Text);
                command.ExecuteNonQuery();
                con.Close();
                DialogResult = true;
            }

            else
            {
                MessageBox.Show("Please make sure to fill in every field!", "Empty Field", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
