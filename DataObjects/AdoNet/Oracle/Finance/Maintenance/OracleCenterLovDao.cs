using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleCenterLovDao : ICenterLovDao
    {
        public object Get()
        {
            string sp = "centerlov_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CenterLov> lst = new List<CenterLov>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CenterLov obj = new CenterLov();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.InstituteCode = drow["InstituteCode"].ToString();
                    obj.InstituteName = drow["InstituteName"].ToString();
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.EmployeeName = drow["EmployeeName"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(CenterLov centerlov)
        {
            string sp = "centerlov_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", centerlov.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", centerlov.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstituteCode", centerlov.InstituteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstituteName", centerlov.InstituteName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", centerlov.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", centerlov.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", centerlov.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(CenterLov centerlov)
        {
            string sp = "fn_center_pkg.p_center_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_InstituteCode", centerlov.InstituteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", centerlov.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CenterLov> lst = new List<CenterLov>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CenterLov obj = new CenterLov();
                    /*
                     * FC.CENTER_CODE,INITCAP(FC.CENTER_NAME) AS CENTER_NAME, MI.INSTITUTE_CODE, MI.INSTITUTE_NAME, 
                        FC.EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(FC.EMPLOYEE_ID) AS EMP_NAME,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
                     FROM FN_CENTER FC, MS_INSTITUTE MI */

                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.InstituteCode = drow["INSTITUTE_CODE"].ToString();
                    obj.InstituteName = drow["INSTITUTE_NAME"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.EmployeeName = drow["EMP_NAME"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetTransferLovList(CenterLov centerlov)
        {
            string sp = "fn_center_pkg.p_transfer_center_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", centerlov.InstituteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_name", centerlov.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_old_center_code", centerlov.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CenterLov> lst = new List<CenterLov>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CenterLov obj = new CenterLov();
                    /*
                     * FC.CENTER_CODE,INITCAP(FC.CENTER_NAME) AS CENTER_NAME, MI.INSTITUTE_CODE, MI.INSTITUTE_NAME, 
                        FC.EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(FC.EMPLOYEE_ID) AS EMP_NAME,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
                     FROM FN_CENTER FC, MS_INSTITUTE MI */

                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();


                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

    }
}
