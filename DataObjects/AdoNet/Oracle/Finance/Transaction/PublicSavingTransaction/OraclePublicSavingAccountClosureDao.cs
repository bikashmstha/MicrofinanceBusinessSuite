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
    public class OraclePublicSavingAccountClosureDao : IPublicSavingAccountClosureDao
    {
        public object SavePublicSavingAccountClosure(PublicSavingAccountClosure publicSavingAccountClosure)
        {
            string sp = "fn_public_saving_account_pkg.p_public_saving_ac_closure";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingAccountClosure.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE", publicSavingAccountClosure.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicSavingAccountClosure.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicSavingAccountClosure.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicSavingAccountClosure.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingAccountClosure.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicSavingAccountClosure.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE", publicSavingAccountClosure.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_TYPE", publicSavingAccountClosure.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_CLOSING", publicSavingAccountClosure.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingAccountClosure.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicSavingAccountClosure.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_ON_UNPOST_INTEREST", publicSavingAccountClosure.TaxOnUnpost_Interest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNPOST_INTEREST", publicSavingAccountClosure.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", publicSavingAccountClosure.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RECEIVED_INTEREST", publicSavingAccountClosure.ReceivedInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_CLOSING", publicSavingAccountClosure.MidTermClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_BALANCE", publicSavingAccountClosure.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_INTEREST", publicSavingAccountClosure.MidTermInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_TAXABLE_AMOUNT", publicSavingAccountClosure.MidTermTaxable_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TDS_DIFFERENCE", publicSavingAccountClosure.TdsDifference, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_AMOUNT", publicSavingAccountClosure.OtherIncomeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WAIVED_AMOUNT", publicSavingAccountClosure.WaivedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PREMATURED_INT_RATIO", publicSavingAccountClosure.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_CLOSING_TYPE", publicSavingAccountClosure.MidTermClosing_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingAccountClosure.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", publicSavingAccountClosure.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", publicSavingAccountClosure.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_WITHDRAWAL_NO", publicSavingAccountClosure.OutWithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicSavingAccountClosure.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object DeletePublicSavingAccountClosure(string accountNo, string accountClosedDate, string otherIncomeVoucherNo, string username)
        {
            string sp = "fn_public_saving_account_pkg.P_DELETE_PUBLIC_SAVING_CLOSER";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", accountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_account_closed_date", accountClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_other_income_voucher_no", otherIncomeVoucherNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user_name", username, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicSavingAccountClosure(PublicSavingAccountClosure publicSavingAccountClosure)
        {
            string sp = "publicSavingAccountClosure_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingAccountClosure.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_DATE", publicSavingAccountClosure.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicSavingAccountClosure.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicSavingAccountClosure.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicSavingAccountClosure.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingAccountClosure.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicSavingAccountClosure.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE", publicSavingAccountClosure.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_TYPE", publicSavingAccountClosure.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_CLOSING", publicSavingAccountClosure.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingAccountClosure.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", publicSavingAccountClosure.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_ON_UNPOST_INTEREST", publicSavingAccountClosure.TaxOnUnpost_Interest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNPOST_INTEREST", publicSavingAccountClosure.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", publicSavingAccountClosure.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RECEIVED_INTEREST", publicSavingAccountClosure.ReceivedInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_CLOSING", publicSavingAccountClosure.MidTermClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_BALANCE", publicSavingAccountClosure.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_INTEREST", publicSavingAccountClosure.MidTermInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_TAXABLE_AMOUNT", publicSavingAccountClosure.MidTermTaxable_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TDS_DIFFERENCE", publicSavingAccountClosure.TdsDifference, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_AMOUNT", publicSavingAccountClosure.OtherIncomeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WAIVED_AMOUNT", publicSavingAccountClosure.WaivedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PREMATURED_INT_RATIO", publicSavingAccountClosure.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MID_TERM_CLOSING_TYPE", publicSavingAccountClosure.MidTermClosing_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingAccountClosure.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", publicSavingAccountClosure.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", publicSavingAccountClosure.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_WITHDRAWAL_NO", publicSavingAccountClosure.OutWithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingAccountClosure> lst = new List<PublicSavingAccountClosure>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingAccountClosure obj = new PublicSavingAccountClosure();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.WithdrawDate = drow["WITHDRAW_DATE"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.ClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CLOSING_CHARGE"].ToString()));
                    obj.WithdrawType = drow["WITHDRAW_TYPE"].ToString();
                    obj.ReasonForClosing = drow["REASON_FOR_CLOSING"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.TaxOnUnpost_Interest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TAX_ON_UNPOST_INTEREST"].ToString()));
                    obj.UnpostInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UNPOST_INTEREST"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.ReceivedInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["RECEIVED_INTEREST"].ToString()));
                    obj.MidTermClosing = drow["MID_TERM_CLOSING"].ToString();
                    obj.MidTermBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MID_TERM_BALANCE"].ToString()));
                    obj.MidTermInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MID_TERM_INTEREST"].ToString()));
                    obj.MidTermTaxable_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MID_TERM_TAXABLE_AMOUNT"].ToString()));
                    obj.TdsDifference = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TDS_DIFFERENCE"].ToString()));
                    obj.OtherIncomeAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OTHER_INCOME_AMOUNT"].ToString()));
                    obj.WaivedAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WAIVED_AMOUNT"].ToString()));
                    obj.PrematuredIntRatio = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PREMATURED_INT_RATIO"].ToString()));
                    obj.MidTermClosing_Type = drow["MID_TERM_CLOSING_TYPE"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutWithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_WITHDRAWAL_NO"].ToString()));

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
