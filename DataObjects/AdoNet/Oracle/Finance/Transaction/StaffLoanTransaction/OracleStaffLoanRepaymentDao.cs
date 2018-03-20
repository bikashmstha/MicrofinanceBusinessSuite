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
    public class OracleStaffLoanRepaymentDao : IStaffLoanRepaymentDao
    {
        public object SaveStaffLoanRepayment(StaffLoanRepayment staffLoanRepayment)
        {
            string sp = "fn_loan_pkg. p_staff_loan_repayment";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanRepayment.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", staffLoanRepayment.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", staffLoanRepayment.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_BALANCE", staffLoanRepayment.TotalBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", staffLoanRepayment.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_PRINCIPAL_DUE", staffLoanRepayment.PastPrincipalDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_PRINCIPAL_SCHEDULE", staffLoanRepayment.CurrentPrincipalSchedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_INTEREST_DUE", staffLoanRepayment.PastInterestDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMOUNT", staffLoanRepayment.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", staffLoanRepayment.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", staffLoanRepayment.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", staffLoanRepayment.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", staffLoanRepayment.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", staffLoanRepayment.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanRepayment.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanRepayment.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", staffLoanRepayment.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanRepayment.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID_AMOUNT", staffLoanRepayment.TotalPrincipalPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID_AMOUNT", staffLoanRepayment.TotalInterestPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY_PAID_AMOUNT", staffLoanRepayment.TotalPenaltyPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", staffLoanRepayment.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanRepayment.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffLoanRepayment.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffLoanRepayment.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffLoanRepayment.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_REPAYMENT_NO", staffLoanRepayment.OutLoanRepayment_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffLoanRepayment.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffLoanRepayment(StaffLoanRepayment staffLoanRepayment)
        {
            string sp = "staffLoanRepayment_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanRepayment.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", staffLoanRepayment.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", staffLoanRepayment.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_BALANCE", staffLoanRepayment.TotalBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", staffLoanRepayment.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_PRINCIPAL_DUE", staffLoanRepayment.PastPrincipalDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_PRINCIPAL_SCHEDULE", staffLoanRepayment.CurrentPrincipalSchedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAST_INTEREST_DUE", staffLoanRepayment.PastInterestDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMOUNT", staffLoanRepayment.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", staffLoanRepayment.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", staffLoanRepayment.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", staffLoanRepayment.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", staffLoanRepayment.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", staffLoanRepayment.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanRepayment.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanRepayment.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", staffLoanRepayment.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanRepayment.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID_AMOUNT", staffLoanRepayment.TotalPrincipalPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID_AMOUNT", staffLoanRepayment.TotalInterestPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY_PAID_AMOUNT", staffLoanRepayment.TotalPenaltyPaid_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", staffLoanRepayment.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanRepayment.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffLoanRepayment.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffLoanRepayment.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffLoanRepayment.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_REPAYMENT_NO", staffLoanRepayment.OutLoanRepayment_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanRepayment> lst = new List<StaffLoanRepayment>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanRepayment obj = new StaffLoanRepayment();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.TotalBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_BALANCE"].ToString()));
                    obj.TotalPrincipalOutstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.PastPrincipalDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_PRINCIPAL_DUE"].ToString()));
                    obj.CurrentPrincipalSchedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_PRINCIPAL_SCHEDULE"].ToString()));
                    obj.PastInterestDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAST_INTEREST_DUE"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMOUNT"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TotalPrincipalPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.TotalInterestPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID_AMOUNT"].ToString()));
                    obj.TotalPenaltyPaid_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY_PAID_AMOUNT"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutLoanRepayment_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_LOAN_REPAYMENT_NO"].ToString()));

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
