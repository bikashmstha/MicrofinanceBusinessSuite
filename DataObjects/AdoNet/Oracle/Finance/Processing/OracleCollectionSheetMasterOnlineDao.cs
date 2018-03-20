using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleCollectionSheetMasterOnlineDao : ICollectionSheetMasterOnlineDao
    {
        public object SaveCollectionSheetMasterOnline(CollectionSheetMasterOnline collectionSheetMasterOnline)
        {
            string sp = "collectionSheetMasterOnline_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_SHEET_NO", collectionSheetMasterOnline.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", collectionSheetMasterOnline.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", collectionSheetMasterOnline.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", collectionSheetMasterOnline.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", collectionSheetMasterOnline.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_FUND_AMOUNT", collectionSheetMasterOnline.CenterFundAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_FUND_ACCOUNT", collectionSheetMasterOnline.CenterFundAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", collectionSheetMasterOnline.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", collectionSheetMasterOnline.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchCollectionSheetMasterOnline(CollectionSheetMasterOnline collectionSheetMasterOnline)
        {
            string sp = "collectionSheetMasterOnline_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_SHEET_NO", collectionSheetMasterOnline.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", collectionSheetMasterOnline.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", collectionSheetMasterOnline.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", collectionSheetMasterOnline.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", collectionSheetMasterOnline.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_FUND_AMOUNT", collectionSheetMasterOnline.CenterFundAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_FUND_ACCOUNT", collectionSheetMasterOnline.CenterFundAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", collectionSheetMasterOnline.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CollectionSheetMasterOnline> lst = new List<CollectionSheetMasterOnline>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    CollectionSheetMasterOnline obj = new CollectionSheetMasterOnline();
                    obj.CollectionSheetNo = drow["COLLECTION_SHEET_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.CenterFundAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CENTER_FUND_AMOUNT"].ToString()));
                    obj.CenterFundAccount = drow["CENTER_FUND_ACCOUNT"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetCollectionSheetMstOnline(string OfficeCode)
        {
            string sp = "transaction_approval_pkg.p_collection_sheet_mst_online";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CollectionSheetMasterOnline> lst = new List<CollectionSheetMasterOnline>();

                for (int i = 0; i < 10; i++)
                {

                    CollectionSheetMasterOnline obj = new CollectionSheetMasterOnline();
                    obj.CollectionSheetNo = i.ToString();
                    obj.CenterCode = i.ToString();
                    obj.CenterName = i.ToString();
                    obj.EmployeeId = i.ToString();
                    obj.EmpName = i.ToString();
                    obj.CenterFundAmount = i;
                    obj.CenterFundAccount = i.ToString();
                    obj.TranOfficeCode = i.ToString();

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    CollectionSheetMasterOnline obj = new CollectionSheetMasterOnline();
                //    obj.CollectionSheetNo = drow["COLLECTION_SHEET_NO"].ToString();
                //    obj.CenterCode = drow["CENTER_CODE"].ToString();
                //    obj.CenterName = drow["CENTER_NAME"].ToString();
                //    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                //    obj.EmpName = drow["EMP_NAME"].ToString();
                //    obj.CenterFundAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CENTER_FUND_AMOUNT"].ToString()));
                //    obj.CenterFundAccount = drow["CENTER_FUND_ACCOUNT"].ToString();
                //    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

                //    lst.Add(obj);
                //}
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}

