using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using BusinessObjects;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleModuleDao : IModuleDao
    {
        public object Get()
        {
            string sp = "module_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Module> lst = new List<Module>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Module obj = new Module();
                    obj.ModuleId = drow["ModuleId"].ToString();
                    obj.ModuleDesc = drow["ModuleDesc"].ToString();
                    obj.DisplaySeq = int.Parse(drow["DisplaySeq"].ToString());
                    obj.Active = drow["Active"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Module module)
        {
            string sp = "module_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ModuleId", module.ModuleId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModuleDesc", module.ModuleDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DisplaySeq", module.DisplaySeq, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", module.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", module.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(Module module)
        {
            string sp = "module_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ModuleId", module.ModuleId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModuleDesc", module.ModuleDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DisplaySeq", module.DisplaySeq, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", module.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Module> lst = new List<Module>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Module obj = new Module();
                    obj.ModuleId = drow["ModuleId"].ToString();
                    obj.ModuleDesc = drow["ModuleDesc"].ToString();
                    obj.DisplaySeq = int.Parse(drow["DisplaySeq"].ToString());
                    obj.Active = drow["Active"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetModuleShort()
        {
            string sp = "security_pkg.p_module_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Module> lst = new List<Module>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Module obj = new Module();
                    obj.ModuleId = drow["MODULE_ID"].ToString();
                    obj.ModuleDesc = drow["MODULE_DESC"].ToString();
                    
                    obj.Action = "U";
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
