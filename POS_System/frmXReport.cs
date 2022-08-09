﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace CapstoneProject_3.POS_System
{
    public partial class frmXReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        private int userID = 0;
        //private string transNo = "";
        private string timeIn = "";
        private string timeOut = "";

        frmPOS pos;
        public frmXReport(frmPOS fpos)
        {
            InitializeComponent();
            pos = fpos;
        }
        private void loadUsers()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE status = 'Active'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbUsers.Items.Add(reader["Name"].ToString());
                        }
                    }
                    Console.WriteLine("FROM loadUsers():" + userID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getUserId()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers 
                                            WHERE Name LIKE @user";
                    command.Parameters.AddWithValue("@user", cbUsers.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = int.Parse(reader["userID"].ToString());
                        }
                    }
                    Console.WriteLine("FROM getUserID():" + userID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTime()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblAttendance WHERE userID LIKE @uid";
                    command.Parameters.AddWithValue("@uid", userID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timeIn =reader["Time_In"].ToString();
                            timeOut = reader["Time_Out"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadXReport()
        {
            try
            {
                LoadTime();
                double _total = 0;
                string _date = "";
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT u.Name, s.Method, sum(s.Discount) AS DISCOUNT, sum(s.Total_Sales) AS sales, s.date FROM tblSales AS s
                                            INNER JOIN tblUsers AS u ON s.userID = u.userID
                                            WHERE u.userID LIKE @uid
                                            AND DATE LIKE @date
                                            AND time BETWEEN @timeIn AND @timeOut
                                            GROUP BY u.Name, Method, date";
                    command.Parameters.AddWithValue("@uid", userID);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@timeIn", timeIn);
                    command.Parameters.AddWithValue("@timeOut", timeOut);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //transNo = reader["TransactionID"].ToString();
                            _total = Double.Parse(reader["sales"].ToString());
                            _date = Convert.ToDateTime(reader["date"].ToString()).ToString("ddd, MMM, dd, yyyy");
                        }
                        txtTotal.Text = _total.ToString("C", culture);
                        txtCash.Text = _total.ToString("C", culture);

                        txtOpened.Text = _date +" At " + Convert.ToDateTime(timeIn).ToString("hh:mm:ss tt");
                        //Console.WriteLine(transNo);
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }
        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUserId();
            loadXReport();
        }

        private void frmXReport_Load(object sender, EventArgs e)
        {
            getUserId();
            loadUsers();
            loadXReport();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}