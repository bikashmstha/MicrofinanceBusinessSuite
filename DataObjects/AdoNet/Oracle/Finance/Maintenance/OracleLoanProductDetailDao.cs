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
    public class OracleLoanProductDetailDao : ILoanProductDetailDao
    {
        public object SaveLoanProductDetail(LoanProductDetail loanProductDetail)
        {
            string sp = "loanProductDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanProductDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", loanProductDetail.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_TYPE", loanProductDetail.LoanType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PREFIX", loanProductDetail.LoanPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_LOAN_AMOUNT", loanProductDetail.MinLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_LOAN_AMOUNT", loanProductDetail.MaxLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", loanProductDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_PAY_ON_INSTALLMENT", loanProductDetail.IntPayOn_Installment, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_TYPE", loanProductDetail.IntCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_LOAN_TERM_MONTHS", loanProductDetail.MinLoanTerm_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_LOAN_TERM_MONTHS", loanProductDetail.MaxLoanTerm_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_GRACE_DAYS", loanProductDetail.MaxGraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_ON_GRACE_DAYS", loanProductDetail.IntCalcOn_Grace_Days, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC", loanProductDetail.PenaltyCalc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TYPE", loanProductDetail.PenaltyCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_VALUE", loanProductDetail.PenaltyCalcValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_ON_HOLIDAY", loanProductDetail.PenaltyCalcOn_Holiday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TILL_MONTHS", loanProductDetail.PenaltyCalcTill_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS_PENALTY", loanProductDetail.GraceDaysPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_BALANCE_IN_SAVING_ACCOUNT", loanProductDetail.MinBalanceIn_Saving_Account, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ACCOUNT_HEAD", loanProductDetail.PrincipalAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ACCOUNT_NO", loanProductDetail.PrincipalAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ACCOUNT_DESC", loanProductDetail.PrincipalAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_HEAD", loanProductDetail.InterestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_NO", loanProductDetail.InterestAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEMAND_Y_N", loanProductDetail.DemandYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", loanProductDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_ACCOUNT_OPEN", loanProductDetail.NoOfAccount_Open, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_DESC", loanProductDetail.InterestAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_HEAD", loanProductDetail.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_NO", loanProductDetail.PenaltyAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_DESC", loanProductDetail.PenaltyAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_WISE_LOAN_LIMIT", loanProductDetail.YearWiseLoan_Limit, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_FIXED_LOAN_PCT", loanProductDetail.MaxFixedLoan_Pct, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_DAY", loanProductDetail.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_RECEIVABLE_ACC_HEAD", loanProductDetail.IntReceivableAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_RECEIVE_ACCOUNT_NO", loanProductDetail.IntReceiveAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_RECEIVE_ACCOUNT_DESC", loanProductDetail.IntReceiveAccount_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVABLE_ACC_HEAD", loanProductDetail.PenReceivableAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVE_ACCOUNT_NO", loanProductDetail.PenReceiveAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVE_ACCOUNT_DESC", loanProductDetail.PenReceiveAccount_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACC_HEAD", loanProductDetail.SuspenseAccHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACCOUNT_NO", loanProductDetail.SuspenseAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACCOUNT_DESC", loanProductDetail.SuspenseAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISPLAY_SEQ", loanProductDetail.DisplaySeq, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CATEGORY", loanProductDetail.LoanCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_FROM", loanProductDetail.ProductValidFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_TILL", loanProductDetail.ProductValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CIB_CODE", loanProductDetail.CibCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_TYPE_CODE", loanProductDetail.SavingProductType_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVAL_PERCENTAGE", loanProductDetail.ApprovalPercentage, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE", loanProductDetail.ProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanProductDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchLoanProductDetail(LoanProductDetail loanProductDetail)
        {
            string sp = "loanProductDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanProductDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", loanProductDetail.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_TYPE", loanProductDetail.LoanType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PREFIX", loanProductDetail.LoanPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_LOAN_AMOUNT", loanProductDetail.MinLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_LOAN_AMOUNT", loanProductDetail.MaxLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_RATE", loanProductDetail.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_PAY_ON_INSTALLMENT", loanProductDetail.IntPayOn_Installment, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_TYPE", loanProductDetail.IntCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_LOAN_TERM_MONTHS", loanProductDetail.MinLoanTerm_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_LOAN_TERM_MONTHS", loanProductDetail.MaxLoanTerm_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_GRACE_DAYS", loanProductDetail.MaxGraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_ON_GRACE_DAYS", loanProductDetail.IntCalcOn_Grace_Days, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC", loanProductDetail.PenaltyCalc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TYPE", loanProductDetail.PenaltyCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_VALUE", loanProductDetail.PenaltyCalcValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_ON_HOLIDAY", loanProductDetail.PenaltyCalcOn_Holiday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TILL_MONTHS", loanProductDetail.PenaltyCalcTill_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS_PENALTY", loanProductDetail.GraceDaysPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_BALANCE_IN_SAVING_ACCOUNT", loanProductDetail.MinBalanceIn_Saving_Account, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ACCOUNT_HEAD", loanProductDetail.PrincipalAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ACCOUNT_NO", loanProductDetail.PrincipalAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_ACCOUNT_DESC", loanProductDetail.PrincipalAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_HEAD", loanProductDetail.InterestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_NO", loanProductDetail.InterestAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEMAND_Y_N", loanProductDetail.DemandYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", loanProductDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_ACCOUNT_OPEN", loanProductDetail.NoOfAccount_Open, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_DESC", loanProductDetail.InterestAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_HEAD", loanProductDetail.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_NO", loanProductDetail.PenaltyAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_DESC", loanProductDetail.PenaltyAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_WISE_LOAN_LIMIT", loanProductDetail.YearWiseLoan_Limit, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_FIXED_LOAN_PCT", loanProductDetail.MaxFixedLoan_Pct, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_DAY", loanProductDetail.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_RECEIVABLE_ACC_HEAD", loanProductDetail.IntReceivableAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_RECEIVE_ACCOUNT_NO", loanProductDetail.IntReceiveAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_RECEIVE_ACCOUNT_DESC", loanProductDetail.IntReceiveAccount_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVABLE_ACC_HEAD", loanProductDetail.PenReceivableAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVE_ACCOUNT_NO", loanProductDetail.PenReceiveAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVE_ACCOUNT_DESC", loanProductDetail.PenReceiveAccount_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACC_HEAD", loanProductDetail.SuspenseAccHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACCOUNT_NO", loanProductDetail.SuspenseAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACCOUNT_DESC", loanProductDetail.SuspenseAccountDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISPLAY_SEQ", loanProductDetail.DisplaySeq, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CATEGORY", loanProductDetail.LoanCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_FROM", loanProductDetail.ProductValidFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_TILL", loanProductDetail.ProductValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CIB_CODE", loanProductDetail.CibCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_TYPE_CODE", loanProductDetail.SavingProductType_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVAL_PERCENTAGE", loanProductDetail.ApprovalPercentage, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE", loanProductDetail.ProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanProductDetail> lst = new List<LoanProductDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanProductDetail obj = new LoanProductDetail();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanProductName = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanType = drow["LOAN_TYPE"].ToString();
                    obj.LoanPrefix = drow["LOAN_PREFIX"].ToString();
                    obj.MinLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_LOAN_AMOUNT"].ToString()));
                    obj.MaxLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_LOAN_AMOUNT"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.IntPayOn_Installment = drow["INT_PAY_ON_INSTALLMENT"].ToString();
                    obj.IntCalcType = drow["INT_CALC_TYPE"].ToString();
                    obj.MinLoanTerm_Months = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_LOAN_TERM_MONTHS"].ToString()));
                    obj.MaxLoanTerm_Months = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_LOAN_TERM_MONTHS"].ToString()));
                    obj.MaxGraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_GRACE_DAYS"].ToString()));
                    obj.IntCalcOn_Grace_Days = drow["INT_CALC_ON_GRACE_DAYS"].ToString();
                    obj.PenaltyCalc = drow["PENALTY_CALC"].ToString();
                    obj.PenaltyCalcType = drow["PENALTY_CALC_TYPE"].ToString();
                    obj.PenaltyCalcValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_CALC_VALUE"].ToString()));
                    obj.PenaltyCalcOn_Holiday = drow["PENALTY_CALC_ON_HOLIDAY"].ToString();
                    obj.PenaltyCalcTill_Months = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_CALC_TILL_MONTHS"].ToString()));
                    obj.GraceDaysPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS_PENALTY"].ToString()));
                    obj.MinBalanceIn_Saving_Account = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_BALANCE_IN_SAVING_ACCOUNT"].ToString()));
                    obj.PrincipalAccountHead = drow["PRINCIPAL_ACCOUNT_HEAD"].ToString();
                    obj.PrincipalAccountNo = drow["PRINCIPAL_ACCOUNT_NO"].ToString();
                    obj.PrincipalAccountDesc = drow["PRINCIPAL_ACCOUNT_DESC"].ToString();
                    obj.InterestAccountHead = drow["INTEREST_ACCOUNT_HEAD"].ToString();
                    obj.InterestAccountNo = drow["INTEREST_ACCOUNT_NO"].ToString();
                    obj.DemandYN = drow["DEMAND_Y_N"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.NoOfAccount_Open = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_ACCOUNT_OPEN"].ToString()));
                    obj.InterestAccountDesc = drow["INTEREST_ACCOUNT_DESC"].ToString();
                    obj.PenaltyAccountHead = drow["PENALTY_ACCOUNT_HEAD"].ToString();
                    obj.PenaltyAccountNo = drow["PENALTY_ACCOUNT_NO"].ToString();
                    obj.PenaltyAccountDesc = drow["PENALTY_ACCOUNT_DESC"].ToString();
                    obj.YearWiseLoan_Limit = drow["YEAR_WISE_LOAN_LIMIT"].ToString();
                    obj.MaxFixedLoan_Pct = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_FIXED_LOAN_PCT"].ToString()));
                    obj.FixedCollectionDay = drow["FIXED_COLLECTION_DAY"].ToString();
                    obj.IntReceivableAcc_Head = drow["INT_RECEIVABLE_ACC_HEAD"].ToString();
                    obj.IntReceiveAccount_No = drow["INT_RECEIVE_ACCOUNT_NO"].ToString();
                    obj.IntReceiveAccount_Desc = drow["INT_RECEIVE_ACCOUNT_DESC"].ToString();
                    obj.PenReceivableAcc_Head = drow["PEN_RECEIVABLE_ACC_HEAD"].ToString();
                    obj.PenReceiveAccount_No = drow["PEN_RECEIVE_ACCOUNT_NO"].ToString();
                    obj.PenReceiveAccount_Desc = drow["PEN_RECEIVE_ACCOUNT_DESC"].ToString();
                    obj.SuspenseAccHead = drow["SUSPENSE_ACC_HEAD"].ToString();
                    obj.SuspenseAccountNo = drow["SUSPENSE_ACCOUNT_NO"].ToString();
                    obj.SuspenseAccountDesc = drow["SUSPENSE_ACCOUNT_DESC"].ToString();
                    obj.DisplaySeq = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DISPLAY_SEQ"].ToString()));
                    obj.LoanCategory = drow["LOAN_CATEGORY"].ToString();
                    obj.ProductValidFrom = drow["PRODUCT_VALID_FROM"].ToString();
                    obj.ProductValidTill = drow["PRODUCT_VALID_TILL"].ToString();
                    obj.CibCode = drow["CIB_CODE"].ToString();
                    obj.SavingProductType_Code = drow["SAVING_PRODUCT_TYPE_CODE"].ToString();
                    obj.ApprovalPercentage = drow["APPROVAL_PERCENTAGE"].ToString();
                    obj.ProductType = drow["PRODUCT_TYPE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanProductDetailList(string LoanProductCode, string LoanType)
        {
            string sp = "fn_loan_pkg.p_loan_product_detail_list ";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_PRODUCT_CODE", LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_TYPE", LoanType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanProductDetail> lst = new List<LoanProductDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanProductDetail obj = new LoanProductDetail();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanProductName = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanType = drow["LOAN_TYPE"].ToString();
                    obj.LoanPrefix = drow["LOAN_PREFIX"].ToString();
                    obj.MinLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_LOAN_AMOUNT"].ToString()));
                    obj.MaxLoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_LOAN_AMOUNT"].ToString()));
                    obj.InterestRate = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RATE"].ToString()));
                    obj.IntPayOn_Installment = drow["INT_PAY_ON_INSTALLMENT"].ToString();
                    obj.IntCalcType = drow["INT_CALC_TYPE"].ToString();
                    obj.MinLoanTerm_Months = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_LOAN_TERM_MONTHS"].ToString()));
                    obj.MaxLoanTerm_Months = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_LOAN_TERM_MONTHS"].ToString()));
                    obj.MaxGraceDays = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_GRACE_DAYS"].ToString()));
                    obj.IntCalcOn_Grace_Days = drow["INT_CALC_ON_GRACE_DAYS"].ToString();
                    obj.PenaltyCalc = drow["PENALTY_CALC"].ToString();
                    obj.PenaltyCalcType = drow["PENALTY_CALC_TYPE"].ToString();
                    obj.PenaltyCalcValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_CALC_VALUE"].ToString()));
                    obj.PenaltyCalcOn_Holiday = drow["PENALTY_CALC_ON_HOLIDAY"].ToString();
                    obj.PenaltyCalcTill_Months = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_CALC_TILL_MONTHS"].ToString()));
                    obj.GraceDaysPenalty = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS_PENALTY"].ToString()));
                    obj.MinBalanceIn_Saving_Account = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_BALANCE_IN_SAVING_ACCOUNT"].ToString()));
                    obj.PrincipalAccountHead = drow["PRINCIPAL_ACCOUNT_HEAD"].ToString();
                    obj.PrincipalAccountNo = drow["PRINCIPAL_ACCOUNT_NO"].ToString();
                    obj.PrincipalAccountDesc = drow["PRINCIPAL_ACCOUNT_DESC"].ToString();
                    obj.InterestAccountHead = drow["INTEREST_ACCOUNT_HEAD"].ToString();
                    obj.InterestAccountNo = drow["INTEREST_ACCOUNT_NO"].ToString();
                    obj.DemandYN = drow["DEMAND_Y_N"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.NoOfAccount_Open = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_ACCOUNT_OPEN"].ToString()));
                    obj.InterestAccountDesc = drow["INTEREST_ACCOUNT_DESC"].ToString();
                    obj.PenaltyAccountHead = drow["PENALTY_ACCOUNT_HEAD"].ToString();
                    obj.PenaltyAccountNo = drow["PENALTY_ACCOUNT_NO"].ToString();
                    obj.PenaltyAccountDesc = drow["PENALTY_ACCOUNT_DESC"].ToString();
                    obj.YearWiseLoan_Limit = drow["YEAR_WISE_LOAN_LIMIT"].ToString();
                    obj.MaxFixedLoan_Pct = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_FIXED_LOAN_PCT"].ToString()));
                    obj.FixedCollectionDay = drow["FIXED_COLLECTION_DAY"].ToString();
                    obj.IntReceivableAcc_Head = drow["INT_RECEIVABLE_ACC_HEAD"].ToString();
                    obj.IntReceiveAccount_No = drow["INT_RECEIVE_ACCOUNT_NO"].ToString();
                    obj.IntReceiveAccount_Desc = drow["INT_RECEIVE_ACCOUNT_DESC"].ToString();
                    obj.PenReceivableAcc_Head = drow["PEN_RECEIVABLE_ACC_HEAD"].ToString();
                    obj.PenReceiveAccount_No = drow["PEN_RECEIVE_ACCOUNT_NO"].ToString();
                    obj.PenReceiveAccount_Desc = drow["PEN_RECEIVE_ACCOUNT_DESC"].ToString();
                    obj.SuspenseAccHead = drow["SUSPENSE_ACC_HEAD"].ToString();
                    obj.SuspenseAccountNo = drow["SUSPENSE_ACCOUNT_NO"].ToString();
                    obj.SuspenseAccountDesc = drow["SUSPENSE_ACCOUNT_DESC"].ToString();
                    obj.DisplaySeq = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DISPLAY_SEQ"].ToString()));
                    obj.LoanCategory = drow["LOAN_CATEGORY"].ToString();
                    obj.ProductValidFrom = drow["PRODUCT_VALID_FROM"].ToString();
                    obj.ProductValidTill = drow["PRODUCT_VALID_TILL"].ToString();
                    obj.CibCode = drow["CIB_CODE"].ToString();
                    obj.SavingProductType_Code = drow["SAVING_PRODUCT_TYPE_CODE"].ToString();
                    obj.ApprovalPercentage = drow["APPROVAL_PERCENTAGE"].ToString();
                    obj.ProductType = drow["PRODUCT_TYPE"].ToString();

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
