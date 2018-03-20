using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanPurposeDao : ILoanPurposeDao
    {
        private List<OracleParameter> PrepareParameterList(LoanPurpose loanPurpose)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_loan_purpose_code", loanPurpose.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_purpose_desc", loanPurpose.LoanPurposeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sub_sector_code", loanPurpose.SubSectorCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_cib_code", loanPurpose.CibCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanPurpose.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanPurpose.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", loanPurpose.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;

            return paramList;

        }


        public List<LoanPurpose> GetLoanPurpose()
        {
            try
            {

                string SP = "MS_LOAN_PURPOSE_PKG.p_loan_purpose_list";

                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanPurpose> lst = new List<LoanPurpose>();


                LoanPurpose obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new LoanPurpose();
                    obj.LoanPurposeCode = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.LoanPurposeDesc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.SubSectorCode = drow["SUB_SECTOR_CODE"].ToString();
                    obj.SubSectorDesc = drow["SUB_SECTOR_DESC"].ToString();
                    obj.CibCode = drow["CIB_CODE"].ToString();
                   
                    obj.Action = "U";

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public OutMessage SaveLoanPurpose(LoanPurpose loanPurpose)
        {
            string SP = "ms_loan_purpose_pkg.p_iud_loan_purpose_det";
            OutMessage oMsg = new OutMessage();
            OracleConnection conn = new GetConnection().GetDbConn();
            List<OracleParameter> paramList = PrepareParameterList(loanPurpose);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[7].Value.ToString();
                oMsg.OutResultMessage = paramList[8].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object GetMfLoanPurpose(string productCode, string purposeName)
        {
            string sp = "fn_loan_pkg.p_mf_loan_purpose_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanSectorCode", productCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanSectorDesc", purposeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Sector> lst = new List<Sector>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {

                    Sector obj = new Sector();
                    obj.LoanSectorCode = drow["SUB_SECTOR_CODE"].ToString();
                    obj.LoanSectorDesc = drow["SUB_SECTOR_DESC"].ToString();
                    obj.LoanPurposeCode = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.LoanPurposeDesc = drow["LOAN_PURPOSE_DESC"].ToString();


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
