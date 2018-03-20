using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Maintenance;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleSavingProductDao : ISavingProductDao
    {
        public object Get()
        {
            string sp = "savingProduct_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProduct> lst = new List<SavingProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingProduct obj = new SavingProduct();
                    obj.PenaltyCalcTill = int.Parse(drow["PenaltyCalcTill"].ToString());
                    obj.SavingAccountHead = drow["SavingAccountHead"].ToString();
                    obj.InterestAccountHead = drow["InterestAccountHead"].ToString();
                    obj.PenaltyAccountHead = drow["PenaltyAccountHead"].ToString();
                    obj.ProductStartFrom = drow["ProductStartFrom"].ToString();
                    obj.ProductValidTill = drow["ProductValidTill"].ToString();
                    obj.TdsInterestPercentage = int.Parse(drow["TdsInterestPercentage"].ToString());
                    obj.IntCalcPeriod = int.Parse(drow["IntCalcPeriod"].ToString());
                    obj.Compulsory = drow["Compulsory"].ToString();
                    obj.MinAccountOpenAmount = int.Parse(drow["MinAccountOpenAmount"].ToString());
                    obj.AccountClosingCharge = int.Parse(drow["AccountClosingCharge"].ToString());
                    obj.AccCloseIfLoanExists = drow["AccCloseIfLoanExists"].ToString();
                    obj.ClosingChargeAccHead = drow["ClosingChargeAccHead"].ToString();
                    obj.TaxOnIntAccHead = drow["TaxOnIntAccHead"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.FixedCollectionDay = drow["FixedCollectionDay"].ToString();
                    obj.PrematuredIntRatio = int.Parse(drow["PrematuredIntRatio"].ToString());
                    obj.InterestTaxableLimit = int.Parse(drow["InterestTaxableLimit"].ToString());
                    obj.InterestTaxable = drow["InterestTaxable"].ToString();
                    obj.MinTermIntRate = int.Parse(drow["MinTermIntRate"].ToString());
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.ReferenceAccountYN = drow["ReferenceAccountYN"].ToString();
                    obj.PreCashDeductionOrder = int.Parse(drow["PreCashDeductionOrder"].ToString());
                    obj.Active = drow["Active"].ToString();
                    obj.Description = drow["Description"].ToString();
                    obj.NoOfAccountOpen = int.Parse(drow["NoOfAccountOpen"].ToString());
                    obj.AccClosedIfClientActive = drow["AccClosedIfClientActive"].ToString();
                    obj.OtherIncomeAcHead = drow["OtherIncomeAcHead"].ToString();
                    obj.OtherExpenseAcHead = drow["OtherExpenseAcHead"].ToString();
                    obj.IntCapitalized = drow["IntCapitalized"].ToString();
                    obj.SavingProductFor = drow["SavingProductFor"].ToString();
                    obj.CompulsoryAmount = int.Parse(drow["CompulsoryAmount"].ToString());
                    obj.MidTermClosingType = drow["MidTermClosingType"].ToString();
                    obj.LedgerReportName = drow["LedgerReportName"].ToString();
                    obj.RegisterReportName = drow["RegisterReportName"].ToString();
                    obj.InterestPayableReportName = drow["InterestPayableReportName"].ToString();
                    obj.ChargeIncomeAccountHead = drow["ChargeIncomeAccountHead"].ToString();
                    obj.ClosedAcLedgerReportName = drow["ClosedAcLedgerReportName"].ToString();
                    obj.PayUnpostInterestYN = drow["PayUnpostInterestYN"].ToString();
                    obj.MannualClosingYN = drow["MannualClosingYN"].ToString();
                    obj.NoOfChequePrint = int.Parse(drow["NoOfChequePrint"].ToString());
                    obj.TotalDepositPeriodType = drow["TotalDepositPeriodType"].ToString();
                    obj.TotalDepositPeriod = int.Parse(drow["TotalDepositPeriod"].ToString());
                    obj.ReferenceSavingProductCode = drow["ReferenceSavingProductCode"].ToString();
                    obj.TransferIntPeriodic = drow["TransferIntPeriodic"].ToString();
                    obj.MaximumInactiveDays = int.Parse(drow["MaximumInactiveDays"].ToString());
                    obj.ActionForMaxInactiveDays = drow["ActionForMaxInactiveDays"].ToString();
                    obj.RecalculateMidtermInt = drow["RecalculateMidtermInt"].ToString();
                    obj.AccurateIntAcHead = drow["AccurateIntAcHead"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ProductPrefix = drow["ProductPrefix"].ToString();
                    obj.ProductTypeCode = drow["ProductTypeCode"].ToString();
                    obj.IntSchemeCode = drow["IntSchemeCode"].ToString();
                    obj.IntCalcMethod = drow["IntCalcMethod"].ToString();
                    obj.MinBalance = int.Parse(drow["MinBalance"].ToString());
                    obj.MinInterestBalance = int.Parse(drow["MinInterestBalance"].ToString());
                    obj.MaxWithdrawAmount = int.Parse(drow["MaxWithdrawAmount"].ToString());
                    obj.LessInterestPrematureEnd = int.Parse(drow["LessInterestPrematureEnd"].ToString());
                    obj.PeriodType = drow["PeriodType"].ToString();
                    obj.InstallmentPeriod = int.Parse(drow["InstallmentPeriod"].ToString());
                    obj.PenaltyLateInstallment = int.Parse(drow["PenaltyLateInstallment"].ToString());
                    obj.GraceDaysPenalty = int.Parse(drow["GraceDaysPenalty"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SaveSavingProduct(SavingProductForSave savingProduct)
        {
            string sp = "FN_SAVING_PKG.P_SAVING_PRODUCTS";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_CODE", savingProduct.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_NAME", savingProduct.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_PREFIX", savingProduct.ProductPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_TYPE_CODE", savingProduct.ProductTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_SCHEME_CODE", savingProduct.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_METHOD", savingProduct.IntCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_BALANCE", savingProduct.MinBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_INTEREST_BALANCE", savingProduct.MinInterestBalance, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_WITHDRAW_AMOUNT", savingProduct.MaxWithdrawAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LESS_INTEREST_PREMATURE_END", savingProduct.LessInterestPremature_End, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PERIOD_TYPE", savingProduct.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_PERIOD", savingProduct.InstallmentPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_LATE_INSTALLMENT", savingProduct.PenaltyLateInstallment, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS_PENALTY", savingProduct.GraceDaysPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TILL", savingProduct.PenaltyCalcTill, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_HEAD", savingProduct.SavingAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCURATE_INT_ACCOUNT_HEAD", savingProduct.AccurateIntAccount_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_ACCOUNT_HEAD", savingProduct.InterestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_HEAD", savingProduct.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_START_FROM", savingProduct.ProductStartFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRODUCT_VALID_TILL", savingProduct.ProductValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TDS_INTEREST_PERCENTAGE", savingProduct.TdsInterestPercentage, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_PERIOD", savingProduct.IntCalcPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COMPULSORY", savingProduct.Compulsory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_ACCOUNT_OPEN_AMOUNT", savingProduct.MinAccountOpen_Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACCOUNT_CLOSING_CHARGE", savingProduct.AccountClosingCharge, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSE_IF_LOAN_EXISTS", savingProduct.AccCloseIf_Loan_Exists, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLOSING_CHARGE_ACC_HEAD", savingProduct.ClosingChargeAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TAX_ON_INT_ACC_HEAD", savingProduct.TaxOnInt_Acc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_DAY", savingProduct.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PREMATURED_INT_RATIO", savingProduct.PrematuredIntRatio, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE_LIMIT", savingProduct.InterestTaxableLimit, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_TAXABLE", savingProduct.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MIN_TERM_INT_RATE", savingProduct.MinTermInt_Rate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CAPITALIZED", savingProduct.IntCapitalized, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_ACCOUNT_OPEN", savingProduct.NoOfAccount_Open, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACC_CLOSED_IF_CLIENT_ACTIVE", savingProduct.AccClosedIf_Client_Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_INCOME_AC_HEAD_NO", savingProduct.OtherIncomeAc_Head_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OTHER_EXPENSE_AC_HEAD_NO", savingProduct.OtherExpenseAc_Head_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_ACCOUNT_Y_N", savingProduct.ReferenceAccountY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_PRODUCT_FOR", savingProduct.SavingProductFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", savingProduct.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MANUAL_CLOSING", savingProduct.ManualClosing, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_THIRD_PARTY_DATA", savingProduct.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPOSIT_PERIOD_TYPE", savingProduct.TotalDepositPeriod_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TOTAL_DEPOSIT_PERIOD", savingProduct.TotalDepositPeriod, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REFERENCE_SAV_PRODUCT_CODE", savingProduct.ReferenceSavProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_INT_PERIODIC", savingProduct.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAXIMUM_INACTIVE_DAYS", savingProduct.MaximumInactiveDays, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTION_FOR_MAX_INACTIVE_DAYS", savingProduct.ActionForMax_Inactive_Days, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", savingProduct.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", savingProduct.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(SavingProduct savingProduct)
        {
            string sp = "savingProduct_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyCalcTill", savingProduct.PenaltyCalcTill, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountHead", savingProduct.SavingAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestAccountHead", savingProduct.InterestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyAccountHead", savingProduct.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductStartFrom", savingProduct.ProductStartFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductValidTill", savingProduct.ProductValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TdsInterestPercentage", savingProduct.TdsInterestPercentage, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntCalcPeriod", savingProduct.IntCalcPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Compulsory", savingProduct.Compulsory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinAccountOpenAmount", savingProduct.MinAccountOpenAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccountClosingCharge", savingProduct.AccountClosingCharge, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccCloseIfLoanExists", savingProduct.AccCloseIfLoanExists, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosingChargeAccHead", savingProduct.ClosingChargeAccHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TaxOnIntAccHead", savingProduct.TaxOnIntAccHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", savingProduct.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", savingProduct.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", savingProduct.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", savingProduct.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectionDay", savingProduct.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PrematuredIntRatio", savingProduct.PrematuredIntRatio, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestTaxableLimit", savingProduct.InterestTaxableLimit, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestTaxable", savingProduct.InterestTaxable, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinTermIntRate", savingProduct.MinTermIntRate, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", savingProduct.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceAccountYN", savingProduct.ReferenceAccountYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PreCashDeductionOrder", savingProduct.PreCashDeductionOrder, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", savingProduct.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Description", savingProduct.Description, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfAccountOpen", savingProduct.NoOfAccountOpen, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccClosedIfClientActive", savingProduct.AccClosedIfClientActive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherIncomeAcHead", savingProduct.OtherIncomeAcHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OtherExpenseAcHead", savingProduct.OtherExpenseAcHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntCapitalized", savingProduct.IntCapitalized, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductFor", savingProduct.SavingProductFor, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CompulsoryAmount", savingProduct.CompulsoryAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MidTermClosingType", savingProduct.MidTermClosingType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LedgerReportName", savingProduct.LedgerReportName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RegisterReportName", savingProduct.RegisterReportName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestPayableReportName", savingProduct.InterestPayableReportName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeIncomeAccountHead", savingProduct.ChargeIncomeAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ClosedAcLedgerReportName", savingProduct.ClosedAcLedgerReportName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PayUnpostInterestYN", savingProduct.PayUnpostInterestYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MannualClosingYN", savingProduct.MannualClosingYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfChequePrint", savingProduct.NoOfChequePrint, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalDepositPeriodType", savingProduct.TotalDepositPeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TotalDepositPeriod", savingProduct.TotalDepositPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ReferenceSavingProductCode", savingProduct.ReferenceSavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TransferIntPeriodic", savingProduct.TransferIntPeriodic, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaximumInactiveDays", savingProduct.MaximumInactiveDays, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActionForMaxInactiveDays", savingProduct.ActionForMaxInactiveDays, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RecalculateMidtermInt", savingProduct.RecalculateMidtermInt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AccurateIntAcHead", savingProduct.AccurateIntAcHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductCode", savingProduct.ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductName", savingProduct.ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductPrefix", savingProduct.ProductPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ProductTypeCode", savingProduct.ProductTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntSchemeCode", savingProduct.IntSchemeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntCalcMethod", savingProduct.IntCalcMethod, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinBalance", savingProduct.MinBalance, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinInterestBalance", savingProduct.MinInterestBalance, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxWithdrawAmount", savingProduct.MaxWithdrawAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LessInterestPrematureEnd", savingProduct.LessInterestPrematureEnd, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PeriodType", savingProduct.PeriodType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InstallmentPeriod", savingProduct.InstallmentPeriod, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PenaltyLateInstallment", savingProduct.PenaltyLateInstallment, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GraceDaysPenalty", savingProduct.GraceDaysPenalty, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProduct> lst = new List<SavingProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingProduct obj = new SavingProduct();
                    obj.PenaltyCalcTill = int.Parse(drow["PenaltyCalcTill"].ToString());
                    obj.SavingAccountHead = drow["SavingAccountHead"].ToString();
                    obj.InterestAccountHead = drow["InterestAccountHead"].ToString();
                    obj.PenaltyAccountHead = drow["PenaltyAccountHead"].ToString();
                    obj.ProductStartFrom = drow["ProductStartFrom"].ToString();
                    obj.ProductValidTill = drow["ProductValidTill"].ToString();
                    obj.TdsInterestPercentage = int.Parse(drow["TdsInterestPercentage"].ToString());
                    obj.IntCalcPeriod = int.Parse(drow["IntCalcPeriod"].ToString());
                    obj.Compulsory = drow["Compulsory"].ToString();
                    obj.MinAccountOpenAmount = int.Parse(drow["MinAccountOpenAmount"].ToString());
                    obj.AccountClosingCharge = int.Parse(drow["AccountClosingCharge"].ToString());
                    obj.AccCloseIfLoanExists = drow["AccCloseIfLoanExists"].ToString();
                    obj.ClosingChargeAccHead = drow["ClosingChargeAccHead"].ToString();
                    obj.TaxOnIntAccHead = drow["TaxOnIntAccHead"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.FixedCollectionDay = drow["FixedCollectionDay"].ToString();
                    obj.PrematuredIntRatio = int.Parse(drow["PrematuredIntRatio"].ToString());
                    obj.InterestTaxableLimit = int.Parse(drow["InterestTaxableLimit"].ToString());
                    obj.InterestTaxable = drow["InterestTaxable"].ToString();
                    obj.MinTermIntRate = int.Parse(drow["MinTermIntRate"].ToString());
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.ReferenceAccountYN = drow["ReferenceAccountYN"].ToString();
                    obj.PreCashDeductionOrder = int.Parse(drow["PreCashDeductionOrder"].ToString());
                    obj.Active = drow["Active"].ToString();
                    obj.Description = drow["Description"].ToString();
                    obj.NoOfAccountOpen = int.Parse(drow["NoOfAccountOpen"].ToString());
                    obj.AccClosedIfClientActive = drow["AccClosedIfClientActive"].ToString();
                    obj.OtherIncomeAcHead = drow["OtherIncomeAcHead"].ToString();
                    obj.OtherExpenseAcHead = drow["OtherExpenseAcHead"].ToString();
                    obj.IntCapitalized = drow["IntCapitalized"].ToString();
                    obj.SavingProductFor = drow["SavingProductFor"].ToString();
                    obj.CompulsoryAmount = int.Parse(drow["CompulsoryAmount"].ToString());
                    obj.MidTermClosingType = drow["MidTermClosingType"].ToString();
                    obj.LedgerReportName = drow["LedgerReportName"].ToString();
                    obj.RegisterReportName = drow["RegisterReportName"].ToString();
                    obj.InterestPayableReportName = drow["InterestPayableReportName"].ToString();
                    obj.ChargeIncomeAccountHead = drow["ChargeIncomeAccountHead"].ToString();
                    obj.ClosedAcLedgerReportName = drow["ClosedAcLedgerReportName"].ToString();
                    obj.PayUnpostInterestYN = drow["PayUnpostInterestYN"].ToString();
                    obj.MannualClosingYN = drow["MannualClosingYN"].ToString();
                    obj.NoOfChequePrint = int.Parse(drow["NoOfChequePrint"].ToString());
                    obj.TotalDepositPeriodType = drow["TotalDepositPeriodType"].ToString();
                    obj.TotalDepositPeriod = int.Parse(drow["TotalDepositPeriod"].ToString());
                    obj.ReferenceSavingProductCode = drow["ReferenceSavingProductCode"].ToString();
                    obj.TransferIntPeriodic = drow["TransferIntPeriodic"].ToString();
                    obj.MaximumInactiveDays = int.Parse(drow["MaximumInactiveDays"].ToString());
                    obj.ActionForMaxInactiveDays = drow["ActionForMaxInactiveDays"].ToString();
                    obj.RecalculateMidtermInt = drow["RecalculateMidtermInt"].ToString();
                    obj.AccurateIntAcHead = drow["AccurateIntAcHead"].ToString();
                    obj.ProductCode = drow["ProductCode"].ToString();
                    obj.ProductName = drow["ProductName"].ToString();
                    obj.ProductPrefix = drow["ProductPrefix"].ToString();
                    obj.ProductTypeCode = drow["ProductTypeCode"].ToString();
                    obj.IntSchemeCode = drow["IntSchemeCode"].ToString();
                    obj.IntCalcMethod = drow["IntCalcMethod"].ToString();
                    obj.MinBalance = int.Parse(drow["MinBalance"].ToString());
                    obj.MinInterestBalance = int.Parse(drow["MinInterestBalance"].ToString());
                    obj.MaxWithdrawAmount = int.Parse(drow["MaxWithdrawAmount"].ToString());
                    obj.LessInterestPrematureEnd = int.Parse(drow["LessInterestPrematureEnd"].ToString());
                    obj.PeriodType = drow["PeriodType"].ToString();
                    obj.InstallmentPeriod = int.Parse(drow["InstallmentPeriod"].ToString());
                    obj.PenaltyLateInstallment = int.Parse(drow["PenaltyLateInstallment"].ToString());
                    obj.GraceDaysPenalty = int.Parse(drow["GraceDaysPenalty"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetProductAccOpen(string productName)
        {
            string sp = "fn_saving_utility_pkg.p_product_ac_open_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_product_name", productName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProduct> lst = new List<SavingProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    /*
                     * PRODUCT_CODE,
         PRODUCT_NAME,
         INT_SCHEME_CODE,
         F_GET_INT_SCHEME_DESC (INT_SCHEME_CODE) AS INT_SCHEME_DESC,
         ACCOUNT_CLOSING_CHARGE,
         PRODUCT_TYPE_CODE,
         NVL (COMPULSORY_AMOUNT, 0) COMPULSORY_AMOUNT,*/
                    SavingProduct obj = new SavingProduct();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.IntSchemeDesc = drow["INT_SCHEME_DESC"].ToString();
                    obj.AccountClosingCharge =double.Parse(OracleUtilityDao.ConvertNullToNumber( drow["ACCOUNT_CLOSING_CHARGE"].ToString()));
                    obj.ProductTypeCode   = drow["PRODUCT_TYPE_CODE"].ToString();
                    obj.CompulsoryAmount = double.Parse(drow["COMPULSORY_AMOUNT"].ToString());
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetSavingProduct(string ProductName)
        {
            string sp = "FN_SAVING_UTILITY_PKG.p_saving_product_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRODUCT_NAME", ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProduct> lst = new List<SavingProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingProduct obj = new SavingProduct();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetSavingProductList(string ProductName)
        {
            string sp = "fn_saving_utility_pkg.p_saving_product_lov_list  ";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRODUCT_NAME", ProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<SavingProduct> lst = new List<SavingProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    SavingProduct obj = new SavingProduct();
                    obj.ProductCode = drow["PRODUCT_CODE"].ToString();
                    obj.ProductName = drow["PRODUCT_NAME"].ToString();
                    obj.IntSchemeCode = drow["INT_SCHEME_CODE"].ToString();
                    obj.IntSchemeDesc = drow["INT_SCHEME_DESC"].ToString();
                    obj.ProductTypeCode = drow["PRODUCT_TYPE_CODE"].ToString();
                    obj.ProductTypeDesc = drow["PRODUCT_TYPE_DESC"].ToString();
                    obj.AccountClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ACCOUNT_CLOSING_CHARGE"].ToString()));
                    obj.ProductClass = drow["PRODUCT_CLASS"].ToString();

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
