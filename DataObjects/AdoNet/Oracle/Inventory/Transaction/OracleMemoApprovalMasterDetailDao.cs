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
    public class OracleMemoApprovalMasterDetailDao : IMemoApprovalMasterDetailDao
    {
        public object SaveMemoApprovalMasterDetail(MemoApprovalMasterDetail memoApprovalMasterDetail)
        {
            string sp = "memoApprovalMasterDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", memoApprovalMasterDetail.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memoApprovalMasterDetail.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_NEP", memoApprovalMasterDetail.TransactionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", memoApprovalMasterDetail.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_DESC", memoApprovalMasterDetail.LocationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", memoApprovalMasterDetail.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_DESC", memoApprovalMasterDetail.DeptDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", memoApprovalMasterDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_TAG", memoApprovalMasterDetail.ApprovedTag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_QUANTITY", memoApprovalMasterDetail.Quantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_COST", memoApprovalMasterDetail.TotalCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_TYPE", memoApprovalMasterDetail.TransactionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memoApprovalMasterDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchMemoApprovalMasterDetail(MemoApprovalMasterDetail memoApprovalMasterDetail)
        {
            string sp = "memoApprovalMasterDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", memoApprovalMasterDetail.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memoApprovalMasterDetail.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_NEP", memoApprovalMasterDetail.TransactionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", memoApprovalMasterDetail.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_DESC", memoApprovalMasterDetail.LocationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", memoApprovalMasterDetail.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_DESC", memoApprovalMasterDetail.DeptDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", memoApprovalMasterDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_TAG", memoApprovalMasterDetail.ApprovedTag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_QUANTITY", memoApprovalMasterDetail.Quantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_COST", memoApprovalMasterDetail.TotalCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_TYPE", memoApprovalMasterDetail.TransactionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemoApprovalMasterDetail> lst = new List<MemoApprovalMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemoApprovalMasterDetail obj = new MemoApprovalMasterDetail();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.TransactionDateNep = drow["TRANSACTION_DATE_NEP"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.LocationDesc = drow["LOCATION_DESC"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptDesc = drow["DEPT_DESC"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ApprovedTag = drow["APPROVED_TAG"].ToString();
                    obj.Quantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["QUANTITY"].ToString()));
                    obj.TotalCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_COST"].ToString()));
                    obj.TransactionType = drow["TRANSACTION_TYPE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemoApprovalMstDetail(string OfficeCode)
        {
            string sp = "in_inventory_utility_pkg.p_memo_approval_mst_detail";
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
                List<MemoApprovalMasterDetail> lst = new List<MemoApprovalMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemoApprovalMasterDetail obj = new MemoApprovalMasterDetail();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.TransactionDateNep = drow["TRANSACTION_DATE_NEP"].ToString();
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.LocationDesc = drow["LOCATION_DESC"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptDesc = drow["DEPT_DESC"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ApprovedTag = drow["APPROVED_TAG"].ToString();
                    obj.Quantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["QUANTITY"].ToString()));
                    obj.TotalCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_COST"].ToString()));
                    obj.TransactionType = drow["TRANSACTION_TYPE"].ToString();

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
