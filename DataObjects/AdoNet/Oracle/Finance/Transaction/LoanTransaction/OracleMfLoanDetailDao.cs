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
    public class OracleMfLoanDetailDao : IMfLoanDetailDao
    {
        public object Get()
        {
            string sp = "mfLoanDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanDetail> lst = new List<MfLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanDetail obj = new MfLoanDetail();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.LoanDate = drow["LoanDate"].ToString();
                    obj.LoanDateBs = drow["LoanDateBs"].ToString();
                    obj.SectorDesc = drow["SectorDesc"].ToString();
                    obj.LoanMaturityDate = drow["LoanMaturityDate"].ToString();
                    obj.LoanMatureBs = drow["LoanMatureBs"].ToString();
                    obj.HusbandName = drow["HusbandName"].ToString();
                    obj.FatherInlawName = drow["FatherInlawName"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(drow["ApprovedLoanAmount"].ToString());
                    obj.TotalLoanAmount = double.Parse(drow["TotalLoanAmount"].ToString());
                    obj.LoanPeriodType = drow["LoanPeriodType"].ToString();
                    obj.LoanPeriod = double.Parse(drow["LoanPeriod"].ToString());
                    obj.GraceDays = double.Parse(drow["GraceDays"].ToString());
                    obj.TotalPrincipalOutstanding = double.Parse(drow["TotalPrincipalOutstanding"].ToString());
                    obj.TotalInterest = double.Parse(drow["TotalInterest"].ToString());
                    obj.TotalPenalty = double.Parse(drow["TotalPenalty"].ToString());
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.FundingAgencyCode = drow["FundingAgencyCode"].ToString();
                    obj.InterestCalcMethod = drow["InterestCalcMethod"].ToString();
                    obj.LoanStatus = drow["LoanStatus"].ToString();
                    obj.TotalPrincipalPaid = double.Parse(drow["TotalPrincipalPaid"].ToString());
                    obj.TotalInterestPaid = double.Parse(drow["TotalInterestPaid"].ToString());
                    obj.InstallmentAmount = double.Parse(drow["InstallmentAmount"].ToString());
                    obj.InstallmentPeriodType = drow["InstallmentPeriodType"].ToString();
                    obj.InstallmentPeriod = int.Parse(drow["InstallmentPeriod"].ToString());
                    obj.PrincipalAmount = double.Parse(drow["PrincipalAmount"].ToString());
                    obj.YearNo = double.Parse(drow["YearNo"].ToString());
                    obj.WithdrawalNo = drow["WithdrawalNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.AdjustFromSaving = drow["AdjustFromSaving"].ToString();
                    obj.InsurancePolicyNo = drow["InsurancePolicyNo"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.FixedPrincipalAmount = double.Parse(drow["FixedPrincipalAmount"].ToString());
                    obj.FirstInstallDate = drow["FirstInstallDate"].ToString();
                    obj.FirstInstallDateBs = drow["FirstInstallDateBs"].ToString();
                    obj.ClientCenter = drow["ClientCenter"].ToString();
                    obj.FixedInterestAmount = double.Parse(drow["FixedInterestAmount"].ToString());
                    obj.NoOfInstallment = int.Parse(drow["NoOfInstallment"].ToString());
                    obj.EmployeeName = drow["EmployeeName"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.LoanProductName = drow["LoanProductName"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.GroupName = drow["GroupName"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.NomineeName = drow["NomineeName"].ToString();
                    obj.SpouseName = drow["SpouseName"].ToString();
                    obj.LoanPurposeDesc = drow["LoanPurposeDesc"].ToString();
                    obj.CollectionDay = int.Parse(drow["CollectionDay"].ToString());
                    obj.AccountNo =drow["AccountNo"].ToString();
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.PeriodType = drow["PeriodType"].ToString();
                    obj.CenterGroup = drow["CenterGroup"].ToString();
                    obj.SavAcDno = drow["SavAcDno"].ToString();
                    obj.SavProdName = drow["SavProdName"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfLoanDetail mfLoanDetail)
        {
            string sp = "mfLoanDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", mfLoanDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", mfLoanDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", mfLoanDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDate", mfLoanDetail.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDateBs", mfLoanDetail.LoanDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SectorDesc", mfLoanDetail.SectorDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanMaturityDate", mfLoanDetail.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanMatureBs", mfLoanDetail.LoanMatureBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HusbandName", mfLoanDetail.HusbandName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FatherInlawName", mfLoanDetail.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", mfLoanDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfLoanDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", mfLoanDetail.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ApprovedLoanAmount", mfLoanDetail.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalLoanAmount", mfLoanDetail.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriodType", mfLoanDetail.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriod", mfLoanDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GraceDays", mfLoanDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalOutstanding", mfLoanDetail.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalInterest", mfLoanDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPenalty", mfLoanDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", mfLoanDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FundingAgencyCode", mfLoanDetail.FundingAgencyCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestCalcMethod", mfLoanDetail.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanStatus", mfLoanDetail.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalPaid", mfLoanDetail.TotalPrincipalPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalInterestPaid", mfLoanDetail.TotalInterestPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentAmount", mfLoanDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriodType", mfLoanDetail.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriod", mfLoanDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalAmount", mfLoanDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YearNo", mfLoanDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfLoanDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfLoanDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfLoanDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", mfLoanDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyNo", mfLoanDetail.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfLoanDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", mfLoanDetail.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedPrincipalAmount", mfLoanDetail.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstInstallDate", mfLoanDetail.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstInstallDateBs", mfLoanDetail.FirstInstallDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCenter", mfLoanDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedInterestAmount", mfLoanDetail.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfInstallment", mfLoanDetail.NoOfInstallment, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", mfLoanDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfLoanDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", mfLoanDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfLoanDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductName", mfLoanDetail.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", mfLoanDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GroupName", mfLoanDetail.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", mfLoanDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", mfLoanDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SpouseName", mfLoanDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeDesc", mfLoanDetail.LoanPurposeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDay", mfLoanDetail.CollectionDay, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfLoanDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfLoanDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PeriodType", mfLoanDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterGroup", mfLoanDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavAcDno", mfLoanDetail.SavAcDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavProdName", mfLoanDetail.SavProdName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfLoanDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfLoanDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfLoanDetail mfLoanDetail)
        {
            string sp = "mfLoanDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", mfLoanDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", mfLoanDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", mfLoanDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDate", mfLoanDetail.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDateBs", mfLoanDetail.LoanDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SectorDesc", mfLoanDetail.SectorDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanMaturityDate", mfLoanDetail.LoanMaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanMatureBs", mfLoanDetail.LoanMatureBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HusbandName", mfLoanDetail.HusbandName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FatherInlawName", mfLoanDetail.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", mfLoanDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfLoanDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", mfLoanDetail.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ApprovedLoanAmount", mfLoanDetail.ApprovedLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalLoanAmount", mfLoanDetail.TotalLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriodType", mfLoanDetail.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPeriod", mfLoanDetail.LoanPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GraceDays", mfLoanDetail.GraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalOutstanding", mfLoanDetail.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalInterest", mfLoanDetail.TotalInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPenalty", mfLoanDetail.TotalPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", mfLoanDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FundingAgencyCode", mfLoanDetail.FundingAgencyCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestCalcMethod", mfLoanDetail.InterestCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanStatus", mfLoanDetail.LoanStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalPaid", mfLoanDetail.TotalPrincipalPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalInterestPaid", mfLoanDetail.TotalInterestPaid, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentAmount", mfLoanDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriodType", mfLoanDetail.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriod", mfLoanDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalAmount", mfLoanDetail.PrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YearNo", mfLoanDetail.YearNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfLoanDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfLoanDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfLoanDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", mfLoanDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsurancePolicyNo", mfLoanDetail.InsurancePolicyNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfLoanDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", mfLoanDetail.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedPrincipalAmount", mfLoanDetail.FixedPrincipalAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstInstallDate", mfLoanDetail.FirstInstallDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FirstInstallDateBs", mfLoanDetail.FirstInstallDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCenter", mfLoanDetail.ClientCenter, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedInterestAmount", mfLoanDetail.FixedInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfInstallment", mfLoanDetail.NoOfInstallment, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeName", mfLoanDetail.EmployeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfLoanDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", mfLoanDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfLoanDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductName", mfLoanDetail.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", mfLoanDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GroupName", mfLoanDetail.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", mfLoanDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", mfLoanDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SpouseName", mfLoanDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeDesc", mfLoanDetail.LoanPurposeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDay", mfLoanDetail.CollectionDay, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfLoanDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfLoanDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PeriodType", mfLoanDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterGroup", mfLoanDetail.CenterGroup, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavAcDno", mfLoanDetail.SavAcDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavProdName", mfLoanDetail.SavProdName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfLoanDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanDetail> lst = new List<MfLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanDetail obj = new MfLoanDetail();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.LoanDate = drow["LoanDate"].ToString();
                    obj.LoanDateBs = drow["LoanDateBs"].ToString();
                    obj.SectorDesc = drow["SectorDesc"].ToString();
                    obj.LoanMaturityDate = drow["LoanMaturityDate"].ToString();
                    obj.LoanMatureBs = drow["LoanMatureBs"].ToString();
                    obj.HusbandName = drow["HusbandName"].ToString();
                    obj.FatherInlawName = drow["FatherInlawName"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(drow["ApprovedLoanAmount"].ToString());
                    obj.TotalLoanAmount = double.Parse(drow["TotalLoanAmount"].ToString());
                    obj.LoanPeriodType = drow["LoanPeriodType"].ToString();
                    obj.LoanPeriod = double.Parse(drow["LoanPeriod"].ToString());
                    obj.GraceDays = double.Parse(drow["GraceDays"].ToString());
                    obj.TotalPrincipalOutstanding = double.Parse(drow["TotalPrincipalOutstanding"].ToString());
                    obj.TotalInterest = double.Parse(drow["TotalInterest"].ToString());
                    obj.TotalPenalty = double.Parse(drow["TotalPenalty"].ToString());
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.FundingAgencyCode = drow["FundingAgencyCode"].ToString();
                    obj.InterestCalcMethod = drow["InterestCalcMethod"].ToString();
                    obj.LoanStatus = drow["LoanStatus"].ToString();
                    obj.TotalPrincipalPaid = double.Parse(drow["TotalPrincipalPaid"].ToString());
                    obj.TotalInterestPaid = double.Parse(drow["TotalInterestPaid"].ToString());
                    obj.InstallmentAmount = double.Parse(drow["InstallmentAmount"].ToString());
                    obj.InstallmentPeriodType = drow["InstallmentPeriodType"].ToString();
                    obj.InstallmentPeriod = int.Parse(drow["InstallmentPeriod"].ToString());
                    obj.PrincipalAmount = double.Parse(drow["PrincipalAmount"].ToString());
                    obj.YearNo = double.Parse(drow["YearNo"].ToString());
                    obj.WithdrawalNo = drow["WithdrawalNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.AdjustFromSaving = drow["AdjustFromSaving"].ToString();
                    obj.InsurancePolicyNo = drow["InsurancePolicyNo"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.FixedPrincipalAmount = double.Parse(drow["FixedPrincipalAmount"].ToString());
                    obj.FirstInstallDate = drow["FirstInstallDate"].ToString();
                    obj.FirstInstallDateBs = drow["FirstInstallDateBs"].ToString();
                    obj.ClientCenter = drow["ClientCenter"].ToString();
                    obj.FixedInterestAmount = double.Parse(drow["FixedInterestAmount"].ToString());
                    obj.NoOfInstallment = int.Parse(drow["NoOfInstallment"].ToString());
                    obj.EmployeeName = drow["EmployeeName"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.LoanProductName = drow["LoanProductName"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.GroupName = drow["GroupName"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.NomineeName = drow["NomineeName"].ToString();
                    obj.SpouseName = drow["SpouseName"].ToString();
                    obj.LoanPurposeDesc = drow["LoanPurposeDesc"].ToString();
                    obj.CollectionDay = int.Parse(drow["CollectionDay"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.PeriodType = drow["PeriodType"].ToString();
                    obj.CenterGroup = drow["CenterGroup"].ToString();
                    obj.SavAcDno = drow["SavAcDno"].ToString();
                    obj.SavProdName = drow["SavProdName"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMfLoanDetail(string offCode, string clientName,string loanNo, string loanDateFrom, string loanDateTo)
        {

            string sp = "fn_loan_pkg.p_mf_loan_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", loanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDate", loanDateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDateBs", loanDateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanDetail> lst = new List<MfLoanDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanDetail obj = new MfLoanDetail();
                    obj.FiscalYear = drow["Fiscal_Year"].ToString();
                    obj.LoanNo = drow["Loan_No"].ToString();
                    obj.LoanDno = drow["Loan_Dno"].ToString();
                    obj.LoanDate = drow["Loan_Date"].ToString();
                    obj.LoanDateBs = drow["Loan_Date_Bs"].ToString();
                    obj.SectorDesc = drow["Sector_Desc"].ToString();
                    obj.LoanMaturityDate = drow["Loan_Maturity_Date"].ToString();
                    obj.LoanMatureBs = drow["Loan_Mature_Bs"].ToString();
                    obj.HusbandName = drow["Husband_Name"].ToString();
                    obj.FatherInlawName = drow["Father_Inlaw_Name"].ToString();
                    obj.LoanProductCode = drow["Loan_Product_Code"].ToString();
                    obj.ClientNo = drow["Client_No"].ToString();
                    obj.LoanPurposeCode = drow["Loan_Purpose_Code"].ToString();
                    obj.ApprovedLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Approved_Loan_Amount"].ToString()));
                    obj.TotalLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Loan_Amount"].ToString()));
                    obj.LoanPeriodType = drow["Loan_Period_Type"].ToString();
                    obj.LoanPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Loan_Period"].ToString()));
                    obj.GraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber( drow["Grace_Days"].ToString()));
                    obj.TotalPrincipalOutstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Principal_Outstanding"].ToString()));
                    obj.TotalInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Interest"].ToString()));
                    obj.TotalPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Penalty"].ToString()));
                    obj.EmployeeId = drow["Employee_Id"].ToString();
                    obj.FundingAgencyCode = drow["Funding_Agency_Code"].ToString();
                    obj.InterestCalcMethod = drow["Interest_Calc_Method"].ToString();
                    obj.LoanStatus = drow["Loan_Status"].ToString();
                    obj.TotalPrincipalPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Principal_Paid"].ToString()));
                    obj.TotalInterestPaid = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Interest_Paid"].ToString()));
                    obj.InstallmentAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Installment_Amount"].ToString()));
                    obj.InstallmentPeriodType = drow["Installment_Period_Type"].ToString();
                    obj.InstallmentPeriod = int.Parse(drow["Installment_Period"].ToString());
                    obj.PrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Principal_Amount"].ToString()));
                    obj.YearNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Year_No"].ToString()));
                    obj.WithdrawalNo = drow["Withdrawal_No"].ToString();
                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.AdjustFromSaving = drow["Adjust_From_Saving"].ToString();
                    obj.InsurancePolicyNo = drow["Insurance_Policy_No"].ToString();
                    obj.TranOfficeCode = drow["Tran_Office_Code"].ToString();
                    obj.TransferDate = drow["Transfer_Date"].ToString();
                    obj.FixedPrincipalAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Fixed_Principal_Amount"].ToString()));
                    obj.FirstInstallDate = drow["First_Install_Date"].ToString();
                    obj.FirstInstallDateBs = drow["First_Install_Date_Bs"].ToString();
                    obj.ClientCenter = drow["Client_Center"].ToString();
                    obj.FixedInterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Fixed_Interest_Amount"].ToString()));
                    obj.NoOfInstallment = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["No_Of_Installment"].ToString()));
                    obj.EmployeeName = drow["Employee_Name"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.LoanProductName = drow["Loan_Product_Name"].ToString();
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Interest_Rate"].ToString()));
                    obj.GroupName = drow["Group_Name"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.NomineeName = drow["Nominee_Name"].ToString();
                    obj.SpouseName = drow["Spouse_Name"].ToString();
                    obj.LoanPurposeDesc = drow["Loan_Purpose_Desc"].ToString();
                    obj.CollectionDay = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Collection_Day"].ToString()));
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.AccountDesc = drow["Account_Desc"].ToString();
                    obj.PeriodType = drow["Period_Type"].ToString();
                    obj.CenterGroup = drow["Center_Group"].ToString();
                    obj.SavAcDno = drow["Sav_Ac_Dno"].ToString();
                    obj.SavProdName = drow["Sav_Prod_Name"].ToString();
                    obj.VoucherNo = drow["Voucher_No"].ToString();

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
