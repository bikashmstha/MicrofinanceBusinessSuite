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
    public class OracleLnUtilizationLoanDao : ILnUtilizationLoanDao
    {
        public object Get()
        {
            string sp = "lnUtilizationLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LnUtilizationLoan> lst = new List<LnUtilizationLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LnUtilizationLoan obj = new LnUtilizationLoan();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.LoanPurpose = drow["LOAN_PURPOSE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
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

        public object Save(LnUtilizationLoan lnUtilizationLoan)
        {
            string sp = "lnUtilizationLoan_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", lnUtilizationLoan.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lnUtilizationLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lnUtilizationLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", lnUtilizationLoan.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", lnUtilizationLoan.LoanDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", lnUtilizationLoan.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", lnUtilizationLoan.LoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE", lnUtilizationLoan.LoanPurpose, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", lnUtilizationLoan.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", lnUtilizationLoan.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", lnUtilizationLoan.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", lnUtilizationLoan.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LnUtilizationLoan lnUtilizationLoan)
        {
            string sp = "lnUtilizationLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", lnUtilizationLoan.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lnUtilizationLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lnUtilizationLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", lnUtilizationLoan.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE_BS", lnUtilizationLoan.LoanDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_LOAN_AMOUNT", lnUtilizationLoan.TotalLoan_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE_CODE", lnUtilizationLoan.LoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PURPOSE", lnUtilizationLoan.LoanPurpose, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", lnUtilizationLoan.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", lnUtilizationLoan.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", lnUtilizationLoan.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LnUtilizationLoan> lst = new List<LnUtilizationLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LnUtilizationLoan obj = new LnUtilizationLoan();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.LoanPurpose = drow["LOAN_PURPOSE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLnUtilizationLoan(string CenterCode, string ClientName)
        {
            string sp = "fn_loan_utility_pkg.p_ln_utilization_loan_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_CENTER_CODE", CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LnUtilizationLoan> lst = new List<LnUtilizationLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LnUtilizationLoan obj = new LnUtilizationLoan();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.LoanDate_Bs = drow["LOAN_DATE_BS"].ToString();
                    obj.TotalLoan_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_LOAN_AMOUNT"].ToString()));
                    obj.LoanPurpose_Code = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.LoanPurpose = drow["LOAN_PURPOSE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
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
