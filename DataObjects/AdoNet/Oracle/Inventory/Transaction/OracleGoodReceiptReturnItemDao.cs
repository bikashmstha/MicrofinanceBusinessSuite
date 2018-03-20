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
    public class OracleGoodReceiptReturnItemDao : IGoodReceiptReturnItemDao
    {
        public object SaveGoodReceiptReturnItem(GoodReceiptReturnItem goodReceiptReturnItem)
        {
            string sp = "goodReceiptReturnItem_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", goodReceiptReturnItem.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", goodReceiptReturnItem.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", goodReceiptReturnItem.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", goodReceiptReturnItem.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COSTING_TYPE", goodReceiptReturnItem.CostingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", goodReceiptReturnItem.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchGoodReceiptReturnItem(GoodReceiptReturnItem goodReceiptReturnItem)
        {
            string sp = "goodReceiptReturnItem_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", goodReceiptReturnItem.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", goodReceiptReturnItem.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", goodReceiptReturnItem.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", goodReceiptReturnItem.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COSTING_TYPE", goodReceiptReturnItem.CostingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GoodReceiptReturnItem> lst = new List<GoodReceiptReturnItem>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GoodReceiptReturnItem obj = new GoodReceiptReturnItem();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.CostingType = drow["COSTING_TYPE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetGoodReceiptReturnItem(string ItemDesc, string ReferenceNo)
        {
            string sp = "in_inventory_utility_pkg.p_good_receipt_return_item_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_ITEM_DESC", ItemDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_REFERENCE_NO", ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<GoodReceiptReturnItem> lst = new List<GoodReceiptReturnItem>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    GoodReceiptReturnItem obj = new GoodReceiptReturnItem();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.CostingType = drow["COSTING_TYPE"].ToString();

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
