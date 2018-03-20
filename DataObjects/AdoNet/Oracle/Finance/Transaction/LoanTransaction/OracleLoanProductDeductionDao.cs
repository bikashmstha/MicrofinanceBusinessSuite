using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.LoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;


namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanProductDeductionDao : ILoanProductDeductionDao
    {
        public object SaveLoanProductDeduction(List<LoanProductDeduction> loanProductDeductions,OracleTransaction tran)
        {
            string sp = "fn_loan_pkg.p_loan_product_deduction";
            OutMessage oMsg = new OutMessage();
            try
            {
                List<OracleParameter> paramList = new List<OracleParameter>();

                foreach (LoanProductDeduction loanProductDeduction in loanProductDeductions)
                {
                    paramList = new List<OracleParameter>();
                    paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanProductDeduction.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE_CODE", loanProductDeduction.DeductionTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", loanProductDeduction.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE", loanProductDeduction.DeductionType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_VALUE", loanProductDeduction.DeductionValue, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_CRITERIA", loanProductDeduction.DeductionCriteria, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_FROM_YEAR", loanProductDeduction.DeductionFromYear, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N", loanProductDeduction.ChoiceDeductY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", loanProductDeduction.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_LOW_VAL", loanProductDeduction.LoanPeriodLow_Val, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_HIGH_VAL", loanProductDeduction.LoanPeriodHigh_Val, OracleDbType.Double, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_ROW_ID", loanProductDeduction.RowId, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_USER1", loanProductDeduction.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":p_action", loanProductDeduction.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                    paramList[paramList.Count - 1].Size = 100;
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());

                }
                
                
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) {  oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            
        }

        public object SearchLoanProductDeduction(LoanProductDeduction loanProductDeduction)
        {
            string sp = "loanProductDeduction_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanProductDeduction.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE_CODE", loanProductDeduction.DeductionTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", loanProductDeduction.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE", loanProductDeduction.DeductionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_VALUE", loanProductDeduction.DeductionValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_CRITERIA", loanProductDeduction.DeductionCriteria, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_FROM_YEAR", loanProductDeduction.DeductionFromYear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N", loanProductDeduction.ChoiceDeductY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", loanProductDeduction.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_LOW_VAL", loanProductDeduction.LoanPeriodLow_Val, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_HIGH_VAL", loanProductDeduction.LoanPeriodHigh_Val, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_ID", loanProductDeduction.RowId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", loanProductDeduction.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanProductDeduction> lst = new List<LoanProductDeduction>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanProductDeduction obj = new LoanProductDeduction();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.DeductionTypeCode = drow["DEDUCTION_TYPE_CODE"].ToString();
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.DeductionType = drow["DEDUCTION_TYPE"].ToString();
                    obj.DeductionValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_VALUE"].ToString()));
                    obj.DeductionCriteria = drow["DEDUCTION_CRITERIA"].ToString();
                    obj.DeductionFromYear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_FROM_YEAR"].ToString()));
                    obj.ChoiceDeductY_N = drow["CHOICE_DEDUCT_Y_N"].ToString();
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriodLow_Val = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD_LOW_VAL"].ToString()));
                    obj.LoanPeriodHigh_Val = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD_HIGH_VAL"].ToString()));
                    obj.RowId = drow["ROW_ID"].ToString();
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
