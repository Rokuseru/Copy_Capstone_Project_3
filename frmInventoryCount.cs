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
using System.Runtime.InteropServices;

namespace CapstoneProject_3
{
    public partial class frmInventoryCount : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        //Fields
        private int borderSize = 1;
        public frmInventoryCount()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
            this.panel1.BackColor = Color.White;
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
        private void checkDatagridView()
        {
            for (int i = dataGridView.RowCount - 2; i >= 0; i--)
            {
                for (int j = 0; j < dataGridViewStore.RowCount - 1; j++)
                {
                    if (Convert.ToDouble(dataGridView.Rows[i].Cells[3].Value.ToString()) != Convert.ToDouble(dataGridViewStore.Rows[j].Cells[3].Value.ToString()))
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        dataGridViewStore.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dataGridViewStore.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnCompare_Click(object sender, EventArgs e)
        {
            compare();
        }
        private void dataGridViewStore_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkQty();
        }  
        private void compare()
        {
            DataTable src1 = new DataTable();
            DataTable src2 = new DataTable();

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                src1.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dr = src1.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.ColumnIndex] = cell.Value;
                }
                src1.Rows.Add(dr);
            }
            //Store
            foreach (DataGridViewColumn col in dataGridViewStore.Columns)
            {
                src2.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dataGridViewStore.Rows)
            {
                DataRow dr = src2.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.ColumnIndex] = cell.Value;
                }
                src2.Rows.Add(dr);
            }

            for (int i = 0; i < src1.Rows.Count; i++)
            {
                var row1 = src1.Rows[i].ItemArray;
                var row2 = src2.Rows[i].ItemArray;

                for (int j = 0; j < row1.Length; j++)
                {
                    if (row1[j].ToString().Equals(row2[j].ToString()))
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dataGridViewStore.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                    else if (!row1[j].ToString().Equals(row2[j].ToString()))
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        dataGridViewStore.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
