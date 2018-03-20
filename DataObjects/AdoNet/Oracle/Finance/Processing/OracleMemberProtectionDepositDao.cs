using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMemberProtectionDepositDao : IMemberProtectionDepositDao
    {
        public object SaveMemberProtectionDeposit(MemberProtectionDeposit memberProtectionDeposit)
        {
            string sp = "memberProtectionDeposit_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_PROTECTION_CODE", memberProtectionDeposit.MemProtectionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", memberProtectionDeposit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", memberProtectionDeposit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", memberProtectionDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", memberProtectionDeposit.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRO_DEPOSIT_NO", memberProtectionDeposit.ProDepositNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", memberProtectionDeposit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memberProtectionDeposit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchMemberProtectionDeposit(MemberProtectionDeposit memberProtectionDeposit)
        {
            string sp = "memberProtectionDeposit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_PROTECTION_CODE", memberProtectionDeposit.MemProtectionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", memberProtectionDeposit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_DATE", memberProtectionDeposit.DepositDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEPOSIT_AMOUNT", memberProtectionDeposit.DepositAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CURRENT_BALANCE", memberProtectionDeposit.CurrentBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRO_DEPOSIT_NO", memberProtectionDeposit.ProDepositNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", memberProtectionDeposit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberProtectionDeposit> lst = new List<MemberProtectionDeposit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberProtectionDeposit obj = new MemberProtectionDeposit();
                    obj.MemProtectionCode = drow["MEM_PROTECTION_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                    obj.ProDepositNo = drow["PRO_DEPOSIT_NO"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemProtectDeposit(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_mem_protect_deposit_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER_CODE", UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberProtectionDeposit> lst = new List<MemberProtectionDeposit>();

                for (int i = 0; i < 10; i++)
                {

                    MemberProtectionDeposit obj = new MemberProtectionDeposit();
                    obj.MemProtectionCode = i.ToString();
                    obj.ClientName = i.ToString();
                    obj.DepositDate = i.ToString();
                    obj.DepositAmount = i;
                    obj.CurrentBalance = i;
                    obj.ProDepositNo = i.ToString();
                    obj.AccountDesc = i.ToString();

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    MemberProtectionDeposit obj = new MemberProtectionDeposit();
                //    obj.MemProtectionCode = drow["MEM_PROTECTION_CODE"].ToString();
                //    obj.ClientName = drow["CLIENT_NAME"].ToString();
                //    obj.DepositDate = drow["DEPOSIT_DATE"].ToString();
                //    obj.DepositAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEPOSIT_AMOUNT"].ToString()));
                //    obj.CurrentBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CURRENT_BALANCE"].ToString()));
                //    obj.ProDepositNo = drow["PRO_DEPOSIT_NO"].ToString();
                //    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();

                //    lst.Add(obj);
                //}
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
