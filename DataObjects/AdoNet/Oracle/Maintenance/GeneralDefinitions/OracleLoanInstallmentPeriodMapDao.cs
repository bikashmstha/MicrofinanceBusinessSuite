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
    public class OracleLoanInstallmentPeriodMapDao:ILoanInstallmentPeriodMapDao
    {
        private List<OracleParameter> PrepareParameterList(LoanInstallmentPeriodMap loanInstallmentPeriodMap)
        {/*p_install_period            IN     NUMBER,
      p_installment_period_type   IN     VARCHAR2,
      p_loan_period               IN     VARCHAR2,
      p_loan_period_type          IN     VARCHAR2,
      p_no_of_installment         IN     NUMBER,
      p_created_modified_on       IN     DATE,
      p_created_modified_by       IN     VARCHAR2,
      p_active                    IN     VARCHAR2,
      p_insert_update             IN     VARCHAR2,
      v_out_result_code              OUT VARCHAR2,
      v_out_result_msg               OUT VARCHAR2 */
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_install_period", loanInstallmentPeriodMap.InstallmentPeriod, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_installment_period_type", loanInstallmentPeriodMap.InstallmentPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period", loanInstallmentPeriodMap.LoanPeriod, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period_type", loanInstallmentPeriodMap.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_no_of_installment", loanInstallmentPeriodMap.NoOfInstallment, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanInstallmentPeriodMap.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanInstallmentPeriodMap.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active", loanInstallmentPeriodMap.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", loanInstallmentPeriodMap.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[9].Size = 10;
            paramList[10].Size = 100;

            return paramList;

        }
        public List<LoanInstallmentPeriodMap> GetLoanInstallmentPeriodMap()
        {
            try
            {
               string SP = "ms_general_definition_pkg.p_loan_installment_map";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanInstallmentPeriodMap> lst = new List<LoanInstallmentPeriodMap>();


                LoanInstallmentPeriodMap obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new LoanInstallmentPeriodMap();
                    /*INSTALL_PERIOD, 
                        INSTALLMENT_PERIOD_TYPE, 
                        MS_REF_CODE_PKG.F_REF_DTL_NAME ('INSTALLMENT_PERIOD_TYPE', INSTALLMENT_PERIOD_TYPE) INSTALLMENT_PERIOD_TYPE_DET, 
                        LOAN_PERIOD, 
                        LOAN_PERIOD_TYPE, 
                        MS_REF_CODE_PKG.F_REF_DTL_NAME ('LOAN_PERIOD_TYPE', LOAN_PERIOD_TYPE) LOAN_PERIOD_TYPE_DET, 
                        NO_OF_INSTALLMENT, 
                        CREATED_ON, 
                        CREATED_BY, 
                        MODIFIED_ON, 
                        MODIFIED_BY, 
                        ACTIVE*/
                    obj.InstallmentPeriod = drow["INSTALL_PERIOD"].ToString();//APPLICATION_ID
                    obj.InstallmentPeriodType = drow["INSTALLMENT_PERIOD_TYPE"].ToString();//APPLICATION_DESCRIPTION
                    obj.InstallmentPeriodTypeDet =drow["INSTALLMENT_PERIOD_TYPE_DET"].ToString();//APPLICATION_ID
                    obj.LoanPeriod = drow["LOAN_PERIOD"].ToString();//APPLICATION_DESCRIPTION
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();//APPLICATION_ID
                    obj.LoanPeriodTypeDet = drow["LOAN_PERIOD_TYPE_DET"].ToString();//APPLICATION_DESCRIPTION
                    obj.NoOfInstallment =Int16.Parse( drow["NO_OF_INSTALLMENT"].ToString());
                    obj.CreatedOn = drow["CREATED_ON"].ToString();//APPLICATION_DESCRIPTION
                    obj.CreatedBy = drow["CREATED_BY"].ToString();//APPLICATION_ID
                    obj.ModifiedOn = drow["MODIFIED_ON"].ToString();//APPLICATION_DESCRIPTION
                    obj.ModifiedBy = drow["MODIFIED_ON"].ToString();//APPLICATION_ID
                    obj.Active = drow["ACTIVE"].ToString();//APPLICATION_DESCRIPTION
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

        public OutMessage SaveLoanInstallmentPeriodMap(LoanInstallmentPeriodMap loanInstallmentPeriodMap)
        {
            string SP = "ms_general_definition_pkg.p_insert_update_li_period_map"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(loanInstallmentPeriodMap);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[9].Value.ToString();
                oMsg.OutResultMessage = paramList[10].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}
