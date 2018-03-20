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
    public class OracleSavingAccountClosureDao : ISavingAccountClosureDao
    {
        public object Get()
        {
            string sp = "savingAccountClosure_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingAccountClosure> lst = new List<SavingAccountClosure>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingAccountClosure obj = new SavingAccountClosure();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ClosingCharge = double.Parse(drow["ClosingCharge"].ToString());
                    obj.WithdrawType = drow["WithdrawType"].ToString();
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.TaxOnUnpostInterest = double.Parse(drow["TaxOnUnpostInterest"].ToString());
                    obj.UnpostInterest = double.Parse(drow["UnpostInterest"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.ReceivedInterest = double.Parse(drow["ReceivedInterest"].ToString());
                    obj.MidTermClosing = drow["MidTermClosing"].ToString();
                    obj.MidTermBalance = double.Parse(drow["MidTermBalance"].ToString());
                    obj.MidTermInterest = double.Parse(drow["MidTermInterest"].ToString());
                    obj.MidTermTaxableAmount = double.Parse(drow["MidTermTaxableAmount"].ToString());
                    obj.TdsDifference = double.Parse(drow["TdsDifference"].ToString());
                    obj.OtherIncomeAmount = double.Parse(drow["OtherIncomeAmount"].ToString());
                    obj.WaivedAmount = double.Parse(drow["WaivedAmount"].ToString());
                    obj.PrematuredIntRatio = double.Parse(drow["PrematuredIntRatio"].ToString());
                    obj.MidTermClosingType = drow["MidTermClosingType"].ToString();
                    obj.InsertUpdate = drow["InsertUpdate"].ToString();
                    obj.OutFiscalYear = drow["OutFiscalYear"].ToString();
                    obj.OutWithdrawalNo = double.Parse(drow["OutWithdrawalNo"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(SavingAccountClosure savingAccountClosure)
        {
            string sp = "fn_saving_pkg.p_mf_saving_ac_closure";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", savingAccountClosure.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", savingAccountClosure.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", savingAccountClosure.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", savingAccountClosure.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", savingAccountClosure.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", savingAccountClosure.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", savingAccountClosure.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", savingAccountClosure.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawType", savingAccountClosure.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", savingAccountClosure.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", savingAccountClosure.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", savingAccountClosure.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxOnUnpostInterest", savingAccountClosure.TaxOnUnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", savingAccountClosure.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", savingAccountClosure.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterest", savingAccountClosure.ReceivedInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermClosing", savingAccountClosure.MidTermClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", savingAccountClosure.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermInterest", savingAccountClosure.MidTermInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermTaxableAmount", savingAccountClosure.MidTermTaxableAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TdsDifference", savingAccountClosure.TdsDifference, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeAmount", savingAccountClosure.OtherIncomeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WaivedAmount", savingAccountClosure.WaivedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrematuredIntRatio", savingAccountClosure.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermClosingType", savingAccountClosure.MidTermClosingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", savingAccountClosure.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsertUpdate", savingAccountClosure.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutFiscalYear", savingAccountClosure.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":p_OutWithdrawalNo", savingAccountClosure.OutWithdrawalNo, OracleDbType.Double, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();

                SavingAccountClosure obj = new SavingAccountClosure();
                obj.OutFiscalYear = paramList[paramList.Count - 4].Value.ToString();
                    obj.OutWithdrawalNo=double.Parse( paramList[paramList.Count - 3].Value.ToString());

                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(SavingAccountClosure savingAccountClosure)
        {
            string sp = "fn_saving_pkg.p_mf_saving_ac_closure";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", savingAccountClosure.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawDate", savingAccountClosure.WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawAmount", savingAccountClosure.WithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChequeNo", savingAccountClosure.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayeeName", savingAccountClosure.PayeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ContraAccount", savingAccountClosure.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Remarks", savingAccountClosure.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingCharge", savingAccountClosure.ClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WithdrawType", savingAccountClosure.WithdrawType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForClosing", savingAccountClosure.ReasonForClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", savingAccountClosure.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CurrentBalance", savingAccountClosure.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxOnUnpostInterest", savingAccountClosure.TaxOnUnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UnpostInterest", savingAccountClosure.UnpostInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAmount", savingAccountClosure.PenaltyAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedInterest", savingAccountClosure.ReceivedInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermClosing", savingAccountClosure.MidTermClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermBalance", savingAccountClosure.MidTermBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermInterest", savingAccountClosure.MidTermInterest, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermTaxableAmount", savingAccountClosure.MidTermTaxableAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TdsDifference", savingAccountClosure.TdsDifference, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeAmount", savingAccountClosure.OtherIncomeAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_WaivedAmount", savingAccountClosure.WaivedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrematuredIntRatio", savingAccountClosure.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermClosingType", savingAccountClosure.MidTermClosingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", savingAccountClosure.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InsertUpdate", savingAccountClosure.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutFiscalYear", savingAccountClosure.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OutWithdrawalNo", savingAccountClosure.OutWithdrawalNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingAccountClosure> lst = new List<SavingAccountClosure>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingAccountClosure obj = new SavingAccountClosure();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.WithdrawDate = drow["WithdrawDate"].ToString();
                    obj.WithdrawAmount = double.Parse(drow["WithdrawAmount"].ToString());
                    obj.ChequeNo = drow["ChequeNo"].ToString();
                    obj.PayeeName = drow["PayeeName"].ToString();
                    obj.ContraAccount = drow["ContraAccount"].ToString();
                    obj.Remarks = drow["Remarks"].ToString();
                    obj.ClosingCharge = double.Parse(drow["ClosingCharge"].ToString());
                    obj.WithdrawType = drow["WithdrawType"].ToString();
                    obj.ReasonForClosing = drow["ReasonForClosing"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.CurrentBalance = double.Parse(drow["CurrentBalance"].ToString());
                    obj.TaxOnUnpostInterest = double.Parse(drow["TaxOnUnpostInterest"].ToString());
                    obj.UnpostInterest = double.Parse(drow["UnpostInterest"].ToString());
                    obj.PenaltyAmount = double.Parse(drow["PenaltyAmount"].ToString());
                    obj.ReceivedInterest = double.Parse(drow["ReceivedInterest"].ToString());
                    obj.MidTermClosing = drow["MidTermClosing"].ToString();
                    obj.MidTermBalance = double.Parse(drow["MidTermBalance"].ToString());
                    obj.MidTermInterest = double.Parse(drow["MidTermInterest"].ToString());
                    obj.MidTermTaxableAmount = double.Parse(drow["MidTermTaxableAmount"].ToString());
                    obj.TdsDifference = double.Parse(drow["TdsDifference"].ToString());
                    obj.OtherIncomeAmount = double.Parse(drow["OtherIncomeAmount"].ToString());
                    obj.WaivedAmount = double.Parse(drow["WaivedAmount"].ToString());
                    obj.PrematuredIntRatio = double.Parse(drow["PrematuredIntRatio"].ToString());
                    obj.MidTermClosingType = drow["MidTermClosingType"].ToString();
                    obj.InsertUpdate = drow["InsertUpdate"].ToString();
                    obj.OutFiscalYear = drow["OutFiscalYear"].ToString();
                    obj.OutWithdrawalNo = double.Parse(drow["OutWithdrawalNo"].ToString());

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
