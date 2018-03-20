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
    public class OracleTabDao:ITabDao
    {
        public List<Tab> SearchTab(Tab tab)
        {
            try
            {
                string SP = "security_pkg. p_tab_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<Tab> lst = new List<Tab>();
                Tab obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new Tab();
                    obj.TabId = drow["TAB_ID"].ToString();//APPLICATION_ID
                    obj.TabDesc = drow["TAB_DESC"].ToString();//APPLICATION_DESCRIPTION
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
