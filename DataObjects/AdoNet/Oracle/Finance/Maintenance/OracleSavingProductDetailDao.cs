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
    public class OracleSavingProductDetailDao : ISavingProductDetailDao
    {
        public object SaveSavingProductDetail(SavingProductDetail savingProductDetail)
        {
            string sp = "savingProductDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", savingProductDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", savingProductDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_PREFIX", savingProductDetail.ProductPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_CODE", savingProductDetail.ProductTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE", savingProductDetail.ProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_HEAD", savingProductDetail.SavingAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_HEAD", savingProductDetail.SavHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_HEAD_NO", savingProductDetail.SavHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", savingProductDetail.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_DESC", savingProductDetail.IntDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COMPULSORY", savingProductDetail.Compulsory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_START_FROM", savingProductDetail.ProductStartFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_TILL", savingProductDetail.ProductValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_HEAD", savingProductDetail.InterestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_HEAD", savingProductDetail.IntHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_HEAD_NO", savingProductDetail.IntHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_HEAD", savingProductDetail.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_HEAD", savingProductDetail.PenHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_HEAD_NO", savingProductDetail.PenHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE_ACC_HEAD", savingProductDetail.ClosingChargeAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSE_HEAD", savingProductDetail.CloseHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COMPULSORY_AMOUNT", savingProductDetail.CompulsoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSE_HEAD_NO", savingProductDetail.CloseHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_ON_INT_ACC_HEAD", savingProductDetail.TaxOnInt_Acc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_HEAD", savingProductDetail.TaxHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_HEAD_NO", savingProductDetail.TaxHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", savingProductDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_METHOD", savingProductDetail.IntCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TDS_INTEREST_PERCENTAGE", savingProductDetail.TdsInterestPercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_BALANCE", savingProductDetail.MinBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_INTEREST_BALANCE", savingProductDetail.MinInterestBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_WITHDRAW_AMOUNT", savingProductDetail.MaxWithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_ACCOUNT_OPEN_AMOUNT", savingProductDetail.MinAccountOpen_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSING_CHARGE", savingProductDetail.AccountClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSE_IF_LOAN_EXISTS", savingProductDetail.AccCloseIf_Loan_Exists, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_DAY", savingProductDetail.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CAPITALIZED", savingProductDetail.IntCapitalized, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", savingProductDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LESS_INTEREST_PREMATURE_END", savingProductDetail.LessInterestPremature_End, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_LATE_INSTALLMENT", savingProductDetail.PenaltyLateInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PREMATURED_INT_RATIO", savingProductDetail.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE_LIMIT", savingProductDetail.InterestTaxableLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE", savingProductDetail.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_ACCOUNT_OPEN", savingProductDetail.NoOfAccount_Open, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSED_IF_CLIENT_ACTIVE", savingProductDetail.AccClosedIf_Client_Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_AC_HEAD", savingProductDetail.OtherIncomeAc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_EXPENSE_AC_HEAD", savingProductDetail.OtherExpenseAc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_Y_N", savingProductDetail.ReferenceAccountY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_FOR", savingProductDetail.SavingProductFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", savingProductDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANNUAL_CLOSING_Y_N", savingProductDetail.MannualClosingY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS_PENALTY", savingProductDetail.GraceDaysPenalty, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAXIMUM_INACTIVE_DAYS", savingProductDetail.MaximumInactiveDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTION_FOR_MAX_INACTIVE_DAYS", savingProductDetail.ActionForMax_Inactive_Days, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPOSIT_PERIOD_TYPE", savingProductDetail.TotalDepositPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPOSIT_PERIOD", savingProductDetail.TotalDepositPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", savingProductDetail.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_SAVING_PRODUCT_CODE", savingProductDetail.ReferenceSavingProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_DESC", savingProductDetail.SavingProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_AC_NO", savingProductDetail.AccurateIntAc_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_AC_HEAD", savingProductDetail.AccurateIntAc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_AC_DESC", savingProductDetail.AccurateIntAc_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CATEGORY_CODE", savingProductDetail.ProductCategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingProductDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchSavingProductDetail(SavingProductDetail savingProductDetail)
        {
            string sp = "savingProductDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", savingProductDetail.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", savingProductDetail.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_PREFIX", savingProductDetail.ProductPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_CODE", savingProductDetail.ProductTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE", savingProductDetail.ProductType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_HEAD", savingProductDetail.SavingAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_HEAD", savingProductDetail.SavHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_HEAD_NO", savingProductDetail.SavHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", savingProductDetail.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_DESC", savingProductDetail.IntDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COMPULSORY", savingProductDetail.Compulsory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_START_FROM", savingProductDetail.ProductStartFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_TILL", savingProductDetail.ProductValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_HEAD", savingProductDetail.InterestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_HEAD", savingProductDetail.IntHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_HEAD_NO", savingProductDetail.IntHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_HEAD", savingProductDetail.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_HEAD", savingProductDetail.PenHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_HEAD_NO", savingProductDetail.PenHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE_ACC_HEAD", savingProductDetail.ClosingChargeAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSE_HEAD", savingProductDetail.CloseHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COMPULSORY_AMOUNT", savingProductDetail.CompulsoryAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSE_HEAD_NO", savingProductDetail.CloseHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_ON_INT_ACC_HEAD", savingProductDetail.TaxOnInt_Acc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_HEAD", savingProductDetail.TaxHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_HEAD_NO", savingProductDetail.TaxHeadNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", savingProductDetail.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_METHOD", savingProductDetail.IntCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TDS_INTEREST_PERCENTAGE", savingProductDetail.TdsInterestPercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_BALANCE", savingProductDetail.MinBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_INTEREST_BALANCE", savingProductDetail.MinInterestBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_WITHDRAW_AMOUNT", savingProductDetail.MaxWithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_ACCOUNT_OPEN_AMOUNT", savingProductDetail.MinAccountOpen_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSING_CHARGE", savingProductDetail.AccountClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSE_IF_LOAN_EXISTS", savingProductDetail.AccCloseIf_Loan_Exists, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_DAY", savingProductDetail.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CAPITALIZED", savingProductDetail.IntCapitalized, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", savingProductDetail.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LESS_INTEREST_PREMATURE_END", savingProductDetail.LessInterestPremature_End, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_LATE_INSTALLMENT", savingProductDetail.PenaltyLateInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PREMATURED_INT_RATIO", savingProductDetail.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE_LIMIT", savingProductDetail.InterestTaxableLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE", savingProductDetail.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_ACCOUNT_OPEN", savingProductDetail.NoOfAccount_Open, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSED_IF_CLIENT_ACTIVE", savingProductDetail.AccClosedIf_Client_Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_AC_HEAD", savingProductDetail.OtherIncomeAc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_EXPENSE_AC_HEAD", savingProductDetail.OtherExpenseAc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_Y_N", savingProductDetail.ReferenceAccountY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_FOR", savingProductDetail.SavingProductFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", savingProductDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANNUAL_CLOSING_Y_N", savingProductDetail.MannualClosingY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS_PENALTY", savingProductDetail.GraceDaysPenalty, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAXIMUM_INACTIVE_DAYS", savingProductDetail.MaximumInactiveDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTION_FOR_MAX_INACTIVE_DAYS", savingProductDetail.ActionForMax_Inactive_Days, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPOSIT_PERIOD_TYPE", savingProductDetail.TotalDepositPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPOSIT_PERIOD", savingProductDetail.TotalDepositPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", savingProductDetail.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_SAVING_PRODUCT_CODE", savingProductDetail.ReferenceSavingProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_DESC", savingProductDetail.SavingProductDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_AC_NO", savingProductDetail.AccurateIntAc_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_AC_HEAD", savingProductDetail.AccurateIntAc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_AC_DESC", savingProductDetail.AccurateIntAc_Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CATEGORY_CODE", savingProductDetail.ProductCategoryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProductDetail> lst = new List<SavingProductDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingProductDetail obj = new SavingProductDetail();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ProductPrefix = drow["PRODUCT_PREFIX"].ToString();
                    obj.ProductTypeCode = drow["PRODUCT_TYPE_CODE"].ToString();
                    obj.ProductType = drow["PRODUCT_TYPE"].ToString();
                    obj.SavingAccountHead = drow["SAVING_ACCOUNT_HEAD"].ToString();
                    obj.SavHead = drow["SAV_HEAD"].ToString();
                    obj.SavHeadNo = drow["SAV_HEAD_NO"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.IntDesc = drow["INT_DESC"].ToString();
                    obj.Compulsory = drow["COMPULSORY"].ToString();
                    obj.ProductStartFrom = drow["PRODUCT_START_FROM"].ToString();
                    obj.ProductValidTill = drow["PRODUCT_VALID_TILL"].ToString();
                    obj.InterestAccountHead = drow["INTEREST_ACCOUNT_HEAD"].ToString();
                    obj.IntHead = drow["INT_HEAD"].ToString();
                    obj.IntHeadNo = drow["INT_HEAD_NO"].ToString();
                    obj.PenaltyAccountHead = drow["PENALTY_ACCOUNT_HEAD"].ToString();
                    obj.PenHead = drow["PEN_HEAD"].ToString();
                    obj.PenHeadNo = drow["PEN_HEAD_NO"].ToString();
                    obj.ClosingChargeAcc_Head = drow["CLOSING_CHARGE_ACC_HEAD"].ToString();
                    obj.CloseHead = drow["CLOSE_HEAD"].ToString();
                    obj.CompulsoryAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COMPULSORY_AMOUNT"].ToString()));
                    obj.CloseHeadNo = drow["CLOSE_HEAD_NO"].ToString();
                    obj.TaxOnInt_Acc_Head = drow["TAX_ON_INT_ACC_HEAD"].ToString();
                    obj.TaxHead = drow["TAX_HEAD"].ToString();
                    obj.TaxHeadNo = drow["TAX_HEAD_NO"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.IntCalcMethod = drow["INT_CALC_METHOD"].ToString();
                    obj.TdsInterestPercentage = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TDS_INTEREST_PERCENTAGE"].ToString()));
                    obj.MinBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_BALANCE"].ToString()));
                    obj.MinInterestBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_INTEREST_BALANCE"].ToString()));
                    obj.MaxWithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_WITHDRAW_AMOUNT"].ToString()));
                    obj.MinAccountOpen_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_ACCOUNT_OPEN_AMOUNT"].ToString()));
                    obj.AccountClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_CLOSING_CHARGE"].ToString()));
                    obj.AccCloseIf_Loan_Exists = drow["ACC_CLOSE_IF_LOAN_EXISTS"].ToString();
                    obj.FixedCollectionDay = drow["FIXED_COLLECTION_DAY"].ToString();
                    obj.IntCapitalized = drow["INT_CAPITALIZED"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.LessInterestPremature_End = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LESS_INTEREST_PREMATURE_END"].ToString()));
                    obj.PenaltyLateInstallment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_LATE_INSTALLMENT"].ToString()));
                    obj.PrematuredIntRatio = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PREMATURED_INT_RATIO"].ToString()));
                    obj.InterestTaxableLimit = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_TAXABLE_LIMIT"].ToString()));
                    obj.InterestTaxable = drow["INTEREST_TAXABLE"].ToString();
                    obj.NoOfAccount_Open = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_ACCOUNT_OPEN"].ToString()));
                    obj.AccClosedIf_Client_Active = drow["ACC_CLOSED_IF_CLIENT_ACTIVE"].ToString();
                    obj.OtherIncomeAc_Head = drow["OTHER_INCOME_AC_HEAD"].ToString();
                    obj.OtherExpenseAc_Head = drow["OTHER_EXPENSE_AC_HEAD"].ToString();
                    obj.ReferenceAccountY_N = drow["REFERENCE_ACCOUNT_Y_N"].ToString();
                    obj.SavingProductFor = drow["SAVING_PRODUCT_FOR"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.MannualClosingY_N = drow["MANNUAL_CLOSING_Y_N"].ToString();
                    obj.GraceDaysPenalty = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS_PENALTY"].ToString()));
                    obj.MaximumInactiveDays = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAXIMUM_INACTIVE_DAYS"].ToString()));
                    obj.ActionForMax_Inactive_Days = drow["ACTION_FOR_MAX_INACTIVE_DAYS"].ToString();
                    obj.TotalDepositPeriod_Type = drow["TOTAL_DEPOSIT_PERIOD_TYPE"].ToString();
                    obj.TotalDepositPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_DEPOSIT_PERIOD"].ToString()));
                    obj.TransferIntPeriodic = drow["TRANSFER_INT_PERIODIC"].ToString();
                    obj.ReferenceSavingProduct_Code = drow["REFERENCE_SAVING_PRODUCT_CODE"].ToString();
                    obj.SavingProductDesc = drow["SAVING_PRODUCT_DESC"].ToString();
                    obj.AccurateIntAc_No = drow["ACCURATE_INT_AC_NO"].ToString();
                    obj.AccurateIntAc_Head = drow["ACCURATE_INT_AC_HEAD"].ToString();
                    obj.AccurateIntAc_Desc = drow["ACCURATE_INT_AC_DESC"].ToString();
                    obj.ProductCategoryCode = drow["PRODUCT_CATEGORY_CODE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetSavingProductDetail()
        {
            string sp = "fn_saving_utility_pkg.p_saving_product_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProductDetail> lst = new List<SavingProductDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingProductDetail obj = new SavingProductDetail();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.ProductPrefix = drow["PRODUCT_PREFIX"].ToString();
                    obj.ProductTypeCode = drow["PRODUCT_TYPE_CODE"].ToString();
                    obj.ProductType = drow["PRODUCT_TYPE"].ToString();
                    obj.SavingAccountHead = drow["SAVING_ACCOUNT_HEAD"].ToString();
                    obj.SavHead = drow["SAV_HEAD"].ToString();
                    obj.SavHeadNo = drow["SAV_HEAD_NO"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.IntDesc = drow["INT_DESC"].ToString();
                    obj.Compulsory = drow["COMPULSORY"].ToString();
                    obj.ProductStartFrom = drow["PRODUCT_START_FROM"].ToString();
                    obj.ProductValidTill = drow["PRODUCT_VALID_TILL"].ToString();
                    obj.InterestAccountHead = drow["INTEREST_ACCOUNT_HEAD"].ToString();
                    obj.IntHead = drow["INT_HEAD"].ToString();
                    obj.IntHeadNo = drow["INT_HEAD_NO"].ToString();
                    obj.PenaltyAccountHead = drow["PENALTY_ACCOUNT_HEAD"].ToString();
                    obj.PenHead = drow["PEN_HEAD"].ToString();
                    obj.PenHeadNo = drow["PEN_HEAD_NO"].ToString();
                    obj.ClosingChargeAcc_Head = drow["CLOSING_CHARGE_ACC_HEAD"].ToString();
                    obj.CloseHead = drow["CLOSE_HEAD"].ToString();
                    obj.CompulsoryAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COMPULSORY_AMOUNT"].ToString()));
                    obj.CloseHeadNo = drow["CLOSE_HEAD_NO"].ToString();
                    obj.TaxOnInt_Acc_Head = drow["TAX_ON_INT_ACC_HEAD"].ToString();
                    obj.TaxHead = drow["TAX_HEAD"].ToString();
                    obj.TaxHeadNo = drow["TAX_HEAD_NO"].ToString();
                    obj.PeriodType = drow["PERIOD_TYPE"].ToString();
                    obj.IntCalcMethod = drow["INT_CALC_METHOD"].ToString();
                    obj.TdsInterestPercentage = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TDS_INTEREST_PERCENTAGE"].ToString()));
                    obj.MinBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_BALANCE"].ToString()));
                    obj.MinInterestBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_INTEREST_BALANCE"].ToString()));
                    obj.MaxWithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAX_WITHDRAW_AMOUNT"].ToString()));
                    obj.MinAccountOpen_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MIN_ACCOUNT_OPEN_AMOUNT"].ToString()));
                    obj.AccountClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_CLOSING_CHARGE"].ToString()));
                    obj.AccCloseIf_Loan_Exists = drow["ACC_CLOSE_IF_LOAN_EXISTS"].ToString();
                    obj.FixedCollectionDay = drow["FIXED_COLLECTION_DAY"].ToString();
                    obj.IntCapitalized = drow["INT_CAPITALIZED"].ToString();
                    obj.InstallmentPeriod = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INSTALLMENT_PERIOD"].ToString()));
                    obj.LessInterestPremature_End = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LESS_INTEREST_PREMATURE_END"].ToString()));
                    obj.PenaltyLateInstallment = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_LATE_INSTALLMENT"].ToString()));
                    obj.PrematuredIntRatio = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PREMATURED_INT_RATIO"].ToString()));
                    obj.InterestTaxableLimit = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_TAXABLE_LIMIT"].ToString()));
                    obj.InterestTaxable = drow["INTEREST_TAXABLE"].ToString();
                    obj.NoOfAccount_Open = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_ACCOUNT_OPEN"].ToString()));
                    obj.AccClosedIf_Client_Active = drow["ACC_CLOSED_IF_CLIENT_ACTIVE"].ToString();
                    obj.OtherIncomeAc_Head = drow["OTHER_INCOME_AC_HEAD"].ToString();
                    obj.OtherExpenseAc_Head = drow["OTHER_EXPENSE_AC_HEAD"].ToString();
                    obj.ReferenceAccountY_N = drow["REFERENCE_ACCOUNT_Y_N"].ToString();
                    obj.SavingProductFor = drow["SAVING_PRODUCT_FOR"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.MannualClosingY_N = drow["MANNUAL_CLOSING_Y_N"].ToString();
                    obj.GraceDaysPenalty = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRACE_DAYS_PENALTY"].ToString()));
                    obj.MaximumInactiveDays = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["MAXIMUM_INACTIVE_DAYS"].ToString()));
                    obj.ActionForMax_Inactive_Days = drow["ACTION_FOR_MAX_INACTIVE_DAYS"].ToString();
                    obj.TotalDepositPeriod_Type = drow["TOTAL_DEPOSIT_PERIOD_TYPE"].ToString();
                    obj.TotalDepositPeriod = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_DEPOSIT_PERIOD"].ToString()));
                    obj.TransferIntPeriodic = drow["TRANSFER_INT_PERIODIC"].ToString();
                    obj.ReferenceSavingProduct_Code = drow["REFERENCE_SAVING_PRODUCT_CODE"].ToString();
                    obj.SavingProductDesc = drow["SAVING_PRODUCT_DESC"].ToString();
                    obj.AccurateIntAc_No = drow["ACCURATE_INT_AC_NO"].ToString();
                    obj.AccurateIntAc_Head = drow["ACCURATE_INT_AC_HEAD"].ToString();
                    obj.AccurateIntAc_Desc = drow["ACCURATE_INT_AC_DESC"].ToString();
                    obj.ProductCategoryCode = drow["PRODUCT_CATEGORY_CODE"].ToString();

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
