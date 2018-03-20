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
    public class OracleChequeGenerateDetailDao : IChequeGenerateDetailDao
    {
        public object Get()
        {
            string sp = "chequeGenerateDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ChequeGenerateDetail> lst = new List<ChequeGenerateDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ChequeGenerateDetail obj = new ChequeGenerateDetail();
                    obj.Status = drow["Status"].ToString();
                    obj.ReasonForCancel = drow["ReasonForCancel"].ToString();
                    obj.StatusValue = drow["StatusValue"].ToString();
                    obj.PrintedByOn = drow["PrintedByOn"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.DisplayNo = drow["DisplayNo"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(ChequeGenerateDetail chequeGenerateDetail)
        {
            string sp = "chequeGenerateDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_Status", chequeGenerateDetail.Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForCancel", chequeGenerateDetail.ReasonForCancel, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_StatusValue", chequeGenerateDetail.StatusValue, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrintedByOn", chequeGenerateDetail.PrintedByOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", chequeGenerateDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DisplayNo", chequeGenerateDetail.DisplayNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", chequeGenerateDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", chequeGenerateDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(ChequeGenerateDetail chequeGenerateDetail)
        {
            string sp = "chequeGenerateDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_Status", chequeGenerateDetail.Status, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForCancel", chequeGenerateDetail.ReasonForCancel, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_StatusValue", chequeGenerateDetail.StatusValue, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrintedByOn", chequeGenerateDetail.PrintedByOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", chequeGenerateDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DisplayNo", chequeGenerateDetail.DisplayNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", chequeGenerateDetail.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ChequeGenerateDetail> lst = new List<ChequeGenerateDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ChequeGenerateDetail obj = new ChequeGenerateDetail();
                    obj.Status = drow["Status"].ToString();
                    obj.ReasonForCancel = drow["ReasonForCancel"].ToString();
                    obj.StatusValue = drow["StatusValue"].ToString();
                    obj.PrintedByOn = drow["PrintedByOn"].ToString();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.DisplayNo = drow["DisplayNo"].ToString();
                    obj.ChequeNo = drow["ChequeNo"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetChequeGenerateDetail(string offCode, string accountNo)
        {
            string sp = "fn_saving_utility_pkg.p_cheque_generate_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_Status", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForCancel", accountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ChequeGenerateDetail> lst = new List<ChequeGenerateDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ChequeGenerateDetail obj = new ChequeGenerateDetail();
                    obj.Status = drow["Status"].ToString();
                    obj.ReasonForCancel = drow["Reason_For_Cancel"].ToString();
                    obj.StatusValue = drow["Status_Value"].ToString();
                    obj.PrintedByOn = drow["Printed_By_On"].ToString();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.DisplayNo = drow["Display_No"].ToString();
                    obj.ChequeNo = drow["Cheque_No"].ToString();

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
