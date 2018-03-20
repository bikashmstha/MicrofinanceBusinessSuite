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
    public class OracleMfLoanSearchDao : IMfLoanSearchDao
    {
        public object Get()
        {
            string sp = "mfLoanSearch_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanSearch> lst = new List<MfLoanSearch>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanSearch obj = new MfLoanSearch();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfLoanSearch mfLoanSearch)
        {
            string sp = "mfLoanSearch_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", mfLoanSearch.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", mfLoanSearch.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfLoanSearch.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfLoanSearch.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfLoanSearch.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfLoanSearch.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfLoanSearch.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfLoanSearch.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfLoanSearch mfLoanSearch)
        {
            string sp = "mfLoanSearch_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanDno", mfLoanSearch.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanNo", mfLoanSearch.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfLoanSearch.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfLoanSearch.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfLoanSearch.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfLoanSearch.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfLoanSearch.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanSearch> lst = new List<MfLoanSearch>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanSearch obj = new MfLoanSearch();
                    obj.LoanDno = drow["LoanDno"].ToString();
                    obj.LoanNo = drow["LoanNo"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMfLoanSearch(string offCode, string loanDno)
        {
            string sp = "fn_loan_pkg.p_mf_loan_search_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_dno", loanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanSearch> lst = new List<MfLoanSearch>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanSearch obj = new MfLoanSearch();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.RowCount = double.Parse(drow["ROW_COUNT"].ToString());
                    obj.CenterName = drow["Center_Name"].ToString();
                    //obj.LoanDno = drow["Loan_Dno"].ToString();
                    obj.LoanNo = drow["Loan_No"].ToString();
                    //obj.CenterCode = drow["Center_Code"].ToString();

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
