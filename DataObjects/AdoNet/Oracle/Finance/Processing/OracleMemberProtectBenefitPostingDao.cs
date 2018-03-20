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
    public class OracleMemberProtectBenefitPostingDao : IMemberProtectBenefitPostingDao
    {
        public object SaveMemberProtectBenefitPosting(List<MemberProtectBenefitPosting> memberProtectBenefitPostings)
        {
            string sp = "daily_transaction_pkg.p_mem_protect_benefit_posting";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();

                foreach (MemberProtectBenefitPosting memberProtectBenefitPosting in memberProtectBenefitPostings)
                {
                    paramList = new List<OracleParameter>();
                    paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", memberProtectBenefitPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memberProtectBenefitPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_NO", memberProtectBenefitPosting.BenefitNo, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_USER1", memberProtectBenefitPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());

                }
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchMemberProtectBenefitPosting(MemberProtectBenefitPosting memberProtectBenefitPosting)
        {
            string sp = "memberProtectBenefitPosting_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_OFFICE_CODE", memberProtectBenefitPosting.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSACTION_DATE", memberProtectBenefitPosting.TransactionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BENEFIT_NO", memberProtectBenefitPosting.BenefitNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", memberProtectBenefitPosting.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MemberProtectBenefitPosting> lst = new List<MemberProtectBenefitPosting>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MemberProtectBenefitPosting obj = new MemberProtectBenefitPosting();
                    obj.OfficeCode = drow["OFFICE_CODE"].ToString();
                    obj.TransactionDate = drow["TRANSACTION_DATE"].ToString();
                    obj.BenefitNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BENEFIT_NO"].ToString()));
                    obj.User1 = drow["USER1"].ToString();

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
