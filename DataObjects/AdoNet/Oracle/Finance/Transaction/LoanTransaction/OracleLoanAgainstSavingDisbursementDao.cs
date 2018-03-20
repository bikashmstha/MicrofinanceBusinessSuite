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
    public class OracleLoanAgainstSavingDisbursementDao : ILoanAgainstSavingDisbursementDao
    {
        public object Get()
        {
            string sp = "loanAgainstSavingDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanAgainstSavingDisbursement> lst = new List<LoanAgainstSavingDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanAgainstSavingDisbursement obj = new LoanAgainstSavingDisbursement();
                    obj.PLoan_Date = drow["P_LOAN_DATE"].ToString();
                    obj.PLoan_Maturity_Date = drow["P_LOAN_MATURITY_DATE"].ToString();
                    obj.PLoan_Product_Code = drow["P_LOAN_PRODUCT_CODE"].ToString();
                    obj.PClient_No = drow["P_CLIENT_NO"].ToString();
                    obj.PLoan_Purpose_Code = drow["P_LOAN_PURPOSE_CODE"].ToString();
                    obj.PApproved_Loan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.PTotal_Loan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.PLoan_Period_Type = drow["P_LOAN_PERIOD_TYPE"].ToString();
                    obj.PLoan_Period = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_LOAN_PERIOD"].ToString()));
                    obj.PGrace_Days = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_GRACE_DAYS"].ToString()));
                    obj.PEmployee_Id = drow["P_EMPLOYEE_ID"].ToString();
                    obj.PInterest_Rate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_INTEREST_RATE"].ToString()));
                    obj.PInterest_Calc_Method = drow["P_INTEREST_CALC_METHOD"].ToString();
                    obj.PLoan_Close_Date = drow["P_LOAN_CLOSE_DATE"].ToString();
                    obj.PLoan_Status = drow["P_LOAN_STATUS"].ToString();
                    obj.PRating = drow["P_RATING"].ToString();
                    obj.PInstallment_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_INSTALLMENT_AMOUNT"].ToString()));
                    obj.PRef_Account_No = drow["P_REF_ACCOUNT_NO"].ToString();
                    obj.PInstallment_Period_Type = drow["P_INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.PInstallment_Period = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_INSTALLMENT_PERIOD"].ToString()));
                    obj.PPrincipal_Arrear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_PRINCIPAL_ARREAR"].ToString()));
                    obj.PPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_PRINCIPAL_AMOUNT"].ToString()));
                    obj.PYear_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_YEAR_NO"].ToString()));
                    obj.PWithdrawal_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_WITHDRAWAL_NO"].ToString()));
                    obj.PChk_Adjust_Saving = drow["P_CHK_ADJUST_SAVING"].ToString();
                    obj.PSaving_Account_No = drow["P_SAVING_ACCOUNT_NO"].ToString();
                    obj.PInsurance_Policy_No = drow["P_INSURANCE_POLICY_NO"].ToString();
                    obj.PTran_Office_Code = drow["P_TRAN_OFFICE_CODE"].ToString();
                    obj.PFixed_Principal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.PFirst_Install_Date = drow["P_FIRST_INSTALL_DATE"].ToString();
                    obj.PClient_Center = drow["P_CLIENT_CENTER"].ToString();
                    obj.PFixed_Interest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_FIXED_INTEREST_AMOUNT"].ToString()));
                    obj.PContra_Account = drow["P_CONTRA_ACCOUNT"].ToString();
                    obj.PDeduction1_Code = drow["P_DEDUCTION1_CODE"].ToString();
                    obj.PDeduction1_Desc = drow["P_DEDUCTION1_DESC"].ToString();
                    obj.PDeduction_Amount1 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT1"].ToString()));
                    obj.PDeduction2_Code = drow["P_DEDUCTION2_CODE"].ToString();
                    obj.PDeduction2_Desc = drow["P_DEDUCTION2_DESC"].ToString();
                    obj.PDeduction_Amount2 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT2"].ToString()));
                    obj.PDeduction3_Code = drow["P_DEDUCTION3_CODE"].ToString();
                    obj.PDeduction3_Desc = drow["P_DEDUCTION3_DESC"].ToString();
                    obj.PDeduction_Amount3 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT3"].ToString()));
                    obj.PDeduction4_Code = drow["P_DEDUCTION4_CODE"].ToString();
                    obj.PDeduction4_Desc = drow["P_DEDUCTION4_DESC"].ToString();
                    obj.PDeduction_Amount4 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT4"].ToString()));
                    obj.PNo_Of_Installment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_NO_OF_INSTALLMENT"].ToString()));
                    obj.PFunding_Agency_Code = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_FUNDING_AGENCY_CODE"].ToString()));
                    obj.PLoan_Against_Saving_No = drow["P_LOAN_AGAINST_SAVING_NO"].ToString();
                    obj.PUser1 = drow["P_USER1"].ToString();
                    obj.PInsert_Update = drow["P_INSERT_UPDATE"].ToString();
                    obj.VOut_Fiscal_Year = drow["V_OUT_FISCAL_YEAR"].ToString();
                    obj.VOut_Loan_No = drow["V_OUT_LOAN_NO"].ToString();
                    obj.VOut_Loan_Dno = drow["V_OUT_LOAN_DNO"].ToString();
                    obj.VOut_Result_Code = drow["V_OUT_RESULT_CODE"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LoanAgainstSavingDisbursement loanAgainstSavingDisbursement)
        {
            string sp = "fn_loan_pkg.p_loan_against_sav_disburse";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_DATE", loanAgainstSavingDisbursement.PLoan_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_MATURITY_DATE", loanAgainstSavingDisbursement.PLoan_Maturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PRODUCT_CODE", loanAgainstSavingDisbursement.PLoan_Product_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NO", loanAgainstSavingDisbursement.PClient_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PURPOSE_CODE", loanAgainstSavingDisbursement.PLoan_Purpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_APPROVED_LOAN_AMOUNT", loanAgainstSavingDisbursement.PApproved_Loan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TOTAL_LOAN_AMOUNT", loanAgainstSavingDisbursement.PTotal_Loan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PERIOD_TYPE", loanAgainstSavingDisbursement.PLoan_Period_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PERIOD", loanAgainstSavingDisbursement.PLoan_Period, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_GRACE_DAYS", loanAgainstSavingDisbursement.PGrace_Days, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_EMPLOYEE_ID", loanAgainstSavingDisbursement.PEmployee_Id, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INTEREST_RATE", loanAgainstSavingDisbursement.PInterest_Rate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INTEREST_CALC_METHOD", loanAgainstSavingDisbursement.PInterest_Calc_Method, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_CLOSE_DATE", loanAgainstSavingDisbursement.PLoan_Close_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_STATUS", loanAgainstSavingDisbursement.PLoan_Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_RATING", loanAgainstSavingDisbursement.PRating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSTALLMENT_AMOUNT", loanAgainstSavingDisbursement.PInstallment_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_REF_ACCOUNT_NO", loanAgainstSavingDisbursement.PRef_Account_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSTALLMENT_PERIOD_TYPE", loanAgainstSavingDisbursement.PInstallment_Period_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSTALLMENT_PERIOD", loanAgainstSavingDisbursement.PInstallment_Period, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRINCIPAL_ARREAR", loanAgainstSavingDisbursement.PPrincipal_Arrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRINCIPAL_AMOUNT", loanAgainstSavingDisbursement.PPrincipal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_YEAR_NO", loanAgainstSavingDisbursement.PYear_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_WITHDRAWAL_NO", loanAgainstSavingDisbursement.PWithdrawal_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CHK_ADJUST_SAVING", loanAgainstSavingDisbursement.PChk_Adjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", loanAgainstSavingDisbursement.PSaving_Account_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSURANCE_POLICY_NO", loanAgainstSavingDisbursement.PInsurance_Policy_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TRAN_OFFICE_CODE", loanAgainstSavingDisbursement.PTran_Office_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FIXED_PRINCIPAL_AMOUNT", loanAgainstSavingDisbursement.PFixed_Principal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FIRST_INSTALL_DATE", loanAgainstSavingDisbursement.PFirst_Install_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_CENTER", loanAgainstSavingDisbursement.PClient_Center, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FIXED_INTEREST_AMOUNT", loanAgainstSavingDisbursement.PFixed_Interest_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CONTRA_ACCOUNT", loanAgainstSavingDisbursement.PContra_Account, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION1_CODE", loanAgainstSavingDisbursement.PDeduction1_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION1_DESC", loanAgainstSavingDisbursement.PDeduction1_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT1", loanAgainstSavingDisbursement.PDeduction_Amount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION2_CODE", loanAgainstSavingDisbursement.PDeduction2_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION2_DESC", loanAgainstSavingDisbursement.PDeduction2_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT2", loanAgainstSavingDisbursement.PDeduction_Amount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION3_CODE", loanAgainstSavingDisbursement.PDeduction3_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION3_DESC", loanAgainstSavingDisbursement.PDeduction3_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT3", loanAgainstSavingDisbursement.PDeduction_Amount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION4_CODE", loanAgainstSavingDisbursement.PDeduction4_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION4_DESC", loanAgainstSavingDisbursement.PDeduction4_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT4", loanAgainstSavingDisbursement.PDeduction_Amount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_NO_OF_INSTALLMENT", loanAgainstSavingDisbursement.PNo_Of_Installment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FUNDING_AGENCY_CODE", loanAgainstSavingDisbursement.PFunding_Agency_Code, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_AGAINST_SAVING_NO", loanAgainstSavingDisbursement.PLoan_Against_Saving_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER1", loanAgainstSavingDisbursement.PUser1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSERT_UPDATE", loanAgainstSavingDisbursement.PInsert_Update, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_FISCAL_YEAR", loanAgainstSavingDisbursement.VOut_Fiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_LOAN_NO", loanAgainstSavingDisbursement.VOut_Loan_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_LOAN_DNO", loanAgainstSavingDisbursement.VOut_Loan_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RESULT_CODE", loanAgainstSavingDisbursement.VOut_Result_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanAgainstSavingDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LoanAgainstSavingDisbursement loanAgainstSavingDisbursement)
        {
            string sp = "loanAgainstSavingDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_DATE", loanAgainstSavingDisbursement.PLoan_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_MATURITY_DATE", loanAgainstSavingDisbursement.PLoan_Maturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PRODUCT_CODE", loanAgainstSavingDisbursement.PLoan_Product_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NO", loanAgainstSavingDisbursement.PClient_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PURPOSE_CODE", loanAgainstSavingDisbursement.PLoan_Purpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_APPROVED_LOAN_AMOUNT", loanAgainstSavingDisbursement.PApproved_Loan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TOTAL_LOAN_AMOUNT", loanAgainstSavingDisbursement.PTotal_Loan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PERIOD_TYPE", loanAgainstSavingDisbursement.PLoan_Period_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PERIOD", loanAgainstSavingDisbursement.PLoan_Period, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_GRACE_DAYS", loanAgainstSavingDisbursement.PGrace_Days, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_EMPLOYEE_ID", loanAgainstSavingDisbursement.PEmployee_Id, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INTEREST_RATE", loanAgainstSavingDisbursement.PInterest_Rate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INTEREST_CALC_METHOD", loanAgainstSavingDisbursement.PInterest_Calc_Method, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_CLOSE_DATE", loanAgainstSavingDisbursement.PLoan_Close_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_STATUS", loanAgainstSavingDisbursement.PLoan_Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_RATING", loanAgainstSavingDisbursement.PRating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSTALLMENT_AMOUNT", loanAgainstSavingDisbursement.PInstallment_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_REF_ACCOUNT_NO", loanAgainstSavingDisbursement.PRef_Account_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSTALLMENT_PERIOD_TYPE", loanAgainstSavingDisbursement.PInstallment_Period_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSTALLMENT_PERIOD", loanAgainstSavingDisbursement.PInstallment_Period, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRINCIPAL_ARREAR", loanAgainstSavingDisbursement.PPrincipal_Arrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRINCIPAL_AMOUNT", loanAgainstSavingDisbursement.PPrincipal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_YEAR_NO", loanAgainstSavingDisbursement.PYear_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_WITHDRAWAL_NO", loanAgainstSavingDisbursement.PWithdrawal_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CHK_ADJUST_SAVING", loanAgainstSavingDisbursement.PChk_Adjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", loanAgainstSavingDisbursement.PSaving_Account_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSURANCE_POLICY_NO", loanAgainstSavingDisbursement.PInsurance_Policy_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TRAN_OFFICE_CODE", loanAgainstSavingDisbursement.PTran_Office_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FIXED_PRINCIPAL_AMOUNT", loanAgainstSavingDisbursement.PFixed_Principal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FIRST_INSTALL_DATE", loanAgainstSavingDisbursement.PFirst_Install_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_CENTER", loanAgainstSavingDisbursement.PClient_Center, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FIXED_INTEREST_AMOUNT", loanAgainstSavingDisbursement.PFixed_Interest_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CONTRA_ACCOUNT", loanAgainstSavingDisbursement.PContra_Account, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION1_CODE", loanAgainstSavingDisbursement.PDeduction1_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION1_DESC", loanAgainstSavingDisbursement.PDeduction1_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT1", loanAgainstSavingDisbursement.PDeduction_Amount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION2_CODE", loanAgainstSavingDisbursement.PDeduction2_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION2_DESC", loanAgainstSavingDisbursement.PDeduction2_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT2", loanAgainstSavingDisbursement.PDeduction_Amount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION3_CODE", loanAgainstSavingDisbursement.PDeduction3_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION3_DESC", loanAgainstSavingDisbursement.PDeduction3_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT3", loanAgainstSavingDisbursement.PDeduction_Amount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION4_CODE", loanAgainstSavingDisbursement.PDeduction4_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION4_DESC", loanAgainstSavingDisbursement.PDeduction4_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEDUCTION_AMOUNT4", loanAgainstSavingDisbursement.PDeduction_Amount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_NO_OF_INSTALLMENT", loanAgainstSavingDisbursement.PNo_Of_Installment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FUNDING_AGENCY_CODE", loanAgainstSavingDisbursement.PFunding_Agency_Code, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_AGAINST_SAVING_NO", loanAgainstSavingDisbursement.PLoan_Against_Saving_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER1", loanAgainstSavingDisbursement.PUser1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INSERT_UPDATE", loanAgainstSavingDisbursement.PInsert_Update, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_FISCAL_YEAR", loanAgainstSavingDisbursement.VOut_Fiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_LOAN_NO", loanAgainstSavingDisbursement.VOut_Loan_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_LOAN_DNO", loanAgainstSavingDisbursement.VOut_Loan_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RESULT_CODE", loanAgainstSavingDisbursement.VOut_Result_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanAgainstSavingDisbursement> lst = new List<LoanAgainstSavingDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanAgainstSavingDisbursement obj = new LoanAgainstSavingDisbursement();
                    obj.PLoan_Date = drow["P_LOAN_DATE"].ToString();
                    obj.PLoan_Maturity_Date = drow["P_LOAN_MATURITY_DATE"].ToString();
                    obj.PLoan_Product_Code = drow["P_LOAN_PRODUCT_CODE"].ToString();
                    obj.PClient_No = drow["P_CLIENT_NO"].ToString();
                    obj.PLoan_Purpose_Code = drow["P_LOAN_PURPOSE_CODE"].ToString();
                    obj.PApproved_Loan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.PTotal_Loan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.PLoan_Period_Type = drow["P_LOAN_PERIOD_TYPE"].ToString();
                    obj.PLoan_Period = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_LOAN_PERIOD"].ToString()));
                    obj.PGrace_Days = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_GRACE_DAYS"].ToString()));
                    obj.PEmployee_Id = drow["P_EMPLOYEE_ID"].ToString();
                    obj.PInterest_Rate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_INTEREST_RATE"].ToString()));
                    obj.PInterest_Calc_Method = drow["P_INTEREST_CALC_METHOD"].ToString();
                    obj.PLoan_Close_Date = drow["P_LOAN_CLOSE_DATE"].ToString();
                    obj.PLoan_Status = drow["P_LOAN_STATUS"].ToString();
                    obj.PRating = drow["P_RATING"].ToString();
                    obj.PInstallment_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_INSTALLMENT_AMOUNT"].ToString()));
                    obj.PRef_Account_No = drow["P_REF_ACCOUNT_NO"].ToString();
                    obj.PInstallment_Period_Type = drow["P_INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.PInstallment_Period = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_INSTALLMENT_PERIOD"].ToString()));
                    obj.PPrincipal_Arrear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_PRINCIPAL_ARREAR"].ToString()));
                    obj.PPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_PRINCIPAL_AMOUNT"].ToString()));
                    obj.PYear_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_YEAR_NO"].ToString()));
                    obj.PWithdrawal_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_WITHDRAWAL_NO"].ToString()));
                    obj.PChk_Adjust_Saving = drow["P_CHK_ADJUST_SAVING"].ToString();
                    obj.PSaving_Account_No = drow["P_SAVING_ACCOUNT_NO"].ToString();
                    obj.PInsurance_Policy_No = drow["P_INSURANCE_POLICY_NO"].ToString();
                    obj.PTran_Office_Code = drow["P_TRAN_OFFICE_CODE"].ToString();
                    obj.PFixed_Principal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.PFirst_Install_Date = drow["P_FIRST_INSTALL_DATE"].ToString();
                    obj.PClient_Center = drow["P_CLIENT_CENTER"].ToString();
                    obj.PFixed_Interest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_FIXED_INTEREST_AMOUNT"].ToString()));
                    obj.PContra_Account = drow["P_CONTRA_ACCOUNT"].ToString();
                    obj.PDeduction1_Code = drow["P_DEDUCTION1_CODE"].ToString();
                    obj.PDeduction1_Desc = drow["P_DEDUCTION1_DESC"].ToString();
                    obj.PDeduction_Amount1 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT1"].ToString()));
                    obj.PDeduction2_Code = drow["P_DEDUCTION2_CODE"].ToString();
                    obj.PDeduction2_Desc = drow["P_DEDUCTION2_DESC"].ToString();
                    obj.PDeduction_Amount2 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT2"].ToString()));
                    obj.PDeduction3_Code = drow["P_DEDUCTION3_CODE"].ToString();
                    obj.PDeduction3_Desc = drow["P_DEDUCTION3_DESC"].ToString();
                    obj.PDeduction_Amount3 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT3"].ToString()));
                    obj.PDeduction4_Code = drow["P_DEDUCTION4_CODE"].ToString();
                    obj.PDeduction4_Desc = drow["P_DEDUCTION4_DESC"].ToString();
                    obj.PDeduction_Amount4 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_DEDUCTION_AMOUNT4"].ToString()));
                    obj.PNo_Of_Installment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_NO_OF_INSTALLMENT"].ToString()));
                    obj.PFunding_Agency_Code = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["P_FUNDING_AGENCY_CODE"].ToString()));
                    obj.PLoan_Against_Saving_No = drow["P_LOAN_AGAINST_SAVING_NO"].ToString();
                    obj.PUser1 = drow["P_USER1"].ToString();
                    obj.PInsert_Update = drow["P_INSERT_UPDATE"].ToString();
                    obj.VOut_Fiscal_Year = drow["V_OUT_FISCAL_YEAR"].ToString();
                    obj.VOut_Loan_No = drow["V_OUT_LOAN_NO"].ToString();
                    obj.VOut_Loan_Dno = drow["V_OUT_LOAN_DNO"].ToString();
                    obj.VOut_Result_Code = drow["V_OUT_RESULT_CODE"].ToString();

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
