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
    public class OracleLoanPurposeProductsDao : ILoanPurposeProductsDao
    {
        private List<OracleParameter> PrepareParameterList(LoanPurposeProducts loanPurposeProducts)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":p_loan_purpose_code", loanPurposeProducts.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_loan_product_code", loanPurposeProducts.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_interest_rate", loanPurposeProducts.InterestRate, OracleDbType.Int64, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_min_loan_amount", loanPurposeProducts.MinLoanAmount, OracleDbType.Int64, ParameterDirection.Input));

            paramList.Add(SqlHelper.GetOraParam(":p_max_loan_amount", loanPurposeProducts.MaxLoanAmount, OracleDbType.Int64, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_min_loan_term_months", loanPurposeProducts.MinLoanTermsMonths, OracleDbType.Int64, ParameterDirection.Input));

            paramList.Add(SqlHelper.GetOraParam(":p_max_loan_term_months", loanPurposeProducts.MaxLoanTermsMonths, OracleDbType.Int64, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_no_of_account_open", loanPurposeProducts.NoOfAccountOpen, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_active", loanPurposeProducts.Active, OracleDbType.Varchar2, ParameterDirection.Input));
           
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_on", loanPurposeProducts.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":p_created_modified_by", loanPurposeProducts.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.InputOutput));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", loanPurposeProducts.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[paramList.Count - 1].Size = 100;

            return paramList;

        }


        public List<LoanPurposeProducts> GetLoanPurposeProducts(string LoanProductCode)
        {
            try
            {

                string SP = "MS_LOAN_PURPOSE_PKG.p_loan_purpose_product_dtl";

                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_loan_product_code", LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<LoanPurposeProducts> lst = new List<LoanPurposeProducts>();


                LoanPurposeProducts obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new LoanPurposeProducts();
                    obj.LoanPurposeCode = drow["LOAN_PURPOSE_CODE"].ToString();
                    obj.LoanPurposeDesc = drow["LOAN_PURPOSE_DESC"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                   // obj.InterestRate = Int64.Parse(drow["INTEREST_RATE"].ToString());
                    //obj.MinLoanAmount = Int64.Parse(drow["MIN_LOAN_AMOUNT"].ToString());
                   // obj.MaxLoanAmount = Int64.Parse(drow["MAX_LOAN_AMOUNT"].ToString());
                   // obj.MinLoanTermsMonths = Int64.Parse(drow["MIN_LOAN_TERMS_MONTHS"].ToString());
                    //obj.MaxLoanTermsMonths = Int64.Parse(drow["MAX_LOAN_TERMS_MONTHS"].ToString());
                    obj.Action = drow["ACTIVE"].ToString();


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

        public OutMessage SaveLoanPurposeProducts(LoanPurposeProducts loanPurposeProducts)
        {
            string SP = "ms_loan_purpose_pkg.p_iud_loan_purpose_product_det";
            OutMessage oMsg = new OutMessage();
            OracleConnection conn = new GetConnection().GetDbConn();
            List<OracleParameter> paramList = PrepareParameterList(loanPurposeProducts);

            try
            {
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[12].Value.ToString();
                oMsg.OutResultMessage = paramList[13].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
