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
    public class OracleLiveProtectBenefitDao : ILiveProtectBenefitDao
    {
        public object SaveLiveProtectBenefit(LiveProtectBenefit LiveProtectBenefit)
        {
            string sp = "LiveProtectBenefit_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_DATE", LiveProtectBenefit.BenefitDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_NO", LiveProtectBenefit.BenefitNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFITED_AMOUNT", LiveProtectBenefit.BenefitedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PROTECTION_CODE", LiveProtectBenefit.LoanProtectionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", LiveProtectBenefit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", LiveProtectBenefit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_INFO", LiveProtectBenefit.BenefitInfo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", LiveProtectBenefit.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchLiveProtectBenefit(LiveProtectBenefit LiveProtectBenefit)
        {
            string sp = "LiveProtectBenefit_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_DATE", LiveProtectBenefit.BenefitDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_NO", LiveProtectBenefit.BenefitNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFITED_AMOUNT", LiveProtectBenefit.BenefitedAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PROTECTION_CODE", LiveProtectBenefit.LoanProtectionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NAME", LiveProtectBenefit.ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", LiveProtectBenefit.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_INFO", LiveProtectBenefit.BenefitInfo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LiveProtectBenefit> lst = new List<LiveProtectBenefit>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LiveProtectBenefit obj = new LiveProtectBenefit();
                    obj.BenefitDate = drow["BENEFIT_DATE"].ToString();
                    obj.BenefitNo = drow["BENEFIT_NO"].ToString();
                    obj.BenefitedAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BENEFITED_AMOUNT"].ToString()));
                    obj.LoanProtectionCode = drow["LOAN_PROTECTION_CODE"].ToString();
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

        public object GetLiveProtectBenifit(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_live_protect_benifit_list";
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
                List<LiveProtectBenefit> lst = new List<LiveProtectBenefit>();

                for (int i = 0; i < 10; i++)
                {

                    LiveProtectBenefit obj = new LiveProtectBenefit();
                    obj.BenefitDate = i.ToString();
                    obj.BenefitNo = i.ToString();
                    obj.BenefitedAmount = i;
                    obj.ClientName = i.ToString();
                    obj.AccountDesc = i.ToString();
                    obj.BenefitInfo = i.ToString();

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    LiveProtectBenefit obj = new LiveProtectBenefit();
                //    obj.BenefitDate = drow["BENEFIT_DATE"].ToString();
                //    obj.BenefitNo = drow["BENEFIT_NO"].ToString();
                //    obj.BenefitedAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BENEFITED_AMOUNT"].ToString()));
                //    obj.LoanProtectionCode = drow["LOAN_PROTECTION_CODE"].ToString();
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
