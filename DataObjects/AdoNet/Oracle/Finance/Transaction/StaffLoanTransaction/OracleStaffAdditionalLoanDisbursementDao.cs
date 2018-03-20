using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleStaffAdditionalLoanDisbursementDao : IStaffAdditionalLoanDisbursementDao
    {
        public object SaveStaffAdditionalLoanDisbursement(StaffAdditionalLoanDisbursement staffAdditionalLoanDisbursement)
        {
            string sp = "staffAdditionalLoanDisbursement_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffAdditionalLoanDisbursement.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffAdditionalLoanDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffAdditionalLoanDisbursement.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", staffAdditionalLoanDisbursement.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", staffAdditionalLoanDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffAdditionalLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffAdditionalLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffAdditionalLoanDisbursement.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", staffAdditionalLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", staffAdditionalLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", staffAdditionalLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", staffAdditionalLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", staffAdditionalLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", staffAdditionalLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", staffAdditionalLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", staffAdditionalLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", staffAdditionalLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", staffAdditionalLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", staffAdditionalLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", staffAdditionalLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", staffAdditionalLoanDisbursement.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffAdditionalLoanDisbursement.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffAdditionalLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffAdditionalLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffAdditionalLoanDisbursement.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_S_NO", staffAdditionalLoanDisbursement.OutSNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffAdditionalLoanDisbursement.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffAdditionalLoanDisbursement(StaffAdditionalLoanDisbursement staffAdditionalLoanDisbursement)
        {
            string sp = "staffAdditionalLoanDisbursement_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", staffAdditionalLoanDisbursement.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffAdditionalLoanDisbursement.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffAdditionalLoanDisbursement.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DISBURSE_DATE", staffAdditionalLoanDisbursement.DisburseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_AMOUNT", staffAdditionalLoanDisbursement.LoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_ACCOUNT", staffAdditionalLoanDisbursement.ContraAccount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffAdditionalLoanDisbursement.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", staffAdditionalLoanDisbursement.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", staffAdditionalLoanDisbursement.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", staffAdditionalLoanDisbursement.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", staffAdditionalLoanDisbursement.DeductionAmount1, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", staffAdditionalLoanDisbursement.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", staffAdditionalLoanDisbursement.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", staffAdditionalLoanDisbursement.DeductionAmount2, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", staffAdditionalLoanDisbursement.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", staffAdditionalLoanDisbursement.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", staffAdditionalLoanDisbursement.DeductionAmount3, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", staffAdditionalLoanDisbursement.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", staffAdditionalLoanDisbursement.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", staffAdditionalLoanDisbursement.DeductionAmount4, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHK_ADJUST_SAVING", staffAdditionalLoanDisbursement.ChkAdjustSaving, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAVING_ACCOUNT_NO", staffAdditionalLoanDisbursement.SavingAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", staffAdditionalLoanDisbursement.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", staffAdditionalLoanDisbursement.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", staffAdditionalLoanDisbursement.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_S_NO", staffAdditionalLoanDisbursement.OutSNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffAdditionalLoanDisbursement> lst = new List<StaffAdditionalLoanDisbursement>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffAdditionalLoanDisbursement obj = new StaffAdditionalLoanDisbursement();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.DisburseDate = drow["DISBURSE_DATE"].ToString();
                    obj.LoanAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LOAN_AMOUNT"].ToString()));
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
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
                    obj.ChkAdjustSaving = drow["CHK_ADJUST_SAVING"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutSNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_S_NO"].ToString()));

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
