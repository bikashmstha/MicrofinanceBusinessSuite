using BusinessObjects.GeneralMasterParameters;
using DataObjects.Interfaces.GeneralMasterParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using System.Data;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleReportDao:IReportDao
    {

        public List<Report> GetReportShort(string moduleId, string tabId)
        {
            try
            {
                string SP = "security_pkg.p_report_type_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_module_id", moduleId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tab_id", tabId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<Report> lst = new List<Report>();
                Report obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new Report();
                    obj.ReportId = drow["REPORT_TYPE_CODE"].ToString();//APPLICATION_ID
                    obj.ReportDesc = drow["REPORT_TYPE_DESC"].ToString();//APPLICATION_DESCRIPTION
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
