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
    public class OracleItemTransactionDetailDao : IItemTransactionDetailDao
    {
        public object SaveItemTransactionDetail(List<ItemTransactionDetail> itemTransactionDetails, OracleTransaction tran, string referenceNo)
        {
            string sp = "in_inventory_trans_pkg.p_item_transaction_detail";
            OutMessage oMsg = new OutMessage();
            List<OracleParameter> paramList = new List<OracleParameter>();

            try
            {
                foreach (ItemTransactionDetail itemTransactionDetail in itemTransactionDetails)
                {
                    paramList = new List<OracleParameter>();
                    paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", referenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", itemTransactionDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_TYPE", itemTransactionDetail.TransactionType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", itemTransactionDetail.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", itemTransactionDetail.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_REMAINING_QTY", itemTransactionDetail.RemainingQty, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_UNIT_CODE", itemTransactionDetail.UnitCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE", itemTransactionDetail.ExpiryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_ORDER_NO", itemTransactionDetail.OrderNo, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", itemTransactionDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DATE1", itemTransactionDetail.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", itemTransactionDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", itemTransactionDetail.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_action", itemTransactionDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());

                }
                
                
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            
        }

        public object SearchItemTransactionDetail(ItemTransactionDetail itemTransactionDetail)
        {
            string sp = "itemTransactionDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_NO", itemTransactionDetail.ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", itemTransactionDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_TYPE", itemTransactionDetail.TransactionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", itemTransactionDetail.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", itemTransactionDetail.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMAINING_QTY", itemTransactionDetail.RemainingQty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIT_CODE", itemTransactionDetail.UnitCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE", itemTransactionDetail.ExpiryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ORDER_NO", itemTransactionDetail.OrderNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", itemTransactionDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", itemTransactionDetail.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", itemTransactionDetail.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", itemTransactionDetail.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<ItemTransactionDetail> lst = new List<ItemTransactionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    ItemTransactionDetail obj = new ItemTransactionDetail();
                    obj.ReferenceNo = drow["REFERENCE_NO"].ToString();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.TransactionType = drow["TRANSACTION_TYPE"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.RemainingQty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REMAINING_QTY"].ToString()));
                    obj.UnitCode = drow["UNIT_CODE"].ToString();
                    obj.ExpiryDate = drow["EXPIRY_DATE"].ToString();
                    obj.OrderNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ORDER_NO"].ToString()));
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.Date1 = drow["DATE1"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.Username = drow["USERNAME"].ToString();

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
