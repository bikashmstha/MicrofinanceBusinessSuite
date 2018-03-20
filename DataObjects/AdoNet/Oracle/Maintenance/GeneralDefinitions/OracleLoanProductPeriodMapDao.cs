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
    public class OracleLoanProductPeriodMapDao:ILoanProductPeriodMapDao
    {
        private List<OracleParameter> PrepareParameterList(LoanProductPeriodMap loanProductPeriodMap)
        {
            /* LOAN_PERIOD        VARCHAR2(10 BYTE),
  LOAN_PERIOD_TYPE   VARCHAR2(5 BYTE),
  LOAN_PRODUCT_CODE  VARCHAR2(2 BYTE),
  DESCRIPTION        VARCHAR2(200 BYTE),
  DISPLAY_SEQ        NUMBER(5),
  CREATED_ON         DATE,
  CREATED_BY         VARCHAR2(30 BYTE),
  MODIFIED_ON        DATE,
  MODIFIED_BY        VARCHAR2(30 BYTE),
  ACTIVE             VARCHAR2(5 BYTE)*/
            List<OracleParameter> paramList = new List<OracleParameter>();
            /*p_loan_period           IN     NUMBER,
      p_loan_period_type      IN     VARCHAR2,
      p_loan_product_code     IN     VARCHAR2,
      p_description           IN     VARCHAR2,
      p_display_seq           IN     NUMBER,
      p_created_modified_on   IN     DATE,
      p_created_modified_by   IN     VARCHAR2,
      p_active                IN     VARCHAR2,
      p_insert_update         IN     VARCHAR2,
      v_out_result_code          OUT VARCHAR2,
      v_out_result_msg           OUT VARCHAR2*/
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period", loanProductPeriodMap.LoanPeriod, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_period_type", loanProductPeriodMap.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_product_code", loanProductPeriodMap.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_description", loanProductPeriodMap.Description, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_display_seq", loanProductPeriodMap.DisplaySequence, OracleDbType.Int64, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanProductPeriodMap.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanProductPeriodMap.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active", loanProductPeriodMap.Active, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_Action", loanProductPeriodMap.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[9].Size = 10;
            paramList[10].Size = 100;

            return paramList;

        }
        public List<LoanProductPeriodMap> GetLoanProductPeriodMap(string loanProductCode)
        {
            try
            {
                string SP = "ms_general_definition_pkg.p_loan_product_period_map";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_loan_product_code", loanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanProductPeriodMap> lst = new List<LoanProductPeriodMap>();


                LoanProductPeriodMap obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {/*LOAN_PERIOD, 
                        LOAN_PERIOD_TYPE, 
                        MS_REF_CODE_PKG.F_REF_DTL_NAME ('LOAN_PERIOD_TYPE', LOAN_PERIOD_TYPE) LOAN_PERIOD_TYPE_DET, 
                        LOAN_PRODUCT_CODE, 
                        DESCRIPTION, 
                        DISPLAY_SEQ, 
                        CREATED_ON, 
                        CREATED_BY, 
                        MODIFIED_ON, 
                        MODIFIED_BY, 
                        ACTIVE */
                    obj = new LoanProductPeriodMap();
                    obj.LoanPeriod = drow["LOAN_PERIOD"].ToString();//APPLICATION_ID
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();//APPLICATION_DESCRIPTION
                    obj.LoanPeriodTypeDet = drow["LOAN_PERIOD_TYPE_DET"].ToString();//APPLICATION_ID
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();//APPLICATION_DESCRIPTION
                    obj.Description = drow["DESCRIPTION"].ToString();//APPLICATION_ID
                    obj.DisplaySequence =Int64.Parse( drow["DISPLAY_SEQ"].ToString());//APPLICATION_DESCRIPTION
                    obj.CreatedOn = drow["CREATED_ON"].ToString();//APPLICATION_ID
                    obj.CreatedBy = drow["CREATED_BY"].ToString();//APPLICATION_DESCRIPTION
                    obj.ModifiedOn = drow["MODIFIED_ON"].ToString();//APPLICATION_ID
                    obj.ModifiedBy = drow["MODIFIED_BY"].ToString();//APPLICATION_DESCRIPTION
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

        public OutMessage SaveLoanProductPeriodMap(LoanProductPeriodMap loanProductPeriodMap)
        {
            string SP = "ms_general_definition_pkg.p_insert_update_lper_lpro_map"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(loanProductPeriodMap);

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
