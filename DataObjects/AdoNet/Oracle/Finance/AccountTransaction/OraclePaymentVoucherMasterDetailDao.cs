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
    public class OraclePaymentVoucherMasterDetailDao : IPaymentVoucherMasterDetailDao
    {
        public object SavePaymentVoucherMasterDetail(PaymentVoucherMasterDetail paymentVoucherMasterDetail)
        {
            string sp = "paymentVoucherMasterDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", paymentVoucherMasterDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", paymentVoucherMasterDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_AD", paymentVoucherMasterDetail.TransactionDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEPALI_DATE", paymentVoucherMasterDetail.NepaliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", paymentVoucherMasterDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", paymentVoucherMasterDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", paymentVoucherMasterDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_BILL_NO", paymentVoucherMasterDetail.ChequeBillNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", paymentVoucherMasterDetail.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", paymentVoucherMasterDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", paymentVoucherMasterDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", paymentVoucherMasterDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_TYPE", paymentVoucherMasterDetail.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", paymentVoucherMasterDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", paymentVoucherMasterDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MASTER_PARTICULARS", paymentVoucherMasterDetail.MasterParticulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", paymentVoucherMasterDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", paymentVoucherMasterDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", paymentVoucherMasterDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPaymentVoucherMasterDetail(PaymentVoucherMasterDetail paymentVoucherMasterDetail)
        {
            string sp = "paymentVoucherMasterDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", paymentVoucherMasterDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", paymentVoucherMasterDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE_AD", paymentVoucherMasterDetail.TransactionDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEPALI_DATE", paymentVoucherMasterDetail.NepaliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", paymentVoucherMasterDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", paymentVoucherMasterDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", paymentVoucherMasterDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_BILL_NO", paymentVoucherMasterDetail.ChequeBillNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", paymentVoucherMasterDetail.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", paymentVoucherMasterDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", paymentVoucherMasterDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", paymentVoucherMasterDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_TYPE", paymentVoucherMasterDetail.VoucherType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", paymentVoucherMasterDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", paymentVoucherMasterDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MASTER_PARTICULARS", paymentVoucherMasterDetail.MasterParticulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", paymentVoucherMasterDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", paymentVoucherMasterDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PaymentVoucherMasterDetail> lst = new List<PaymentVoucherMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PaymentVoucherMasterDetail obj = new PaymentVoucherMasterDetail();
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
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.MasterParticulars = drow["MASTER_PARTICULARS"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPayVoucherMstDetail(string OfficeCode, string VoucherNo, string FromDate, string ToDate)
        {
            string sp = "gl_voucher_utility_pkg.p_pay_voucher_mst_detail";
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
                List<PaymentVoucherMasterDetail> lst = new List<PaymentVoucherMasterDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PaymentVoucherMasterDetail obj = new PaymentVoucherMasterDetail();
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
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.MasterParticulars = drow["MASTER_PARTICULARS"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();

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
