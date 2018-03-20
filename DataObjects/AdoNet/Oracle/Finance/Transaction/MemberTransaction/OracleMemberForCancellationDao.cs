using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Transaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMemberForCancellationDao : IMemberForCancellationDao
    {
        public object Get()
        {
            string sp = "memberforcancellation_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberForCancellation> lst = new List<MemberForCancellation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberForCancellation obj = new MemberForCancellation();
                    obj.MembershipCloseDate = drow["MembershipCloseDate"].ToString();
                    obj.MemCloseDateBs = drow["MemCloseDateBs"].ToString();
                    obj.MembershipDate = drow["MembershipDate"].ToString();
                    obj.MemDateBs = drow["MemDateBs"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.GroupCode = drow["GroupCode"].ToString();
                    obj.GroupName = drow["GroupName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.NomineeName = drow["NomineeName"].ToString();
                    obj.NomineeRelation = drow["NomineeRelation"].ToString();
                    obj.ReasonForInactive = drow["ReasonForInactive"].ToString();
                    obj.Active = drow["Active"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.RowCount = int.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MemberForCancellation memberforcancellation)
        {
            string sp = "memberforcancellation_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MembershipCloseDate", memberforcancellation.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MemCloseDateBs", memberforcancellation.MemCloseDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MembershipDate", memberforcancellation.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MemDateBs", memberforcancellation.MemDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", memberforcancellation.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", memberforcancellation.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", memberforcancellation.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GroupCode", memberforcancellation.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GroupName", memberforcancellation.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", memberforcancellation.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", memberforcancellation.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", memberforcancellation.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NomineeRelation", memberforcancellation.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForInactive", memberforcancellation.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", memberforcancellation.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", memberforcancellation.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", memberforcancellation.RowCount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memberforcancellation.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MemberForCancellation memberforcancellation)
        {
            string sp = "fn_member_clients_pkg.p_member_for_cafsdfgsdfgdfgncel_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                   paramList.Add(SqlHelper.GetOraParam(":p_MembershipCloseDate", memberforcancellation.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MemCloseDateBs", memberforcancellation.MemCloseDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MembershipDate", memberforcancellation.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MemDateBs", memberforcancellation.MemDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", memberforcancellation.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", memberforcancellation.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", memberforcancellation.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GroupCode", memberforcancellation.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GroupName", memberforcancellation.GroupName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", memberforcancellation.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", memberforcancellation.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", memberforcancellation.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NomineeRelation", memberforcancellation.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReasonForInactive", memberforcancellation.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", memberforcancellation.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", memberforcancellation.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", memberforcancellation.RowCount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberForCancellation> lst = new List<MemberForCancellation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberForCancellation obj = new MemberForCancellation();
                    obj.MembershipCloseDate = drow["MembershipCloseDate"].ToString();
                    obj.MemCloseDateBs = drow["MemCloseDateBs"].ToString();
                    obj.MembershipDate = drow["MembershipDate"].ToString();
                    obj.MemDateBs = drow["MemDateBs"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.GroupCode = drow["GroupCode"].ToString();
                    obj.GroupName = drow["GroupName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.NomineeName = drow["NomineeName"].ToString();
                    obj.NomineeRelation = drow["NomineeRelation"].ToString();
                    obj.ReasonForInactive = drow["ReasonForInactive"].ToString();
                    obj.Active = drow["Active"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();
                    obj.RowCount = int.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object GetMemberForCancelList(string offCode, string centerCode, string memberName, string clientNo)
        {
            string sp = "fn_member_clients_pkg.p_member_for_cancel_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_name", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_client_no", clientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberForCancellation> lst = new List<MemberForCancellation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberForCancellation obj = new MemberForCancellation();
                    obj.MembershipCloseDate = drow["MEMBERSHIP_CLOSE_DATE"].ToString();
                    obj.MemCloseDateBs = drow["MEM_CLOSE_DATE_BS"].ToString();
                    obj.MembershipDate = drow["MEMBERSHIP_DATE"].ToString();
                    obj.MemDateBs = drow["MEM_DATE_BS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupName = drow["GROUP_NAME"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.NomineeRelation = drow["NOMINEE_RELATION"].ToString();
                    obj.ReasonForInactive = drow["REASON_FOR_INACTIVE"].ToString();
                    obj.Active = drow["Active"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.RowCount = int.Parse(drow["ROW_COUNT"].ToString());

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
