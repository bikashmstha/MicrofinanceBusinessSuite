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
    public class OracleDamageLostDetailDetailDao : IDamageLostDetailDetailDao
    {
        public object SaveDamageLostDetailDetail(DamageLostDetailDetail damageLostDetailDetail)
        {
            string sp = "damageLostDetailDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", damageLostDetailDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", damageLostDetailDetail.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", damageLostDetailDetail.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", damageLostDetailDetail.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMAINING_QTY", damageLostDetailDetail.RemainingQty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIT_CODE", damageLostDetailDetail.UnitCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE", damageLostDetailDetail.ExpiryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ORDER_NO", damageLostDetailDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS_DTL", damageLostDetailDetail.RemarksDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE_DTL", damageLostDetailDetail.InsertUpdateDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", damageLostDetailDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchDamageLostDetailDetail(DamageLostDetailDetail damageLostDetailDetail)
        {
            string sp = "damageLostDetailDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_CODE", damageLostDetailDetail.ItemCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ITEM_NAME", damageLostDetailDetail.ItemName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_QUANTITY", damageLostDetailDetail.TransactionQuantity, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_COST", damageLostDetailDetail.TransactionCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMAINING_QTY", damageLostDetailDetail.RemainingQty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIT_CODE", damageLostDetailDetail.UnitCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EXPIRY_DATE", damageLostDetailDetail.ExpiryDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ORDER_NO", damageLostDetailDetail.OrderNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS_DTL", damageLostDetailDetail.RemarksDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE_DTL", damageLostDetailDetail.InsertUpdateDtl, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<DamageLostDetailDetail> lst = new List<DamageLostDetailDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    DamageLostDetailDetail obj = new DamageLostDetailDetail();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.RemainingQty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REMAINING_QTY"].ToString()));
                    obj.UnitCode = drow["UNIT_CODE"].ToString();
                    obj.ExpiryDate = drow["EXPIRY_DATE"].ToString();
                    obj.OrderNo = drow["ORDER_NO"].ToString();
                    obj.RemarksDtl = drow["REMARKS_DTL"].ToString();
                    obj.InsertUpdateDtl = drow["INSERT_UPDATE_DTL"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetDamageLostDtlDetail(string ReferenceNo)
        {
            string sp = "in_inventory_utility_pkg.p_damage_lost_dtl_detail";
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
                List<DamageLostDetailDetail> lst = new List<DamageLostDetailDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    DamageLostDetailDetail obj = new DamageLostDetailDetail();
                    obj.ItemCode = drow["ITEM_CODE"].ToString();
                    obj.ItemName = drow["ITEM_NAME"].ToString();
                    obj.TransactionQuantity = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_QUANTITY"].ToString()));
                    obj.TransactionCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TRANSACTION_COST"].ToString()));
                    obj.RemainingQty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REMAINING_QTY"].ToString()));
                    obj.UnitCode = drow["UNIT_CODE"].ToString();
                    obj.ExpiryDate = drow["EXPIRY_DATE"].ToString();
                    obj.OrderNo = drow["ORDER_NO"].ToString();
                    obj.RemarksDtl = drow["REMARKS_DTL"].ToString();
                    obj.InsertUpdateDtl = drow["INSERT_UPDATE_DTL"].ToString();

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
