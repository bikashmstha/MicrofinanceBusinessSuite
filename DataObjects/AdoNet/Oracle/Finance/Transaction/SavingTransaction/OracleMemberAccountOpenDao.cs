using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMemberAccountOpenDao : IMemberAccountOpenDao
    {
        public object Get()
        {
            string sp = "memberAccountOpen_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberAccountOpen> lst = new List<MemberAccountOpen>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberAccountOpen obj = new MemberAccountOpen();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MemberAccountOpen memberAccountOpen)
        {
            string sp = "memberAccountOpen_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", memberAccountOpen.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", memberAccountOpen.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", memberAccountOpen.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", memberAccountOpen.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", memberAccountOpen.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", memberAccountOpen.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memberAccountOpen.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MemberAccountOpen memberAccountOpen)
        {
            string sp = "memberAccountOpen_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", memberAccountOpen.AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", memberAccountOpen.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientName", memberAccountOpen.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CenterName", memberAccountOpen.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", memberAccountOpen.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", memberAccountOpen.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberAccountOpen> lst = new List<MemberAccountOpen>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberAccountOpen obj = new MemberAccountOpen();
                    obj.AccountNo = drow["AccountNo"].ToString();
                    obj.SavingAccountNo = drow["SavingAccountNo"].ToString();
                    obj.ClientName = drow["ClientName"].ToString();
                    obj.CenterName = drow["CenterName"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

       

        public object GetMemberAccount( string offCode, string memberName)
        {
            string sp = "fn_member_clients_pkg.p_mem_ac_open_search_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_AccountNo", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountNo", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_rc", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberAccountOpen> lst = new List<MemberAccountOpen>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberAccountOpen obj = new MemberAccountOpen();
                    obj.AccountNo = drow["Account_No"].ToString();
                    obj.SavingAccountNo = drow["Saving_Account_No"].ToString();
                    obj.ClientName = drow["Client_Name"].ToString();
                    obj.CenterName = drow["Center_Name"].ToString();
                    obj.ClientCode = drow["Client_Code"].ToString();
                    obj.RowCount = double.Parse(drow["Row_Count"].ToString());

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
