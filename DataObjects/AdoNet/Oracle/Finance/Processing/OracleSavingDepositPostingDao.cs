using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleSavingDepositPostingDao : ISavingDepositPostingDao
    {
        public object SaveSavingDepositPosting(List<SavingDepositPosting> savingDepositPostings)
        {
            string sp = "daily_transaction_pkg.p_saving_deposit_posting";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();

                foreach (SavingDepositPosting savingDepositPosting in savingDepositPostings)
                {
                    paramList = new List<OracleParameter>();
                    paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", savingDepositPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", savingDepositPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_NO", savingDepositPosting.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_USER1", savingDepositPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());


                }
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchSavingDepositPosting(SavingDepositPosting savingDepositPosting)
        {
            string sp = "savingDepositPosting_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", savingDepositPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", savingDepositPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_NO", savingDepositPosting.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", savingDepositPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingDepositPosting> lst = new List<SavingDepositPosting>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingDepositPosting obj = new SavingDepositPosting();
                    obj.OfficeCode = drow["OFFICE_CODE"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.DepositNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_NO"].ToString()));
                    obj.User1 = drow["USER1"].ToString();

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
