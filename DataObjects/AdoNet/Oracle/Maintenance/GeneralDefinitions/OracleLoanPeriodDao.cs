using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;
using DataObjects.Interfaces.Maintenance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Maintenance
{
    public class OracleLoanPeriodDao : ILoanPeriodDao
    {
        private List<OracleParameter> PrepareParameterList(LoanPeriod loanPeriod)
        {/*
      p_loan_period           IN     NUMBER,
      p_loan_period_desc      IN     VARCHAR2,
      p_loan_period_type      IN     VARCHAR2,
      p_created_modified_on   IN     DATE,
      p_created_modified_by   IN     VARCHAR2,
      p_active                IN     VARCHAR2,
      p_insert_update         IN     VARCHAR2,
      v_out_result_code          OUT VARCHAR2,
      v_out_result_msg           OUT VARCHAR2*/
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period", loanPeriod.LoanPeriods, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period_desc", loanPeriod.LoanPeriodDesc, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period_type", loanPeriod.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanPeriod.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanPeriod.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active", loanPeriod.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", loanPeriod.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[7].Size = 10;
            paramList[8].Size = 100;

            return paramList;

        }
        public List<LoanPeriod> GetLoanPeriod()
        {
            try
            {
                string SP = "ms_general_definition_pkg.p_loan_period_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanPeriod> lst = new List<LoanPeriod>();


                LoanPeriod obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new LoanPeriod();
                    /*LOAN_PERIOD, 
                                 LOAN_PERIOD_DESC, 
                                 LOAN_PERIOD_TYPE, 
                                 MS_REF_CODE_PKG.F_REF_DTL_NAME('LOAN_PERIOD_TYPE',LOAN_PERIOD_TYPE) LOAN_PERIOD_TYPE_DET, 
                                 CREATED_ON, 
                                 CREATED_BY, 
                                 MODIFIED_ON, 
                                 MODIFIED_BY, 
                                 ACTIVE 
                            FROM FN_LOAN_PERIOD */
                    obj.LoanPeriods = drow["LOAN_PERIOD"].ToString();//APPLICATION_ID
                    obj.LoanPeriodDesc = drow["LOAN_PERIOD_DESC"].ToString();//APPLICATION_DESCRIPTION
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();//APPLICATION_ID
                    obj.LoanPeriodTypeDet = drow["LOAN_PERIOD_TYPE_DET"].ToString();//APPLICATION_DESCRIPTION
                    obj.CreatedOn = drow["CREATED_ON"].ToString();//APPLICATION_ID
                    obj.CreatedBy = drow["CREATED_BY"].ToString();//APPLICATION_DESCRIPTION
                    obj.ModifiedOn =drow["MODIFIED_ON"].ToString();//APPLICATION_ID
                    obj.ModifiedBy = drow["MODIFIED_BY"].ToString();//APPLICATION_DESCRIPTION
                    obj.Active = drow["ACTIVE"].ToString();//APPLICATION_ID
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

        public OutMessage SaveLoanPeriod(LoanPeriod loanPeriod)
        {
            string SP = "ms_general_definition_pkg.p_insert_update_loan_period"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(loanPeriod);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
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

    }
}
