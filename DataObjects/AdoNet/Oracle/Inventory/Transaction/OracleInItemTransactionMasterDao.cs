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
    public class OracleInItemTransactionMasterDao : IInItemTransactionMasterDao
    {
        private static IItemTransactionDetailDao itemTransactionDetailDao = DataAccess.ItemTransactionDetailDao;
        public object SaveInItemTransactionMaster(InItemTransactionMaster inItemTransactionMaster)
        {
            string sp = "in_inventory_trans_pkg.p_in_item_tran_master";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", inItemTransactionMaster.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_CODE", inItemTransactionMaster.SupplierCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", inItemTransactionMaster.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_TYPE", inItemTransactionMaster.TransactionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", inItemTransactionMaster.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_NEP", inItemTransactionMaster.TransactionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", inItemTransactionMaster.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", inItemTransactionMaster.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", inItemTransactionMaster.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTED_FLAG", inItemTransactionMaster.PostedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARENT_REF_NO", inItemTransactionMaster.ParentRefNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", inItemTransactionMaster.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", inItemTransactionMaster.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMO_RECEIPT_NO", inItemTransactionMaster.MemoReceiptNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_TAG", inItemTransactionMaster.ApprovedTag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", inItemTransactionMaster.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CRE_TRAN_OFFICE_CODE", inItemTransactionMaster.CreTranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", inItemTransactionMaster.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_REFERENCE_NO", inItemTransactionMaster.OutReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());

                itemTransactionDetailDao.SaveItemTransactionDetail(inItemTransactionMaster.ItemTransactionDetails, tran, paramList[18].Value.ToString());

                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchInItemTransactionMaster(InItemTransactionMaster inItemTransactionMaster)
        {
            string sp = "inItemTransactionMaster_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", inItemTransactionMaster.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUPPLIER_CODE", inItemTransactionMaster.SupplierCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOCATION_CODE", inItemTransactionMaster.LocationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_TYPE", inItemTransactionMaster.TransactionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", inItemTransactionMaster.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_NEP", inItemTransactionMaster.TransactionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", inItemTransactionMaster.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", inItemTransactionMaster.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", inItemTransactionMaster.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTED_FLAG", inItemTransactionMaster.PostedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARENT_REF_NO", inItemTransactionMaster.ParentRefNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPT_CODE", inItemTransactionMaster.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", inItemTransactionMaster.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMO_RECEIPT_NO", inItemTransactionMaster.MemoReceiptNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_TAG", inItemTransactionMaster.ApprovedTag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", inItemTransactionMaster.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CRE_TRAN_OFFICE_CODE", inItemTransactionMaster.CreTranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", inItemTransactionMaster.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_REFERENCE_NO", inItemTransactionMaster.OutReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<InItemTransactionMaster> lst = new List<InItemTransactionMaster>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    InItemTransactionMaster obj = new InItemTransactionMaster();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.SupplierCode = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SUPPLIER_CODE"].ToString()));
                    obj.LocationCode = drow["LOCATION_CODE"].ToString();
                    obj.TransactionType = drow["TRANSACTION_TYPE"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.TransactionDateNep = drow["TRANSACTION_DATE_NEP"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.Date1 = drow["DATE1"].ToString();
                    obj.Username = drow["USERNAME"].ToString();
                    obj.PostedFlag = drow["POSTED_FLAG"].ToString();
                    obj.ParentRefNo = drow["PARENT_REF_NO"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.MemoReceiptNo = drow["MEMO_RECEIPT_NO"].ToString();
                    obj.ApprovedTag = drow["APPROVED_TAG"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CreTranOffice_Code = drow["CRE_TRAN_OFFICE_CODE"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutReferenceNo = drow["OUT_REFERENCE_NO"].ToString();

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
