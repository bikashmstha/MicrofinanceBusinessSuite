using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OraclePublicAccountChequeAccountDao : IPublicAccountChequeAccountDao
    {
        public object SavePublicAccountChequeAccount(PublicAccountChequeAccount publicAccountChequeAccount)
        {
            string sp = "publicAccountChequeAccount_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicAccountChequeAccount.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicAccountChequeAccount.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", publicAccountChequeAccount.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicAccountChequeAccount.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", publicAccountChequeAccount.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", publicAccountChequeAccount.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicAccountChequeAccount.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECT_AMOUNT", publicAccountChequeAccount.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", publicAccountChequeAccount.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicAccountChequeAccount.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicAccountChequeAccount(PublicAccountChequeAccount publicAccountChequeAccount)
        {
            string sp = "publicAccountChequeAccount_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicAccountChequeAccount.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", publicAccountChequeAccount.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", publicAccountChequeAccount.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicAccountChequeAccount.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", publicAccountChequeAccount.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", publicAccountChequeAccount.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicAccountChequeAccount.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECT_AMOUNT", publicAccountChequeAccount.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", publicAccountChequeAccount.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicAccountChequeAccount> lst = new List<PublicAccountChequeAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicAccountChequeAccount obj = new PublicAccountChequeAccount();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.FixedCollectAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_COLLECT_AMOUNT"].ToString()));
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPubAccCheqAcc(string OfficeCode, string ProductCode, string SavingAccountNo)
        {
            string sp = "fn_saving_utility_pkg.p_pub_acc_cheq_acc_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRODUCT_CODE", ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicAccountChequeAccount> lst = new List<PublicAccountChequeAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicAccountChequeAccount obj = new PublicAccountChequeAccount();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.FixedCollectAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_COLLECT_AMOUNT"].ToString()));
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
