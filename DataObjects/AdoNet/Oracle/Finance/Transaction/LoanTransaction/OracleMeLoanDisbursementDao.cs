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
    public class OracleMeLoanDisbursementDao : IMeLoanDisbursementDao
    {
        

        public object Get()
        {
            string sp = "meLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeLoanDisbursement> lst = new List<MeLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeLoanDisbursement obj = new MeLoanDisbursement();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.InterestCalc_Method = drow["INTEREST_CALC_METHOD"].ToString();
                    obj.LoanClose_Date = drow["LOAN_CLOSE_DATE"].ToString();
                    obj.LoanStatus = drow["LOAN_STATUS"].ToString();
                    obj.Rating = drow["RATING"].ToString();
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.RefAccount_No = drow["REF_ACCOUNT_NO"].ToString();
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalArrear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_ARREAR"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ChkAdjust_Saving = drow["CHK_ADJUST_SAVING"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.InsurancePolicy_No = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.FixedPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.FirstInstall_Date = drow["FIRST_INSTALL_DATE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.FixedInterest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_INTEREST_AMOUNT"].ToString()));
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
                    obj.NoOf_Installment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_INSTALLMENT"].ToString()));
                    obj.FundingAgency_Code = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FUNDING_AGENCY_CODE"].ToString()));
                    obj.CreatedBy = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscal_Year = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutLoan_No = drow["OUT_LOAN_NO"].ToString();
                    obj.OutLoan_Dno = drow["OUT_LOAN_DNO"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MeLoanDisbursement meLoanDisbursement)
        {
            string sp = "fn_loan_pkg.p_me_loan_disbursement";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", meLoanDisbursement.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", meLoanDisbursement.LoanMaturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meLoanDisbursement.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", meLoanDisbursement.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", meLoanDisbursement.LoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", meLoanDisbursement.ApprovedLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", meLoanDisbursement.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", meLoanDisbursement.LoanPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", meLoanDisbursement.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", meLoanDisbursement.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", meLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", meLoanDisbursement.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", meLoanDisbursement.InterestCalc_Method, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CLOSE_DATE", meLoanDisbursement.LoanClose_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", meLoanDisbursement.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RATING", meLoanDisbursement.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", meLoanDisbursement.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_ACCOUNT_NO", meLoanDisbursement.RefAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", meLoanDisbursement.InstallmentPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", meLoanDisbursement.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ARREAR", meLoanDisbursement.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", meLoanDisbursement.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", meLoanDisbursement.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", meLoanDisbursement.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", meLoanDisbursement.ChkAdjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", meLoanDisbursement.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", meLoanDisbursement.InsurancePolicy_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", meLoanDisbursement.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", meLoanDisbursement.FixedPrincipal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", meLoanDisbursement.FirstInstall_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", meLoanDisbursement.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", meLoanDisbursement.FixedInterest_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", meLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", meLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", meLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", meLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", meLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", meLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", meLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", meLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", meLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", meLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", meLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", meLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", meLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", meLoanDisbursement.NoOf_Installment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", meLoanDisbursement.FundingAgency_Code, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", meLoanDisbursement.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", meLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", meLoanDisbursement.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_NO", meLoanDisbursement.OutLoan_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_DNO", meLoanDisbursement.OutLoan_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", meLoanDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MeLoanDisbursement meLoanDisbursement)
        {
            string sp = "meLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", meLoanDisbursement.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", meLoanDisbursement.LoanMaturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meLoanDisbursement.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", meLoanDisbursement.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", meLoanDisbursement.LoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", meLoanDisbursement.ApprovedLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", meLoanDisbursement.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", meLoanDisbursement.LoanPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", meLoanDisbursement.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", meLoanDisbursement.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", meLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", meLoanDisbursement.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", meLoanDisbursement.InterestCalc_Method, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CLOSE_DATE", meLoanDisbursement.LoanClose_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", meLoanDisbursement.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RATING", meLoanDisbursement.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", meLoanDisbursement.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_ACCOUNT_NO", meLoanDisbursement.RefAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", meLoanDisbursement.InstallmentPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", meLoanDisbursement.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ARREAR", meLoanDisbursement.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", meLoanDisbursement.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", meLoanDisbursement.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", meLoanDisbursement.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", meLoanDisbursement.ChkAdjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", meLoanDisbursement.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", meLoanDisbursement.InsurancePolicy_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", meLoanDisbursement.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", meLoanDisbursement.FixedPrincipal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", meLoanDisbursement.FirstInstall_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", meLoanDisbursement.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", meLoanDisbursement.FixedInterest_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", meLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", meLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", meLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", meLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", meLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", meLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", meLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", meLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", meLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", meLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", meLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", meLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", meLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", meLoanDisbursement.NoOf_Installment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", meLoanDisbursement.FundingAgency_Code, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", meLoanDisbursement.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", meLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", meLoanDisbursement.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_NO", meLoanDisbursement.OutLoan_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_LOAN_DNO", meLoanDisbursement.OutLoan_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeLoanDisbursement> lst = new List<MeLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeLoanDisbursement obj = new MeLoanDisbursement();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.InterestCalc_Method = drow["INTEREST_CALC_METHOD"].ToString();
                    obj.LoanClose_Date = drow["LOAN_CLOSE_DATE"].ToString();
                    obj.LoanStatus = drow["LOAN_STATUS"].ToString();
                    obj.Rating = drow["RATING"].ToString();
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.RefAccount_No = drow["REF_ACCOUNT_NO"].ToString();
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalArrear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_ARREAR"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.ChkAdjust_Saving = drow["CHK_ADJUST_SAVING"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.InsurancePolicy_No = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.FixedPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.FirstInstall_Date = drow["FIRST_INSTALL_DATE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.FixedInterest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_INTEREST_AMOUNT"].ToString()));
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
                    obj.NoOf_Installment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_INSTALLMENT"].ToString()));
                    obj.FundingAgency_Code = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FUNDING_AGENCY_CODE"].ToString()));
                    obj.CreatedBy = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscal_Year = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutLoan_No = drow["OUT_LOAN_NO"].ToString();
                    obj.OutLoan_Dno = drow["OUT_LOAN_DNO"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMeLoanMember(string offCode, string centerCode, string memberName)
        {
           
            string sp = "fn_member_clients_pkg.p_me_loan_mem_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_name", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanMember> lst = new List<LoanMember>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanMember obj = new LoanMember();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.Name = drow["NAME"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();

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
