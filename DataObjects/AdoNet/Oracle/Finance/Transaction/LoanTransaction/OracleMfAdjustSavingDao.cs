using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMfAdjustSavingDao : IMfAdjustSavingDao
    {
        public object Get()
        {
            string sp = "mfAdjustSaving_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdjustSaving> lst = new List<MfAdjustSaving>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdjustSaving obj = new MfAdjustSaving();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.SavingAccountHead = drow["SavingAccountHead"].ToString();
                    obj.AacountCode = int.Parse(drow["AacountCode"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
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

        public object Save(MfAdjustSaving mfAdjustSaving)
        {
            string sp = "mfAdjustSaving_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfAdjustSaving.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfAdjustSaving.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", mfAdjustSaving.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountHead", mfAdjustSaving.SavingAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AacountCode", mfAdjustSaving.AacountCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfAdjustSaving.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", mfAdjustSaving.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfAdjustSaving.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfAdjustSaving.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfAdjustSaving mfAdjustSaving)
        {
            string sp = "mfAdjustSaving_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfAdjustSaving.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfAdjustSaving.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", mfAdjustSaving.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountHead", mfAdjustSaving.SavingAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AacountCode", mfAdjustSaving.AacountCode, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfAdjustSaving.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", mfAdjustSaving.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfAdjustSaving.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdjustSaving> lst = new List<MfAdjustSaving>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdjustSaving obj = new MfAdjustSaving();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.SavingAccountHead = drow["SavingAccountHead"].ToString();
                    obj.AacountCode = int.Parse(drow["AacountCode"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMfAdjustSaving(string offCode, string clientNo, string productName)
        {
            
            string sp = "fn_loan_pkg.p_mf_adjust_saving_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", clientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", productName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdjustSaving> lst = new List<MfAdjustSaving>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdjustSaving obj = new MfAdjustSaving();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.ProductName = drow["Product_Name"].ToString();
                    obj.SavingAccountHead = drow["Saving_Account_Head"].ToString();
                    obj.AacountCode = int.Parse(drow["Aacount_Code"].ToString());
                    obj.AccountDesc = drow["Account_Desc"].ToString();
                    obj.CurrentBalance = double.Parse(drow["Current_Balance"].ToString());
                    obj.RowCount = double.Parse(drow["Row_Count"].ToString());

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
