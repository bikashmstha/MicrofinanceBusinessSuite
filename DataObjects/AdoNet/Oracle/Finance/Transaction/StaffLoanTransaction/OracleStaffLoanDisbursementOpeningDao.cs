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
    public class OracleStaffLoanDisbursementOpeningDao : IStaffLoanDisbursementOpeningDao
    {
        public object SaveStaffLoanDisbursementOpening(StaffLoanDisbursementOpening staffLoanDisbursementOpening)
        {
            string sp = "fn_loan_pkg.p_staff_loan_disburse_opening";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanDisbursementOpening.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", staffLoanDisbursementOpening.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", staffLoanDisbursementOpening.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanDisbursementOpening.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanDisbursementOpening.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", staffLoanDisbursementOpening.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", staffLoanDisbursementOpening.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", staffLoanDisbursementOpening.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", staffLoanDisbursementOpening.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", staffLoanDisbursementOpening.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", staffLoanDisbursementOpening.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanDisbursementOpening.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", staffLoanDisbursementOpening.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", staffLoanDisbursementOpening.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CLOSE_DATE", staffLoanDisbursementOpening.LoanCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", staffLoanDisbursementOpening.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RATING", staffLoanDisbursementOpening.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", staffLoanDisbursementOpening.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_ACCOUNT_NO", staffLoanDisbursementOpening.RefAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", staffLoanDisbursementOpening.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", staffLoanDisbursementOpening.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ARREAR", staffLoanDisbursementOpening.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", staffLoanDisbursementOpening.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", staffLoanDisbursementOpening.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", staffLoanDisbursementOpening.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", staffLoanDisbursementOpening.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanDisbursementOpening.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", staffLoanDisbursementOpening.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanDisbursementOpening.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", staffLoanDisbursementOpening.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", staffLoanDisbursementOpening.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", staffLoanDisbursementOpening.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", staffLoanDisbursementOpening.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanDisbursementOpening.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", staffLoanDisbursementOpening.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", staffLoanDisbursementOpening.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", staffLoanDisbursementOpening.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", staffLoanDisbursementOpening.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", staffLoanDisbursementOpening.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", staffLoanDisbursementOpening.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", staffLoanDisbursementOpening.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", staffLoanDisbursementOpening.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", staffLoanDisbursementOpening.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", staffLoanDisbursementOpening.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", staffLoanDisbursementOpening.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", staffLoanDisbursementOpening.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", staffLoanDisbursementOpening.NoOfInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", staffLoanDisbursementOpening.FundingAgencyCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_OUTSTANDING", staffLoanDisbursementOpening.PrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", staffLoanDisbursementOpening.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", staffLoanDisbursementOpening.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", staffLoanDisbursementOpening.TotalInterestPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_INSTALL_PAID_DATE", staffLoanDisbursementOpening.LastInstallPaid_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_LOAN_DATE", staffLoanDisbursementOpening.NewLoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffLoanDisbursementOpening.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffLoanDisbursementOpening.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffLoanDisbursementOpening.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_NO", staffLoanDisbursementOpening.OutLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_DNO", staffLoanDisbursementOpening.OutLoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffLoanDisbursementOpening.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffLoanDisbursementOpening(StaffLoanDisbursementOpening staffLoanDisbursementOpening)
        {
            string sp = "staffLoanDisbursementOpening_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanDisbursementOpening.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", staffLoanDisbursementOpening.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", staffLoanDisbursementOpening.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanDisbursementOpening.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanDisbursementOpening.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", staffLoanDisbursementOpening.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", staffLoanDisbursementOpening.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", staffLoanDisbursementOpening.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", staffLoanDisbursementOpening.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", staffLoanDisbursementOpening.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", staffLoanDisbursementOpening.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanDisbursementOpening.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", staffLoanDisbursementOpening.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", staffLoanDisbursementOpening.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CLOSE_DATE", staffLoanDisbursementOpening.LoanCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", staffLoanDisbursementOpening.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RATING", staffLoanDisbursementOpening.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", staffLoanDisbursementOpening.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_ACCOUNT_NO", staffLoanDisbursementOpening.RefAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", staffLoanDisbursementOpening.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", staffLoanDisbursementOpening.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ARREAR", staffLoanDisbursementOpening.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", staffLoanDisbursementOpening.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", staffLoanDisbursementOpening.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", staffLoanDisbursementOpening.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", staffLoanDisbursementOpening.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanDisbursementOpening.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", staffLoanDisbursementOpening.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanDisbursementOpening.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", staffLoanDisbursementOpening.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", staffLoanDisbursementOpening.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", staffLoanDisbursementOpening.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", staffLoanDisbursementOpening.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanDisbursementOpening.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", staffLoanDisbursementOpening.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", staffLoanDisbursementOpening.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", staffLoanDisbursementOpening.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", staffLoanDisbursementOpening.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", staffLoanDisbursementOpening.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", staffLoanDisbursementOpening.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", staffLoanDisbursementOpening.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", staffLoanDisbursementOpening.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", staffLoanDisbursementOpening.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", staffLoanDisbursementOpening.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", staffLoanDisbursementOpening.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", staffLoanDisbursementOpening.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", staffLoanDisbursementOpening.NoOfInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", staffLoanDisbursementOpening.FundingAgencyCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_OUTSTANDING", staffLoanDisbursementOpening.PrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", staffLoanDisbursementOpening.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", staffLoanDisbursementOpening.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", staffLoanDisbursementOpening.TotalInterestPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LAST_INSTALL_PAID_DATE", staffLoanDisbursementOpening.LastInstallPaid_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_LOAN_DATE", staffLoanDisbursementOpening.NewLoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffLoanDisbursementOpening.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffLoanDisbursementOpening.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffLoanDisbursementOpening.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_NO", staffLoanDisbursementOpening.OutLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_DNO", staffLoanDisbursementOpening.OutLoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanDisbursementOpening> lst = new List<StaffLoanDisbursementOpening>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanDisbursementOpening obj = new StaffLoanDisbursementOpening();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanMaturityDate = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanPurposeCode = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.InterestCalcMethod = drow["INTEREST_CALC_METHOD"].ToString();
                    obj.LoanCloseDate = drow["LOAN_CLOSE_DATE"].ToString();
                    obj.LoanStatus = drow["LOAN_STATUS"].ToString();
                    obj.Rating = drow["RATING"].ToString();
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.RefAccountNo = drow["REF_ACCOUNT_NO"].ToString();
                    obj.InstallmentPeriodType = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalArrear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_ARREAR"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ChkAdjustSaving = drow["CHK_ADJUST_SAVING"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.InsurancePolicyNo = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.FixedPrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.FirstInstallDate = drow["FIRST_INSTALL_DATE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.FixedInterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_INTEREST_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.Deduction1Code = drow["DEDUCTION1_CODE"].ToString();
                    obj.Deduction1Desc = drow["DEDUCTION1_DESC"].ToString();
                    obj.DeductionAmount1 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT1"].ToString()));
                    obj.Deduction2Code = drow["DEDUCTION2_CODE"].ToString();
                    obj.Deduction2Desc = drow["DEDUCTION2_DESC"].ToString();
                    obj.DeductionAmount2 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT2"].ToString()));
                    obj.Deduction3Code = drow["DEDUCTION3_CODE"].ToString();
                    obj.Deduction3Desc = drow["DEDUCTION3_DESC"].ToString();
                    obj.DeductionAmount3 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT3"].ToString()));
                    obj.Deduction4Code = drow["DEDUCTION4_CODE"].ToString();
                    obj.Deduction4Desc = drow["DEDUCTION4_DESC"].ToString();
                    obj.DeductionAmount4 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT4"].ToString()));
                    obj.NoOfInstallment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_INSTALLMENT"].ToString()));
                    obj.FundingAgencyCode = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FUNDING_AGENCY_CODE"].ToString()));
                    obj.PrincipalOutstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalInterestPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.LastInstallPaid_Date = drow["LAST_INSTALL_PAID_DATE"].ToString();
                    obj.NewLoanDate = drow["NEW_LOAN_DATE"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutLoanNo = drow["OUT_LOAN_NO"].ToString();
                    obj.OutLoanDno = drow["OUT_LOAN_DNO"].ToString();

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
