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

    public class OracleMfSavingDepositEditDao : IMfSavingDepositEditDao
    {
        public object Get()
        {
            string sp = "mfSavingDepositEdit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfSavingDepositEdit> lst = new List<MfSavingDepositEdit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfSavingDepositEdit obj = new MfSavingDepositEdit();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.MandatorySaving_Type = drow["MANDATORY_SAVING_TYPE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.DepositBy = drow["DEPOSIT_BY"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscal_Year = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutMf_Deposit_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_MF_DEPOSIT_NO"].ToString()));

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfSavingDepositEdit mfSavingDepositEdit)
        {
            string sp = "fn_saving_pkg.p_mf_saving_deposit";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", mfSavingDepositEdit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", mfSavingDepositEdit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", mfSavingDepositEdit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", mfSavingDepositEdit.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANDATORY_SAVING_TYPE", mfSavingDepositEdit.MandatorySaving_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", mfSavingDepositEdit.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", mfSavingDepositEdit.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", mfSavingDepositEdit.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", mfSavingDepositEdit.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", mfSavingDepositEdit.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_BY", mfSavingDepositEdit.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", mfSavingDepositEdit.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", mfSavingDepositEdit.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_MF_DEPOSIT_NO", mfSavingDepositEdit.OutMf_Deposit_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfSavingDepositEdit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfSavingDepositEdit mfSavingDepositEdit)
        {
            string sp = "mfSavingDepositEdit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", mfSavingDepositEdit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", mfSavingDepositEdit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", mfSavingDepositEdit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", mfSavingDepositEdit.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANDATORY_SAVING_TYPE", mfSavingDepositEdit.MandatorySaving_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", mfSavingDepositEdit.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", mfSavingDepositEdit.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", mfSavingDepositEdit.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", mfSavingDepositEdit.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", mfSavingDepositEdit.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_BY", mfSavingDepositEdit.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", mfSavingDepositEdit.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", mfSavingDepositEdit.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_MF_DEPOSIT_NO", mfSavingDepositEdit.OutMf_Deposit_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfSavingDepositEdit> lst = new List<MfSavingDepositEdit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfSavingDepositEdit obj = new MfSavingDepositEdit();
                    obj.AccountNo = drow["ACCOUNT_NO"].ToString();
                    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.MandatorySaving_Type = drow["MANDATORY_SAVING_TYPE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.DepositBy = drow["DEPOSIT_BY"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscal_Year = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutMf_Deposit_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_MF_DEPOSIT_NO"].ToString()));

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
