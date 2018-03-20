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
    class OracleLoanSubSectorDao : ILoanSubSectorDao
    {
        private List<OracleParameter> PrepareParameterList(LoanSubSector loanSubSector)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_loan_sector_code", loanSubSector.LoanSectorCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sub_sector_code", loanSubSector.LoanSubSectorCode,OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_sub_sector_desc", loanSubSector.LoanSubSectorDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanSubSector.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanSubSector.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":p_insert_update_delete", loanSubSector.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;

            return paramList;

        }

        public List<LoanSubSector> GetLoanSubSector()
        {
            try
            {

                string SP = "MS_LOAN_PURPOSE_PKG.p_loan_sub_sector_list";

                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanSubSector> lst = new List<LoanSubSector>();


                LoanSubSector obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new LoanSubSector();
                    obj.LoanSubSectorCode = drow["SUB_SECTOR_CODE"].ToString();
                    obj.LoanSubSectorDesc = drow["SUB_SECTOR_DESC"].ToString();

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

        public OutMessage SaveLoanSubSector(LoanSubSector loanSubSector)
        {
            string SP = "ms_loan_purpose_pkg.p_iud_loan_sub_sector";
            OutMessage oMsg = new OutMessage();
            OracleConnection conn = new GetConnection().GetDbConn();
            List<OracleParameter> paramList = PrepareParameterList(loanSubSector);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[6].Value.ToString();
                oMsg.OutResultMessage = paramList[7].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
