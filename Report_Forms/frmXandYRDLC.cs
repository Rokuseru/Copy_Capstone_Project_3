using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CapstoneProject_3.Datasets;
using CapstoneProject_3.POS_System;
using System.Data.SqlClient;


namespace CapstoneProject_3.Report_Forms
{
    public partial class frmXandYRDLC : Form
    {
        frmZReport zReport;
        public frmXandYRDLC(frmZReport z)
        {
            InitializeComponent();
            zReport = z;
        }

        private void frmXandYRDLC_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
        public void loadZReport()
        {
            try
            {
                ReportDataSource ds;

                reportViewer.ProcessingMode = ProcessingMode.Local;
                this.reportViewer.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwZReport.rdlc";
                this.reportViewer.LocalReport.DataSources.Clear();

                DataSetXZReport z = new DataSetXZReport();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.Fill(z.Tables["dtZReport"]);

                //Parameters
                ReportParameter pDate = new ReportParameter("pDate", DateTime.Now.ToString("yyyy-MM-dd"));
                ReportParameter pUser = new ReportParameter("PUser", zReport.cbUsers.Text);

                //Set the paramters
                reportViewer.LocalReport.SetParameters(pDate);

                ds = new ReportDataSource("rwZReport", z.Tables["dtZReport"]);
                reportViewer.LocalReport.DataSources.Add(ds);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
