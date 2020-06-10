using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookMyShow.RPTReports
{
    public partial class ReportForm : System.Web.UI.Page
    {
        public object ConfigurationManger { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/RPTReports/Report1.rdlc");
            //NorthwindEntities entities = new NorthwindEntities();
            string conStr = ConfigurationManager.ConnectionStrings["BookMyShowDbContext"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetHighestEarningMovie";
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Connection = con;

            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adp.SelectCommand = cmd;
            adp.Fill(ds);

            ReportDataSource datasource = new ReportDataSource("GetHighestEarningMovie", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            con.Close();
        }
    }
}