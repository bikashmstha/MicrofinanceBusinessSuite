using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;
namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMainInterestSchemeDao : IMainInterestSchemeDao
    {
        public object Get()
        {
            string sp = "mainInterestScheme_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MainInterestScheme> lst = new List<MainInterestScheme>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MainInterestScheme obj = new MainInterestScheme();
                    obj.IntSchemeCode = drow["IntSchemeCode"].ToString();
                    obj.IntSchemeDesc = drow["IntSchemeDesc"].ToString();
                    obj.SchemeFor = drow["SchemeFor"].ToString();
                    obj.EffectiveDate = drow["EffectiveDate"].ToString();
                    obj.ValidTill = drow["ValidTill"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.ActiveFlag = drow["ActiveFlag"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MainInterestScheme mainInterestScheme)
        {
            string sp = "mainInterestScheme_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeCode", mainInterestScheme.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeDesc", mainInterestScheme.IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SchemeFor", mainInterestScheme.SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EffectiveDate", mainInterestScheme.EffectiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ValidTill", mainInterestScheme.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", mainInterestScheme.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", mainInterestScheme.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", mainInterestScheme.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", mainInterestScheme.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlag", mainInterestScheme.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mainInterestScheme.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MainInterestScheme mainInterestScheme)
        {
            string sp = "mainInterestScheme_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeCode", mainInterestScheme.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeDesc", mainInterestScheme.IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SchemeFor", mainInterestScheme.SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EffectiveDate", mainInterestScheme.EffectiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ValidTill", mainInterestScheme.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", mainInterestScheme.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", mainInterestScheme.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", mainInterestScheme.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", mainInterestScheme.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlag", mainInterestScheme.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MainInterestScheme> lst = new List<MainInterestScheme>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MainInterestScheme obj = new MainInterestScheme();
                    obj.IntSchemeCode = drow["IntSchemeCode"].ToString();
                    obj.IntSchemeDesc = drow["IntSchemeDesc"].ToString();
                    obj.SchemeFor = drow["SchemeFor"].ToString();
                    obj.EffectiveDate = drow["EffectiveDate"].ToString();
                    obj.ValidTill = drow["ValidTill"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.ActiveFlag = drow["ActiveFlag"].ToString();

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
