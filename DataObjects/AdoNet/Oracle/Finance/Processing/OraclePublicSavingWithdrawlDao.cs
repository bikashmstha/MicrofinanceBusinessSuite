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
    public class OraclePublicSavingWithdrawlDao : IPublicSavingWithdrawlDao
    {
        public object SavePublicSavingWithdrawl(PublicSavingWithdrawl publicSavingWithdrawl)
        {
            string sp = "publicSavingWithdrawl_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicSavingWithdrawl.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", publicSavingWithdrawl.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicSavingWithdrawl.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicSavingWithdrawl.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingWithdrawl.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicSavingWithdrawl.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicSavingWithdrawl.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicSavingWithdrawl.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicSavingWithdrawl.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FLAG_FOR_POSTING", publicSavingWithdrawl.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicSavingWithdrawl.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicSavingWithdrawl(PublicSavingWithdrawl publicSavingWithdrawl)
        {
            string sp = "publicSavingWithdrawl_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicSavingWithdrawl.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", publicSavingWithdrawl.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAWAL_NO", publicSavingWithdrawl.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicSavingWithdrawl.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingWithdrawl.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WITHDRAW_AMOUNT", publicSavingWithdrawl.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", publicSavingWithdrawl.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", publicSavingWithdrawl.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYEE_NAME", publicSavingWithdrawl.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FLAG_FOR_POSTING", publicSavingWithdrawl.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingWithdrawl> lst = new List<PublicSavingWithdrawl>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingWithdrawl obj = new PublicSavingWithdrawl();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
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

        public object GetPubSavingWithdrawal(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_pub_saving_withdrawal_list";
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
                List<PublicSavingWithdrawl> lst = new List<PublicSavingWithdrawl>();
                for (int i = 0; i < 10; i++)
                {

                    PublicSavingWithdrawl obj = new PublicSavingWithdrawl();
                    obj.ClientCode = i.ToString();
                    obj.ClientName = i.ToString();
                    obj.WithdrawalNo = i;
                    obj.SavingAccountNo = i.ToString();
                    obj.AccountNo = i.ToString();
                    obj.WithdrawAmount = i;
                    obj.ChequeNo = i.ToString();
                    obj.AccountDesc = i.ToString();
                    obj.PayeeName = i.ToString();
                    obj.FlagForPosting = i.ToString();
                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    PublicSavingWithdrawl obj = new PublicSavingWithdrawl();
                //    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                //    obj.ClientName = drow["CLIENT_NAME"].ToString();
                //    obj.WithdrawalNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAWAL_NO"].ToString()));
                //    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                //    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                //    obj.WithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["WITHDRAW_AMOUNT"].ToString()));
                //    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                //    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                //    obj.PayeeName = drow["PAYEE_NAME"].ToString();
                //    obj.FlagForPosting = drow["FLAG_FOR_POSTING"].ToString();

                //    lst.Add(obj);
                //}
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
