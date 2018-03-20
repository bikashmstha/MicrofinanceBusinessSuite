using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleStaffLoanRepayDetailDao : IStaffLoanRepayDetailDao
    {
        public object SaveStaffLoanRepayDetail(StaffLoanRepayDetail staffLoanRepayDetail)
        {
            string sp = "staffLoanRepayDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanRepayDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", staffLoanRepayDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", staffLoanRepayDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanRepayDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_DESC", staffLoanRepayDetail.ProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", staffLoanRepayDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanRepayDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffLoanRepayDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", staffLoanRepayDetail.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", staffLoanRepayDetail.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", staffLoanRepayDetail.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", staffLoanRepayDetail.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", staffLoanRepayDetail.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", staffLoanRepayDetail.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_BS", staffLoanRepayDetail.PaymentBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", staffLoanRepayDetail.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", staffLoanRepayDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_PRINCIPAL_DUE", staffLoanRepayDetail.PastPrincipalDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_PRINCIPAL_SCHEDULE", staffLoanRepayDetail.CurrentPrincipalSchedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_INTEREST_DUE", staffLoanRepayDetail.PastInterestDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMOUNT", staffLoanRepayDetail.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", staffLoanRepayDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanRepayDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanRepayDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanRepayDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", staffLoanRepayDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", staffLoanRepayDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", staffLoanRepayDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", staffLoanRepayDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanRepayDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", staffLoanRepayDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffLoanRepayDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffLoanRepayDetail(StaffLoanRepayDetail staffLoanRepayDetail)
        {
            string sp = "staffLoanRepayDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanRepayDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", staffLoanRepayDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", staffLoanRepayDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanRepayDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_DESC", staffLoanRepayDetail.ProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", staffLoanRepayDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanRepayDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffLoanRepayDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", staffLoanRepayDetail.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", staffLoanRepayDetail.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", staffLoanRepayDetail.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", staffLoanRepayDetail.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", staffLoanRepayDetail.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", staffLoanRepayDetail.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_BS", staffLoanRepayDetail.PaymentBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", staffLoanRepayDetail.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", staffLoanRepayDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_PRINCIPAL_DUE", staffLoanRepayDetail.PastPrincipalDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_PRINCIPAL_SCHEDULE", staffLoanRepayDetail.CurrentPrincipalSchedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_INTEREST_DUE", staffLoanRepayDetail.PastInterestDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMOUNT", staffLoanRepayDetail.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", staffLoanRepayDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanRepayDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanRepayDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanRepayDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", staffLoanRepayDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", staffLoanRepayDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", staffLoanRepayDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", staffLoanRepayDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanRepayDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", staffLoanRepayDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanRepayDetail> lst = new List<StaffLoanRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanRepayDetail obj = new StaffLoanRepayDetail();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ProductDesc = drow["PRODUCT_DESC"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.PaymentBs = drow["PAYMENT_BS"].ToString();
                    obj.TotalPrincipalOutstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.PastPrincipalDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_PRINCIPAL_DUE"].ToString()));
                    obj.CurrentPrincipalSchedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_PRINCIPAL_SCHEDULE"].ToString()));
                    obj.PastInterestDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_INTEREST_DUE"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMOUNT"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetStaffLoanRepayDetail(string OfficeCode, long? RepaymentNo, string LoanDno, string ClientName, string FromDate, string ToDate)
        {
            string sp = "fn_loan_utility_pkg.p_staff_loan_repay_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_REPAYMENT_NO", RepaymentNo, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_DNO", LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanRepayDetail> lst = new List<StaffLoanRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanRepayDetail obj = new StaffLoanRepayDetail();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ProductDesc = drow["PRODUCT_DESC"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.PaymentBs = drow["PAYMENT_BS"].ToString();
                    obj.TotalPrincipalOutstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.PastPrincipalDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_PRINCIPAL_DUE"].ToString()));
                    obj.CurrentPrincipalSchedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_PRINCIPAL_SCHEDULE"].ToString()));
                    obj.PastInterestDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_INTEREST_DUE"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMOUNT"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
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
