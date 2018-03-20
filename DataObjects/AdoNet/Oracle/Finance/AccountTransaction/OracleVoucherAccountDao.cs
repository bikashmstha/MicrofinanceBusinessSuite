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
    public class OracleVoucherAccountDao : IVoucherAccountDao
    {
        public object SaveVoucherAccount(VoucherAccount voucherAccount)
        {
            string sp = "voucherAccount_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", voucherAccount.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", voucherAccount.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", voucherAccount.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENCY_CODE", voucherAccount.CurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GROUP_NAME", voucherAccount.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", voucherAccount.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", voucherAccount.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchVoucherAccount(VoucherAccount voucherAccount)
        {
            string sp = "voucherAccount_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", voucherAccount.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", voucherAccount.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", voucherAccount.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENCY_CODE", voucherAccount.CurrencyCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GROUP_NAME", voucherAccount.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", voucherAccount.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<VoucherAccount> lst = new List<VoucherAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    VoucherAccount obj = new VoucherAccount();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.CurrencyCode = drow["CURRENCY_CODE"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetVoucherAcc(string OfficeCode, string AccountDesc)
        {
            string sp = "gl_voucher_utility_pkg.p_voucher_acc_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_ACCOUNT_DESC", AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<VoucherAccount> lst = new List<VoucherAccount>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    VoucherAccount obj = new VoucherAccount();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.AccountNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.CurrencyCode = drow["CURRENCY_CODE"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
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
