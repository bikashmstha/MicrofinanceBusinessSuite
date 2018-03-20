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
    public class OracleMfAdditionalLoanDetailDao : IMfAdditionalLoanDetailDao
    {
        public object Get()
        {
            string sp = "mfAdditionalLoanDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdditionalLoanDetail> lst = new List<MfAdditionalLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdditionalLoanDetail obj = new MfAdditionalLoanDetail();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanMature_Bs = drow["LOAN_MATURE_BS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TotalPrincipal_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterest_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAc_Dno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProd_Name = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.DisburseDate_Bs = drow["DISBURSE_DATE_BS"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfAdditionalLoanDetail mfAdditionalLoanDetail)
        {
            string sp = "mfAdditionalLoanDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", mfAdditionalLoanDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", mfAdditionalLoanDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", mfAdditionalLoanDetail.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", mfAdditionalLoanDetail.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", mfAdditionalLoanDetail.LoanDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", mfAdditionalLoanDetail.LoanMaturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURE_BS", mfAdditionalLoanDetail.LoanMature_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", mfAdditionalLoanDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", mfAdditionalLoanDetail.ApprovedLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", mfAdditionalLoanDetail.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", mfAdditionalLoanDetail.LoanPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", mfAdditionalLoanDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", mfAdditionalLoanDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", mfAdditionalLoanDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY", mfAdditionalLoanDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", mfAdditionalLoanDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID", mfAdditionalLoanDetail.TotalPrincipal_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", mfAdditionalLoanDetail.TotalInterest_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", mfAdditionalLoanDetail.InstallmentPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", mfAdditionalLoanDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", mfAdditionalLoanDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", mfAdditionalLoanDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", mfAdditionalLoanDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", mfAdditionalLoanDetail.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", mfAdditionalLoanDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", mfAdditionalLoanDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", mfAdditionalLoanDetail.AdjustFrom_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", mfAdditionalLoanDetail.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", mfAdditionalLoanDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_NAME", mfAdditionalLoanDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", mfAdditionalLoanDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", mfAdditionalLoanDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", mfAdditionalLoanDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", mfAdditionalLoanDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", mfAdditionalLoanDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", mfAdditionalLoanDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", mfAdditionalLoanDetail.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", mfAdditionalLoanDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_GROUP", mfAdditionalLoanDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_DNO", mfAdditionalLoanDetail.SavAc_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_NAME", mfAdditionalLoanDetail.SavProd_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", mfAdditionalLoanDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", mfAdditionalLoanDetail.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE_BS", mfAdditionalLoanDetail.DisburseDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", mfAdditionalLoanDetail.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfAdditionalLoanDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfAdditionalLoanDetail mfAdditionalLoanDetail)
        {
            string sp = "mfAdditionalLoanDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", mfAdditionalLoanDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", mfAdditionalLoanDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", mfAdditionalLoanDetail.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", mfAdditionalLoanDetail.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", mfAdditionalLoanDetail.LoanDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE", mfAdditionalLoanDetail.LoanMaturity_Date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURE_BS", mfAdditionalLoanDetail.LoanMature_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", mfAdditionalLoanDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", mfAdditionalLoanDetail.ApprovedLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", mfAdditionalLoanDetail.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", mfAdditionalLoanDetail.LoanPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", mfAdditionalLoanDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", mfAdditionalLoanDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", mfAdditionalLoanDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY", mfAdditionalLoanDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", mfAdditionalLoanDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID", mfAdditionalLoanDetail.TotalPrincipal_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", mfAdditionalLoanDetail.TotalInterest_Paid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", mfAdditionalLoanDetail.InstallmentPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", mfAdditionalLoanDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", mfAdditionalLoanDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", mfAdditionalLoanDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", mfAdditionalLoanDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", mfAdditionalLoanDetail.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", mfAdditionalLoanDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", mfAdditionalLoanDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", mfAdditionalLoanDetail.AdjustFrom_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", mfAdditionalLoanDetail.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", mfAdditionalLoanDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_NAME", mfAdditionalLoanDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", mfAdditionalLoanDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", mfAdditionalLoanDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", mfAdditionalLoanDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", mfAdditionalLoanDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", mfAdditionalLoanDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", mfAdditionalLoanDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", mfAdditionalLoanDetail.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", mfAdditionalLoanDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_GROUP", mfAdditionalLoanDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_DNO", mfAdditionalLoanDetail.SavAc_Dno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_NAME", mfAdditionalLoanDetail.SavProd_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", mfAdditionalLoanDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", mfAdditionalLoanDetail.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE_BS", mfAdditionalLoanDetail.DisburseDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", mfAdditionalLoanDetail.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdditionalLoanDetail> lst = new List<MfAdditionalLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdditionalLoanDetail obj = new MfAdditionalLoanDetail();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanMature_Bs = drow["LOAN_MATURE_BS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TotalPrincipal_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterest_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAc_Dno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProd_Name = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.DisburseDate_Bs = drow["DISBURSE_DATE_BS"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMfAdditionalLoanDetail(string offCode, string clientName, string loanNo, string dateFrom, string dateTo)
        {

            string sp = "fn_loan_pkg.p_mf_add_loan_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", dateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", dateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdditionalLoanDetail> lst = new List<MfAdditionalLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdditionalLoanDetail obj = new MfAdditionalLoanDetail();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturity_Date = drow["LOAN_MATURITY_DATE"].ToString();
                    obj.LoanMature_Bs = drow["LOAN_MATURE_BS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ApprovedLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriod_Type = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TotalPrincipal_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterest_Paid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentPeriod_Type = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AdjustFrom_Saving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAc_Dno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProd_Name = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.DisburseDate_Bs = drow["DISBURSE_DATE_BS"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));

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
