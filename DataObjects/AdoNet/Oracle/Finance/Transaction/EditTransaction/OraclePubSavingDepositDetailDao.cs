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
    public class OraclePubSavingDepositDetailDao : IPubSavingDepositDetailDao
    {
        public object SavePubSavingDepositDetail(PubSavingDepositDetail pubSavingDepositDetail)
        {
            string sp = "pubSavingDepositDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_NO", pubSavingDepositDetail.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AC_OFFICE_CODE", pubSavingDepositDetail.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", pubSavingDepositDetail.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE_BS", pubSavingDepositDetail.DepositDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", pubSavingDepositDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", pubSavingDepositDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_AMOUNT", pubSavingDepositDetail.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_TYPE", pubSavingDepositDetail.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", pubSavingDepositDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUE_DATE", pubSavingDepositDetail.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", pubSavingDepositDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", pubSavingDepositDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", pubSavingDepositDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", pubSavingDepositDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", pubSavingDepositDetail.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", pubSavingDepositDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", pubSavingDepositDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", pubSavingDepositDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", pubSavingDepositDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", pubSavingDepositDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", pubSavingDepositDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_BY", pubSavingDepositDetail.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_SOURCE", pubSavingDepositDetail.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_NO", pubSavingDepositDetail.ChargeVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_DATE", pubSavingDepositDetail.ChargeVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", pubSavingDepositDetail.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", pubSavingDepositDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPubSavingDepositDetail(PubSavingDepositDetail pubSavingDepositDetail)
        {
            string sp = "pubSavingDepositDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_NO", pubSavingDepositDetail.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AC_OFFICE_CODE", pubSavingDepositDetail.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", pubSavingDepositDetail.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE_BS", pubSavingDepositDetail.DepositDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", pubSavingDepositDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", pubSavingDepositDetail.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_AMOUNT", pubSavingDepositDetail.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_TYPE", pubSavingDepositDetail.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", pubSavingDepositDetail.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUE_DATE", pubSavingDepositDetail.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", pubSavingDepositDetail.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", pubSavingDepositDetail.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", pubSavingDepositDetail.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", pubSavingDepositDetail.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", pubSavingDepositDetail.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", pubSavingDepositDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", pubSavingDepositDetail.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", pubSavingDepositDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", pubSavingDepositDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_NO", pubSavingDepositDetail.ContraAcNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", pubSavingDepositDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_BY", pubSavingDepositDetail.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_SOURCE", pubSavingDepositDetail.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_NO", pubSavingDepositDetail.ChargeVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_VOUCHER_DATE", pubSavingDepositDetail.ChargeVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", pubSavingDepositDetail.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PubSavingDepositDetail> lst = new List<PubSavingDepositDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PubSavingDepositDetail obj = new PubSavingDepositDetail();
                    obj.DepositNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_NO"].ToString()));
                    obj.AcOfficeCode = drow["AC_OFFICE_CODE"].ToString();
                    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                    obj.DepositDateBs = drow["DEPOSIT_DATE_BS"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ChargeAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHARGE_AMOUNT"].ToString()));
                    obj.ChargeType = drow["CHARGE_TYPE"].ToString();
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.ValueDate = drow["VALUE_DATE"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CONTRA_AC_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.DepositBy = drow["DEPOSIT_BY"].ToString();
                    obj.ChargeSource = drow["CHARGE_SOURCE"].ToString();
                    obj.ChargeVoucherNo = drow["CHARGE_VOUCHER_NO"].ToString();
                    obj.ChargeVoucherDate = drow["CHARGE_VOUCHER_DATE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetPubSavDepoDetail(string OfficeCode, long? DepositNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            string sp = "fn_saving_utility_pkg.p_pub_sav_depo_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DEPOSIT_NO", DepositNo, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_ACCOUNT_NO", SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PubSavingDepositDetail> lst = new List<PubSavingDepositDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PubSavingDepositDetail obj = new PubSavingDepositDetail();
                    obj.DepositNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_NO"].ToString()));
                    obj.AcOfficeCode = drow["AC_OFFICE_CODE"].ToString();
                    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                    obj.DepositDateBs = drow["DEPOSIT_DATE_BS"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.ChargeAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHARGE_AMOUNT"].ToString()));
                    obj.ChargeType = drow["CHARGE_TYPE"].ToString();
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.ValueDate = drow["VALUE_DATE"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ContraAcNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CONTRA_AC_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.DepositBy = drow["DEPOSIT_BY"].ToString();
                    obj.ChargeSource = drow["CHARGE_SOURCE"].ToString();
                    obj.ChargeVoucherNo = drow["CHARGE_VOUCHER_NO"].ToString();
                    obj.ChargeVoucherDate = drow["CHARGE_VOUCHER_DATE"].ToString();
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
