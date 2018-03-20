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
    public class OracleInterestSchemeDetailDao : IInterestSchemeDetailDao
    {
        public object SaveInterestSchemeDetail(InterestSchemeDetail interestSchemeDetail)
        {
            string sp = "interestSchemeDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", interestSchemeDetail.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_DESC", interestSchemeDetail.IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR", interestSchemeDetail.SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE", interestSchemeDetail.EffectiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE_BS", interestSchemeDetail.EffectiveDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL", interestSchemeDetail.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL_BS", interestSchemeDetail.ValidTillBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", interestSchemeDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON_BS", interestSchemeDetail.CreatedOnBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", interestSchemeDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR_DESC", interestSchemeDetail.SchemeForDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", interestSchemeDetail.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", interestSchemeDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchInterestSchemeDetail(InterestSchemeDetail interestSchemeDetail)
        {
            string sp = "interestSchemeDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", interestSchemeDetail.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_DESC", interestSchemeDetail.IntSchemeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR", interestSchemeDetail.SchemeFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE", interestSchemeDetail.EffectiveDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EFFECTIVE_DATE_BS", interestSchemeDetail.EffectiveDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL", interestSchemeDetail.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL_BS", interestSchemeDetail.ValidTillBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", interestSchemeDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON_BS", interestSchemeDetail.CreatedOnBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", interestSchemeDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHEME_FOR_DESC", interestSchemeDetail.SchemeForDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE_FLAG", interestSchemeDetail.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<InterestSchemeDetail> lst = new List<InterestSchemeDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    InterestSchemeDetail obj = new InterestSchemeDetail();
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

        public object GetIntSchemeDtl(string IntSchemeCode)
        {
            string sp = "FN_INTEREST_SCHEME_PKG.p_int_scheme_dtl_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_INT_SCHEME_CODE", IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<InterestSchemeDetail> lst = new List<InterestSchemeDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    InterestSchemeDetail obj = new InterestSchemeDetail();
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
