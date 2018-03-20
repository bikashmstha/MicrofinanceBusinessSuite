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
    public class OracleSavingTransferFromAccountDao : ISavingTransferFromAccountDao
    {
        public object SaveSavingTransferFromAccount(SavingTransferFromAccount savingTransferFromAccount)
        {
            string sp = "savingTransferFromAccount_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", savingTransferFromAccount.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", savingTransferFromAccount.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", savingTransferFromAccount.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", savingTransferFromAccount.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", savingTransferFromAccount.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE_BS", savingTransferFromAccount.AccountOpenDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", savingTransferFromAccount.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingTransferFromAccount.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchSavingTransferFromAccount(SavingTransferFromAccount savingTransferFromAccount)
        {
            string sp = "savingTransferFromAccount_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", savingTransferFromAccount.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", savingTransferFromAccount.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE", savingTransferFromAccount.AccountOpenDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", savingTransferFromAccount.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", savingTransferFromAccount.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_OPEN_DATE_BS", savingTransferFromAccount.AccountOpenDate_Bs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", savingTransferFromAccount.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingTransferFromAccount> lst = new List<SavingTransferFromAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingTransferFromAccount obj = new SavingTransferFromAccount();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AccountOpenDate_Bs = drow["ACCOUNT_OPEN_DATE_BS"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetSavTransferFrmAcc(string OfficeCode, string CenterCode, string ClientNo)
        {
            string sp = "fn_loan_utility_pkg.p_sav_transfer_frm_acc_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CENTER_CODE", CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NO", ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingTransferFromAccount> lst = new List<SavingTransferFromAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingTransferFromAccount obj = new SavingTransferFromAccount();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.AccountOpenDate = drow["ACCOUNT_OPEN_DATE"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AccountOpenDate_Bs = drow["ACCOUNT_OPEN_DATE_BS"].ToString();
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
