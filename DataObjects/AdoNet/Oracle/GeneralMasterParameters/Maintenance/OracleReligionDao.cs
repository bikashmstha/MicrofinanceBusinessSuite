using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleReligionDao : IReligionDao
    {
        public object Get()
        {
            string sp = "ms_religion_pkg.p_religion_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Religion> lst = new List<Religion>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Religion obj = new Religion();
                    obj.ReligionCode = drow["RELIGION_CODE"].ToString();
                    obj.ReligionDesc = drow["RELIGION_DESC"].ToString();
                    //obj.CreatedBy = drow["CREATED_BY"].ToString();
                    //obj.CreatedOn = drow["CREATED_ON"].ToString();
                    obj.CibCode = drow["CIB_CODE"].ToString();
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Religion religion)
        {
            string sp = "ms_religion_pkg.p_religion";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ReligionCode", religion.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReligionDesc", religion.ReligionDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CibCode", religion.CibCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", religion.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", religion.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", religion.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 10;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString();
                oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(Religion religion)
        {
            string sp = "ms_religion_pkg.p_religion_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_ReligionCode", religion.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReligionDesc", religion.ReligionDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", religion.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", religion.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CibCode", religion.CibCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Religion> lst = new List<Religion>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Religion obj = new Religion();
                    obj.ReligionCode = drow["ReligionCode"].ToString();
                    obj.ReligionDesc = drow["ReligionDesc"].ToString();
                    obj.CreatedBy = drow["CreatedBy"].ToString();
                    obj.CreatedOn = drow["CreatedOn"].ToString();
                    obj.CibCode = drow["CibCode"].ToString();

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
