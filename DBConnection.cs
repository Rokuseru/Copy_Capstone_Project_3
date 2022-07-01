using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace CapstoneProject_3
{
    public class DBConnection
    {
        public string myConnection()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            return con;
        }
    }
}
