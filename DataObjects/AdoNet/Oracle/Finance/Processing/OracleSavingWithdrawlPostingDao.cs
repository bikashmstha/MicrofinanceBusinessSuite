﻿using System;
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
    public class OracleSavingWithdrawlPostingDao : ISavingWithdrawlPostingDao
    {
        public object SaveSavingWithdrawlPosting(List<SavingWithdrawlPosting> savingWithdrawlPostings)
        {
            string sp = "daily_transaction_pkg.p_saving_withdrawal_posting";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                foreach (SavingWithdrawlPosting savingWithdrawlPosting in savingWithdrawlPostings)
                {
                    paramList = new List<OracleParameter>();
                    paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", savingWithdrawlPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", savingWithdrawlPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", savingWithdrawlPosting.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_USER1", savingWithdrawlPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchSavingWithdrawlPosting(SavingWithdrawlPosting savingWithdrawlPosting)
        {
            string sp = "savingWithdrawlPosting_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", savingWithdrawlPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", savingWithdrawlPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", savingWithdrawlPosting.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", savingWithdrawlPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingWithdrawlPosting> lst = new List<SavingWithdrawlPosting>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingWithdrawlPosting obj = new SavingWithdrawlPosting();
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
