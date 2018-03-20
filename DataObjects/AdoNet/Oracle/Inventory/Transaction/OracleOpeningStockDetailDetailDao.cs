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
    public class OracleOpeningStockDetailDetailDao : IOpeningStockDetailDetailDao
    {
        public object SaveOpeningStockDetailDetail(OpeningStockDetailDetail openingStockDetailDetail)
        {
            string sp = "openingStockDetailDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", openingStockDetailDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", openingStockDetailDetail.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", openingStockDetailDetail.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", openingStockDetailDetail.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMAINING_QTY", openingStockDetailDetail.RemainingQty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIT_CODE", openingStockDetailDetail.UnitCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE", openingStockDetailDetail.ExpiryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE_BS", openingStockDetailDetail.ExpiryDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ORDER_NO", openingStockDetailDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS_DTL", openingStockDetailDetail.RemarksDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE_DTL", openingStockDetailDetail.InsertUpdateDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_COST", openingStockDetailDetail.TotalCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", openingStockDetailDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchOpeningStockDetailDetail(OpeningStockDetailDetail openingStockDetailDetail)
        {
            string sp = "openingStockDetailDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", openingStockDetailDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", openingStockDetailDetail.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", openingStockDetailDetail.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", openingStockDetailDetail.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMAINING_QTY", openingStockDetailDetail.RemainingQty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIT_CODE", openingStockDetailDetail.UnitCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE", openingStockDetailDetail.ExpiryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE_BS", openingStockDetailDetail.ExpiryDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ORDER_NO", openingStockDetailDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS_DTL", openingStockDetailDetail.RemarksDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE_DTL", openingStockDetailDetail.InsertUpdateDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_COST", openingStockDetailDetail.TotalCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OpeningStockDetailDetail> lst = new List<OpeningStockDetailDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OpeningStockDetailDetail obj = new OpeningStockDetailDetail();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.RemainingQty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REMAINING_QTY"].ToString()));
                    obj.UnitCode = drow["UNIT_CODE"].ToString();
                    obj.ExpiryDate = drow["EXPIRY_DATE"].ToString();
                    obj.ExpiryDateBs = drow["EXPIRY_DATE_BS"].ToString();
                    obj.OrderNo = drow["ORDER_NO"].ToString();
                    obj.RemarksDtl = drow["REMARKS_DTL"].ToString();
                    obj.InsertUpdateDtl = drow["INSERT_UPDATE_DTL"].ToString();
                    obj.TotalCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_COST"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetOpeningStockDtlDetail(string ReferenceNo)
        {
            string sp = "in_inventory_utility_pkg.p_opening_stock_dtl_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_REFERENCE_NO", ReferenceNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OpeningStockDetailDetail> lst = new List<OpeningStockDetailDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OpeningStockDetailDetail obj = new OpeningStockDetailDetail();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.RemainingQty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REMAINING_QTY"].ToString()));
                    obj.UnitCode = drow["UNIT_CODE"].ToString();
                    obj.ExpiryDate = drow["EXPIRY_DATE"].ToString();
                    obj.ExpiryDateBs = drow["EXPIRY_DATE_BS"].ToString();
                    obj.OrderNo = drow["ORDER_NO"].ToString();
                    obj.RemarksDtl = drow["REMARKS_DTL"].ToString();
                    obj.InsertUpdateDtl = drow["INSERT_UPDATE_DTL"].ToString();
                    obj.TotalCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_COST"].ToString()));

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
