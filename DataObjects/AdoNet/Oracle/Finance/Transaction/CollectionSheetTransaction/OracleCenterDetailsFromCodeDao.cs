using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleCenterDetailsFromCodeDao : ICenterDetailsFromCodeDao
    {

        public object Get()
        {
            string sp = "centerDetailsFromCode_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CenterDetailsFromCode> lst = new List<CenterDetailsFromCode>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CenterDetailsFromCode obj = new CenterDetailsFromCode();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.EmployeeName = drow["EmployeeName"].ToString();
                    obj.CollectionDay = drow["CollectionDay"].ToString();
                    obj.CollectionDate = drow["CollectionDate"].ToString();
                    obj.CollectionDateBS = drow["CollectionDateBS"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(CenterDetailsFromCode centerDetailsFromCode)
        {
            string sp = "centerDetailsFromCode_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", centerDetailsFromCode.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", centerDetailsFromCode.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", centerDetailsFromCode.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDay", centerDetailsFromCode.CollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDate", centerDetailsFromCode.CollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDateBS", centerDetailsFromCode.CollectionDateBS, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", centerDetailsFromCode.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(CenterDetailsFromCode centerDetailsFromCode)
        {
            string sp = "centerDetailsFromCode_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", centerDetailsFromCode.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", centerDetailsFromCode.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", centerDetailsFromCode.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDay", centerDetailsFromCode.CollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDate", centerDetailsFromCode.CollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDateBS", centerDetailsFromCode.CollectionDateBS, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CenterDetailsFromCode> lst = new List<CenterDetailsFromCode>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CenterDetailsFromCode obj = new CenterDetailsFromCode();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.EmployeeName = drow["EmployeeName"].ToString();
                    obj.CollectionDay = drow["CollectionDay"].ToString();
                    obj.CollectionDate = drow["CollectionDate"].ToString();
                    obj.CollectionDateBS = drow["CollectionDateBS"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetCenterDetailsFromCode(string centerCode)
        {
            string sp = "collection_sheet_generate_pkg.p_center_details_from_code";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_employee_id", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_employee_name", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_collection_day", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_collection_date", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_collection_date_bs", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CenterDetailsFromCode> lst = new List<CenterDetailsFromCode>();

                CenterDetailsFromCode obj = new CenterDetailsFromCode();
                obj.CenterCode = centerCode;
                obj.EmployeeId = paramList[1].Value.ToString();
                obj.EmployeeName = paramList[2].Value.ToString();
                obj.CollectionDay = paramList[3].Value.ToString();
                obj.CollectionDate = paramList[4].Value.ToString();
                obj.CollectionDateBS = paramList[5].Value.ToString();

                obj.Action = "U";
                lst.Add(obj);

                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

    }
}
