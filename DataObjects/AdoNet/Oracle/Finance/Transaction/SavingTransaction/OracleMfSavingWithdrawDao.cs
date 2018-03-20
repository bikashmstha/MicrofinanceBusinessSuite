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

    public class OracleMfSavingWithdrawDao : IMfSavingWithdrawDao
    {
        public object Get()
        {
            string sp = "savingWithdraw_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfSavingWithdraw> lst = new List<MfSavingWithdraw>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfSavingWithdraw obj = new MfSavingWithdraw();
                    obj.AcAdjustAbbs = drow["AcAdjustAbbs"].ToString();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.RepaymentNo = double.Parse(drow["RepaymentNo"].ToString());
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.FlagForPosting = drow["FlagForPosting"].ToString();
                    obj.ClosingCharge = double.Parse(drow["ClosingCharge"].ToString());
                    obj.WithdrawType = drow["WithdrawType"].ToString();
                    obj.AccountClosed = drow["AccountClosed"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.HalfWayInt = int.Parse(drow["HalfWayInt"].ToString());
                    obj.UnpostInterest = double.Parse(drow["UnpostInterest"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.TaxAmount = double.Parse(drow["TaxAmount"].ToString());
                    obj.OtherIncomeExpAmount = double.Parse(drow["OtherIncomeExpAmount"].ToString());
                    obj.OtherIncomeExpVoucherNo = drow["OtherIncomeExpVoucherNo"].ToString();
                    obj.VoucherDate = drow["VoucherDate"].ToString();
                    obj.AcOfficeCode = drow["AcOfficeCode"].ToString();
                    obj.ValueDate = drow["ValueDate"].ToString();
                    obj.ChargeAmount = double.Parse(drow["ChargeAmount"].ToString());
                    obj.ChargeType = drow["ChargeType"].ToString();
                    obj.ChargeSource = drow["ChargeSource"].ToString();
                    obj.ReferenceDepositNo = int.Parse(drow["ReferenceDepositNo"].ToString());
                    obj.ReferenceWithdrawalNo = int.Parse(drow["ReferenceWithdrawalNo"].ToString());
                    obj.ChargeVoucherNo = drow["ChargeVoucherNo"].ToString();
                    obj.ChargeVoucherDate = drow["ChargeVoucherDate"].ToString();
                    obj.InterbranchVoucherNo = drow["InterbranchVoucherNo"].ToString();
                    obj.InterbranchVoucherDate = drow["InterbranchVoucherDate"].ToString();
                    obj.ChargeIbVoucherNo = drow["ChargeIbVoucherNo"].ToString();
                    obj.ChargeIbVoucherDate = drow["ChargeIbVoucherDate"].ToString();
                    obj.TdsTaxableInterestAmount = double.Parse(drow["TdsTaxableInterestAmount"].ToString());
                    obj.MidTermBalance = double.Parse(drow["MidTermBalance"].ToString());
                    obj.MidTermInterest = double.Parse(drow["MidTermInterest"].ToString());
                    obj.MidTermTaxableAmount = double.Parse(drow["MidTermTaxableAmount"].ToString());
                    obj.WaivedAmount = double.Parse(drow["WaivedAmount"].ToString());
                    obj.AccurateInterest = double.Parse(drow["AccurateInterest"].ToString());
                    obj.AccurateInterestVoucherNo = drow["AccurateInterestVoucherNo"].ToString();
                    obj.TranAdjustAbbs = drow["TranAdjustAbbs"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfSavingWithdraw savingWithdraw)
        {
            string sp = "fn_saving_pkg.p_mf_saving_withdraw";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();

               

                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", savingWithdraw.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", savingWithdraw.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", savingWithdraw.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", savingWithdraw.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", savingWithdraw.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", savingWithdraw.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", savingWithdraw.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", savingWithdraw.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawType", savingWithdraw.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AcAdjustAbbs", savingWithdraw.MaxWithdrawAmount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", savingWithdraw.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", savingWithdraw.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingWithdraw.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", savingWithdraw.FiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", savingWithdraw.WithdrawalNo, OracleDbType.Double, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 200;


                
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(MfSavingWithdraw savingWithdraw)
        {
            string sp = "savingWithdraw_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AcAdjustAbbs", savingWithdraw.AcAdjustAbbs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", savingWithdraw.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawalNo", savingWithdraw.WithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", savingWithdraw.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", savingWithdraw.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", savingWithdraw.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", savingWithdraw.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", savingWithdraw.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", savingWithdraw.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RepaymentNo", savingWithdraw.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", savingWithdraw.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionSheetNo", savingWithdraw.CollectionSheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherNo", savingWithdraw.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FlagForPosting", savingWithdraw.FlagForPosting, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", savingWithdraw.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawType", savingWithdraw.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountClosed", savingWithdraw.AccountClosed, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", savingWithdraw.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", savingWithdraw.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", savingWithdraw.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", savingWithdraw.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", savingWithdraw.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", savingWithdraw.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", savingWithdraw.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_HalfWayInt", savingWithdraw.HalfWayInt, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", savingWithdraw.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", savingWithdraw.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxAmount", savingWithdraw.TaxAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpAmount", savingWithdraw.OtherIncomeExpAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeExpVoucherNo", savingWithdraw.OtherIncomeExpVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VoucherDate", savingWithdraw.VoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AcOfficeCode", savingWithdraw.AcOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ValueDate", savingWithdraw.ValueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeAmount", savingWithdraw.ChargeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeType", savingWithdraw.ChargeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeSource", savingWithdraw.ChargeSource, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceDepositNo", savingWithdraw.ReferenceDepositNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceWithdrawalNo", savingWithdraw.ReferenceWithdrawalNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeVoucherNo", savingWithdraw.ChargeVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeVoucherDate", savingWithdraw.ChargeVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterbranchVoucherNo", savingWithdraw.InterbranchVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterbranchVoucherDate", savingWithdraw.InterbranchVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeIbVoucherNo", savingWithdraw.ChargeIbVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeIbVoucherDate", savingWithdraw.ChargeIbVoucherDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TdsTaxableInterestAmount", savingWithdraw.TdsTaxableInterestAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", savingWithdraw.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermInterest", savingWithdraw.MidTermInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermTaxableAmount", savingWithdraw.MidTermTaxableAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WaivedAmount", savingWithdraw.WaivedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccurateInterest", savingWithdraw.AccurateInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccurateInterestVoucherNo", savingWithdraw.AccurateInterestVoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranAdjustAbbs", savingWithdraw.TranAdjustAbbs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfSavingWithdraw> lst = new List<MfSavingWithdraw>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfSavingWithdraw obj = new MfSavingWithdraw();
                    obj.AcAdjustAbbs = drow["AcAdjustAbbs"].ToString();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.WithdrawalNo = double.Parse(drow["WithdrawalNo"].ToString());
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.RepaymentNo = double.Parse(drow["RepaymentNo"].ToString());
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.CollectionSheetNo = drow["CollectionSheetNo"].ToString();
                    obj.VoucherNo = drow["VoucherNo"].ToString();
                    obj.FlagForPosting = drow["FlagForPosting"].ToString();
                    obj.ClosingCharge = double.Parse(drow["ClosingCharge"].ToString());
                    obj.WithdrawType = drow["WithdrawType"].ToString();
                    obj.AccountClosed = drow["AccountClosed"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.HalfWayInt = int.Parse(drow["HalfWayInt"].ToString());
                    obj.UnpostInterest = double.Parse(drow["UnpostInterest"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.TaxAmount = double.Parse(drow["TaxAmount"].ToString());
                    obj.OtherIncomeExpAmount = double.Parse(drow["OtherIncomeExpAmount"].ToString());
                    obj.OtherIncomeExpVoucherNo = drow["OtherIncomeExpVoucherNo"].ToString();
                    obj.VoucherDate = drow["VoucherDate"].ToString();
                    obj.AcOfficeCode = drow["AcOfficeCode"].ToString();
                    obj.ValueDate = drow["ValueDate"].ToString();
                    obj.ChargeAmount = double.Parse(drow["ChargeAmount"].ToString());
                    obj.ChargeType = drow["ChargeType"].ToString();
                    obj.ChargeSource = drow["ChargeSource"].ToString();
                    obj.ReferenceDepositNo = int.Parse(drow["ReferenceDepositNo"].ToString());
                    obj.ReferenceWithdrawalNo = int.Parse(drow["ReferenceWithdrawalNo"].ToString());
                    obj.ChargeVoucherNo = drow["ChargeVoucherNo"].ToString();
                    obj.ChargeVoucherDate = drow["ChargeVoucherDate"].ToString();
                    obj.InterbranchVoucherNo = drow["InterbranchVoucherNo"].ToString();
                    obj.InterbranchVoucherDate = drow["InterbranchVoucherDate"].ToString();
                    obj.ChargeIbVoucherNo = drow["ChargeIbVoucherNo"].ToString();
                    obj.ChargeIbVoucherDate = drow["ChargeIbVoucherDate"].ToString();
                    obj.TdsTaxableInterestAmount = double.Parse(drow["TdsTaxableInterestAmount"].ToString());
                    obj.MidTermBalance = double.Parse(drow["MidTermBalance"].ToString());
                    obj.MidTermInterest = double.Parse(drow["MidTermInterest"].ToString());
                    obj.MidTermTaxableAmount = double.Parse(drow["MidTermTaxableAmount"].ToString());
                    obj.WaivedAmount = double.Parse(drow["WaivedAmount"].ToString());
                    obj.AccurateInterest = double.Parse(drow["AccurateInterest"].ToString());
                    obj.AccurateInterestVoucherNo = drow["AccurateInterestVoucherNo"].ToString();
                    obj.TranAdjustAbbs = drow["TranAdjustAbbs"].ToString();

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

