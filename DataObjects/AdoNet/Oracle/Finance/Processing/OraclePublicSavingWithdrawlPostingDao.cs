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
    public class OraclePublicSavingWithdrawlPostingDao : IPublicSavingWithdrawlPostingDao
    {
        public object SavePublicSavingWithdrawlPosting(PublicSavingWithdrawlPosting publicSavingWithdrawlPosting)
        {
            string sp = "daily_transaction_pkg.p_pub_sav_withdrawal_posting";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", publicSavingWithdrawlPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", publicSavingWithdrawlPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicSavingWithdrawlPosting.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingWithdrawlPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
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
        public object SearchPublicSavingWithdrawlPosting(PublicSavingWithdrawlPosting publicSavingWithdrawlPosting)
        {
            string sp = "publicSavingWithdrawlPosting_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", publicSavingWithdrawlPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", publicSavingWithdrawlPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicSavingWithdrawlPosting.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingWithdrawlPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingWithdrawlPosting> lst = new List<PublicSavingWithdrawlPosting>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingWithdrawlPosting obj = new PublicSavingWithdrawlPosting();
                    obj.OfficeCode = drow["OFFICE_CODE"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
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
