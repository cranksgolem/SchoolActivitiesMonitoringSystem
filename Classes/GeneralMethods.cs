using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMS
{
    public static class GeneralMethods
    {
        public static SqlConnection ConnectToDatabase()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\4th Year\ObjectOrientedProgramming\FinalSchoolMonitoringSystem\SAMS\SAMS\Database.mdf");
            con.Open();
            return con;
        }
    }
}
