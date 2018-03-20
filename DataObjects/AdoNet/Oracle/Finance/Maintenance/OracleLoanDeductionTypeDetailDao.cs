using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanDeductionDetailDao : ILoanDeductionDetailDao
    {
        public object SaveLoanDeductionDetail(LoanDeductionDetail loanDeductionDetail)
        {
            string sp = "loanDeductionDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanDeductionDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE_DESC", loanDeductionDetail.DeductionTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", loanDeductionDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", loanDeductionDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", loanDeductionDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_ID", loanDeductionDetail.RowId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", loanDeductionDetail.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_LOW_VAL", loanDeductionDetail.LoanPeriodLow_Val, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_HIGH_VAL", loanDeductionDetail.LoanPeriodHigh_Val, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE", loanDeductionDetail.DeductionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE_CODE", loanDeductionDetail.DeductionTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_VALUE", loanDeductionDetail.DeductionValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_CRITERIA", loanDeductionDetail.DeductionCriteria, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N", loanDeductionDetail.ChoiceDeductY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_FROM_YEAR", loanDeductionDetail.DeductionFromYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DED_TYPE_DETAIL", loanDeductionDetail.DedTypeDetail, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DED_CRITERIA", loanDeductionDetail.DedCriteria, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanDeductionDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchLoanDeductionDetail(LoanDeductionDetail loanDeductionDetail)
        {
            string sp = "loanDeductionDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanDeductionDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE_DESC", loanDeductionDetail.DeductionTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CODE", loanDeductionDetail.AccountCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_NO", loanDeductionDetail.AccountNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_DESC", loanDeductionDetail.AccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_ID", loanDeductionDetail.RowId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_TYPE", loanDeductionDetail.LoanPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_LOW_VAL", loanDeductionDetail.LoanPeriodLow_Val, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PERIOD_HIGH_VAL", loanDeductionDetail.LoanPeriodHigh_Val, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE", loanDeductionDetail.DeductionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_TYPE_CODE", loanDeductionDetail.DeductionTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_VALUE", loanDeductionDetail.DeductionValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_CRITERIA", loanDeductionDetail.DeductionCriteria, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N", loanDeductionDetail.ChoiceDeductY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_FROM_YEAR", loanDeductionDetail.DeductionFromYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DED_TYPE_DETAIL", loanDeductionDetail.DedTypeDetail, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DED_CRITERIA", loanDeductionDetail.DedCriteria, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanDeductionDetail> lst = new List<LoanDeductionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanDeductionDetail obj = new LoanDeductionDetail();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.DeductionTypeDesc = drow["DEDUCTION_TYPE_DESC"].ToString();
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.RowId = drow["ROW_ID"].ToString();
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriodLow_Val = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD_LOW_VAL"].ToString()));
                    obj.LoanPeriodHigh_Val = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD_HIGH_VAL"].ToString()));
                    obj.DeductionType = drow["DEDUCTION_TYPE"].ToString();
                    obj.DeductionTypeCode = drow["DEDUCTION_TYPE_CODE"].ToString();
                    obj.DeductionValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_VALUE"].ToString()));
                    obj.DeductionCriteria = drow["DEDUCTION_CRITERIA"].ToString();
                    obj.ChoiceDeductY_N = drow["CHOICE_DEDUCT_Y_N"].ToString();
                    obj.DeductionFromYear = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_FROM_YEAR"].ToString()));
                    obj.DedTypeDetail = drow["DED_TYPE_DETAIL"].ToString();
                    obj.DedCriteria = drow["DED_CRITERIA"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanDeductionDtl(string LoanProductCode)
        {
            string sp = "fn_loan_pkg.p_loan_deduction_dtl_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PRODUCT_CODE", LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanDeductionDetail> lst = new List<LoanDeductionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanDeductionDetail obj = new LoanDeductionDetail();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.DeductionTypeDesc = drow["DEDUCTION_TYPE_DESC"].ToString();
                    obj.AccountCode = drow["ACCOUNT_CODE"].ToString();
                    obj.AccountNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_NO"].ToString()));
                    obj.AccountDesc = drow["ACCOUNT_DESC"].ToString();
                    obj.RowId = drow["ROW_ID"].ToString();
                    obj.LoanPeriodType = drow["LOAN_PERIOD_TYPE"].ToString();
                    obj.LoanPeriodLow_Val = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD_LOW_VAL"].ToString()));
                    obj.LoanPeriodHigh_Val = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_PERIOD_HIGH_VAL"].ToString()));
                    obj.DeductionType = drow["DEDUCTION_TYPE"].ToString();
                    obj.DeductionTypeCode = drow["DEDUCTION_TYPE_CODE"].ToString();
                    obj.DeductionValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_VALUE"].ToString()));
                    obj.DeductionCriteria = drow["DEDUCTION_CRITERIA"].ToString();
                    obj.ChoiceDeductY_N = drow["CHOICE_DEDUCT_Y_N"].ToString();
                    obj.DeductionFromYear = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_FROM_YEAR"].ToString()));
                    obj.DedTypeDetail = drow["DED_TYPE_DETAIL"].ToString();
                    obj.DedCriteria = drow["DED_CRITERIA"].ToString();

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
