using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapstoneProject_3
{
    class AuditTrail
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        int userID = 0;
        public void insertAction(string Action, string value, string module)
        {
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO tblAuditTrail (action, userID, value, module,date, time)
                                        VALUES (@action, @userid, @value, @module, @date, @time)";
                command.Parameters.AddWithValue("@action", Action);
                command.Parameters.AddWithValue("@userid", userID);
                command.Parameters.AddWithValue("@module", module);
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"));
                command.ExecuteNonQuery();
            }

        }
        public void loadUserID(string name)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name LIKE @name";
                    command.Parameters.AddWithValue("@name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = int.Parse(reader["userID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
