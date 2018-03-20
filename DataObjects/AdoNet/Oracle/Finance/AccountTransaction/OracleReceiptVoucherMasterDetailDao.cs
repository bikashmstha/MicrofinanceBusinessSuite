using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle
{
    public class OracleReceiptVoucherMasterDetailDao : IReceiptVoucherMasterDetailDao
    {
        public object SaveReceiptVoucherMasterDetail(ReceiptVoucherMasterDetail receiptVoucherMasterDetail)
        {
            string sp = "receiptVoucherMasterDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", receiptVoucherMasterDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", receiptVoucherMasterDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_AD", receiptVoucherMasterDetail.TransactionDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEPALI_DATE", receiptVoucherMasterDetail.NepaliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", receiptVoucherMasterDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", receiptVoucherMasterDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", receiptVoucherMasterDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_BILL_NO", receiptVoucherMasterDetail.ChequeBillNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", receiptVoucherMasterDetail.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", receiptVoucherMasterDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", receiptVoucherMasterDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", receiptVoucherMasterDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_TYPE", receiptVoucherMasterDetail.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", receiptVoucherMasterDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", receiptVoucherMasterDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchReceiptVoucherMasterDetail(ReceiptVoucherMasterDetail receiptVoucherMasterDetail)
        {
            string sp = "receiptVoucherMasterDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", receiptVoucherMasterDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", receiptVoucherMasterDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_AD", receiptVoucherMasterDetail.TransactionDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEPALI_DATE", receiptVoucherMasterDetail.NepaliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", receiptVoucherMasterDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", receiptVoucherMasterDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", receiptVoucherMasterDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_BILL_NO", receiptVoucherMasterDetail.ChequeBillNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", receiptVoucherMasterDetail.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", receiptVoucherMasterDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", receiptVoucherMasterDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", receiptVoucherMasterDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_TYPE", receiptVoucherMasterDetail.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", receiptVoucherMasterDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ReceiptVoucherMasterDetail> lst = new List<ReceiptVoucherMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ReceiptVoucherMasterDetail obj = new ReceiptVoucherMasterDetail();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.TransactionDateAd = drow["TRANSACTION_DATE_AD"].ToString();
                    obj.NepaliDate = drow["NEPALI_DATE"].ToString();
                    obj.Particulars = drow["PARTICULARS"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();

                    obj.ChequeBillNo = drow["CHEQUE_BILL_NO"].ToString();
                    obj.ApprovedDateBs = drow["APPROVED_DATE_BS"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.VoucherType = drow["VOUCHER_TYPE"].ToString();
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetReceiptVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            string sp = "gl_voucher_utility_pkg.p_receipt_voucher_mst_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_VOUCHER_NO", VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ReceiptVoucherMasterDetail> lst = new List<ReceiptVoucherMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ReceiptVoucherMasterDetail obj = new ReceiptVoucherMasterDetail();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.TransactionDateAd = drow["TRANSACTION_DATE_AD"].ToString();
                    obj.NepaliDate = drow["NEPALI_DATE"].ToString();
                    obj.Particulars = drow["PARTICULARS"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();

                    obj.ChequeBillNo = drow["CHEQUE_BILL_NO"].ToString();
                    obj.ApprovedDateBs = drow["APPROVED_DATE_BS"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.VoucherType = drow["VOUCHER_TYPE"].ToString();
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));

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
