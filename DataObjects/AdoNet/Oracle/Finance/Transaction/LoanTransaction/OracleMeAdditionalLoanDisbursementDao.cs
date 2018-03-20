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
    public class OracleMeAdditionalLoanDisbursementDao : IMeAdditionalLoanDisbursementDao
    {
        public object Get()
        {
            string sp = "meAdditionalLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeAdditionalLoanDisbursement> lst = new List<MeAdditionalLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeAdditionalLoanDisbursement obj = new MeAdditionalLoanDisbursement();
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

        public object Save(MeAdditionalLoanDisbursement meAdditionalLoanDisbursement)
        {
            string sp = "fn_loan_pkg.p_me_additional_loan_disb";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {

                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_loan_no", meAdditionalLoanDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_product_code", meAdditionalLoanDisbursement.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_disburse_date", meAdditionalLoanDisbursement.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_amount", meAdditionalLoanDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_contra_account", meAdditionalLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_employee_id", meAdditionalLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", meAdditionalLoanDisbursement.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction1_code", meAdditionalLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction1_desc", meAdditionalLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_deduction_amount1", meAdditionalLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", meAdditionalLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", meAdditionalLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", meAdditionalLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", meAdditionalLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", meAdditionalLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", meAdditionalLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", meAdditionalLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", meAdditionalLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", meAdditionalLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", meAdditionalLoanDisbursement.ChkAdjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", meAdditionalLoanDisbursement.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", meAdditionalLoanDisbursement.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", meAdditionalLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", meAdditionalLoanDisbursement.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_S_NO", meAdditionalLoanDisbursement.OutS_No, OracleDbType.Double, ParameterDirection.InputOutput));
                //paramList.Add(SqlHelper.GetOraParam(":p_action", meAdditionalLoanDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MeAdditionalLoanDisbursement meAdditionalLoanDisbursement)
        {
            string sp = "meAdditionalLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", meAdditionalLoanDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meAdditionalLoanDisbursement.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", meAdditionalLoanDisbursement.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", meAdditionalLoanDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", meAdditionalLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", meAdditionalLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", meAdditionalLoanDisbursement.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", meAdditionalLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", meAdditionalLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", meAdditionalLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", meAdditionalLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", meAdditionalLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", meAdditionalLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", meAdditionalLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", meAdditionalLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", meAdditionalLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", meAdditionalLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", meAdditionalLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", meAdditionalLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", meAdditionalLoanDisbursement.ChkAdjust_Saving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", meAdditionalLoanDisbursement.SavingAccount_No, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", meAdditionalLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", meAdditionalLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", meAdditionalLoanDisbursement.OutFiscal_Year, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_S_NO", meAdditionalLoanDisbursement.OutS_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeAdditionalLoanDisbursement> lst = new List<MeAdditionalLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeAdditionalLoanDisbursement obj = new MeAdditionalLoanDisbursement();
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
