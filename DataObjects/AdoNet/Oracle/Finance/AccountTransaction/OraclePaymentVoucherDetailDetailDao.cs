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
    public class OraclePaymentVoucherDetailDetailDao : IPaymentVoucherDetailDetailDao
    {
        public object SavePaymentVoucherDetailDetail(PaymentVoucherDetailDetail paymentVoucherDetailDetail)
        {
            string sp = "paymentVoucherDetailDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_ID", paymentVoucherDetailDetail.TransactionId, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", paymentVoucherDetailDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", paymentVoucherDetailDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", paymentVoucherDetailDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DR_CR_FLAG", paymentVoucherDetailDetail.DrCrFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", paymentVoucherDetailDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENCY_CODE", paymentVoucherDetailDetail.CurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_TYPE", paymentVoucherDetailDetail.TranType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DML_TYPE", paymentVoucherDetailDetail.DmlType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", paymentVoucherDetailDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", paymentVoucherDetailDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE_DET", paymentVoucherDetailDetail.TranOfficeCode_Det, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DR_AMOUNT", paymentVoucherDetailDetail.DrAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CR_AMOUNT", paymentVoucherDetailDetail.CrAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", paymentVoucherDetailDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPaymentVoucherDetailDetail(PaymentVoucherDetailDetail paymentVoucherDetailDetail)
        {
            string sp = "paymentVoucherDetailDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_ID", paymentVoucherDetailDetail.TransactionId, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", paymentVoucherDetailDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", paymentVoucherDetailDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", paymentVoucherDetailDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DR_CR_FLAG", paymentVoucherDetailDetail.DrCrFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", paymentVoucherDetailDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENCY_CODE", paymentVoucherDetailDetail.CurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_TYPE", paymentVoucherDetailDetail.TranType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DML_TYPE", paymentVoucherDetailDetail.DmlType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", paymentVoucherDetailDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", paymentVoucherDetailDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE_DET", paymentVoucherDetailDetail.TranOfficeCode_Det, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DR_AMOUNT", paymentVoucherDetailDetail.DrAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CR_AMOUNT", paymentVoucherDetailDetail.CrAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PaymentVoucherDetailDetail> lst = new List<PaymentVoucherDetailDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PaymentVoucherDetailDetail obj = new PaymentVoucherDetailDetail();
                    obj.TransactionId = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_ID"].ToString()));
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.Particulars = drow["PARTICULARS"].ToString();
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));
                    obj.DrCrFlag = drow["DR_CR_FLAG"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.CurrencyCode = drow["CURRENCY_CODE"].ToString();
                    obj.TranType = drow["TRAN_TYPE"].ToString();
                    obj.DmlType = drow["DML_TYPE"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.TranOfficeCode_Det = drow["TRAN_OFFICE_CODE_DET"].ToString();
                    obj.DrAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DR_AMOUNT"].ToString()));
                    obj.CrAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CR_AMOUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPayVoucherDtlDetail(string VoucherNo)
        {
            string sp = "gl_voucher_utility_pkg.p_pay_voucher_dtl_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_VOUCHER_NO", VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PaymentVoucherDetailDetail> lst = new List<PaymentVoucherDetailDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PaymentVoucherDetailDetail obj = new PaymentVoucherDetailDetail();
                    obj.TransactionId = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_ID"].ToString()));
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.Particulars = drow["PARTICULARS"].ToString();
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));
                    obj.DrCrFlag = drow["DR_CR_FLAG"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.CurrencyCode = drow["CURRENCY_CODE"].ToString();
                    obj.TranType = drow["TRAN_TYPE"].ToString();
                    obj.DmlType = drow["DML_TYPE"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.TranOfficeCode_Det = drow["TRAN_OFFICE_CODE_DET"].ToString();
                    obj.DrAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DR_AMOUNT"].ToString()));
                    obj.CrAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CR_AMOUNT"].ToString()));

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
