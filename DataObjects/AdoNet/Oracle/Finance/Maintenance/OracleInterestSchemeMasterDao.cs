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
    public class OracleInterestSchemeMasterDao : IInterestSchemeMasterDao
    {
        public object SaveInterestSchemeMaster(InterestSchemeMaster interestSchemeMaster)
        {
            string sp = "interestSchemeMaster_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", interestSchemeMaster.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_DESC", interestSchemeMaster.IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR", interestSchemeMaster.SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE", interestSchemeMaster.EffectiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE_BS", interestSchemeMaster.EffectiveDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL", interestSchemeMaster.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL_BS", interestSchemeMaster.ValidTillBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", interestSchemeMaster.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON_BS", interestSchemeMaster.CreatedOnBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", interestSchemeMaster.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR_DESC", interestSchemeMaster.SchemeForDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", interestSchemeMaster.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", interestSchemeMaster.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchInterestSchemeMaster(InterestSchemeMaster interestSchemeMaster)
        {
            string sp = "interestSchemeMaster_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", interestSchemeMaster.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_DESC", interestSchemeMaster.IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR", interestSchemeMaster.SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE", interestSchemeMaster.EffectiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE_BS", interestSchemeMaster.EffectiveDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL", interestSchemeMaster.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL_BS", interestSchemeMaster.ValidTillBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", interestSchemeMaster.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON_BS", interestSchemeMaster.CreatedOnBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", interestSchemeMaster.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR_DESC", interestSchemeMaster.SchemeForDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", interestSchemeMaster.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<InterestSchemeMaster> lst = new List<InterestSchemeMaster>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    InterestSchemeMaster obj = new InterestSchemeMaster();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.IntSchemeDesc = drow["INT_SCHEME_DESC"].ToString();
                    obj.SchemeFor = drow["SCHEME_FOR"].ToString();
                    obj.EffectiveDate = drow["EFFECTIVE_DATE"].ToString();
                    obj.EffectiveDateBs = drow["EFFECTIVE_DATE_BS"].ToString();
                    obj.ValidTill = drow["VALID_TILL"].ToString();
                    obj.ValidTillBs = drow["VALID_TILL_BS"].ToString();

                    obj.CreatedOnBs = drow["CREATED_ON_BS"].ToString();

                    obj.SchemeForDesc = drow["SCHEME_FOR_DESC"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetIntSchemeMasterList(string IntSchemeCode, string IntSchemeDesc, string SchemeFor)
        {
            string sp = "FN_INTEREST_SCHEME_PKG.p_int_scheme_master_list ";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_INT_SCHEME_CODE", IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_INT_SCHEME_DESC", IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SCHEME_FOR", SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<InterestSchemeMaster> lst = new List<InterestSchemeMaster>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    InterestSchemeMaster obj = new InterestSchemeMaster();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.IntSchemeDesc = drow["INT_SCHEME_DESC"].ToString();
                    obj.SchemeFor = drow["SCHEME_FOR"].ToString();
                    obj.EffectiveDate = drow["EFFECTIVE_DATE"].ToString();
                    obj.EffectiveDateBs = drow["EFFECTIVE_DATE_BS"].ToString();
                    obj.ValidTill = drow["VALID_TILL"].ToString();
                    obj.ValidTillBs = drow["VALID_TILL_BS"].ToString();

                    obj.CreatedOnBs = drow["CREATED_ON_BS"].ToString();

                    obj.SchemeForDesc = drow["SCHEME_FOR_DESC"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();

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
