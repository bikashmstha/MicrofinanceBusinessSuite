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
    public class OracleTransferLoanAccountDao : ITransferLoanAccountDao
    {
        public object SaveTransferLoanAccount(TransferLoanAccount transferLoanAccount)
        {
            string sp = "fn_loan_saving_transfer_pkg.p_transfer_loan_account";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_CENTER_CODE", transferLoanAccount.FromCenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_CLIENT_NO", transferLoanAccount.FromClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_LOAN_PRODUCT", transferLoanAccount.FromLoanProduct, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_LOAN_NO", transferLoanAccount.FromLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_CENTER_CODE", transferLoanAccount.ToCenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_CLIENT_NO", transferLoanAccount.ToClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_LOAN_PRODUCT", transferLoanAccount.ToLoanProduct, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_LOAN_PURPOSE_CODE", transferLoanAccount.ToLoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MODIFIED_ON", transferLoanAccount.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MODIFIED_BY", transferLoanAccount.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", transferLoanAccount.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_TO_LOAN_NO", transferLoanAccount.OutToLoan_No, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchTransferLoanAccount(TransferLoanAccount transferLoanAccount)
        {
            string sp = "transferLoanAccount_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_CENTER_CODE", transferLoanAccount.FromCenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_CLIENT_NO", transferLoanAccount.FromClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_LOAN_PRODUCT", transferLoanAccount.FromLoanProduct, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_LOAN_NO", transferLoanAccount.FromLoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_CENTER_CODE", transferLoanAccount.ToCenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_CLIENT_NO", transferLoanAccount.ToClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_LOAN_PRODUCT", transferLoanAccount.ToLoanProduct, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_LOAN_PURPOSE_CODE", transferLoanAccount.ToLoanPurpose_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MODIFIED_ON", transferLoanAccount.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MODIFIED_BY", transferLoanAccount.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", transferLoanAccount.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_TO_LOAN_NO", transferLoanAccount.OutToLoan_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<TransferLoanAccount> lst = new List<TransferLoanAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    TransferLoanAccount obj = new TransferLoanAccount();
                    obj.FromCenterCode = drow["FROM_CENTER_CODE"].ToString();
                    obj.FromClientNo = drow["FROM_CLIENT_NO"].ToString();
                    obj.FromLoanProduct = drow["FROM_LOAN_PRODUCT"].ToString();
                    obj.FromLoanNo = drow["FROM_LOAN_NO"].ToString();
                    obj.ToCenterCode = drow["TO_CENTER_CODE"].ToString();
                    obj.ToClientNo = drow["TO_CLIENT_NO"].ToString();
                    obj.ToLoanProduct = drow["TO_LOAN_PRODUCT"].ToString();
                    obj.ToLoanPurpose_Code = drow["TO_LOAN_PURPOSE_CODE"].ToString();
                    obj.ModifiedOn = drow["MODIFIED_ON"].ToString();
                    obj.ModifiedBy = drow["MODIFIED_BY"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.OutToLoan_No = drow["OUT_TO_LOAN_NO"].ToString();

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
