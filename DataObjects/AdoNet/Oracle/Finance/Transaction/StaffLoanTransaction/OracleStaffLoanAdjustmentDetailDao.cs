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
    public class OracleStaffLoanAdjustmentDetailDao : IStaffLoanAdjustmentDetailDao
    {
        public object SaveStaffLoanAdjustmentDetail(StaffLoanAdjustmentDetail staffLoanAdjustmentDetail)
        {
            string sp = "staffLoanAdjustmentDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", staffLoanAdjustmentDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanAdjustmentDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffLoanAdjustmentDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanAdjustmentDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_AD", staffLoanAdjustmentDetail.LoanDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", staffLoanAdjustmentDetail.LoanDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE_AD", staffLoanAdjustmentDetail.LoanMaturityDate_Ad, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURE_BS", staffLoanAdjustmentDetail.LoanMatureBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", staffLoanAdjustmentDetail.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", staffLoanAdjustmentDetail.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", staffLoanAdjustmentDetail.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", staffLoanAdjustmentDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", staffLoanAdjustmentDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", staffLoanAdjustmentDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY", staffLoanAdjustmentDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanAdjustmentDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", staffLoanAdjustmentDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID", staffLoanAdjustmentDetail.TotalPrincipalPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", staffLoanAdjustmentDetail.TotalInterestPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", staffLoanAdjustmentDetail.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", staffLoanAdjustmentDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", staffLoanAdjustmentDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", staffLoanAdjustmentDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", staffLoanAdjustmentDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanAdjustmentDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", staffLoanAdjustmentDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanAdjustmentDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", staffLoanAdjustmentDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanAdjustmentDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", staffLoanAdjustmentDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_NAME", staffLoanAdjustmentDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", staffLoanAdjustmentDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", staffLoanAdjustmentDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", staffLoanAdjustmentDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", staffLoanAdjustmentDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", staffLoanAdjustmentDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", staffLoanAdjustmentDetail.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", staffLoanAdjustmentDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_GROUP", staffLoanAdjustmentDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_DNO", staffLoanAdjustmentDetail.SavAcDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_NAME", staffLoanAdjustmentDetail.SavProdName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", staffLoanAdjustmentDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanAdjustmentDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE_AD", staffLoanAdjustmentDetail.DisburseDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE_BS", staffLoanAdjustmentDetail.DisburseDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", staffLoanAdjustmentDetail.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanAdjustmentDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffLoanAdjustmentDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffLoanAdjustmentDetail(StaffLoanAdjustmentDetail staffLoanAdjustmentDetail)
        {
            string sp = "staffLoanAdjustmentDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", staffLoanAdjustmentDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanAdjustmentDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffLoanAdjustmentDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanAdjustmentDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_AD", staffLoanAdjustmentDetail.LoanDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", staffLoanAdjustmentDetail.LoanDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURITY_DATE_AD", staffLoanAdjustmentDetail.LoanMaturityDate_Ad, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_MATURE_BS", staffLoanAdjustmentDetail.LoanMatureBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_LOAN_AMOUNT", staffLoanAdjustmentDetail.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", staffLoanAdjustmentDetail.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", staffLoanAdjustmentDetail.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD", staffLoanAdjustmentDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS", staffLoanAdjustmentDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST", staffLoanAdjustmentDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PENALTY", staffLoanAdjustmentDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanAdjustmentDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", staffLoanAdjustmentDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_PRINCIPAL_PAID", staffLoanAdjustmentDetail.TotalPrincipalPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_INTEREST_PAID", staffLoanAdjustmentDetail.TotalInterestPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD_TYPE", staffLoanAdjustmentDetail.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", staffLoanAdjustmentDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMOUNT", staffLoanAdjustmentDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_NO", staffLoanAdjustmentDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", staffLoanAdjustmentDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffLoanAdjustmentDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", staffLoanAdjustmentDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffLoanAdjustmentDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", staffLoanAdjustmentDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffLoanAdjustmentDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CENTER", staffLoanAdjustmentDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_NAME", staffLoanAdjustmentDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", staffLoanAdjustmentDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", staffLoanAdjustmentDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", staffLoanAdjustmentDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", staffLoanAdjustmentDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", staffLoanAdjustmentDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", staffLoanAdjustmentDetail.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", staffLoanAdjustmentDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_GROUP", staffLoanAdjustmentDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_DNO", staffLoanAdjustmentDetail.SavAcDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_NAME", staffLoanAdjustmentDetail.SavProdName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", staffLoanAdjustmentDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanAdjustmentDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE_AD", staffLoanAdjustmentDetail.DisburseDateAd, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE_BS", staffLoanAdjustmentDetail.DisburseDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", staffLoanAdjustmentDetail.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffLoanAdjustmentDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanAdjustmentDetail> lst = new List<StaffLoanAdjustmentDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanAdjustmentDetail obj = new StaffLoanAdjustmentDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDateAd = drow["LOAN_DATE_AD"].ToString();
                    obj.LoanDateBs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturityDate_Ad = drow["LOAN_MATURITY_DATE_AD"].ToString();
                    obj.LoanMatureBs = drow["LOAN_MATURE_BS"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.TotalPrincipalPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterestPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentPeriodType = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.LoanProductName = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAcDno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProdName = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.DisburseDateAd = drow["DISBURSE_DATE_AD"].ToString();
                    obj.DisburseDateBs = drow["DISBURSE_DATE_BS"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetStaffLoanAdjDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate)
        {
            string sp = "fn_loan_utility_pkg.p_staff_loan_adj_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_NO", LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanAdjustmentDetail> lst = new List<StaffLoanAdjustmentDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanAdjustmentDetail obj = new StaffLoanAdjustmentDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDateAd = drow["LOAN_DATE_AD"].ToString();
                    obj.LoanDateBs = drow["LOAN_DATE_BS"].ToString();
                    obj.LoanMaturityDate_Ad = drow["LOAN_MATURITY_DATE_AD"].ToString();
                    obj.LoanMatureBs = drow["LOAN_MATURE_BS"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["APPROVED_LOAN_AMOUNT"].ToString()));
                    obj.TotalLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PENALTY"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.TotalPrincipalPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_PRINCIPAL_PAID"].ToString()));
                    obj.TotalInterestPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_INTEREST_PAID"].ToString()));
                    obj.InstallmentPeriodType = drow["INSTALLMENT_PERIOD_TYPE"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMOUNT"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_NO"].ToString()));
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.ClientCenter = drow["CLIENT_CENTER"].ToString();
                    obj.EmployeeName = drow["EMPLOYEE_NAME"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.LoanProductName = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.CenterGroup = drow["CENTER_GROUP"].ToString();
                    obj.SavAcDno = drow["SAV_AC_DNO"].ToString();
                    obj.SavProdName = drow["SAV_PROD_NAME"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.DisburseDateAd = drow["DISBURSE_DATE_AD"].ToString();
                    obj.DisburseDateBs = drow["DISBURSE_DATE_BS"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();

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
