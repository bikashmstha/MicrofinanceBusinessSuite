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
    public class OracleLasLoanDetailDao : ILasLoanDetailDao
    {
        public object Get()
        {
            string sp = "lasLoanDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LasLoanDetail> lst = new List<LasLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LasLoanDetail obj = new LasLoanDetail();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanMature_Bs = drow["LOAN_MATURE_BS"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalPrincipal_Outstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.FundingAgency_Code = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FUNDING_AGENCY_CODE"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.InterestCalc_Method = drow["INTEREST_CALC_METHOD"].ToString();
                    obj.LoanStatus = drow["LOAN_STATUS"].ToString();
                    obj.TotalPrincipal_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterest_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.InsurancePolicy_No = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.TransferDate = drow["TRANSFER_DATE"].ToString();
                    obj.FixedPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.FirstInstall_Date = drow["FIRST_INSTALL_DATE"].ToString();
                    obj.FirstInstall_Date_Bs = drow["FIRST_INSTALL_DATE_BS"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.FixedInterest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_INTEREST_AMOUNT"].ToString()));
                    obj.NoOf_Installment = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_INSTALLMENT"].ToString()));
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.LoanPurpose_Desc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.CollectionDay = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLECTION_DAY"].ToString()));
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAc_Dno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProd_Name = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.LoanAgainst_Saving_No = drow["LOAN_AGAINST_SAVING_NO"].ToString();
                    obj.LoanAgainst_Sav_Product_Code = drow["LOAN_AGAINST_SAV_PRODUCT_CODE"].ToString();
                    obj.LoanAgainst_Sav_Product_Desc = drow["LOAN_AGAINST_SAV_PRODUCT_DESC"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LasLoanDetail lasLoanDetail)
        {
            string sp = "lasLoanDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", lasLoanDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lasLoanDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lasLoanDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", lasLoanDetail.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", lasLoanDetail.LoanDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", lasLoanDetail.LoanMaturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURE_BS", lasLoanDetail.LoanMature_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", lasLoanDetail.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", lasLoanDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", lasLoanDetail.LoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", lasLoanDetail.ApprovedLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", lasLoanDetail.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", lasLoanDetail.LoanPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", lasLoanDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", lasLoanDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", lasLoanDetail.TotalPrincipal_Outstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", lasLoanDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY", lasLoanDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", lasLoanDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", lasLoanDetail.FundingAgency_Code, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", lasLoanDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", lasLoanDetail.InterestCalc_Method, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", lasLoanDetail.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID", lasLoanDetail.TotalPrincipal_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", lasLoanDetail.TotalInterest_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", lasLoanDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", lasLoanDetail.InstallmentPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", lasLoanDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", lasLoanDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", lasLoanDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", lasLoanDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", lasLoanDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", lasLoanDetail.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", lasLoanDetail.AdjustFrom_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", lasLoanDetail.InsurancePolicy_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", lasLoanDetail.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE", lasLoanDetail.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", lasLoanDetail.FixedPrincipal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", lasLoanDetail.FirstInstall_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE_BS", lasLoanDetail.FirstInstall_Date_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", lasLoanDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", lasLoanDetail.FixedInterest_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", lasLoanDetail.NoOf_Installment, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_NAME", lasLoanDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", lasLoanDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", lasLoanDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", lasLoanDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", lasLoanDetail.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GROUP_NAME", lasLoanDetail.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", lasLoanDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", lasLoanDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", lasLoanDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_DESC", lasLoanDetail.LoanPurpose_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_DAY", lasLoanDetail.CollectionDay, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", lasLoanDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", lasLoanDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", lasLoanDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_GROUP", lasLoanDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_DNO", lasLoanDetail.SavAc_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_NAME", lasLoanDetail.SavProd_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", lasLoanDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AGAINST_SAVING_NO", lasLoanDetail.LoanAgainst_Saving_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AGAINST_SAV_PRODUCT_CODE", lasLoanDetail.LoanAgainst_Sav_Product_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AGAINST_SAV_PRODUCT_DESC", lasLoanDetail.LoanAgainst_Sav_Product_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", lasLoanDetail.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", lasLoanDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LasLoanDetail lasLoanDetail)
        {
            string sp = "lasLoanDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", lasLoanDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lasLoanDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lasLoanDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", lasLoanDetail.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", lasLoanDetail.LoanDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", lasLoanDetail.LoanMaturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURE_BS", lasLoanDetail.LoanMature_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", lasLoanDetail.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", lasLoanDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", lasLoanDetail.LoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", lasLoanDetail.ApprovedLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", lasLoanDetail.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", lasLoanDetail.LoanPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", lasLoanDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", lasLoanDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_OUTSTANDING", lasLoanDetail.TotalPrincipal_Outstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", lasLoanDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY", lasLoanDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", lasLoanDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FUNDING_AGENCY_CODE", lasLoanDetail.FundingAgency_Code, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", lasLoanDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_CALC_METHOD", lasLoanDetail.InterestCalc_Method, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_STATUS", lasLoanDetail.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID", lasLoanDetail.TotalPrincipal_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", lasLoanDetail.TotalInterest_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMOUNT", lasLoanDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", lasLoanDetail.InstallmentPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", lasLoanDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", lasLoanDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", lasLoanDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", lasLoanDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", lasLoanDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", lasLoanDetail.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", lasLoanDetail.AdjustFrom_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSURANCE_POLICY_NO", lasLoanDetail.InsurancePolicy_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", lasLoanDetail.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE", lasLoanDetail.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRINCIPAL_AMOUNT", lasLoanDetail.FixedPrincipal_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE", lasLoanDetail.FirstInstall_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALL_DATE_BS", lasLoanDetail.FirstInstall_Date_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", lasLoanDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INTEREST_AMOUNT", lasLoanDetail.FixedInterest_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", lasLoanDetail.NoOf_Installment, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_NAME", lasLoanDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", lasLoanDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", lasLoanDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", lasLoanDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", lasLoanDetail.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GROUP_NAME", lasLoanDetail.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", lasLoanDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", lasLoanDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", lasLoanDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_DESC", lasLoanDetail.LoanPurpose_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_DAY", lasLoanDetail.CollectionDay, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", lasLoanDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", lasLoanDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", lasLoanDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_GROUP", lasLoanDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_DNO", lasLoanDetail.SavAc_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_NAME", lasLoanDetail.SavProd_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", lasLoanDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AGAINST_SAVING_NO", lasLoanDetail.LoanAgainst_Saving_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AGAINST_SAV_PRODUCT_CODE", lasLoanDetail.LoanAgainst_Sav_Product_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AGAINST_SAV_PRODUCT_DESC", lasLoanDetail.LoanAgainst_Sav_Product_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", lasLoanDetail.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LasLoanDetail> lst = new List<LasLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LasLoanDetail obj = new LasLoanDetail();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanMature_Bs = drow["LOAN_MATURE_BS"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalPrincipal_Outstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.FundingAgency_Code = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FUNDING_AGENCY_CODE"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.InterestCalc_Method = drow["INTEREST_CALC_METHOD"].ToString();
                    obj.LoanStatus = drow["LOAN_STATUS"].ToString();
                    obj.TotalPrincipal_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterest_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.InsurancePolicy_No = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.TransferDate = drow["TRANSFER_DATE"].ToString();
                    obj.FixedPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.FirstInstall_Date = drow["FIRST_INSTALL_DATE"].ToString();
                    obj.FirstInstall_Date_Bs = drow["FIRST_INSTALL_DATE_BS"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.FixedInterest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_INTEREST_AMOUNT"].ToString()));
                    obj.NoOf_Installment = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_INSTALLMENT"].ToString()));
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.LoanPurpose_Desc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.CollectionDay = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLECTION_DAY"].ToString()));
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAc_Dno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProd_Name = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.LoanAgainst_Saving_No = drow["LOAN_AGAINST_SAVING_NO"].ToString();
                    obj.LoanAgainst_Sav_Product_Code = drow["LOAN_AGAINST_SAV_PRODUCT_CODE"].ToString();
                    obj.LoanAgainst_Sav_Product_Desc = drow["LOAN_AGAINST_SAV_PRODUCT_DESC"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLasLoanDetail(string OfficeCode, string ClientName, string LoanNo, string DateFrom, string DateTo)
        {
            string sp = "fn_loan_pkg.p_las_loan_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_NO", LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DATE_FROM", DateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DATE_TO", DateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LasLoanDetail> lst = new List<LasLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LasLoanDetail obj = new LasLoanDetail();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanMature_Bs = drow["LOAN_MATURE_BS"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalPrincipal_Outstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_OUTSTANDING"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.FundingAgency_Code = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FUNDING_AGENCY_CODE"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.InterestCalc_Method = drow["INTEREST_CALC_METHOD"].ToString();
                    obj.LoanStatus = drow["LOAN_STATUS"].ToString();
                    obj.TotalPrincipal_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterest_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_AMOUNT"].ToString()));
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.InsurancePolicy_No = drow["INSURANCE_POLICY_NO"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.TransferDate = drow["TRANSFER_DATE"].ToString();
                    obj.FixedPrincipal_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_PRINCIPAL_AMOUNT"].ToString()));
                    obj.FirstInstall_Date = drow["FIRST_INSTALL_DATE"].ToString();
                    obj.FirstInstall_Date_Bs = drow["FIRST_INSTALL_DATE_BS"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.FixedInterest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_INTEREST_AMOUNT"].ToString()));
                    obj.NoOf_Installment = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_INSTALLMENT"].ToString()));
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.LoanPurpose_Desc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.CollectionDay = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLECTION_DAY"].ToString()));
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAc_Dno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProd_Name = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.LoanAgainst_Saving_No = drow["LOAN_AGAINST_SAVING_NO"].ToString();
                    obj.LoanAgainst_Sav_Product_Code = drow["LOAN_AGAINST_SAV_PRODUCT_CODE"].ToString();
                    obj.LoanAgainst_Sav_Product_Desc = drow["LOAN_AGAINST_SAV_PRODUCT_DESC"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

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
