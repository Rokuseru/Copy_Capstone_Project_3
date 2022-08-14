using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CapstoneProject_3
{
    public partial class frmInventoryCount : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public frmInventoryCount()
        {
            InitializeComponent();
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {

        }
        public void loadProductQTY()
        {
            try
            {
                dataGridView.Rows.Clear();
                int i = 0;
                int n = 0;
                int qty = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, Description, quantity FROM tblProduct";

                    using (var reader = command.ExecuteReader())
                    {
                       while (reader.Read())
                        {
                            i += 1;
                            qty += int.Parse(reader["quantity"].ToString());
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["Description"].ToString(), reader["quantity"].ToString());
                        }
                        lblSystemItems.Text = qty.ToString();
                    }
                }

                int q = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, Description FROM tblProduct";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            n += 1;
                            dataGridViewStore.Rows.Add(n, reader["productID"].ToString(), reader["Description"].ToString(), q);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        private void checkQty()
        {
            int storeQty = 0;
            for (int i = 0;i < this.dataGridView.Rows.Count; i++)
            {
                storeQty += Convert.ToInt32(dataGridViewStore.Rows[i].Cells["quantity"].Value);
            }
            lblStoreItems.Text = storeQty.ToString();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewStore_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkQty();
        }
    }
}
