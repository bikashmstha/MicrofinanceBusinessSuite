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
    public class OracleAssetMaintenanceDetailDao : IAssetMaintenanceDetailDao
    {
        public object SaveAssetMaintenanceDetail(AssetMaintenanceDetail assetMaintenanceDetail)
        {
            string sp = "assetMaintenanceDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_ID", assetMaintenanceDetail.MaintId, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE", assetMaintenanceDetail.MaintDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE_BS", assetMaintenanceDetail.MaintDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_COST", assetMaintenanceDetail.MaintCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_ADDED_FLAG", assetMaintenanceDetail.MaintAddedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DESCRIPTION", assetMaintenanceDetail.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", assetMaintenanceDetail.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", assetMaintenanceDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchAssetMaintenanceDetail(AssetMaintenanceDetail assetMaintenanceDetail)
        {
            string sp = "assetMaintenanceDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_ID", assetMaintenanceDetail.MaintId, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE", assetMaintenanceDetail.MaintDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE_BS", assetMaintenanceDetail.MaintDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_COST", assetMaintenanceDetail.MaintCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_ADDED_FLAG", assetMaintenanceDetail.MaintAddedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DESCRIPTION", assetMaintenanceDetail.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", assetMaintenanceDetail.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AssetMaintenanceDetail> lst = new List<AssetMaintenanceDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AssetMaintenanceDetail obj = new AssetMaintenanceDetail();
                    obj.MaintId = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAINT_ID"].ToString()));
                    obj.MaintDate = drow["MAINT_DATE"].ToString();
                    obj.MaintDateBs = drow["MAINT_DATE_BS"].ToString();
                    obj.MaintCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAINT_COST"].ToString()));
                    obj.MaintAddedFlag = drow["MAINT_ADDED_FLAG"].ToString();
                    obj.Description = drow["DESCRIPTION"].ToString();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetAssetMaintenanceDtl(string AssetCode)
        {
            string sp = "in_asset_utility_pkg.p_asset_maintenance_dtl";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_ASSET_CODE", AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AssetMaintenanceDetail> lst = new List<AssetMaintenanceDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AssetMaintenanceDetail obj = new AssetMaintenanceDetail();
                    obj.MaintId = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAINT_ID"].ToString()));
                    obj.MaintDate = drow["MAINT_DATE"].ToString();
                    obj.MaintDateBs = drow["MAINT_DATE_BS"].ToString();
                    obj.MaintCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAINT_COST"].ToString()));
                    obj.MaintAddedFlag = drow["MAINT_ADDED_FLAG"].ToString();
                    obj.Description = drow["DESCRIPTION"].ToString();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();

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
