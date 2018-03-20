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
    public class OracleAccountCloseDetailDao : IAccountCloseDetailDao
    {
        public object Get()
        {
            string sp = "accountCloseDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountCloseDetail> lst = new List<AccountCloseDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountCloseDetail obj = new AccountCloseDetail();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawDateBs = drow["WithdrawDateBs"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["ReceivedInterestAmount"].ToString());
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
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
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(AccountCloseDetail accountCloseDetail)
        {
            string sp = "accountCloseDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", accountCloseDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", accountCloseDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountCloseDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", accountCloseDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountCloseDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", accountCloseDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", accountCloseDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", accountCloseDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", accountCloseDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", accountCloseDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterestAmount", accountCloseDetail.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", accountCloseDetail.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", accountCloseDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", accountCloseDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", accountCloseDetail.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", accountCloseDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", accountCloseDetail.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxAmount", accountCloseDetail.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountCloseDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountCloseDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOpenDate", accountCloseDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", accountCloseDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HalfWayInt", accountCloseDetail.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", accountCloseDetail.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpAmount", accountCloseDetail.OtherIncomeExpAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpVoucherNo", accountCloseDetail.OtherIncomeExpVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalBal", accountCloseDetail.TotalBal, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermIntRate", accountCloseDetail.MidTermIntRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountCloseDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountCloseDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountCloseDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", accountCloseDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", accountCloseDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", accountCloseDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(AccountCloseDetail accountCloseDetail)
        {
            string sp = "accountCloseDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", accountCloseDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", accountCloseDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountCloseDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", accountCloseDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountCloseDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", accountCloseDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", accountCloseDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", accountCloseDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", accountCloseDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", accountCloseDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterestAmount", accountCloseDetail.ReceivedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", accountCloseDetail.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", accountCloseDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", accountCloseDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", accountCloseDetail.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", accountCloseDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", accountCloseDetail.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxAmount", accountCloseDetail.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountCloseDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountCloseDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOpenDate", accountCloseDetail.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", accountCloseDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HalfWayInt", accountCloseDetail.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", accountCloseDetail.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpAmount", accountCloseDetail.OtherIncomeExpAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpVoucherNo", accountCloseDetail.OtherIncomeExpVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalBal", accountCloseDetail.TotalBal, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermIntRate", accountCloseDetail.MidTermIntRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountCloseDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountCloseDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountCloseDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", accountCloseDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", accountCloseDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountCloseDetail> lst = new List<AccountCloseDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountCloseDetail obj = new AccountCloseDetail();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawDateBs = drow["WithdrawDateBs"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.ReceivedInterestAmount = double.Parse(drow["ReceivedInterestAmount"].ToString());
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
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
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAccountCloseDetail(string withdrawlNo, string offCode, string savingAccountNo, string clientName, string fromDate, string toDate)
        {
            string sp = "fn_saving_utility_pkg.p_acc_close_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", withdrawlNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", savingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", fromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", toDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountCloseDetail> lst = new List<AccountCloseDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountCloseDetail obj = new AccountCloseDetail();
                    obj.WithdrawDate = drow["Withdraw_Date"].ToString();
                    obj.WithdrawDateBs = drow["Withdraw_Date_Bs"].ToString();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Contra_Ac_No"].ToString()));
                    obj.AccountDesc = drow["Account_Desc"].ToString();
                    obj.ChequeNo = drow["Cheque_No"].ToString();
                    obj.PayeeName = drow["Payee_Name"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Current_Balance"].ToString()));
                    obj.ReceivedInterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Received_Interest_Amount"].ToString()));
                    obj.ReasonForClosing = drow["Reason_For_Closing"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Withdraw_Amount"].ToString()));
                    obj.ClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Closing_Charge"].ToString()));
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.UnpostInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Unpost_Interest"].ToString()));
                    obj.TaxAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Tax_Amount"].ToString()));
                    obj.ProductCode = drow["Product_Code"].ToString();
                    obj.ProductName = drow["Product_Name"].ToString();
                    obj.AccountOpenDate = drow["Account_Open_Date"].ToString();
                    obj.ImagePath = drow["Image_Path"].ToString();
                    obj.HalfWayInt = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Half_Way_Int"].ToString()));
                    obj.MidTermBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Mid_Term_Balance"].ToString()));
                    obj.OtherIncomeExpAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Other_Income_Exp_Amount"].ToString()));
                    obj.OtherIncomeExpVoucherNo = drow["OTHER_INCOME_EXP_VOUCHER_NO"].ToString();
                    obj.TotalBal = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Bal"].ToString()));
                    obj.MidTermIntRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Mid_Term_Int_Rate"].ToString()));
                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Withdrawal_No"].ToString()));
                    obj.ContraAccount = drow["Contra_Account"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { 
                oMsg.OutResultMessage = ex.Message.ToString(); 
                return oMsg; 
            }
            finally { 
                conn.Close();
            }
        }
    }
}
