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
    public class OracleMfLoanDisbursementDao : IMfLoanDisbursementDao
    {
        public object Get()
        {
            string sp = "mfLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanDisbursement> lst = new List<MfLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanDisbursement obj = new MfLoanDisbursement();
                    obj.LoanDate = drow["LoanDate"].ToString();
                    obj.LoanMaturityDate = drow["LoanMaturityDate"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(drow["ApprovedLoanAmount"].ToString());
                    obj.TotalLoanAmount = double.Parse(drow["TotalLoanAmount"].ToString());
                    obj.LoanPeriodType = drow["LoanPeriodType"].ToString();
                    obj.LoanPeriod = double.Parse(drow["LoanPeriod"].ToString());
                    obj.GraceDays = double.Parse(drow["GraceDays"].ToString());
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.InterestCalcMethod = drow["InterestCalcMethod"].ToString();
                    obj.LoanCloseDate = drow["LoanCloseDate"].ToString();
                    obj.LoanStatus = drow["LoanStatus"].ToString();
                    obj.Rating = drow["Rating"].ToString();
                    obj.InstallmentAmount = double.Parse(drow["InstallmentAmount"].ToString());
                    obj.RefAccountNo = drow["RefAccountNo"].ToString();
                    obj.InstallmentPeriodType = drow["InstallmentPeriodType"].ToString();
                    obj.InstallmentPeriod = double.Parse(drow["InstallmentPeriod"].ToString());
                    obj.PrincipalArrear = double.Parse(drow["PrincipalArrear"].ToString());
                    obj.PrincipalAmount = double.Parse(drow["PrincipalAmount"].ToString());
                    obj.YearNo = double.Parse(drow["YearNo"].ToString());
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ChkAdjustSaving = drow["ChkAdjustSaving"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.InsurancePolicyNo = drow["InsurancePolicyNo"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.FixedPrincipalAmount = double.Parse(drow["FixedPrincipalAmount"].ToString());
                    obj.FirstInstallDate = drow["FirstInstallDate"].ToString();
                    obj.ClientCenter = drow["ClientCenter"].ToString();
                    obj.FixedInterestAmount = double.Parse(drow["FixedInterestAmount"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.Deduction1Code = drow["Deduction1Code"].ToString();
                    obj.Deduction1Desc = drow["Deduction1Desc"].ToString();
                    obj.DeductionAmount1 = double.Parse(drow["DeductionAmount1"].ToString());
                    obj.Deduction2Code = drow["Deduction2Code"].ToString();
                    obj.Deduction2Desc = drow["Deduction2Desc"].ToString();
                    obj.DeductionAmount2 = double.Parse(drow["DeductionAmount2"].ToString());
                    obj.Deduction3Code = drow["Deduction3Code"].ToString();
                    obj.Deduction3Desc = drow["Deduction3Desc"].ToString();
                    obj.DeductionAmount3 = double.Parse(drow["DeductionAmount3"].ToString());
                    obj.Deduction4Code = drow["Deduction4Code"].ToString();
                    obj.Deduction4Desc = drow["Deduction4Desc"].ToString();
                    obj.DeductionAmount4 = double.Parse(drow["DeductionAmount4"].ToString());
                    obj.NoOfInstallment = double.Parse(drow["NoOfInstallment"].ToString());
                    obj.FundingAgencyCode = double.Parse(drow["FundingAgencyCode"].ToString());
                    obj.User1 = drow["User1"].ToString();
                    obj.InsertUpdate = drow["InsertUpdate"].ToString();
                    obj.OutFiscalYear = drow["OutFiscalYear"].ToString();
                    obj.OutLoanNo = drow["OutLoanNo"].ToString();
                    obj.OutLoanDno = drow["OutLoanDno"].ToString();
                    obj.OutResultCode = drow["OutResultCode"].ToString();
                    obj.OutResultMsg = drow["OutResultMsg"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfLoanDisbursement mfLoanDisbursement)
        {
            string sp = "fn_loan_pkg.p_mf_loan_disbursement";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDate", mfLoanDisbursement.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanMaturityDate", mfLoanDisbursement.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", mfLoanDisbursement.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfLoanDisbursement.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", mfLoanDisbursement.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ApprovedLoanAmount", mfLoanDisbursement.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalLoanAmount", mfLoanDisbursement.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriodType", mfLoanDisbursement.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriod", mfLoanDisbursement.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GraceDays", mfLoanDisbursement.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", mfLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", mfLoanDisbursement.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestCalcMethod", mfLoanDisbursement.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanCloseDate", mfLoanDisbursement.LoanCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanStatus", mfLoanDisbursement.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Rating", mfLoanDisbursement.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentAmount", mfLoanDisbursement.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RefAccountNo", mfLoanDisbursement.RefAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriodType", mfLoanDisbursement.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriod", mfLoanDisbursement.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalArrear", mfLoanDisbursement.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalAmount", mfLoanDisbursement.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YearNo", mfLoanDisbursement.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfLoanDisbursement.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChkAdjustSaving", mfLoanDisbursement.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfLoanDisbursement.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyNo", mfLoanDisbursement.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfLoanDisbursement.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedPrincipalAmount", mfLoanDisbursement.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstInstallDate", mfLoanDisbursement.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCenter", mfLoanDisbursement.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedInterestAmount", mfLoanDisbursement.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction1Code", mfLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction1Desc", mfLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount1", mfLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction2Code", mfLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction2Desc", mfLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount2", mfLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction3Code", mfLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction3Desc", mfLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount3", mfLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction4Code", mfLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction4Desc", mfLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount4", mfLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfInstallment", mfLoanDisbursement.NoOfInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FundingAgencyCode", mfLoanDisbursement.FundingAgencyCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_User1", mfLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsertUpdate", mfLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutFiscalYear", mfLoanDisbursement.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutLoanNo", mfLoanDisbursement.OutLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutLoanDno", mfLoanDisbursement.OutLoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutResultCode", mfLoanDisbursement.OutResultCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutResultMsg", mfLoanDisbursement.OutResultMsg, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfLoanDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfLoanDisbursement mfLoanDisbursement)
        {
            string sp = "mfLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDate", mfLoanDisbursement.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanMaturityDate", mfLoanDisbursement.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", mfLoanDisbursement.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfLoanDisbursement.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", mfLoanDisbursement.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ApprovedLoanAmount", mfLoanDisbursement.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalLoanAmount", mfLoanDisbursement.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriodType", mfLoanDisbursement.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriod", mfLoanDisbursement.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GraceDays", mfLoanDisbursement.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", mfLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", mfLoanDisbursement.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestCalcMethod", mfLoanDisbursement.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanCloseDate", mfLoanDisbursement.LoanCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanStatus", mfLoanDisbursement.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Rating", mfLoanDisbursement.Rating, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentAmount", mfLoanDisbursement.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RefAccountNo", mfLoanDisbursement.RefAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriodType", mfLoanDisbursement.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriod", mfLoanDisbursement.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalArrear", mfLoanDisbursement.PrincipalArrear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalAmount", mfLoanDisbursement.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YearNo", mfLoanDisbursement.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfLoanDisbursement.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChkAdjustSaving", mfLoanDisbursement.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfLoanDisbursement.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyNo", mfLoanDisbursement.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfLoanDisbursement.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedPrincipalAmount", mfLoanDisbursement.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstInstallDate", mfLoanDisbursement.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCenter", mfLoanDisbursement.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedInterestAmount", mfLoanDisbursement.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction1Code", mfLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction1Desc", mfLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount1", mfLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction2Code", mfLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction2Desc", mfLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount2", mfLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction3Code", mfLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction3Desc", mfLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount3", mfLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction4Code", mfLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Deduction4Desc", mfLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionAmount4", mfLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfInstallment", mfLoanDisbursement.NoOfInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FundingAgencyCode", mfLoanDisbursement.FundingAgencyCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_User1", mfLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsertUpdate", mfLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutFiscalYear", mfLoanDisbursement.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutLoanNo", mfLoanDisbursement.OutLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutLoanDno", mfLoanDisbursement.OutLoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutResultCode", mfLoanDisbursement.OutResultCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutResultMsg", mfLoanDisbursement.OutResultMsg, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanDisbursement> lst = new List<MfLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanDisbursement obj = new MfLoanDisbursement();
                    obj.LoanDate = drow["LoanDate"].ToString();
                    obj.LoanMaturityDate = drow["LoanMaturityDate"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(drow["ApprovedLoanAmount"].ToString());
                    obj.TotalLoanAmount = double.Parse(drow["TotalLoanAmount"].ToString());
                    obj.LoanPeriodType = drow["LoanPeriodType"].ToString();
                    obj.LoanPeriod = double.Parse(drow["LoanPeriod"].ToString());
                    obj.GraceDays = double.Parse(drow["GraceDays"].ToString());
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.InterestCalcMethod = drow["InterestCalcMethod"].ToString();
                    obj.LoanCloseDate = drow["LoanCloseDate"].ToString();
                    obj.LoanStatus = drow["LoanStatus"].ToString();
                    obj.Rating = drow["Rating"].ToString();
                    obj.InstallmentAmount = double.Parse(drow["InstallmentAmount"].ToString());
                    obj.RefAccountNo = drow["RefAccountNo"].ToString();
                    obj.InstallmentPeriodType = drow["InstallmentPeriodType"].ToString();
                    obj.InstallmentPeriod = double.Parse(drow["InstallmentPeriod"].ToString());
                    obj.PrincipalArrear = double.Parse(drow["PrincipalArrear"].ToString());
                    obj.PrincipalAmount = double.Parse(drow["PrincipalAmount"].ToString());
                    obj.YearNo = double.Parse(drow["YearNo"].ToString());
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ChkAdjustSaving = drow["ChkAdjustSaving"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.InsurancePolicyNo = drow["InsurancePolicyNo"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.FixedPrincipalAmount = double.Parse(drow["FixedPrincipalAmount"].ToString());
                    obj.FirstInstallDate = drow["FirstInstallDate"].ToString();
                    obj.ClientCenter = drow["ClientCenter"].ToString();
                    obj.FixedInterestAmount = double.Parse(drow["FixedInterestAmount"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.Deduction1Code = drow["Deduction1Code"].ToString();
                    obj.Deduction1Desc = drow["Deduction1Desc"].ToString();
                    obj.DeductionAmount1 = double.Parse(drow["DeductionAmount1"].ToString());
                    obj.Deduction2Code = drow["Deduction2Code"].ToString();
                    obj.Deduction2Desc = drow["Deduction2Desc"].ToString();
                    obj.DeductionAmount2 = double.Parse(drow["DeductionAmount2"].ToString());
                    obj.Deduction3Code = drow["Deduction3Code"].ToString();
                    obj.Deduction3Desc = drow["Deduction3Desc"].ToString();
                    obj.DeductionAmount3 = double.Parse(drow["DeductionAmount3"].ToString());
                    obj.Deduction4Code = drow["Deduction4Code"].ToString();
                    obj.Deduction4Desc = drow["Deduction4Desc"].ToString();
                    obj.DeductionAmount4 = double.Parse(drow["DeductionAmount4"].ToString());
                    obj.NoOfInstallment = double.Parse(drow["NoOfInstallment"].ToString());
                    obj.FundingAgencyCode = double.Parse(drow["FundingAgencyCode"].ToString());
                    obj.User1 = drow["User1"].ToString();
                    obj.InsertUpdate = drow["InsertUpdate"].ToString();
                    obj.OutFiscalYear = drow["OutFiscalYear"].ToString();
                    obj.OutLoanNo = drow["OutLoanNo"].ToString();
                    obj.OutLoanDno = drow["OutLoanDno"].ToString();
                    obj.OutResultCode = drow["OutResultCode"].ToString();
                    obj.OutResultMsg = drow["OutResultMsg"].ToString();

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
