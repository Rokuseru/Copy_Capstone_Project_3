using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapstoneProject_3.Notifications;
using System.Data.SqlClient;

namespace CapstoneProject_3
{
    public partial class frmInventory : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        showToast toast = new showToast();
        public frmInventory()
        {
            InitializeComponent();
            loadInventory();
        }
        private void loadInventory()
        {
            try
            {
                int i = 0;
                dataGridViewInventory.Rows.Clear();

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.ProductCode, p.Description, i.BatchNo, i.price, i.qty from tblInventory AS i
                                            INNER JOIN tblProduct AS p ON i.productID = p.productID";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridViewInventory.Rows.Add(i, reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["BatchNo"].ToString(), reader["price"].ToString(), reader["qty"].ToString());
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
