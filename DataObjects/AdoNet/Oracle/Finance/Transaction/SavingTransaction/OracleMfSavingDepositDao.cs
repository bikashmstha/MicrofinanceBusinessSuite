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
    public class OracleMfSavingDepositDao : IMfSavingDepositDao
    {
        public object Get()
        {
            string sp = "mfSavingDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfSavingDeposit> lst = new List<MfSavingDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfSavingDeposit obj = new MfSavingDeposit();
                    obj.WithdrawOfficeCode = drow["WithdrawOfficeCode"].ToString();
                    obj.ChargeIbVoucherDate = drow["ChargeIbVoucherDate"].ToString();
                    obj.ChargeIbVoucherNo = drow["ChargeIbVoucherNo"].ToString();
                    obj.TranAdjustAbbs = drow["TranAdjustAbbs"].ToString();
                    obj.AcAdjustAbbs = drow["AcAdjustAbbs"].ToString();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.DepositNo = double.Parse(drow["DepositNo"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.DepositDate = drow["DepositDate"].ToString();
                    obj.DepositAmount = double.Parse(drow["DepositAmount"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.MandatorySavingType = drow["MandatorySavingType"].ToString();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ReferenceNo = drow["ReferenceNo"].ToString();
                    obj.FlagForPosting = drow["FlagForPosting"].ToString();
                    obj.EmpId = drow["EmpId"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.AccountClosed = drow["AccountClosed"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.VoucherDate = drow["VoucherDate"].ToString();
                    obj.DepositBy = drow["DepositBy"].ToString();
                    obj.AcOfficeCode = drow["AcOfficeCode"].ToString();
                    obj.ValueDate = drow["ValueDate"].ToString();
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.ChargeType = drow["ChargeType"].ToString();
                    obj.ChargeAmount = double.Parse(drow["ChargeAmount"].ToString());
                    obj.ChargeSource = drow["ChargeSource"].ToString();
                    obj.ChargeVoucherNo = drow["ChargeVoucherNo"].ToString();
                    obj.ChargeVoucherDate = drow["ChargeVoucherDate"].ToString();
                    obj.InterbranchVoucherNo = drow["InterbranchVoucherNo"].ToString();
                    obj.InterbranchVoucherDate = drow["InterbranchVoucherDate"].ToString();
                    obj.TransferSavingYN = drow["TransferSavingYN"].ToString();
                    obj.TransferAccountNo = drow["TransferAccountNo"].ToString();
                    obj.TransferChequeNo = drow["TransferChequeNo"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfSavingDeposit mfSavingDeposit)
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
                /*
                 * p_account_no              IN     VARCHAR2,
                                  p_deposit_date            IN     DATE,
                                  p_deposit_amount          IN     NUMBER,
                                  p_contra_account          IN     VARCHAR2,
                                  p_mandatory_saving_type   IN     VARCHAR2,
                                  p_voucher_no              IN     VARCHAR2,
                                  p_emp_id                  IN     VARCHAR2,
                                  p_remarks                 IN     VARCHAR2,
                                  p_tran_office_code        IN     VARCHAR2,
                                  p_user                    IN     VARCHAR2,
                                  p_deposit_by              IN     VARCHAR2,
                                  p_insert_update           IN     VARCHAR2,
                                  v_out_fiscal_year         IN OUT VARCHAR2,
                                  v_out_mf_deposit_no       IN OUT NUMBER,
                                  v_out_result_code            OUT VARCHAR2,
                                  v_out_result_msg             OUT VARCHAR2
                 * */
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfSavingDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDate", mfSavingDeposit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositAmount", mfSavingDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfSavingDeposit.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MandatorySavingType", mfSavingDeposit.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfSavingDeposit.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpId", mfSavingDeposit.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", mfSavingDeposit.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfSavingDeposit.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", mfSavingDeposit.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositBy", mfSavingDeposit.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfSavingDeposit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", mfSavingDeposit.FiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositNo", mfSavingDeposit.DepositNo, OracleDbType.Double, ParameterDirection.InputOutput));
                
                
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;

                

                List<MfSavingDeposit> LST = new List<MfSavingDeposit>();
                LST.Add(mfSavingDeposit);
                oMsg.Result = LST;
                
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString();
                mfSavingDeposit.DepositNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[paramList.Count - 3].Value.ToString()));
                mfSavingDeposit.FiscalYear = paramList[paramList.Count - 4].Value.ToString();

                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(MfSavingDeposit mfSavingDeposit)
        {
            string sp = "mfSavingDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawOfficeCode", mfSavingDeposit.WithdrawOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeIbVoucherDate", mfSavingDeposit.ChargeIbVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeIbVoucherNo", mfSavingDeposit.ChargeIbVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranAdjustAbbs", mfSavingDeposit.TranAdjustAbbs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AcAdjustAbbs", mfSavingDeposit.AcAdjustAbbs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", mfSavingDeposit.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositNo", mfSavingDeposit.DepositNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", mfSavingDeposit.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositDate", mfSavingDeposit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositAmount", mfSavingDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", mfSavingDeposit.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MandatorySavingType", mfSavingDeposit.MandatorySavingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", mfSavingDeposit.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", mfSavingDeposit.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", mfSavingDeposit.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceNo", mfSavingDeposit.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FlagForPosting", mfSavingDeposit.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpId", mfSavingDeposit.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", mfSavingDeposit.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountClosed", mfSavingDeposit.AccountClosed, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", mfSavingDeposit.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", mfSavingDeposit.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", mfSavingDeposit.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", mfSavingDeposit.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", mfSavingDeposit.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", mfSavingDeposit.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", mfSavingDeposit.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherDate", mfSavingDeposit.VoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DepositBy", mfSavingDeposit.DepositBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AcOfficeCode", mfSavingDeposit.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ValueDate", mfSavingDeposit.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", mfSavingDeposit.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeType", mfSavingDeposit.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeAmount", mfSavingDeposit.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeSource", mfSavingDeposit.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeVoucherNo", mfSavingDeposit.ChargeVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeVoucherDate", mfSavingDeposit.ChargeVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterbranchVoucherNo", mfSavingDeposit.InterbranchVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterbranchVoucherDate", mfSavingDeposit.InterbranchVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferSavingYN", mfSavingDeposit.TransferSavingYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferAccountNo", mfSavingDeposit.TransferAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferChequeNo", mfSavingDeposit.TransferChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfSavingDeposit> lst = new List<MfSavingDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfSavingDeposit obj = new MfSavingDeposit();
                    obj.WithdrawOfficeCode = drow["WithdrawOfficeCode"].ToString();
                    obj.ChargeIbVoucherDate = drow["ChargeIbVoucherDate"].ToString();
                    obj.ChargeIbVoucherNo = drow["ChargeIbVoucherNo"].ToString();
                    obj.TranAdjustAbbs = drow["TranAdjustAbbs"].ToString();
                    obj.AcAdjustAbbs = drow["AcAdjustAbbs"].ToString();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.DepositNo = double.Parse(drow["DepositNo"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.DepositDate = drow["DepositDate"].ToString();
                    obj.DepositAmount = double.Parse(drow["DepositAmount"].ToString());
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.MandatorySavingType = drow["MandatorySavingType"].ToString();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ReferenceNo = drow["ReferenceNo"].ToString();
                    obj.FlagForPosting = drow["FlagForPosting"].ToString();
                    obj.EmpId = drow["EmpId"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.AccountClosed = drow["AccountClosed"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.VoucherDate = drow["VoucherDate"].ToString();
                    obj.DepositBy = drow["DepositBy"].ToString();
                    obj.AcOfficeCode = drow["AcOfficeCode"].ToString();
                    obj.ValueDate = drow["ValueDate"].ToString();
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.ChargeType = drow["ChargeType"].ToString();
                    obj.ChargeAmount = double.Parse(drow["ChargeAmount"].ToString());
                    obj.ChargeSource = drow["ChargeSource"].ToString();
                    obj.ChargeVoucherNo = drow["ChargeVoucherNo"].ToString();
                    obj.ChargeVoucherDate = drow["ChargeVoucherDate"].ToString();
                    obj.InterbranchVoucherNo = drow["InterbranchVoucherNo"].ToString();
                    obj.InterbranchVoucherDate = drow["InterbranchVoucherDate"].ToString();
                    obj.TransferSavingYN = drow["TransferSavingYN"].ToString();
                    obj.TransferAccountNo = drow["TransferAccountNo"].ToString();
                    obj.TransferChequeNo = drow["TransferChequeNo"].ToString();

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
