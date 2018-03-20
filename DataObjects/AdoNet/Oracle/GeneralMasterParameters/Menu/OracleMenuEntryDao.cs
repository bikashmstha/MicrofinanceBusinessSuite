using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using BusinessObjects;
namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleMenuEntryDao : IMenuEntryDao
    {
        private List<OracleParameter> PrepareParameterList(MenuEntry menuEntry)
        {
            
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_row_id", menuEntry.RowID, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_form_id", menuEntry.FormID, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_form_name", menuEntry.FormName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_display_name", menuEntry.DisplayName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_tab_id", menuEntry.TabID, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_display_seq", menuEntry.DisplaySeq, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_module_id", menuEntry.ModuleID, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_report_type", menuEntry.ReportType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_web_form_name", menuEntry.WebFormName, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update", menuEntry.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[10].Size = 10;
            paramList[11].Size = 100;

            return paramList;

        }
       
        public List<MenuEntry> GetMenuLists(string moduleid,string tabid)
        {
            try
            {
                string SP = "security_pkg.p_menu_entry_list";
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_module_id", moduleid, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tab_id", tabid, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<MenuEntry> lst = new List<MenuEntry>();
                MenuEntry obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new MenuEntry();
                    obj.RowID = drow["ROW_ID"].ToString();//APPLICATION_ID
                    obj.FormID = drow["FORM_ID"].ToString();//APPLICATION_DESCRIPTION
                    obj.FormName = drow["FORM_NAME"].ToString();//APPLICATION_CODE
                    obj.WebFormName = drow["WEB_FORM_NAME"].ToString();
                    obj.DisplayName = drow["DISPLAY_NAME"].ToString();
                    obj.TabID = drow["TAB_ID"].ToString();
                    obj.TabDesc = drow["TAB_DESC"].ToString();
                    obj.ModuleID = drow["MODULE_ID"].ToString();
                    obj.ModuleDesc = drow["MODULE_DESC"].ToString();
                    obj.ReportType = drow["REPORT_TYPE"].ToString();
                    obj.RepoTypeDesc = drow["REPO_TYPE_DESC"].ToString();
                    obj.DisplaySeq = drow["DISPLAY_SEQ"].ToString();
                     
                    obj.Action = "U";

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public OutMessage SaveMenuEntry(MenuEntry menuEntry)
        {
            string SP = "SECURITY_PKG.P_FORM_ACCESS_MASTER";
            OracleConnection conn = new GetConnection().GetDbConn();
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(menuEntry);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[10].Value.ToString();
                oMsg.OutResultMessage = paramList[11].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
