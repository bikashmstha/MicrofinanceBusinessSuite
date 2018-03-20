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
    public class OracleMfRepayDetailDao : IMfRepayDetailDao
    {
        public object Get()
        {
            string sp = "mfRepayDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfRepayDetail> lst = new List<MfRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfRepayDetail obj = new MfRepayDetail();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.ProductDesc = drow["ProductDesc"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.RepaymentNo = double.Parse(drow["RepaymentNo"].ToString());
                    obj.PaidAmount = double.Parse(drow["PaidAmount"].ToString());
                    obj.PrincipalPaidAmount = double.Parse(drow["PrincipalPaidAmount"].ToString());
                    obj.InterestPaidAmount = double.Parse(drow["InterestPaidAmount"].ToString());
                    obj.PenaltyPaidAmount = double.Parse(drow["PenaltyPaidAmount"].ToString());
                    obj.PaymentDate = drow["PaymentDate"].ToString();
                    obj.PaymentBs = drow["PaymentBs"].ToString();
                    obj.TotalPrincipalOutstanding = double.Parse(drow["TotalPrincipalOutstanding"].ToString());
                    obj.InstallmentAmount = double.Parse(drow["InstallmentAmount"].ToString());
                    obj.PastPrincipalDue = double.Parse(drow["PastPrincipalDue"].ToString());
                    obj.CurrentPrincipalSchedule = double.Parse(drow["CurrentPrincipalSchedule"].ToString());
                    obj.PastInterestDue = double.Parse(drow["PastInterestDue"].ToString());
                    obj.InterestAmount = double.Parse(drow["InterestAmount"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.AdjustFromSaving = drow["AdjustFromSaving"].ToString();
                    obj.EmpName = drow["EmpName"].ToString();
                    obj.AccountNo = int.Parse(drow["AccountNo"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfRepayDetail mfRepayDetail)
        {
            string sp = "mfRepayDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfRepayDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfRepayDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfRepayDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", mfRepayDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductDesc", mfRepayDetail.ProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfRepayDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", mfRepayDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", mfRepayDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RepaymentNo", mfRepayDetail.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaidAmount", mfRepayDetail.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalPaidAmount", mfRepayDetail.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestPaidAmount", mfRepayDetail.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyPaidAmount", mfRepayDetail.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaymentDate", mfRepayDetail.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaymentBs", mfRepayDetail.PaymentBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalOutstanding", mfRepayDetail.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentAmount", mfRepayDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastPrincipalDue", mfRepayDetail.PastPrincipalDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentPrincipalSchedule", mfRepayDetail.CurrentPrincipalSchedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastInterestDue", mfRepayDetail.PastInterestDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestAmount", mfRepayDetail.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", mfRepayDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", mfRepayDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfRepayDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", mfRepayDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", mfRepayDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpName", mfRepayDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfRepayDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfRepayDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfRepayDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfRepayDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfRepayDetail.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfRepayDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfRepayDetail mfRepayDetail)
        {
            string sp = "mfRepayDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfRepayDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfRepayDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfRepayDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", mfRepayDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductDesc", mfRepayDetail.ProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfRepayDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", mfRepayDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", mfRepayDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RepaymentNo", mfRepayDetail.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaidAmount", mfRepayDetail.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalPaidAmount", mfRepayDetail.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestPaidAmount", mfRepayDetail.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyPaidAmount", mfRepayDetail.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaymentDate", mfRepayDetail.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaymentBs", mfRepayDetail.PaymentBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalOutstanding", mfRepayDetail.TotalPrincipalOutstanding, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentAmount", mfRepayDetail.InstallmentAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastPrincipalDue", mfRepayDetail.PastPrincipalDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentPrincipalSchedule", mfRepayDetail.CurrentPrincipalSchedule, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastInterestDue", mfRepayDetail.PastInterestDue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestAmount", mfRepayDetail.InterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", mfRepayDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", mfRepayDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfRepayDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", mfRepayDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", mfRepayDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpName", mfRepayDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfRepayDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfRepayDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfRepayDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfRepayDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfRepayDetail.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfRepayDetail> lst = new List<MfRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfRepayDetail obj = new MfRepayDetail();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.ProductDesc = drow["ProductDesc"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.RepaymentNo = double.Parse(drow["RepaymentNo"].ToString());
                    obj.PaidAmount = double.Parse(drow["PaidAmount"].ToString());
                    obj.PrincipalPaidAmount = double.Parse(drow["PrincipalPaidAmount"].ToString());
                    obj.InterestPaidAmount = double.Parse(drow["InterestPaidAmount"].ToString());
                    obj.PenaltyPaidAmount = double.Parse(drow["PenaltyPaidAmount"].ToString());
                    obj.PaymentDate = drow["PaymentDate"].ToString();
                    obj.PaymentBs = drow["PaymentBs"].ToString();
                    obj.TotalPrincipalOutstanding = double.Parse(drow["TotalPrincipalOutstanding"].ToString());
                    obj.InstallmentAmount = double.Parse(drow["InstallmentAmount"].ToString());
                    obj.PastPrincipalDue = double.Parse(drow["PastPrincipalDue"].ToString());
                    obj.CurrentPrincipalSchedule = double.Parse(drow["CurrentPrincipalSchedule"].ToString());
                    obj.PastInterestDue = double.Parse(drow["PastInterestDue"].ToString());
                    obj.InterestAmount = double.Parse(drow["InterestAmount"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.AdjustFromSaving = drow["AdjustFromSaving"].ToString();
                    obj.EmpName = drow["EmpName"].ToString();
                    obj.AccountNo = int.Parse(drow["AccountNo"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMfRepayDetail(string offCode, string clientName, string loanDno, string repaymentNo, string dateForm, string dateTo)
        {

            string sp = "fn_loan_pkg.p_mf_repay_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_client_name", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_dno", loanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_repayment_no", repaymentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_date_from", dateForm, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_date_to", dateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfRepayDetail> lst = new List<MfRepayDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfRepayDetail obj = new MfRepayDetail();
                    obj.TranOfficeCode = drow["Tran_Office_Code"].ToString();
                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.LoanProductCode = drow["Loan_Product_Code"].ToString();
                    obj.ProductDesc = drow["Product_Desc"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.LoanNo = drow["Loan_No"].ToString();
                    obj.LoanDno = drow["Loan_Dno"].ToString();
                    obj.RepaymentNo = double.Parse(drow["Repayment_No"].ToString());
                    obj.PaidAmount = double.Parse(drow["Paid_Amount"].ToString());
                    obj.PrincipalPaidAmount = double.Parse(drow["Principal_Paid_Amount"].ToString());
                    obj.InterestPaidAmount = double.Parse(drow["Interest_Paid_Amount"].ToString());
                    obj.PenaltyPaidAmount = double.Parse(drow["Penalty_Paid_Amount"].ToString());
                    obj.PaymentDate = drow["Payment_Date"].ToString();
                    obj.PaymentBs = drow["Payment_Bs"].ToString();
                    obj.TotalPrincipalOutstanding = double.Parse(drow["Total_Principal_Outstanding"].ToString());
                    obj.InstallmentAmount = double.Parse(drow["Installment_Amount"].ToString());
                    obj.PastPrincipalDue = double.Parse(drow["Past_Principal_Due"].ToString());
                    obj.CurrentPrincipalSchedule = double.Parse(drow["Current_Principal_Schedule"].ToString());
                    obj.PastInterestDue = double.Parse(drow["Past_Interest_Due"].ToString());
                    obj.InterestAmount = double.Parse(drow["Interest_Amount"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["Penalty_Amount"].ToString());
                    obj.EmployeeId = drow["Employee_Id"].ToString();
                    obj.ContraAccount = drow["Contra_Account"].ToString();
                    obj.ChequeNo = drow["Cheque_No"].ToString();
                    obj.AdjustFromSaving = drow["Adjust_From_Saving"].ToString();
                    obj.EmpName = drow["Emp_Name"].ToString();
                    obj.AccountNo = int.Parse(drow["Account_No"].ToString());
                    obj.AccountDesc = drow["Account_Desc"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.VoucherNo = drow["Voucher_No"].ToString();
                    obj.RowCount = double.Parse(drow["Row_Count"].ToString());

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
