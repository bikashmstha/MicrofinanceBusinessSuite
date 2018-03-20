using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.CollectionSheetTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleSavingCollectionSheetDao : ISavingCollectionSheetDao
    {
        public object Get()
        {
            string sp = "savingCollectionSheet_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingCollectionSheet> lst = new List<SavingCollectionSheet>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingCollectionSheet obj = new SavingCollectionSheet();
                    obj.CollectionDate = drow["CollectionDate"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.MonthlySavingACNo = drow["MonthlySavingACNo"].ToString();
                    obj.MonthlySavingRec = drow["MonthlySavingRec"].ToString();
                    obj.MonthlySavingAdjustYN = drow["MonthlySavingAdjustYN"].ToString();
                    obj.MonthlySavingAdjustNo = drow["MonthlySavingAdjustNo"].ToString();
                    obj.MonthlySavingAdjustAmt = drow["MonthlySavingAdjustAmt"].ToString();
                    obj.SSFFundACNo = drow["SSFFundACNo"].ToString();
                    obj.SSFFundRec = drow["SSFFundRec"].ToString();
                    obj.OpionalSavingACNo = drow["OpionalSavingACNo"].ToString();
                    obj.OptionalSavingWithdrawal = drow["OptionalSavingWithdrawal"].ToString();
                    obj.PensionFundACNo = drow["PensionFundACNo"].ToString();
                    obj.PensionFundRec = drow["PensionFundRec"].ToString();
                    obj.PensionFundAdjustYN = drow["PensionFundAdjustYN"].ToString();
                    obj.PensionFundAdjustAmt = drow["PensionFundAdjustAmt"].ToString();
                    obj.ReceivedYN = drow["ReceivedYN"].ToString();
                    obj.PresentYN = drow["PresentYN"].ToString();
                    obj.BusinessAC = drow["BusinessAC"].ToString();
                    obj.BusinessReceived = drow["BusinessReceived"].ToString();
                    obj.BusinessWithdraw = drow["BusinessWithdraw"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(SavingCollectionSheet savingCollectionSheet)
        {
            string sp = "collection_sheet_generate_pkg.p_update_saving_collection_sht";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDate", savingCollectionSheet.CollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", savingCollectionSheet.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingACNo", savingCollectionSheet.MonthlySavingACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingRec", savingCollectionSheet.MonthlySavingRec, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingAdjustYN", savingCollectionSheet.MonthlySavingAdjustYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingAdjustNo", savingCollectionSheet.MonthlySavingAdjustNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingAdjustAmt", savingCollectionSheet.MonthlySavingAdjustAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SSFFundACNo", savingCollectionSheet.SSFFundACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SSFFundRec", savingCollectionSheet.SSFFundRec, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OpionalSavingACNo", savingCollectionSheet.OpionalSavingACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OptionalSavingWithdrawal", savingCollectionSheet.OptionalSavingWithdrawal, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundACNo", savingCollectionSheet.PensionFundACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundRec", savingCollectionSheet.PensionFundRec, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundAdjustYN", savingCollectionSheet.PensionFundAdjustYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundAdjustAmt", savingCollectionSheet.PensionFundAdjustAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedYN", savingCollectionSheet.ReceivedYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PresentYN", savingCollectionSheet.PresentYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BusinessAC", savingCollectionSheet.BusinessAC, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BusinessReceived", savingCollectionSheet.BusinessReceived, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BusinessWithdraw", savingCollectionSheet.BusinessWithdraw, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingCollectionSheet.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(SavingCollectionSheet savingCollectionSheet)
        {
            string sp = "savingCollectionSheet_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CollectionDate", savingCollectionSheet.CollectionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", savingCollectionSheet.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingACNo", savingCollectionSheet.MonthlySavingACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingRec", savingCollectionSheet.MonthlySavingRec, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingAdjustYN", savingCollectionSheet.MonthlySavingAdjustYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingAdjustNo", savingCollectionSheet.MonthlySavingAdjustNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MonthlySavingAdjustAmt", savingCollectionSheet.MonthlySavingAdjustAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SSFFundACNo", savingCollectionSheet.SSFFundACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SSFFundRec", savingCollectionSheet.SSFFundRec, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OpionalSavingACNo", savingCollectionSheet.OpionalSavingACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OptionalSavingWithdrawal", savingCollectionSheet.OptionalSavingWithdrawal, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundACNo", savingCollectionSheet.PensionFundACNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundRec", savingCollectionSheet.PensionFundRec, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundAdjustYN", savingCollectionSheet.PensionFundAdjustYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PensionFundAdjustAmt", savingCollectionSheet.PensionFundAdjustAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReceivedYN", savingCollectionSheet.ReceivedYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PresentYN", savingCollectionSheet.PresentYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BusinessAC", savingCollectionSheet.BusinessAC, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BusinessReceived", savingCollectionSheet.BusinessReceived, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BusinessWithdraw", savingCollectionSheet.BusinessWithdraw, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingCollectionSheet> lst = new List<SavingCollectionSheet>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingCollectionSheet obj = new SavingCollectionSheet();
                    obj.CollectionDate = drow["CollectionDate"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.MonthlySavingACNo = drow["MonthlySavingACNo"].ToString();
                    obj.MonthlySavingRec = drow["MonthlySavingRec"].ToString();
                    obj.MonthlySavingAdjustYN = drow["MonthlySavingAdjustYN"].ToString();
                    obj.MonthlySavingAdjustNo = drow["MonthlySavingAdjustNo"].ToString();
                    obj.MonthlySavingAdjustAmt = drow["MonthlySavingAdjustAmt"].ToString();
                    obj.SSFFundACNo = drow["SSFFundACNo"].ToString();
                    obj.SSFFundRec = drow["SSFFundRec"].ToString();
                    obj.OpionalSavingACNo = drow["OpionalSavingACNo"].ToString();
                    obj.OptionalSavingWithdrawal = drow["OptionalSavingWithdrawal"].ToString();
                    obj.PensionFundACNo = drow["PensionFundACNo"].ToString();
                    obj.PensionFundRec = drow["PensionFundRec"].ToString();
                    obj.PensionFundAdjustYN = drow["PensionFundAdjustYN"].ToString();
                    obj.PensionFundAdjustAmt = drow["PensionFundAdjustAmt"].ToString();
                    obj.ReceivedYN = drow["ReceivedYN"].ToString();
                    obj.PresentYN = drow["PresentYN"].ToString();
                    obj.BusinessAC = drow["BusinessAC"].ToString();
                    obj.BusinessReceived = drow["BusinessReceived"].ToString();
                    obj.BusinessWithdraw = drow["BusinessWithdraw"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object Delete(string sheetNo,string user)
        {
            string sp = "collection_sheet_generate_pkg.p_saving_collect_sheet_delete";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_coll_sheet_no", sheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_username", user, OracleDbType.Varchar2, ParameterDirection.Input));
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


        public object Update(string sheetNo, string dataEntered, string dataEnteredDate, string welfareFundAmount, string user)
        {
            string sp = "collection_sheet_generate_pkg.p_update_collection_sheet_mst";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();


                paramList.Add(SqlHelper.GetOraParam(":p_collectionsheetno", sheetNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_data_entered", dataEntered, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_data_entered_date", dataEnteredDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_welfare_fund_amount", welfareFundAmount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user_name", user, OracleDbType.Varchar2, ParameterDirection.Input));
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
    }
}
