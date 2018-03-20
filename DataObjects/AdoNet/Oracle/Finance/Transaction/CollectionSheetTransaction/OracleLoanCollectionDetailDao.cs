using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanCollectionDetailDao : ILoanCollectionDetailDao
    {
        public object Get()
        {
            string sp = "loanCollectionDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanCollectionDetail> lst = new List<LoanCollectionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanCollectionDetail obj = new LoanCollectionDetail();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.LoanType = drow["LoanType"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.TotalLoanAmount = int.Parse(drow["TotalLoanAmount"].ToString());
                    obj.TotalPrincipalOutstanding = int.Parse(drow["TotalPrincipalOutstanding"].ToString());
                    obj.PastPrincipalDue = int.Parse(drow["PastPrincipalDue"].ToString());
                    obj.CurrentPrincipalSchedule = int.Parse(drow["CurrentPrincipalSchedule"].ToString());
                    obj.PastInterestDue = int.Parse(drow["PastInterestDue"].ToString());
                    obj.InterestAmount = int.Parse(drow["InterestAmount"].ToString());
                    obj.PenaltyAmount = int.Parse(drow["PenaltyAmount"].ToString());
                    obj.PaidAmount = int.Parse(drow["PaidAmount"].ToString());
                    obj.PrincipalPaidAmount = int.Parse(drow["PrincipalPaidAmount"].ToString());
                    obj.InterestPaidAmount = int.Parse(drow["InterestPaidAmount"].ToString());
                    obj.PenaltyPaidAmount = int.Parse(drow["PenaltyPaidAmount"].ToString());
                    obj.AdjustFromSaving = drow["AdjustFromSaving"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.Received = drow["Received"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.AdjustAmtFrmSaving = int.Parse(drow["AdjustAmtFrmSaving"].ToString());
                    obj.TotalInterestAmount = int.Parse(drow["TotalInterestAmount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LoanCollectionDetail loanCollectionDetail)
        {
            string sp = "loanCollectionDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", loanCollectionDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", loanCollectionDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanType", loanCollectionDetail.LoanType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", loanCollectionDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalLoanAmount", loanCollectionDetail.TotalLoanAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalOutstanding", loanCollectionDetail.TotalPrincipalOutstanding, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastPrincipalDue", loanCollectionDetail.PastPrincipalDue, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentPrincipalSchedule", loanCollectionDetail.CurrentPrincipalSchedule, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastInterestDue", loanCollectionDetail.PastInterestDue, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestAmount", loanCollectionDetail.InterestAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", loanCollectionDetail.PenaltyAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaidAmount", loanCollectionDetail.PaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalPaidAmount", loanCollectionDetail.PrincipalPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestPaidAmount", loanCollectionDetail.InterestPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyPaidAmount", loanCollectionDetail.PenaltyPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", loanCollectionDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", loanCollectionDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Received", loanCollectionDetail.Received, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", loanCollectionDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", loanCollectionDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", loanCollectionDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustAmtFrmSaving", loanCollectionDetail.AdjustAmtFrmSaving, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalInterestAmount", loanCollectionDetail.TotalInterestAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanCollectionDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LoanCollectionDetail loanCollectionDetail)
        {
            string sp = "loanCollectionDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", loanCollectionDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", loanCollectionDetail.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanType", loanCollectionDetail.LoanType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", loanCollectionDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalLoanAmount", loanCollectionDetail.TotalLoanAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalPrincipalOutstanding", loanCollectionDetail.TotalPrincipalOutstanding, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastPrincipalDue", loanCollectionDetail.PastPrincipalDue, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentPrincipalSchedule", loanCollectionDetail.CurrentPrincipalSchedule, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PastInterestDue", loanCollectionDetail.PastInterestDue, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestAmount", loanCollectionDetail.InterestAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", loanCollectionDetail.PenaltyAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PaidAmount", loanCollectionDetail.PaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalPaidAmount", loanCollectionDetail.PrincipalPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestPaidAmount", loanCollectionDetail.InterestPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyPaidAmount", loanCollectionDetail.PenaltyPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", loanCollectionDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", loanCollectionDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Received", loanCollectionDetail.Received, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", loanCollectionDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", loanCollectionDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", loanCollectionDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustAmtFrmSaving", loanCollectionDetail.AdjustAmtFrmSaving, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalInterestAmount", loanCollectionDetail.TotalInterestAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanCollectionDetail> lst = new List<LoanCollectionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanCollectionDetail obj = new LoanCollectionDetail();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.LoanType = drow["LoanType"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.TotalLoanAmount = int.Parse(drow["TotalLoanAmount"].ToString());
                    obj.TotalPrincipalOutstanding = int.Parse(drow["TotalPrincipalOutstanding"].ToString());
                    obj.PastPrincipalDue = int.Parse(drow["PastPrincipalDue"].ToString());
                    obj.CurrentPrincipalSchedule = int.Parse(drow["CurrentPrincipalSchedule"].ToString());
                    obj.PastInterestDue = int.Parse(drow["PastInterestDue"].ToString());
                    obj.InterestAmount = int.Parse(drow["InterestAmount"].ToString());
                    obj.PenaltyAmount = int.Parse(drow["PenaltyAmount"].ToString());
                    obj.PaidAmount = int.Parse(drow["PaidAmount"].ToString());
                    obj.PrincipalPaidAmount = int.Parse(drow["PrincipalPaidAmount"].ToString());
                    obj.InterestPaidAmount = int.Parse(drow["InterestPaidAmount"].ToString());
                    obj.PenaltyPaidAmount = int.Parse(drow["PenaltyPaidAmount"].ToString());
                    obj.AdjustFromSaving = drow["AdjustFromSaving"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.Received = drow["Received"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.AdjustAmtFrmSaving = int.Parse(drow["AdjustAmtFrmSaving"].ToString());
                    obj.TotalInterestAmount = int.Parse(drow["TotalInterestAmount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetCollectionLoanDetail(string centerCode, string collectionSheetNo)
        {
            string sp = "collection_sheet_generate_pkg.p_coll_loan_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_collection_sheet_no", collectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanCollectionDetail> lst = new List<LoanCollectionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanCollectionDetail obj = new LoanCollectionDetail();
                    obj.LoanNo = drow["Loan_No"].ToString();
                    obj.LoanDno = drow["Loan_Dno"].ToString();
                    obj.LoanType = drow["Loan_Type"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.TotalLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Loan_Amount"].ToString()));
                    obj.TotalPrincipalOutstanding = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Principal_Outstanding"].ToString()));
                    obj.PastPrincipalDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Past_Principal_Due"].ToString()));
                    obj.CurrentPrincipalSchedule = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Current_Principal_Schedule"].ToString()));
                    obj.PastInterestDue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Past_Interest_Due"].ToString()));
                    obj.InterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Interest_Amount"].ToString()));
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Penalty_Amount"].ToString()));
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Paid_Amount"].ToString()));
                    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Principal_Paid_Amount"].ToString()));
                    obj.InterestPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Interest_Paid_Amount"].ToString()));
                    obj.PenaltyPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Penalty_Paid_Amount"].ToString()));
                    obj.AdjustFromSaving = drow["Adjust_From_Saving"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.Received = drow["Received"].ToString();
                    obj.ChequeNo = drow["Cheque_No"].ToString();
                    obj.ClientNo = drow["Client_No"].ToString();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.AdjustAmtFrmSaving = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Adjust_Amt_Frm_Saving"].ToString()));
                    obj.TotalInterestAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["Total_Interest_Amount"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object DeleteLoanCollectionSheet(string collectionSheetNo, string user)
        {
            string sp = "collection_sheet_generate_pkg.p_loan_coll_sheet_deletion";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", collectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", user, OracleDbType.Varchar2, ParameterDirection.Input));
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


        public object UpdateLoanCollectionSheet(LoanCollectionDetail loanCollectionDetail)
        {
            string sp = "collection_sheet_generate_pkg.p_update_loan_collection_sht";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", loanCollectionDetail.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanType", loanCollectionDetail.CollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", loanCollectionDetail.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));

                paramList.Add(SqlHelper.GetOraParam(":p_PaidAmount", loanCollectionDetail.PaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrincipalPaidAmount", loanCollectionDetail.PrincipalPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestPaidAmount", loanCollectionDetail.InterestPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyPaidAmount", loanCollectionDetail.PenaltyPaidAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustFromSaving", loanCollectionDetail.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", loanCollectionDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Received", loanCollectionDetail.Received, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", loanCollectionDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AdjustAmtFrmSaving", loanCollectionDetail.AdjustAmtFrmSaving, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", loanCollectionDetail.CreatedBy, OracleDbType.Int32, ParameterDirection.Input));

                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
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
    }
}
