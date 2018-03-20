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
    public class OracleMfDepositDetailDao : IMfDepositDetailDao
    {
        public object Get()
        {
            string sp = "mFDepositDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfDepositDetail> lst = new List<MfDepositDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfDepositDetail obj = new MfDepositDetail();
                    obj.DepositNo = double.Parse(drow["DepositNo"].ToString());
                    obj.DepositDate = drow["DepositDate"].ToString();
                    obj.DepositDateBs = drow["DepositDateBs"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.MandatorySavingType = drow["MandatorySavingType"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.DepositAmount = double.Parse(drow["DepositAmount"].ToString());
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.DepositBy = drow["DepositBy"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfDepositDetail mFDepositDetail)
        {
            string sp = "mFDepositDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DepositNo", mFDepositDetail.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDate", mFDepositDetail.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDateBs", mFDepositDetail.DepositDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", mFDepositDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mFDepositDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MandatorySavingType", mFDepositDetail.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mFDepositDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mFDepositDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mFDepositDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", mFDepositDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mFDepositDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositAmount", mFDepositDetail.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", mFDepositDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mFDepositDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", mFDepositDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", mFDepositDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", mFDepositDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mFDepositDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mFDepositDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositBy", mFDepositDetail.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mFDepositDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfDepositDetail mFDepositDetail)
        {
            string sp = "mFDepositDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DepositNo", mFDepositDetail.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDate", mFDepositDetail.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDateBs", mFDepositDetail.DepositDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", mFDepositDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mFDepositDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MandatorySavingType", mFDepositDetail.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mFDepositDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mFDepositDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mFDepositDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", mFDepositDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mFDepositDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositAmount", mFDepositDetail.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", mFDepositDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mFDepositDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", mFDepositDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", mFDepositDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", mFDepositDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mFDepositDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mFDepositDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositBy", mFDepositDetail.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfDepositDetail> lst = new List<MfDepositDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfDepositDetail obj = new MfDepositDetail();
                    obj.DepositNo = double.Parse(drow["DepositNo"].ToString());
                    obj.DepositDate = drow["DepositDate"].ToString();
                    obj.DepositDateBs = drow["DepositDateBs"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.MandatorySavingType = drow["MandatorySavingType"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.DepositAmount = double.Parse(drow["DepositAmount"].ToString());
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.DepositBy = drow["DepositBy"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetMfDepositDetail(string offCode, long? depositNo, string savingAccountNo, string clientName, string fromDate, string toDate)
        {

            string sp = "fn_saving_utility_pkg.p_mf_deposit_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DepositNo", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDate", depositNo, OracleDbType.Int16, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDateBs", savingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", fromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MandatorySavingType", toDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfDepositDetail> lst = new List<MfDepositDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfDepositDetail obj = new MfDepositDetail();
                    obj.DepositNo = double.Parse(drow["Deposit_No"].ToString());
                    obj.DepositDate = drow["Deposit_Date"].ToString();
                    obj.DepositDateBs = drow["Deposit_Date_Bs"].ToString();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.MandatorySavingType = drow["Mandatory_Saving_Type"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.ContraAccount = drow["Contra_Account"].ToString();
                    obj.CurrentBalance = double.Parse(drow["Current_Balance"].ToString());
                    obj.AccountDesc = drow["Account_Desc"].ToString();
                    obj.DepositAmount = double.Parse(drow["Deposit_Amount"].ToString());
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.VoucherNo = drow["Voucher_No"].ToString();
                    obj.ProductCode = drow["Product_Code"].ToString();
                    obj.ProductName = drow["Product_Name"].ToString();
                    obj.ContraAcNo = int.Parse(drow["Contra_Ac_No"].ToString());
                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.DepositBy = drow["Deposit_By"].ToString();

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
