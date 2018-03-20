using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OraclePublicAccountCloseDetailDao : IPublicAccountCloseDetailDao
    {
        public object SavePublicAccountCloseDetail(PublicAccountCloseDetail publicAccountCloseDetail)
        {
            string sp = "publicAccountCloseDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicAccountCloseDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicAccountCloseDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicAccountCloseDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE_AD", publicAccountCloseDetail.WithdrawDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE_BS", publicAccountCloseDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicAccountCloseDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", publicAccountCloseDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicAccountCloseDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", publicAccountCloseDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicAccountCloseDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicAccountCloseDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicAccountCloseDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicAccountCloseDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RECEIVED_INTEREST_AMOUNT", publicAccountCloseDetail.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_CLOSING", publicAccountCloseDetail.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicAccountCloseDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicAccountCloseDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE", publicAccountCloseDetail.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", publicAccountCloseDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNPOST_INTEREST", publicAccountCloseDetail.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_AMOUNT", publicAccountCloseDetail.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", publicAccountCloseDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", publicAccountCloseDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", publicAccountCloseDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicAccountCloseDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", publicAccountCloseDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", publicAccountCloseDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HALF_WAY_INT", publicAccountCloseDetail.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_EXP_AMOUNT", publicAccountCloseDetail.OtherIncomeExp_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_EXP_VOUCHER_NO", publicAccountCloseDetail.OtherIncomeExp_Voucher_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMT_AT_MATURE", publicAccountCloseDetail.AmtAtMature, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_BAL", publicAccountCloseDetail.TotalBal, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_INT_RATE", publicAccountCloseDetail.MidTermInt_Rate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicAccountCloseDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicAccountCloseDetail(PublicAccountCloseDetail publicAccountCloseDetail)
        {
            string sp = "publicAccountCloseDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicAccountCloseDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicAccountCloseDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicAccountCloseDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE_AD", publicAccountCloseDetail.WithdrawDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE_BS", publicAccountCloseDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicAccountCloseDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", publicAccountCloseDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicAccountCloseDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", publicAccountCloseDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicAccountCloseDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicAccountCloseDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicAccountCloseDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicAccountCloseDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RECEIVED_INTEREST_AMOUNT", publicAccountCloseDetail.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_CLOSING", publicAccountCloseDetail.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicAccountCloseDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicAccountCloseDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE", publicAccountCloseDetail.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", publicAccountCloseDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNPOST_INTEREST", publicAccountCloseDetail.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_AMOUNT", publicAccountCloseDetail.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", publicAccountCloseDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", publicAccountCloseDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", publicAccountCloseDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPERATION_TYPE", publicAccountCloseDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", publicAccountCloseDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", publicAccountCloseDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HALF_WAY_INT", publicAccountCloseDetail.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_EXP_AMOUNT", publicAccountCloseDetail.OtherIncomeExp_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_EXP_VOUCHER_NO", publicAccountCloseDetail.OtherIncomeExp_Voucher_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMT_AT_MATURE", publicAccountCloseDetail.AmtAtMature, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_BAL", publicAccountCloseDetail.TotalBal, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_INT_RATE", publicAccountCloseDetail.MidTermInt_Rate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicAccountCloseDetail> lst = new List<PublicAccountCloseDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicAccountCloseDetail obj = new PublicAccountCloseDetail();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.WithdrawDateAd = drow["WITHDRAW_DATE_AD"].ToString();
                    obj.WithdrawDateBs = drow["WITHDRAW_DATE_BS"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CONTRA_AC_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.ReceivedInterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["RECEIVED_INTEREST_AMOUNT"].ToString()));
                    obj.ReasonForClosing = drow["REASON_FOR_CLOSING"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.ClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CLOSING_CHARGE"].ToString()));
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.UnpostInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UNPOST_INTEREST"].ToString()));
                    obj.TaxAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TAX_AMOUNT"].ToString()));
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.JointImagePath = drow["JOINT_IMAGE_PATH"].ToString();
                    obj.HalfWayInt = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["HALF_WAY_INT"].ToString()));
                    obj.OtherIncomeExp_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OTHER_INCOME_EXP_AMOUNT"].ToString()));
                    obj.OtherIncomeExp_Voucher_No = drow["OTHER_INCOME_EXP_VOUCHER_NO"].ToString();
                    obj.AmtAtMature = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMT_AT_MATURE"].ToString()));
                    obj.TotalBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_BAL"].ToString()));
                    obj.MidTermInt_Rate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MID_TERM_INT_RATE"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPubAccCloseDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            string sp = "fn_saving_utility_pkg.p_pub_acc_close_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_WITHDRAWAL_NO", WithdrawalNo, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicAccountCloseDetail> lst = new List<PublicAccountCloseDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicAccountCloseDetail obj = new PublicAccountCloseDetail();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.WithdrawDateAd = drow["WITHDRAW_DATE_AD"].ToString();
                    obj.WithdrawDateBs = drow["WITHDRAW_DATE_BS"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CONTRA_AC_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.ReceivedInterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["RECEIVED_INTEREST_AMOUNT"].ToString()));
                    obj.ReasonForClosing = drow["REASON_FOR_CLOSING"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.ClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CLOSING_CHARGE"].ToString()));
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.UnpostInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UNPOST_INTEREST"].ToString()));
                    obj.TaxAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TAX_AMOUNT"].ToString()));
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountOperationType = drow["ACCOUNT_OPERATION_TYPE"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.JointImagePath = drow["JOINT_IMAGE_PATH"].ToString();
                    obj.HalfWayInt = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["HALF_WAY_INT"].ToString()));
                    obj.OtherIncomeExp_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OTHER_INCOME_EXP_AMOUNT"].ToString()));
                    obj.OtherIncomeExp_Voucher_No = drow["OTHER_INCOME_EXP_VOUCHER_NO"].ToString();
                    obj.AmtAtMature = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMT_AT_MATURE"].ToString()));
                    obj.TotalBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_BAL"].ToString()));
                    obj.MidTermInt_Rate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MID_TERM_INT_RATE"].ToString()));

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
