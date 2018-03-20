using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Inventory.Transaction;
using DataObjects.Interfaces.Inventory;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Inventory
{
    public class OracleFaAssetSendReceiptDao : IFaAssetSendReceiptDao
    {
        public object SaveFaAssetSendReceipt(FaAssetSendReceipt faAssetSendReceipt)
        {
            string sp = "in_fa_asset_info_pkg.p_fa_asset_send_receipt";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", faAssetSendReceipt.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", faAssetSendReceipt.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RECEIVE_SEND_DROP", faAssetSendReceipt.ReceiveSendDrop, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_TRAN_OFFICE_CODE", faAssetSendReceipt.FromTranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_TRAN_OFFICE_CODE", faAssetSendReceipt.ToTranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DEPT_CODE", faAssetSendReceipt.FromDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DEPT_CODE", faAssetSendReceipt.ToDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPR_CALC_Y_N", faAssetSendReceipt.DeprCalcY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_VALUE", faAssetSendReceipt.CurrentValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_DATE", faAssetSendReceipt.TranDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_DATE_BS", faAssetSendReceipt.TranDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_Y_N", faAssetSendReceipt.TransferYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", faAssetSendReceipt.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNCALCDEPR", faAssetSendReceipt.Uncalcdepr, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", faAssetSendReceipt.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", faAssetSendReceipt.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", faAssetSendReceipt.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_SNO", faAssetSendReceipt.OutSno, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 200;
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

        public object SearchFaAssetSendReceipt(FaAssetSendReceipt faAssetSendReceipt)
        {
            string sp = "faAssetSendReceipt_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", faAssetSendReceipt.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", faAssetSendReceipt.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RECEIVE_SEND_DROP", faAssetSendReceipt.ReceiveSendDrop, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_TRAN_OFFICE_CODE", faAssetSendReceipt.FromTranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_TRAN_OFFICE_CODE", faAssetSendReceipt.ToTranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DEPT_CODE", faAssetSendReceipt.FromDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DEPT_CODE", faAssetSendReceipt.ToDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPR_CALC_Y_N", faAssetSendReceipt.DeprCalcY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_VALUE", faAssetSendReceipt.CurrentValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_DATE", faAssetSendReceipt.TranDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_DATE_BS", faAssetSendReceipt.TranDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_Y_N", faAssetSendReceipt.TransferYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", faAssetSendReceipt.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNCALCDEPR", faAssetSendReceipt.Uncalcdepr, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", faAssetSendReceipt.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", faAssetSendReceipt.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", faAssetSendReceipt.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_SNO", faAssetSendReceipt.OutSno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FaAssetSendReceipt> lst = new List<FaAssetSendReceipt>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FaAssetSendReceipt obj = new FaAssetSendReceipt();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();
                    obj.ReceiveSendDrop = drow["RECEIVE_SEND_DROP"].ToString();
                    obj.FromTranOffice_Code = drow["FROM_TRAN_OFFICE_CODE"].ToString();
                    obj.ToTranOffice_Code = drow["TO_TRAN_OFFICE_CODE"].ToString();
                    obj.FromDeptCode = drow["FROM_DEPT_CODE"].ToString();
                    obj.ToDeptCode = drow["TO_DEPT_CODE"].ToString();
                    obj.DeprCalcY_N = drow["DEPR_CALC_Y_N"].ToString();
                    obj.CurrentValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_VALUE"].ToString()));
                    obj.TranDate = drow["TRAN_DATE"].ToString();
                    obj.TranDateBs = drow["TRAN_DATE_BS"].ToString();
                    obj.TransferYN = drow["TRANSFER_Y_N"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.Uncalcdepr = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UNCALCDEPR"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.Username = drow["USERNAME"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutSno = drow["OUT_SNO"].ToString();

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
