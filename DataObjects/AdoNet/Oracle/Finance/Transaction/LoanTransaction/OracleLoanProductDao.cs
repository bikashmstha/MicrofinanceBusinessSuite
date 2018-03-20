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
    public class OracleLoanProductDao : ILoanProductDao
    {
        private static ILoanProductDeductionDao LoanProductDeductionDao = DataAccess.LoanProductDeductionDao;
        public object Get()
        {
            string sp = "loanProduct_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanProduct> lst = new List<LoanProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanProduct obj = new LoanProduct();
                    obj.LoanProductCode = double.Parse(drow["LoanProductCode"].ToString());
                    obj.LoanProductName = drow["LoanProductName"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.IntCalcType = drow["IntCalcType"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SaveLoanProduct(LoanProduct loanProduct)
        {
            string sp = "fn_loan_pkg.p_loan_products";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanProduct.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", loanProduct.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_TYPE", loanProduct.LoanType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PREFIX", loanProduct.LoanPrefix, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_M_LOAN_AMOUNT", loanProduct.MLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_LOAN_AMOUNT", loanProduct.MaxLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TEREST_RATE", loanProduct.TerestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_T_PAY_ON_STALLMENT", loanProduct.TPayOn_Stallment, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_T_CALC_TYPE", loanProduct.TCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_M_LOAN_TERM_MONTHS", loanProduct.MLoanTerm_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_LOAN_TERM_MONTHS", loanProduct.MaxLoanTerm_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_GRACE_DAYS", loanProduct.MaxGraceDays, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_T_CALC_ON_GRACE_DAYS", loanProduct.TCalcOn_Grace_Days, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC", loanProduct.PenaltyCalc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TYPE", loanProduct.PenaltyCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_VALUE", loanProduct.PenaltyCalcValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_ON_HOLIDAY", loanProduct.PenaltyCalcOn_Holiday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_CALC_TILL_MONTHS", loanProduct.PenaltyCalcTill_Months, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRACE_DAYS_PENALTY", loanProduct.GraceDaysPenalty, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_M_BAL__SAVG_ACCOUNT", loanProduct.MBal_Savg_Account, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRCIPAL_ACCOUNT_HEAD", loanProduct.PrcipalAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TEREST_ACCOUNT_HEAD", loanProduct.TerestAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_ACCOUNT_HEAD", loanProduct.PenaltyAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_WISE_LOAN_LIMIT", loanProduct.YearWiseLoan_Limit, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MAX_FIXED_LOAN_PCT", loanProduct.MaxFixedLoan_Pct, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_DAY", loanProduct.FixedCollectionDay, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_T_RECEIVABLE_ACC_HEAD", loanProduct.TReceivableAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PEN_RECEIVABLE_ACC_HEAD", loanProduct.PenReceivableAcc_Head, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUSPENSE_ACC_HEAD", loanProduct.SuspenseAccHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISPLAY_SEQ", loanProduct.DisplaySeq, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_CATEGORY", loanProduct.LoanCategory, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEMAND_Y_N", loanProduct.DemandYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", loanProduct.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_FROM", loanProduct.ValidFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VALID_TILL", loanProduct.ValidTill, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_ACCOUNT_OPEN", loanProduct.NoOfAccount_Open, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CIB_CODE", loanProduct.CibCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_PROD_CODE", loanProduct.SavProdCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVAL_T", loanProduct.ApprovalT, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", loanProduct.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanProduct.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());

                LoanProductDeductionDao.SaveLoanProductDeduction(loanProduct.LoanProductDeductions, tran);


                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object Search(LoanProduct loanProduct)
        {
            string sp = "loanProduct_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", loanProduct.LoanProductCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductName", loanProduct.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", loanProduct.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IntCalcType", loanProduct.IntCalcType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", loanProduct.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanProduct> lst = new List<LoanProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanProduct obj = new LoanProduct();
                    obj.LoanProductCode = double.Parse(drow["LoanProductCode"].ToString());
                    obj.LoanProductName = drow["LoanProductName"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.IntCalcType = drow["IntCalcType"].ToString();
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanProduct(string productName)
        {
            string sp = "fn_loan_pkg.p_mf_loan_product_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", productName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanProduct> lst = new List<LoanProduct>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanProduct obj = new LoanProduct();
                    obj.LoanProductCode = double.Parse(drow["Loan_Product_Code"].ToString());
                    obj.LoanProductName = drow["Loan_Product_Name"].ToString();
                    obj.InterestRate = double.Parse(drow["Interest_Rate"].ToString());
                    obj.IntCalcType = drow["Int_Calc_Type"].ToString();
                    obj.RowCount = double.Parse(drow["Row_Count"].ToString());

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
