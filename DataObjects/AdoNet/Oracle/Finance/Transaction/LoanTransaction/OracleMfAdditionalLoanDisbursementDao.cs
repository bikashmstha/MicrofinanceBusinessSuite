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
    public class OracleMfAdditionalLoanDisbursementDao : IMfAdditionalLoanDisbursementDao
    {
        public object Get()
        {
            string sp = "mfAdditionalLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdditionalLoanDisbursement> lst = new List<MfAdditionalLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdditionalLoanDisbursement obj = new MfAdditionalLoanDisbursement();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.Deduction1Code = drow["DEDUCTION1_CODE"].ToString();
                    obj.Deduction1Desc = drow["DEDUCTION1_DESC"].ToString();
                    obj.DeductionAmount1 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT1"].ToString()));
                    obj.Deduction2Code = drow["DEDUCTION2_CODE"].ToString();
                    obj.Deduction2Desc = drow["DEDUCTION2_DESC"].ToString();
                    obj.DeductionAmount2 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT2"].ToString()));
                    obj.Deduction3Code = drow["DEDUCTION3_CODE"].ToString();
                    obj.Deduction3Desc = drow["DEDUCTION3_DESC"].ToString();
                    obj.DeductionAmount3 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT3"].ToString()));
                    obj.Deduction4Code = drow["DEDUCTION4_CODE"].ToString();
                    obj.Deduction4Desc = drow["DEDUCTION4_DESC"].ToString();
                    obj.DeductionAmount4 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT4"].ToString()));
                    obj.ChkAdjust_Saving = drow["CHK_ADJUST_SAVING"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscal_Year = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutS_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_S_NO"].ToString()));

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfAdditionalLoanDisbursement mfAdditionalLoanDisbursement)
        {
            string sp = "fn_loan_pkg.p_mf_additional_loan_disb";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();

                paramList.Add(SqlHelper.GetOraParam(":p_loan_no", mfAdditionalLoanDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_product_code", mfAdditionalLoanDisbursement.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_disburse_date", mfAdditionalLoanDisbursement.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_amount", mfAdditionalLoanDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_contra_account", mfAdditionalLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_employee_id", mfAdditionalLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", mfAdditionalLoanDisbursement.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction1_code", mfAdditionalLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction1_desc", mfAdditionalLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction_amount1", mfAdditionalLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction2_code", mfAdditionalLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction2_desc", mfAdditionalLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction_amount2", mfAdditionalLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction3_code", mfAdditionalLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction3_desc", mfAdditionalLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction_amount3", mfAdditionalLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction4_code", mfAdditionalLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction4_desc", mfAdditionalLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction_amount4", mfAdditionalLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_chk_adjust_saving", mfAdditionalLoanDisbursement.ChkAdjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_saving_account_no", mfAdditionalLoanDisbursement.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", mfAdditionalLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", mfAdditionalLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_fiscal_year", mfAdditionalLoanDisbursement.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_s_no", mfAdditionalLoanDisbursement.OutS_No, OracleDbType.Double, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                //paramList.Add(SqlHelper.GetOraParam(":p_action", mfAdditionalLoanDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_code", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_msg", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(MfAdditionalLoanDisbursement mfAdditionalLoanDisbursement)
        {
            string sp = "mfAdditionalLoan_pkg.p_search";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                 paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", mfAdditionalLoanDisbursement.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                
                 paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", mfAdditionalLoanDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", mfAdditionalLoanDisbursement.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", mfAdditionalLoanDisbursement.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", mfAdditionalLoanDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", mfAdditionalLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", mfAdditionalLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", mfAdditionalLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", mfAdditionalLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", mfAdditionalLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", mfAdditionalLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", mfAdditionalLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", mfAdditionalLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", mfAdditionalLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", mfAdditionalLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", mfAdditionalLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", mfAdditionalLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", mfAdditionalLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", mfAdditionalLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", mfAdditionalLoanDisbursement.ChkAdjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", mfAdditionalLoanDisbursement.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_USER1", mfAdditionalLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", mfAdditionalLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", mfAdditionalLoanDisbursement.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":p_OUT_S_NO", mfAdditionalLoanDisbursement.OutS_No, OracleDbType.Double, ParameterDirection.Input));
                 paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfAdditionalLoanDisbursement> lst = new List<MfAdditionalLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfAdditionalLoanDisbursement obj = new MfAdditionalLoanDisbursement();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.Deduction1Code = drow["DEDUCTION1_CODE"].ToString();
                    obj.Deduction1Desc = drow["DEDUCTION1_DESC"].ToString();
                    obj.DeductionAmount1 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT1"].ToString()));
                    obj.Deduction2Code = drow["DEDUCTION2_CODE"].ToString();
                    obj.Deduction2Desc = drow["DEDUCTION2_DESC"].ToString();
                    obj.DeductionAmount2 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT2"].ToString()));
                    obj.Deduction3Code = drow["DEDUCTION3_CODE"].ToString();
                    obj.Deduction3Desc = drow["DEDUCTION3_DESC"].ToString();
                    obj.DeductionAmount3 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT3"].ToString()));
                    obj.Deduction4Code = drow["DEDUCTION4_CODE"].ToString();
                    obj.Deduction4Desc = drow["DEDUCTION4_DESC"].ToString();
                    obj.DeductionAmount4 = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["DEDUCTION_AMOUNT4"].ToString()));
                    obj.ChkAdjust_Saving = drow["CHK_ADJUST_SAVING"].ToString();
                    obj.SavingAccount_No = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscal_Year = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutS_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_S_NO"].ToString()));

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
