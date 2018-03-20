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
    public class OracleSavingWithdrawlDao : ISavingWithdrawlDao
    {
        public object SaveSavingWithdrawl(SavingWithdrawl savingWithdrawl)
        {
            string sp = "savingWithdrawl_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", savingWithdrawl.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", savingWithdrawl.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", savingWithdrawl.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", savingWithdrawl.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", savingWithdrawl.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", savingWithdrawl.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", savingWithdrawl.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", savingWithdrawl.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FLAG_FOR_POSTING", savingWithdrawl.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingWithdrawl.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchSavingWithdrawl(SavingWithdrawl savingWithdrawl)
        {
            string sp = "savingWithdrawl_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", savingWithdrawl.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", savingWithdrawl.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", savingWithdrawl.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", savingWithdrawl.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", savingWithdrawl.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", savingWithdrawl.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", savingWithdrawl.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", savingWithdrawl.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FLAG_FOR_POSTING", savingWithdrawl.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingWithdrawl> lst = new List<SavingWithdrawl>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingWithdrawl obj = new SavingWithdrawl();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.FlagForPosting = drow["FLAG_FOR_POSTING"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetSavingWithdrawal(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_saving_withdrawal_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER_CODE", UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingWithdrawl> lst = new List<SavingWithdrawl>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingWithdrawl obj = new SavingWithdrawl();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                    obj.FlagForPosting = drow["FLAG_FOR_POSTING"].ToString();

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
