using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;
namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleAccountForWithdrawlDao : IAccountForWithdrawlDao
    {
        public object Get()
        {
            string sp = "accountForWithdrawl_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountForWithdrawl> lst = new List<AccountForWithdrawl>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountForWithdrawl obj = new AccountForWithdrawl();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientDesc = drow["ClientDesc"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.FixedCollectAmount = double.Parse(drow["FixedCollectAmount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(AccountForWithdrawl accountForWithdrawl)
        {
            string sp = "accountForWithdrawl_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountForWithdrawl.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountForWithdrawl.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientDesc", accountForWithdrawl.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", accountForWithdrawl.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountForWithdrawl.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountForWithdrawl.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", accountForWithdrawl.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountForWithdrawl.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectAmount", accountForWithdrawl.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountForWithdrawl.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountForWithdrawl.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", accountForWithdrawl.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", accountForWithdrawl.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(AccountForWithdrawl accountForWithdrawl)
        {
            string sp = "accountForWithdrawl_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountForWithdrawl.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountForWithdrawl.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientDesc", accountForWithdrawl.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", accountForWithdrawl.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountForWithdrawl.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountForWithdrawl.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", accountForWithdrawl.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountForWithdrawl.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectAmount", accountForWithdrawl.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountForWithdrawl.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountForWithdrawl.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", accountForWithdrawl.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountForWithdrawl> lst = new List<AccountForWithdrawl>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountForWithdrawl obj = new AccountForWithdrawl();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientDesc = drow["ClientDesc"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.FixedCollectAmount = double.Parse(drow["FixedCollectAmount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAccountForWithdrawl( string offCode, string productCode, string savingAccountNo, string centerCode)
        {
            string sp = "fn_saving_utility_pkg.p_acc_for_withdraw_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {

                 
 
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", productCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientDesc", savingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountForWithdrawl> lst = new List<AccountForWithdrawl>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountForWithdrawl obj = new AccountForWithdrawl();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.ClientDesc = drow["Client_Desc"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.ProductCode = drow["Product_Code"].ToString();
                    obj.ProductName = drow["Product_Name"].ToString();
                    obj.ClientNo = drow["Client_No"].ToString();
                    obj.AccountNo = drow["Account_No"].ToString();

                    if (!string.IsNullOrEmpty(drow["Fixed_Collect_Amount"].ToString()))
                        obj.FixedCollectAmount = double.Parse(drow["Fixed_Collect_Amount"].ToString());

                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();

                    if (!string.IsNullOrEmpty(drow["Row_Count"].ToString()))
                        obj.RowCount = double.Parse(drow["Row_Count"].ToString());

                    if (!string.IsNullOrEmpty(drow["WITHDRAW_LIMIT"].ToString()))
                        obj.WithdrawLimit = double.Parse(drow["WITHDRAW_LIMIT"].ToString());

                    if (!string.IsNullOrEmpty(drow["CURRENT_BALANCE"].ToString()))
                        obj.CurrentBalance = double.Parse(drow["CURRENT_BALANCE"].ToString());



                    lst.Add(obj);

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
