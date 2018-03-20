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
    public class OracleAccountForDepositDao : IAccountForDepositDao
    {
        public object Get()
        {
            string sp = "accountForDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountForDeposit> lst = new List<AccountForDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountForDeposit obj = new AccountForDeposit();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.FixedCollectAmount = double.Parse(drow["FixedCollectAmount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());
                    obj.PenaltyLateInstallment = double.Parse(drow["PenaltyLateInstallment"].ToString());
                    obj.ClientDesc = drow["ClientDesc"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(AccountForDeposit accountForDeposit)
        {
            string sp = "accountForDeposit_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountForDeposit.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", accountForDeposit.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountForDeposit.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountForDeposit.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", accountForDeposit.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectAmount", accountForDeposit.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountForDeposit.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountForDeposit.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", accountForDeposit.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyLateInstallment", accountForDeposit.PenaltyLateInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientDesc", accountForDeposit.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountForDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountForDeposit.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", accountForDeposit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(AccountForDeposit accountForDeposit)
        {
            string sp = "accountForDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", accountForDeposit.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Address", accountForDeposit.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", accountForDeposit.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", accountForDeposit.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", accountForDeposit.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectAmount", accountForDeposit.FixedCollectAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", accountForDeposit.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", accountForDeposit.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", accountForDeposit.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyLateInstallment", accountForDeposit.PenaltyLateInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientDesc", accountForDeposit.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", accountForDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", accountForDeposit.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountForDeposit> lst = new List<AccountForDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountForDeposit obj = new AccountForDeposit();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.FixedCollectAmount = double.Parse(drow["FixedCollectAmount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());
                    obj.PenaltyLateInstallment = double.Parse(drow["PenaltyLateInstallment"].ToString());
                    obj.ClientDesc = drow["ClientDesc"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAccountForDeposit(string offCode,string productCode, string savingAccountNo, string centerCode)
        {

            string sp = "fn_saving_utility_pkg.p_acc_for_deposit_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_product_code", productCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_saving_account_no", savingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AccountForDeposit> lst = new List<AccountForDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AccountForDeposit obj = new AccountForDeposit();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.ProductCode = drow["Product_Code"].ToString();
                    obj.ProductName = drow["Product_Name"].ToString();
                    obj.ClientNo = drow["Client_No"].ToString();

                    if (!string.IsNullOrEmpty(drow["Fixed_Collect_Amount"].ToString()))
                    obj.FixedCollectAmount = double.Parse(drow["Fixed_Collect_Amount"].ToString());

                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();

                    if (!string.IsNullOrEmpty(drow["Row_Count"].ToString()))
                    obj.RowCount = double.Parse(drow["Row_Count"].ToString());

                    if (!string.IsNullOrEmpty(drow["Penalty_Late_Installment"].ToString()))
                    obj.PenaltyLateInstallment = double.Parse(drow["Penalty_Late_Installment"].ToString());

                    obj.ClientDesc = drow["Client_Desc"].ToString();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();

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
