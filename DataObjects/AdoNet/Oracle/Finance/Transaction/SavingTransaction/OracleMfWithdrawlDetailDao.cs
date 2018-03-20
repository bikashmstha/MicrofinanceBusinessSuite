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
    public class OracleMfWithdrawlDetailDao : IMfWithdrawlDetailDao
    {
        public object Get()
        {
            string sp = "mfWithDrawlDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfWithdrawlDetail> lst = new List<MfWithdrawlDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfWithdrawlDetail obj = new MfWithdrawlDetail();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.SavingProductCode = drow["SavingProductCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.AccountStatus = drow["AccountStatus"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawDateBs = drow["WithdrawDateBs"].ToString();
                    obj.WithdrawType = drow["WithdrawType"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ImagePath = drow["ImagePath"].ToString();
                    obj.JointImagePath = drow["JointImagePath"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.WithdrawLimit = double.Parse(drow["WithdrawLimit"].ToString());
                    obj.AccountOperationType = drow["AccountOperationType"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.Signature1Path = drow["Signature1Path"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfWithdrawlDetail mfWithDrawlDetail)
        {
            string sp = "mfWithDrawlDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", mfWithDrawlDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfWithDrawlDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfWithDrawlDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", mfWithDrawlDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", mfWithDrawlDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductCode", mfWithDrawlDetail.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfWithDrawlDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", mfWithDrawlDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", mfWithDrawlDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", mfWithDrawlDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfWithDrawlDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", mfWithDrawlDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountStatus", mfWithDrawlDetail.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfWithDrawlDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfWithDrawlDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", mfWithDrawlDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", mfWithDrawlDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", mfWithDrawlDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawType", mfWithDrawlDetail.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfWithDrawlDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", mfWithDrawlDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JointImagePath", mfWithDrawlDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfWithDrawlDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawLimit", mfWithDrawlDetail.WithdrawLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOperationType", mfWithDrawlDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfWithDrawlDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfWithDrawlDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfWithDrawlDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Signature1Path", mfWithDrawlDetail.Signature1Path, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfWithDrawlDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfWithdrawlDetail mfWithDrawlDetail)
        {
            string sp = "mfWithDrawlDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", mfWithDrawlDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfWithDrawlDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfWithDrawlDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", mfWithDrawlDetail.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", mfWithDrawlDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductCode", mfWithDrawlDetail.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", mfWithDrawlDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", mfWithDrawlDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", mfWithDrawlDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAcNo", mfWithDrawlDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountDesc", mfWithDrawlDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", mfWithDrawlDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountStatus", mfWithDrawlDetail.AccountStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", mfWithDrawlDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfWithDrawlDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", mfWithDrawlDetail.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", mfWithDrawlDetail.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDateBs", mfWithDrawlDetail.WithdrawDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawType", mfWithDrawlDetail.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfWithDrawlDetail.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", mfWithDrawlDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JointImagePath", mfWithDrawlDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", mfWithDrawlDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawLimit", mfWithDrawlDetail.WithdrawLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountOperationType", mfWithDrawlDetail.AccountOperationType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfWithDrawlDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", mfWithDrawlDetail.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", mfWithDrawlDetail.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Signature1Path", mfWithDrawlDetail.Signature1Path, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfWithdrawlDetail> lst = new List<MfWithdrawlDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfWithdrawlDetail obj = new MfWithdrawlDetail();
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.SavingProductCode = drow["SavingProductCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ContraAcNo = int.Parse(drow["ContraAcNo"].ToString());
                    obj.AccountDesc = drow["AccountDesc"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.AccountStatus = drow["AccountStatus"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawDateBs = drow["WithdrawDateBs"].ToString();
                    obj.WithdrawType = drow["WithdrawType"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.ImagePath = drow["ImagePath"].ToString();
                    obj.JointImagePath = drow["JointImagePath"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.WithdrawLimit = double.Parse(drow["WithdrawLimit"].ToString());
                    obj.AccountOperationType = drow["AccountOperationType"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.Signature1Path = drow["Signature1Path"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMfWithdrawDetail( string offCode, long? withdrawlNo, string savingAccountNo, string clientName, string fromDate, string toDate)
        {

            string sp = "fn_saving_utility_pkg.p_mf_withdraw_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", withdrawlNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", savingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", fromDate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductCode", toDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfWithdrawlDetail> lst = new List<MfWithdrawlDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfWithdrawlDetail obj = new MfWithdrawlDetail();
                    obj.ChequeNo = drow["Cheque_No"].ToString();
                    obj.ContraAccount = drow["Contra_Account"].ToString();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.PayeeName = drow["Payee_Name"].ToString();
                    obj.PenaltyAmount = double.Parse(drow["Penalty_Amount"].ToString());
                    obj.SavingProductCode = drow["Saving_Product_Code"].ToString();
                    obj.ClientNo = drow["Client_No"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ProductName = drow["Product_Name"].ToString();
                    obj.ContraAcNo = int.Parse(drow["Contra_Ac_No"].ToString());
                    obj.AccountDesc = drow["Account_Desc"].ToString();
                    obj.CurrentBalance = double.Parse(drow["Current_Balance"].ToString());
                    obj.AccountStatus = drow["Account_Status"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.TranOfficeCode = drow["Tran_Office_Code"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["Withdraw_Amount"].ToString());
                    obj.WithdrawDate = drow["Withdraw_Date"].ToString();
                    obj.WithdrawDateBs = drow["Withdraw_Date_Bs"].ToString();
                    obj.WithdrawType = drow["Withdraw_Type"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["Withdrawal_No"].ToString());
                    obj.ImagePath = drow["Image_Path"].ToString();
                    obj.JointImagePath = drow["Joint_Image_Path"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.WithdrawLimit = double.Parse(drow["Withdraw_Limit"].ToString());
                    obj.AccountOperationType = drow["Account_Operation_Type"].ToString();
                    obj.VoucherNo = drow["Voucher_No"].ToString();
                    obj.CenterCode = drow["Center_Code"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.Signature1Path = drow["Signature1_Path"].ToString();

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
