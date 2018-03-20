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
    public class OracleLoanDeductionTypeDao : ILoanDeductionTypeDao
    {
        public object Get()
        {
            string sp = "FN_LOAN_PKG.p_loan_deduction_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanDeductionType> lst = new List<LoanDeductionType>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanDeductionType obj = new LoanDeductionType();
                    obj.DeductionTypeCode = drow["DEDUCTION_TYPE_CODE"].ToString();
                    obj.DeductionTypeDesc = drow["DEDUCTION_TYPE_DESC"].ToString();
                    obj.SavingAccountDeduction = drow["SAVING_ACCOUNT_DEDUCTION"].ToString();
                    obj.SavingProductCode = drow["SAVING_PRODUCT_CODE"].ToString();
                    obj.SavingProductDesc = drow["SAV_PROD_DESC"].ToString();


                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
                    //obj.DeductionRelatedTo = drow["DeductionRelatedTo"].ToString();
                    //obj.ChargeAmount = int.Parse(drow["ChargeAmount"].ToString());
                    obj.NonExistSavingProductDesc = drow["NON_EXIS_PROD_DESC"].ToString();
                    obj.NonExistSavingProductCode = drow["NON_EXIS_PROD_CODE"].ToString();
                    
                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LoanDeductionType loanDeductionType)
        {
            string sp = "FN_LOAN_PKG.P_LOAN_DEDUCTION_TYPE";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();

      



                paramList.Add(SqlHelper.GetOraParam(":p_deduction_type_code", loanDeductionType.DeductionTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction_type_desc", loanDeductionType.DeductionTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_saving_product_code", loanDeductionType.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_saving_account_deduction", loanDeductionType.SavingAccountDeduction, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_non_exist_saving_product", loanDeductionType.NonExistSavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input)); 
                paramList.Add(SqlHelper.GetOraParam(":p_user", loanDeductionType.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", loanDeductionType.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_date", loanDeductionType.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlag", loanDeductionType.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_DeductionRelatedTo", loanDeductionType.DeductionRelatedTo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ChargeAmount", loanDeductionType.ChargeAmount, OracleDbType.Int32, ParameterDirection.Input));
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

        public object Search(LoanDeductionType loanDeductionType)
        {
            string sp = "loanDeductionType_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionTypeCode", loanDeductionType.DeductionTypeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionTypeDesc", loanDeductionType.DeductionTypeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingAccountDeduction", loanDeductionType.SavingAccountDeduction, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SavingProductCode", loanDeductionType.SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", loanDeductionType.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", loanDeductionType.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlag", loanDeductionType.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DeductionRelatedTo", loanDeductionType.DeductionRelatedTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ChargeAmount", loanDeductionType.ChargeAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NonExistSavingProductCode", loanDeductionType.NonExistSavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanDeductionType> lst = new List<LoanDeductionType>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanDeductionType obj = new LoanDeductionType();
                    obj.DeductionTypeCode = drow["DeductionTypeCode"].ToString();
                    obj.DeductionTypeDesc = drow["DeductionTypeDesc"].ToString();
                    obj.SavingAccountDeduction = drow["SavingAccountDeduction"].ToString();
                    obj.SavingProductCode = drow["SavingProductCode"].ToString();


                    obj.ActiveFlag = drow["ActiveFlag"].ToString();
                    obj.DeductionRelatedTo = drow["DeductionRelatedTo"].ToString();
                    obj.ChargeAmount = int.Parse(drow["ChargeAmount"].ToString());
                    obj.NonExistSavingProductCode = drow["NonExistSavingProductCode"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanDeduction(string LoanDeductionDesc)
        {
            string sp = "fn_loan_pkg.p_loan_deduction_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_DEDUCTION_DESC", LoanDeductionDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanDeductionType> lst = new List<LoanDeductionType>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanDeductionType obj = new LoanDeductionType();
                    obj.DeductionTypeCode = drow["DEDUCTION_TYPE_CODE"].ToString();
                    obj.DeductionTypeDesc = drow["DEDUCTION_TYPE_DESC"].ToString();

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
