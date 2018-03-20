using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using DataObjects.Interfaces.Inventory;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Inventory
{
    public class OracleMemoMasterDetailDao : IMemoMasterDetailDao
    {
        public object SaveMemoMasterDetail(MemoMasterDetail memoMasterDetail)
        {
            string sp = "memoMasterDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", memoMasterDetail.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", memoMasterDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", memoMasterDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", memoMasterDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", memoMasterDetail.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_DESC", memoMasterDetail.LocationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memoMasterDetail.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_NEP", memoMasterDetail.TransactionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", memoMasterDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", memoMasterDetail.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_NAME", memoMasterDetail.DeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMO_RECEIPT_NO", memoMasterDetail.MemoReceiptNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", memoMasterDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memoMasterDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchMemoMasterDetail(MemoMasterDetail memoMasterDetail)
        {
            string sp = "memoMasterDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", memoMasterDetail.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", memoMasterDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", memoMasterDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", memoMasterDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", memoMasterDetail.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_DESC", memoMasterDetail.LocationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memoMasterDetail.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_NEP", memoMasterDetail.TransactionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", memoMasterDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", memoMasterDetail.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_NAME", memoMasterDetail.DeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMO_RECEIPT_NO", memoMasterDetail.MemoReceiptNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", memoMasterDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemoMasterDetail> lst = new List<MemoMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemoMasterDetail obj = new MemoMasterDetail();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.LocationDesc = drow["LOCATION_DESC"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.TransactionDateNep = drow["TRANSACTION_DATE_NEP"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.MemoReceiptNo = drow["MEMO_RECEIPT_NO"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemoMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            string sp = "in_inventory_utility_pkg.p_memo_mst_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_REFERENCE_NO", ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FISCAL_YEAR", FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOCATION_CODE", LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemoMasterDetail> lst = new List<MemoMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemoMasterDetail obj = new MemoMasterDetail();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.LocationDesc = drow["LOCATION_DESC"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.TransactionDateNep = drow["TRANSACTION_DATE_NEP"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.MemoReceiptNo = drow["MEMO_RECEIPT_NO"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

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
