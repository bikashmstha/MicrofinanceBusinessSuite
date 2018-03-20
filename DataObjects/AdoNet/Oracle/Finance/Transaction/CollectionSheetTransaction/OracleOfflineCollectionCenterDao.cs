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

    public class OracleOfflineCollectionCenterDao : IOfflineCollectionCenterDao
    {
        public object Get()
        {
            string sp = "offlineCollectionCenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OfflineCollectionCenter> lst = new List<OfflineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OfflineCollectionCenter obj = new OfflineCollectionCenter();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.EmployeeName = drow["EmployeeName"].ToString();
                    obj.FirstCollectionDate = drow["FirstCollectionDate"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(OfflineCollectionCenter offlineCollectionCenter)
        {
            string sp = "offlineCollectionCenter_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", offlineCollectionCenter.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", offlineCollectionCenter.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", offlineCollectionCenter.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstCollectionDate", offlineCollectionCenter.FirstCollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", offlineCollectionCenter.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(OfflineCollectionCenter offlineCollectionCenter)
        {
            string sp = "offlineCollectionCenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", offlineCollectionCenter.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", offlineCollectionCenter.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", offlineCollectionCenter.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstCollectionDate", offlineCollectionCenter.FirstCollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OfflineCollectionCenter> lst = new List<OfflineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OfflineCollectionCenter obj = new OfflineCollectionCenter();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.EmployeeName = drow["EmployeeName"].ToString();
                    obj.FirstCollectionDate = drow["FirstCollectionDate"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetOfflineCollectionCenter(string offCode, string centerName)
        {
            string sp = "fn_center_pkg.p_offline_coll_center_list";

            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_name", centerName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OfflineCollectionCenter> lst = new List<OfflineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    //SELECT ,INITCAP(CENTER_NAME) AS ,EMPLOYEE_ID,HR_EMPLOYEE_PKG.F_EMPLOYEE_NAME(EMPLOYEE_ID) AS EMP_NAME,FIRST_COLLECTION_DATE,ROW_NUMBER() OVER (ORDER BY CENTER_CODE) ROW_COUNT 
  
                    OfflineCollectionCenter obj = new OfflineCollectionCenter();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.EmpId = drow["EMPLOYEE_ID"].ToString();
                    obj.EmployeeName = drow["EMP_NAME"].ToString();
                    obj.FirstCollectionDate = drow["FIRST_COLLECTION_DATE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetOfflineCollectionCenterByDate(string date,string offCode, string centerName)
        {
            string sp = "collection_sheet_generate_pkg.p_center_collect_offline_lov";

            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_date", date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_name", centerName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OfflineCollectionCenter> lst = new List<OfflineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
         
                    OfflineCollectionCenter obj = new OfflineCollectionCenter();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterFundAmount = drow["CENTER_FUND_AMOUNT"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.CollectionSheetNo = drow["COLLECTION_SHEET_NO"].ToString();
                    obj.CollectionDateBS = drow["COLLECTION_DATE_BS"].ToString();
                    obj.DataEntered = drow["DATA_ENTERED"].ToString();

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

