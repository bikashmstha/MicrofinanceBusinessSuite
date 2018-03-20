using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle
{
    public class OracleGlTransactionDetailDao : IGlTransactionDetailDao
    {
        public object SaveGlTransactionDetail(List<GlTransactionDetail> glTransactionDetails, OracleTransaction tran, string voucherNo)
        {
            string sp = "gl_transaction_pkg.p_insert_transaction_detail";
            OutMessage oMsg = new OutMessage();
            foreach (GlTransactionDetail glTransactionDetail in glTransactionDetails)
            {
                try
                {
                    List<OracleParameter> paramList = new List<OracleParameter>();
                    paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", voucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", glTransactionDetail.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_ID", glTransactionDetail.TransactionId, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", glTransactionDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", glTransactionDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", glTransactionDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", glTransactionDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DR_CR_FLAG", glTransactionDetail.DrCrFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", glTransactionDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_CURRENCY_CODE", glTransactionDetail.CurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRAN_TYPE", glTransactionDetail.TranType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DML_TYPE", glTransactionDetail.DmlType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_action", glTransactionDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                    tran.Commit();
                    oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                    
                }
                catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }

            }
            return oMsg;
        }

        public object SearchGlTransactionDetail(GlTransactionDetail glTransactionDetail)
        {
            string sp = "glTransactionDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", glTransactionDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", glTransactionDetail.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_ID", glTransactionDetail.TransactionId, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", glTransactionDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", glTransactionDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PARTICULARS", glTransactionDetail.Particulars, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", glTransactionDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DR_CR_FLAG", glTransactionDetail.DrCrFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", glTransactionDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENCY_CODE", glTransactionDetail.CurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_TYPE", glTransactionDetail.TranType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DML_TYPE", glTransactionDetail.DmlType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GlTransactionDetail> lst = new List<GlTransactionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GlTransactionDetail obj = new GlTransactionDetail();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.TransactionId = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_ID"].ToString()));
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.Particulars = drow["PARTICULARS"].ToString();
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));
                    obj.DrCrFlag = drow["DR_CR_FLAG"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.CurrencyCode = drow["CURRENCY_CODE"].ToString();
                    obj.TranType = drow["TRAN_TYPE"].ToString();
                    obj.DmlType = drow["DML_TYPE"].ToString();

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
