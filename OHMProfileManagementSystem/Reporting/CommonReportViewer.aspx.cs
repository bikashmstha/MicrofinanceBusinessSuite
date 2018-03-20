using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OHMProfileManagementSystem.Utility;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace OHMProfileManagementSystem.Reporting
{
    public partial class CommonReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime t1 = DateTime.Now;
            QueueManager.Control();

            CrystalReport report = (CrystalReport)Session["ITS_Report"];
            
            ReportDocument mainDoc = new ReportDocument();
            mainDoc.Load(report.ReportFilePath, OpenReportMethod.OpenReportByDefault);
            mainDoc.RecordSelectionFormula = report.SelectionCriteria;
            mainDoc.Refresh();
            string server = "itsdbrac";
           // string server = "IRDITS";
            
            string userID = report.UserID;
            string password = report.Password;

             this.ApplyLogonInfo(mainDoc, server, userID, password);

            
             foreach (ReportParameter param in report.ParamList)
             {
                 mainDoc.SetParameterValue(param.ParamName, param.ParamValue);
             }

             //foreach (ReportFormulaFields formula in report.FormulaList)
             //{
             //    mainDoc.DataDefinition.FormulaFields[formula.FormulaName].Text = "'" + formula.FormulaValue.ToString() + "'";
             //}

             foreach (SubReport sr in report.SubReportList)
             {
                 this.ApplyLogonInfo(mainDoc, server, userID, password);
                 foreach (ReportParameter param in sr.ParamList)
                 {
                    
                     mainDoc.SetParameterValue(param.ParamName, param.ParamValue, sr.SubReportName);
                 }
             }
             
             mainDoc.SetDatabaseLogon(userID, password, server, "");
            this.CrystalReportViewer1.ReportSource = mainDoc;

            mainDoc.DataSourceConnections.Clear();

            QueueManager.ReportQueue.Enqueue(mainDoc);

            //DateTime t2 = DateTime.Now;
            //TimeSpan s = t2.Subtract(t1);
            //this.lblEllapsedTime.Text = "Ellapsed time: " + s.TotalMilliseconds.ToString() + " Millisecond(s) :: " + QueueManager.ReportQueue.Count.ToString();

        }

        void ApplyLogonInfo(ReportDocument report, string server, string userID, string password)
        {
            TableLogOnInfo info = new TableLogOnInfo();
            ConnectionInfo cinfo = new ConnectionInfo();

            cinfo.ServerName = server;
            cinfo.UserID = userID;
            cinfo.Password = password;
            info.ConnectionInfo = cinfo;

            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in report.Database.Tables)
            {
                tbl.ApplyLogOnInfo(info);
            }
        }
    }
}