using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using BusinessObjects.BusinessRules;
using DataObjects.Security;

namespace DataObjects.AdoNet.Oracle.Security
{
    /// <summary>
    /// Oracle specific data access object that handles data access
    /// of customers. The details are stubbed out (in a crude way) but should be 
    /// relatively easy to implement as they are similar to MS Access and 
    /// Sql Server Data access objects.
    ///
    /// Enterprise Design Pattern: Service Stub.
    /// </summary>
    public class OracleMenuDao : IMenuDao
    {

        public List<Menu> GetMenuListByUser(GenericUser user)
        {
            GetConnection gc = new GetConnection();
            OracleConnection objConn;
            try
            {

                objConn = gc.GetDbConn();

                User u = user as User;
                string SP = "security_pkg.p_get_menu_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_user_id", u.UserID, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_module_id", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_sod_eod", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_report_type", null, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(objConn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<Menu> lst = new List<Menu>();



                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Menu obj = new Menu();
                    obj.AppID = drow["MODULE_ID"].ToString();//APPLICATION_ID
                    obj.AppDesc = drow["MODULE_DESC"].ToString();//APPLICATION_DESCRIPTION

                    obj.ModuleID = drow["TAB_ID"].ToString();
                    obj.ModuleDesc = drow["TAB_DESC"].ToString();

                    obj.SubModuleID = drow["REPORT_TYPE_CODE"].ToString();
                    obj.SubModuleDesc = drow["REPORT_TYPE_DESC"].ToString();
                    //obj.FuncCD = drow["FUN_CD"].ToString();
                    //obj.FuncDesc = drow["FUN_DESC"].ToString();
                    obj.MenuName = string.IsNullOrEmpty(drow["NEW_WEB_FORM_NAME"].ToString()) ? drow["DISPLAY_NAME"].ToString() : drow["NEW_WEB_FORM_NAME"].ToString(); //NEW_WEB_FORM_NAME
                    //obj.MenuName = drow["WEB_FORM_NAME"].ToString(); //NEW_WEB_FORM_NAME
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<Menu>();

            }
        }
    }
}
