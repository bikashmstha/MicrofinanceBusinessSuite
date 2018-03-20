using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleAccountOpenDetailDao : IAccountOpenDetailDao
    {
        public object Get()
        {
            string sp = "accountOpenDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountOpenDetail> lst = new List<AccountOpenDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountOpenDetail obj = new AccountOpenDetail();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.ClosingCharge = double.Parse(drow["ClosingCharge"].ToString());
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.UnpostInterest = double.Parse(drow["UnpostInterest"].ToString());
                    obj.TaxAmount = double.Parse(drow["TaxAmount"].ToString());
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.AccountOpenDate = drow["AccountOpenDate"].ToString();
                    obj.ImagePath = drow["ImagePath"].ToString();
                    obj.HalfWayInt = int.Parse(drow["HalfWayInt"].ToString());
                    obj.MidTermBalance = double.Parse(drow["MidTermBalance"].ToString());
                    obj.OtherIncomeExpAmount = double.Parse(drow["OtherIncomeExpAmount"].ToString());
                    obj.OtherIncomeExpVoucherNo = drow["OtherIncomeExpVoucherNo"].ToString();
                    obj.TotalBal = double.Parse(drow["TotalBal"].ToString());
                    obj.MidTermIntRate = double.Parse(drow["MidTermIntRate"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["ReceivedInterestAmount"].ToString());
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawDateBs = drow["WithdrawDateBs"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(AccountOpenDetail accountOpenDetail)
        {
            string sp = "accountOpenDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", accountOpenDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", accountOpenDetail.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", accountOpenDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", accountOpenDetail.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxAmount", accountOpenDetail.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountOpenDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountOpenDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOpenDate", accountOpenDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", accountOpenDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HalfWayInt", accountOpenDetail.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", accountOpenDetail.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpAmount", accountOpenDetail.OtherIncomeExpAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpVoucherNo", accountOpenDetail.OtherIncomeExpVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalBal", accountOpenDetail.TotalBal, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermIntRate", accountOpenDetail.MidTermIntRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountOpenDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountOpenDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", accountOpenDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", accountOpenDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", accountOpenDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", accountOpenDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterestAmount", accountOpenDetail.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", accountOpenDetail.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", accountOpenDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", accountOpenDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountOpenDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", accountOpenDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountOpenDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", accountOpenDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", accountOpenDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", accountOpenDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", accountOpenDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountOpenDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", accountOpenDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(AccountOpenDetail accountOpenDetail)
        {
            string sp = "accountOpenDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", accountOpenDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", accountOpenDetail.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", accountOpenDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", accountOpenDetail.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxAmount", accountOpenDetail.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountOpenDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountOpenDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOpenDate", accountOpenDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", accountOpenDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HalfWayInt", accountOpenDetail.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", accountOpenDetail.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpAmount", accountOpenDetail.OtherIncomeExpAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpVoucherNo", accountOpenDetail.OtherIncomeExpVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalBal", accountOpenDetail.TotalBal, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermIntRate", accountOpenDetail.MidTermIntRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountOpenDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountOpenDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", accountOpenDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", accountOpenDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", accountOpenDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", accountOpenDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterestAmount", accountOpenDetail.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", accountOpenDetail.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", accountOpenDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", accountOpenDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountOpenDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", accountOpenDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountOpenDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", accountOpenDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", accountOpenDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", accountOpenDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", accountOpenDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountOpenDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountOpenDetail> lst = new List<AccountOpenDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountOpenDetail obj = new AccountOpenDetail();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.ClosingCharge = double.Parse(drow["ClosingCharge"].ToString());
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.UnpostInterest = double.Parse(drow["UnpostInterest"].ToString());
                    obj.TaxAmount = double.Parse(drow["TaxAmount"].ToString());
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.AccountOpenDate = drow["AccountOpenDate"].ToString();
                    obj.ImagePath = drow["ImagePath"].ToString();
                    obj.HalfWayInt = int.Parse(drow["HalfWayInt"].ToString());
                    obj.MidTermBalance = double.Parse(drow["MidTermBalance"].ToString());
                    obj.OtherIncomeExpAmount = double.Parse(drow["OtherIncomeExpAmount"].ToString());
                    obj.OtherIncomeExpVoucherNo = drow["OtherIncomeExpVoucherNo"].ToString();
                    obj.TotalBal = double.Parse(drow["TotalBal"].ToString());
                    obj.MidTermIntRate = double.Parse(drow["MidTermIntRate"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["ReceivedInterestAmount"].ToString());
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawDateBs = drow["WithdrawDateBs"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAccountOpenDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate)
        {
            /*p_withdrawal_no                IN         FN_SAVING_WITHDRAWAL.WITHDRAWAL_NO%TYPE,
                                                        p_office_code                     IN        MS_INSTITUTE.INSTITUTE_CODE%TYPE,
                                                        p_saving_account_no          IN        FN_CLIENT_SAVING_ACCOUNT.SAVING_ACCOUNT_NO%TYPE,
                                                        p_client_name                    IN        FN_MEMBER_CLIENTS.FNAME%TYPE,
                                                        p_from_date                      IN         DATE,
                                                        p_to_date                          IN         DATE,
                                                        v_out_record     */

            string sp = "fn_saving_utility_pkg.p_mf_acc_open_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_withdrawal_no", withdrawlNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_saving_account_no", savingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_client_name", clientName, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_from_date", fromDate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_to_date", toDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountOpenDetail> lst = new List<AccountOpenDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    
                    AccountOpenDetail obj = new AccountOpenDetail();
                    
                  
          
                   
                    obj.WithdrawAmount = double.Parse(drow["WITHDRAW_AMOUNT"].ToString());
                    obj.ClosingCharge = double.Parse(drow["CLOSING_CHARGE"].ToString());
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.UnpostInterest = double.Parse(drow["UNPOST_INTEREST"].ToString());
                    obj.TaxAmount = double.Parse(drow["TAX_AMOUNT"].ToString());
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.HalfWayInt = int.Parse(drow["HALF_WAY_INT"].ToString());
                    obj.MidTermBalance = double.Parse(drow["MID_TERM_BALANCE"].ToString());
                    obj.OtherIncomeExpAmount = double.Parse(drow["OTHER_INCOME_EXP_AMOUNT"].ToString());
                    obj.OtherIncomeExpVoucherNo = drow["OTHER_INCOME_EXP_VOUCHER_NO"].ToString();
                    obj.TotalBal = double.Parse(drow["TOTAL_BAL"].ToString());
                    obj.MidTermIntRate = double.Parse(drow["MID_TERM_INT_RATE"].ToString());
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CURRENT_BALANCE"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["RECEIVED_INTEREST_AMOUNT"].ToString());
                    obj.ReasonForClosing = drow["REASON_FOR_CLOSING"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ContraAcNo = int.Parse(drow["CONTRA_AC_NO"].ToString());
                    
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WITHDRAWAL_NO"].ToString());
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.WithdrawDate = drow["WITHDRAW_DATE"].ToString();
                    obj.WithdrawDateBs = drow["WITHDRAW_DATE_BS"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();

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
