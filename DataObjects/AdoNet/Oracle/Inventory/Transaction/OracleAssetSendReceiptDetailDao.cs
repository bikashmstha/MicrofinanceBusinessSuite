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
    public class OracleAssetSendReceiptDetailDao : IAssetSendReceiptDetailDao
    {
        
        public object GetAssetSendReceiptDetail(string AssetCode, string ReceiveSendDrop)
        {
            string sp = "in_asset_utility_pkg.p_asset_send_receipt_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_ASSET_CODE", AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_RECEIVE_SEND_DROP", ReceiveSendDrop, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AssetSendReceiptDetail> lst = new List<AssetSendReceiptDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AssetSendReceiptDetail obj = new AssetSendReceiptDetail();
                    obj.Sno = drow["SNO"].ToString();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();
                    obj.ReceiveSendDrop = drow["RECEIVE_SEND_DROP"].ToString();
                    obj.FromDeptCode = drow["FROM_DEPT_CODE"].ToString();
                    obj.FromDeptName = drow["FROM_DEPT_NAME"].ToString();
                    obj.ToDeptCode = drow["TO_DEPT_CODE"].ToString();
                    obj.ToDeptName = drow["TO_DEPT_NAME"].ToString();
                    obj.DeprCalcY_N = drow["DEPR_CALC_Y_N"].ToString();
                    obj.CurrentValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_VALUE"].ToString()));
                    obj.TranDate = drow["TRAN_DATE"].ToString();
                    obj.TranDateBs = drow["TRAN_DATE_BS"].ToString();
                    obj.TransferYN = drow["TRANSFER_Y_N"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.Uncalcdepr = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["UNCALCDEPR"].ToString()));
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ToTranOffice_Code = drow["TO_TRAN_OFFICE_CODE"].ToString();
                    obj.ToTranOffice_Name = drow["TO_TRAN_OFFICE_NAME"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();

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
