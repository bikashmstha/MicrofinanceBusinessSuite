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
    public class OracleLoanSectorDao : ILoanSectorDao
    {
        private List<OracleParameter> PrepareParameterList(LoanSector loanSector)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_loan_sector_code", loanSector.LoanSectorCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_sector_desc", loanSector.LoanSectorDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanSector.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanSector.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", loanSector.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;

            return paramList;

        }


        public List<LoanSector> GetLoanSector()
        {
            try
            {

                string SP = "MS_LOAN_PURPOSE_PKG.p_loan_sector_list";

                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanSector> lst = new List<LoanSector>();


                LoanSector obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new LoanSector();
                    obj.LoanSectorCode = drow["LOAN_SECTOR_CODE"].ToString();
                    obj.LoanSectorDesc = drow["LOAN_SECTOR_DESC"].ToString();
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

        public OutMessage SaveLoanSector(LoanSector loanSector)
        {
            string SP = "ms_loan_purpose_pkg.p_iud_loan_sector"; 
            OutMessage oMsg = new OutMessage();
            OracleConnection conn = new GetConnection().GetDbConn();
            List<OracleParameter> paramList = PrepareParameterList(loanSector);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[5].Value.ToString();
                oMsg.OutResultMessage = paramList[6].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
