using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMeLoanRepayDetailDao : IMeLoanRepayDetailDao
    {
        public object Get()
        {
            string sp = "meLoanRepayDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeLoanRepayDetail> lst = new List<MeLoanRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeLoanRepayDetail obj = new MeLoanRepayDetail();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ProductDesc = drow["PRODUCT_DESC"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.PrincipalPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.PaymentBs = drow["PAYMENT_BS"].ToString();
                    obj.TotalPrincipal_Outstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.PastPrincipal_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_PRINCIPAL_DUE"].ToString()));
                    obj.CurrentPrincipal_Schedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_PRINCIPAL_SCHEDULE"].ToString()));
                    obj.PastInterest_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_INTEREST_DUE"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMOUNT"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MeLoanRepayDetail meLoanRepayDetail)
        {
            string sp = "meLoanRepayDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", meLoanRepayDetail.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", meLoanRepayDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", meLoanRepayDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meLoanRepayDetail.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_DESC", meLoanRepayDetail.ProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", meLoanRepayDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", meLoanRepayDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", meLoanRepayDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", meLoanRepayDetail.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", meLoanRepayDetail.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", meLoanRepayDetail.PrincipalPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", meLoanRepayDetail.InterestPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", meLoanRepayDetail.PenaltyPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", meLoanRepayDetail.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_BS", meLoanRepayDetail.PaymentBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", meLoanRepayDetail.TotalPrincipal_Outstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", meLoanRepayDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_PRINCIPAL_DUE", meLoanRepayDetail.PastPrincipal_Due, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_PRINCIPAL_SCHEDULE", meLoanRepayDetail.CurrentPrincipal_Schedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_INTEREST_DUE", meLoanRepayDetail.PastInterest_Due, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMOUNT", meLoanRepayDetail.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", meLoanRepayDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", meLoanRepayDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", meLoanRepayDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", meLoanRepayDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", meLoanRepayDetail.AdjustFrom_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", meLoanRepayDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", meLoanRepayDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", meLoanRepayDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", meLoanRepayDetail.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", meLoanRepayDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", meLoanRepayDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MeLoanRepayDetail meLoanRepayDetail)
        {
            string sp = "meLoanRepayDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", meLoanRepayDetail.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", meLoanRepayDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", meLoanRepayDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meLoanRepayDetail.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_DESC", meLoanRepayDetail.ProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", meLoanRepayDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", meLoanRepayDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", meLoanRepayDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", meLoanRepayDetail.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", meLoanRepayDetail.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", meLoanRepayDetail.PrincipalPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", meLoanRepayDetail.InterestPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", meLoanRepayDetail.PenaltyPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", meLoanRepayDetail.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_BS", meLoanRepayDetail.PaymentBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", meLoanRepayDetail.TotalPrincipal_Outstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", meLoanRepayDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_PRINCIPAL_DUE", meLoanRepayDetail.PastPrincipal_Due, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_PRINCIPAL_SCHEDULE", meLoanRepayDetail.CurrentPrincipal_Schedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_INTEREST_DUE", meLoanRepayDetail.PastInterest_Due, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMOUNT", meLoanRepayDetail.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", meLoanRepayDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", meLoanRepayDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", meLoanRepayDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", meLoanRepayDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", meLoanRepayDetail.AdjustFrom_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", meLoanRepayDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", meLoanRepayDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", meLoanRepayDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", meLoanRepayDetail.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", meLoanRepayDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeLoanRepayDetail> lst = new List<MeLoanRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeLoanRepayDetail obj = new MeLoanRepayDetail();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ProductDesc = drow["PRODUCT_DESC"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.PrincipalPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.PaymentBs = drow["PAYMENT_BS"].ToString();
                    obj.TotalPrincipal_Outstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.PastPrincipal_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_PRINCIPAL_DUE"].ToString()));
                    obj.CurrentPrincipal_Schedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_PRINCIPAL_SCHEDULE"].ToString()));
                    obj.PastInterest_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_INTEREST_DUE"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMOUNT"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMeLoanRepayDetail(string offCode, string repaymentNo, string clientName, string loanDno, string dateFrom, string dateTo )
        {

            string sp = "fn_loan_pkg.p_me_loan_repay_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_repayment_no", repaymentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_client_name", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_dno", loanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_date_from", dateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_date_to", dateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeLoanRepayDetail> lst = new List<MeLoanRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeLoanRepayDetail obj = new MeLoanRepayDetail();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ProductDesc = drow["PRODUCT_DESC"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.PrincipalPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.PaymentBs = drow["PAYMENT_BS"].ToString();
                    obj.TotalPrincipal_Outstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.PastPrincipal_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_PRINCIPAL_DUE"].ToString()));
                    obj.CurrentPrincipal_Schedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_PRINCIPAL_SCHEDULE"].ToString()));
                    obj.PastInterest_Due = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_INTEREST_DUE"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMOUNT"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();

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
