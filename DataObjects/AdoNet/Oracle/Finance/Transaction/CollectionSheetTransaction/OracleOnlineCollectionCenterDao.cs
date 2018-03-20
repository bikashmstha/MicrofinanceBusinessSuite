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
    public class OracleOnlineCollectionCenterDao : IOnlineCollectionCenterDao
    {
        public object Get()
        {
            string sp = "onlineCollectionCenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OnlineCollectionCenter> lst = new List<OnlineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OnlineCollectionCenter obj = new OnlineCollectionCenter();
                    obj.CollectionDateBs = drow["CollectionDateBs"].ToString();
                    obj.DataEntered = drow["DataEntered"].ToString();
                    obj.RowCount = int.Parse(drow["RowCount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterFundAmount = int.Parse(drow["CenterFundAmount"].ToString());
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(OnlineCollectionCenter onlineCollectionCenter)
        {
            string sp = "onlineCollectionCenter_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDateBs", onlineCollectionCenter.CollectionDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DataEntered", onlineCollectionCenter.DataEntered, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", onlineCollectionCenter.RowCount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", onlineCollectionCenter.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterFundAmount", onlineCollectionCenter.CenterFundAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", onlineCollectionCenter.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", onlineCollectionCenter.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", onlineCollectionCenter.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(OnlineCollectionCenter onlineCollectionCenter)
        {
            string sp = "onlineCollectionCenter_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDateBs", onlineCollectionCenter.CollectionDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DataEntered", onlineCollectionCenter.DataEntered, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", onlineCollectionCenter.RowCount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", onlineCollectionCenter.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterFundAmount", onlineCollectionCenter.CenterFundAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", onlineCollectionCenter.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", onlineCollectionCenter.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OnlineCollectionCenter> lst = new List<OnlineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OnlineCollectionCenter obj = new OnlineCollectionCenter();
                    obj.CollectionDateBs = drow["CollectionDateBs"].ToString();
                    obj.DataEntered = drow["DataEntered"].ToString();
                    obj.RowCount = int.Parse(drow["RowCount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterFundAmount = int.Parse(drow["CenterFundAmount"].ToString());
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetOnlineCenters(string date, string offCode, string centerName)
        {
            string sp = "collection_sheet_generate_pkg. p_center_collect_online_lov";
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
                List<OnlineCollectionCenter> lst = new List<OnlineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OnlineCollectionCenter obj = new OnlineCollectionCenter();
                    obj.CollectionDateBs = drow["COLLECTION_DATE_BS"].ToString();
                    obj.CollectionDateAd = drow["COLLECTION_DATE_AD"].ToString();
                    obj.DataEntered = drow["DATA_ENTERED"].ToString();
                    obj.RowCount = int.Parse(drow["ROW_COUNT"].ToString());
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterFundAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber( drow["CENTER_FUND_AMOUNT"].ToString()));
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.CollectionSheetNo = drow["COLLECTION_SHEET_NO"].ToString();
                    obj.EmployeeId = drow["Employee_ID"].ToString();
                    obj.EmployeeName = drow["Employee_NAME"].ToString();


                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    

        public object GetOnlineCenterList(string offCode, string centerName)
        {
            string sp = "fn_center_pkg.p_online_coll_center_list";
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
                List<OnlineCollectionCenter> lst = new List<OnlineCollectionCenter>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OnlineCollectionCenter obj = new OnlineCollectionCenter();
                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.InstituteCode = drow["Institute_Code"].ToString();
                    obj.InstituteName = drow["Institute_Code"].ToString();
                    obj.CollectionSheetNo = drow["Institute_Name"].ToString();

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
