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
    public class OraclePublicSavingDepositDao : IPublicSavingDepositDao
    {
        public object SavePublicSavingDeposit(PublicSavingDeposit publicSavingDeposit)
        {
            string sp = "fn_public_saving_account_pkg.p_public_saving_deposit";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", publicSavingDeposit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", publicSavingDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingDeposit.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANDATORY_SAVING_TYPE", publicSavingDeposit.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", publicSavingDeposit.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_AMOUNT", publicSavingDeposit.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_TYPE", publicSavingDeposit.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", publicSavingDeposit.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", publicSavingDeposit.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicSavingDeposit.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_BY", publicSavingDeposit.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingDeposit.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AC_OFFICE_CODE", publicSavingDeposit.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUE_DATE", publicSavingDeposit.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_SOURCE", publicSavingDeposit.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", publicSavingDeposit.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_ACCOUNT_NO", publicSavingDeposit.AdjustAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_CHEQUE_NO", publicSavingDeposit.AdjustChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingDeposit.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", publicSavingDeposit.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", publicSavingDeposit.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_PUBLIC_DEPOSIT_NO", publicSavingDeposit.OutPublicDeposit_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicSavingDeposit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicSavingDeposit(PublicSavingDeposit publicSavingDeposit)
        {
            string sp = "publicSavingDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", publicSavingDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", publicSavingDeposit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", publicSavingDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", publicSavingDeposit.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANDATORY_SAVING_TYPE", publicSavingDeposit.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMOUNT", publicSavingDeposit.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_AMOUNT", publicSavingDeposit.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_TYPE", publicSavingDeposit.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", publicSavingDeposit.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", publicSavingDeposit.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", publicSavingDeposit.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_BY", publicSavingDeposit.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", publicSavingDeposit.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AC_OFFICE_CODE", publicSavingDeposit.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALUE_DATE", publicSavingDeposit.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHARGE_SOURCE", publicSavingDeposit.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_FROM_SAVING", publicSavingDeposit.AdjustFromSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_ACCOUNT_NO", publicSavingDeposit.AdjustAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADJUST_CHEQUE_NO", publicSavingDeposit.AdjustChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", publicSavingDeposit.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", publicSavingDeposit.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", publicSavingDeposit.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_PUBLIC_DEPOSIT_NO", publicSavingDeposit.OutPublicDeposit_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicSavingDeposit> lst = new List<PublicSavingDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicSavingDeposit obj = new PublicSavingDeposit();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.MandatorySavingType = drow["MANDATORY_SAVING_TYPE"].ToString();
                    obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMOUNT"].ToString()));
                    obj.ChargeAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHARGE_AMOUNT"].ToString()));
                    obj.ChargeType = drow["CHARGE_TYPE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.DepositBy = drow["DEPOSIT_BY"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.AcOfficeCode = drow["AC_OFFICE_CODE"].ToString();
                    obj.ValueDate = drow["VALUE_DATE"].ToString();
                    obj.ChargeSource = drow["CHARGE_SOURCE"].ToString();
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.AdjustAccountNo = drow["ADJUST_ACCOUNT_NO"].ToString();
                    obj.AdjustChequeNo = drow["ADJUST_CHEQUE_NO"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutPublicDeposit_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_PUBLIC_DEPOSIT_NO"].ToString()));

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
