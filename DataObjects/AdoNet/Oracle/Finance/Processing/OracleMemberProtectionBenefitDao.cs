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
    public class OracleMemberProtectionBenefitDao : IMemberProtectionBenefitDao
    {
        public object SaveMemberProtectionBenefit(MemberProtectionBenefit memberProtectionBenefit)
        {
            string sp = "memberProtectionBenefit_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_DATE", memberProtectionBenefit.BenefitDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_NO", memberProtectionBenefit.BenefitNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFITED_AMOUNT", memberProtectionBenefit.BenefitedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_PROTECTION_CODE", memberProtectionBenefit.MemProtectionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", memberProtectionBenefit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", memberProtectionBenefit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_INFO", memberProtectionBenefit.BenefitInfo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", memberProtectionBenefit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchMemberProtectionBenefit(MemberProtectionBenefit memberProtectionBenefit)
        {
            string sp = "memberProtectionBenefit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_DATE", memberProtectionBenefit.BenefitDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_NO", memberProtectionBenefit.BenefitNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFITED_AMOUNT", memberProtectionBenefit.BenefitedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_PROTECTION_CODE", memberProtectionBenefit.MemProtectionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", memberProtectionBenefit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", memberProtectionBenefit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_INFO", memberProtectionBenefit.BenefitInfo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberProtectionBenefit> lst = new List<MemberProtectionBenefit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberProtectionBenefit obj = new MemberProtectionBenefit();
                    obj.BenefitDate = drow["BENEFIT_DATE"].ToString();
                    obj.BenefitNo = drow["BENEFIT_NO"].ToString();
                    obj.BenefitedAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BENEFITED_AMOUNT"].ToString()));
                    obj.MemProtectionCode = drow["MEM_PROTECTION_CODE"].ToString();
                    obj.ClientName = drow["CLIENT_NAME"].ToString();
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.BenefitInfo = drow["BENEFIT_INFO"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemProtectBenifit(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_mem_protect_benifit_list";
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
                List<MemberProtectionBenefit> lst = new List<MemberProtectionBenefit>();

                for (int i = 0; i < 10; i++)
                {

                    MemberProtectionBenefit obj = new MemberProtectionBenefit();
                    obj.BenefitDate = i.ToString();
                    obj.BenefitNo = i.ToString();
                    obj.BenefitedAmount = i;
                    obj.MemProtectionCode = i.ToString();
                    obj.ClientName = i.ToString();
                    obj.AccountDesc = i.ToString();
                    obj.BenefitInfo = i.ToString();

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    MemberProtectionBenefit obj = new MemberProtectionBenefit();
                //    obj.BenefitDate = drow["BENEFIT_DATE"].ToString();
                //    obj.BenefitNo = drow["BENEFIT_NO"].ToString();
                //    obj.BenefitedAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BENEFITED_AMOUNT"].ToString()));
                //    obj.MemProtectionCode = drow["MEM_PROTECTION_CODE"].ToString();
                //    obj.ClientName = drow["CLIENT_NAME"].ToString();
                //    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                //    obj.BenefitInfo = drow["BENEFIT_INFO"].ToString();

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
