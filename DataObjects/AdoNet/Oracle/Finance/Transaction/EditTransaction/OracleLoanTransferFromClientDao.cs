using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanTransferFromClientDao : ILoanTransferFromClientDao
    {
        public object SaveLoanTransferFromClient(LoanTransferFromClient loanTransferFromClient)
        {
            string sp = "loanTransferFromClient_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", loanTransferFromClient.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", loanTransferFromClient.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", loanTransferFromClient.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", loanTransferFromClient.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanTransferFromClient.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchLoanTransferFromClient(LoanTransferFromClient loanTransferFromClient)
        {
            string sp = "loanTransferFromClient_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", loanTransferFromClient.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", loanTransferFromClient.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", loanTransferFromClient.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", loanTransferFromClient.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanTransferFromClient> lst = new List<LoanTransferFromClient>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanTransferFromClient obj = new LoanTransferFromClient();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanTransferFrmClient(string OfficeCode, string CenterCode, string ClientName)
        {
            string sp = "fn_loan_utility_pkg.p_loan_transfer_frm_client_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CENTER_CODE", CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanTransferFromClient> lst = new List<LoanTransferFromClient>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanTransferFromClient obj = new LoanTransferFromClient();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
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
