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
    public class OracleStaffLoanDisbursementDao : IStaffLoanDisbursementDao
    {
        public object SaveStaffLoanDisbursement(StaffLoanDisbursement staffLoanDisbursement)
        {
            string sp = "fn_loan_pkg.p_staff_loan_disbursement";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanDisbursement.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", staffLoanDisbursement.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", staffLoanDisbursement.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanDisbursement.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanDisbursement.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", staffLoanDisbursement.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", staffLoanDisbursement.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", staffLoanDisbursement.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", staffLoanDisbursement.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", staffLoanDisbursement.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", staffLoanDisbursement.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", staffLoanDisbursement.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", staffLoanDisbursement.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CLOSE_DATE", staffLoanDisbursement.LoanCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", staffLoanDisbursement.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RATING", staffLoanDisbursement.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", staffLoanDisbursement.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_ACCOUNT_NO", staffLoanDisbursement.RefAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", staffLoanDisbursement.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", staffLoanDisbursement.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ARREAR", staffLoanDisbursement.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", staffLoanDisbursement.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", staffLoanDisbursement.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", staffLoanDisbursement.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", staffLoanDisbursement.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanDisbursement.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", staffLoanDisbursement.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanDisbursement.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", staffLoanDisbursement.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", staffLoanDisbursement.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", staffLoanDisbursement.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", staffLoanDisbursement.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", staffLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", staffLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", staffLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", staffLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", staffLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", staffLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", staffLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", staffLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", staffLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", staffLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", staffLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", staffLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", staffLoanDisbursement.NoOfInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", staffLoanDisbursement.FundingAgencyCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffLoanDisbursement.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_NO", staffLoanDisbursement.OutLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_DNO", staffLoanDisbursement.OutLoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_action", staffLoanDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
