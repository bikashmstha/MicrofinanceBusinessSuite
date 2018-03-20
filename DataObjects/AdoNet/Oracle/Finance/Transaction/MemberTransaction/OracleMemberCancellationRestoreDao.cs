using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMemberCancellationRestoreDao : IMemberCancellationRestoreDao
    {
        public object Get()
        {
            string sp = "membercancellationrestore_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberCancellationRestore> lst = new List<MemberCancellationRestore>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberCancellationRestore obj = new MemberCancellationRestore();
                    obj.GroupCode = drow["GroupCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.MembershipClosedDate = drow["MembershipClosedDate"].ToString();
                    obj.TransType = drow["TransType"].ToString();
                    obj.Active = drow["Active "].ToString();
                    obj.ReasonsForInactive = drow["ReasonsForInactive"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MemberCancellationRestore membercancellationrestore)
        {
            string sp = "fn_member_clients_pkg.p_member_cancellation_restore";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_GroupCode", membercancellationrestore.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", membercancellationrestore.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MembershipClosedDate", membercancellationrestore.MembershipClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransType", membercancellationrestore.TransType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active ", membercancellationrestore.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonsForInactive", membercancellationrestore.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", membercancellationrestore.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
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

        public object Search(MemberCancellationRestore membercancellationrestore)
        {
            string sp = "membercancellationrestore_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_GroupCode", membercancellationrestore.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", membercancellationrestore.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MembershipClosedDate", membercancellationrestore.MembershipClosedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransType", membercancellationrestore.TransType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active ", membercancellationrestore.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonsForInactive", membercancellationrestore.ReasonsForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", membercancellationrestore.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberCancellationRestore> lst = new List<MemberCancellationRestore>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberCancellationRestore obj = new MemberCancellationRestore();
                    obj.GroupCode = drow["GroupCode"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.MembershipClosedDate = drow["MembershipClosedDate"].ToString();
                    obj.TransType = drow["TransType"].ToString();
                    obj.Active = drow["Active "].ToString();
                    obj.ReasonsForInactive = drow["ReasonsForInactive"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();

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
