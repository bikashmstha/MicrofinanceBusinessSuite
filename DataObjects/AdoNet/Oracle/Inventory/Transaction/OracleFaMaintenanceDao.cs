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
    public class OracleFaMaintenanceDao : IFaMaintenanceDao
    {
        public object SaveFaMaintenance(FaMaintenance famaintenance)
        {
            string sp = "in_fa_asset_info_pkg.p_in_fa_maintenance";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", famaintenance.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE", famaintenance.MaintDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DESCRIPTION", famaintenance.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_COST", famaintenance.MaintCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", famaintenance.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_ADDED_FLAG", famaintenance.MaintAddedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE_BS", famaintenance.MaintDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", famaintenance.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", famaintenance.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", famaintenance.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_MAINT_ID", famaintenance.OutMaintId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", famaintenance.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchFaMaintenance(FaMaintenance famaintenance)
        {
            string sp = "famaintenance_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ASSET_CODE", famaintenance.AssetCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE", famaintenance.MaintDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DESCRIPTION", famaintenance.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_COST", famaintenance.MaintCost, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", famaintenance.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_ADDED_FLAG", famaintenance.MaintAddedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAINT_DATE_BS", famaintenance.MaintDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USERNAME", famaintenance.Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DATE1", famaintenance.Date1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", famaintenance.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_MAINT_ID", famaintenance.OutMaintId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FaMaintenance> lst = new List<FaMaintenance>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FaMaintenance obj = new FaMaintenance();
                    obj.AssetCode = drow["ASSET_CODE"].ToString();
                    obj.MaintDate = drow["MAINT_DATE"].ToString();
                    obj.Description = drow["DESCRIPTION"].ToString();
                    obj.MaintCost = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAINT_COST"].ToString()));
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.MaintAddedFlag = drow["MAINT_ADDED_FLAG"].ToString();
                    obj.MaintDateBs = drow["MAINT_DATE_BS"].ToString();
                    obj.Username = drow["USERNAME"].ToString();
                    obj.Date1 = drow["DATE1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutMaintId = drow["OUT_MAINT_ID"].ToString();

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
