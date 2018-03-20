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
    public class OracleLoanInformationDao : ILoanInformationDao
    {
        public object SaveLoanInformation(LoanInformation loanInformation)
        {
            string sp = "loanInformation_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALLMENT_DATE", loanInformation.FirstInstallmentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALLMENT_DATE_NP", loanInformation.FirstInstallmentDate_Np, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE", loanInformation.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE_NP", loanInformation.MaturityDateNp, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", loanInformation.NoOfInstallment, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMT", loanInformation.InstallmentAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRIN_AMT", loanInformation.FixedPrinAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INT_AMT", loanInformation.FixedIntAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", loanInformation.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", loanInformation.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", loanInformation.DeductionAmount1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N1", loanInformation.ChoiceDeductY_N1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", loanInformation.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", loanInformation.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", loanInformation.DeductionAmount2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N2", loanInformation.ChoiceDeductY_N2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", loanInformation.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", loanInformation.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", loanInformation.DeductionAmount3, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N3", loanInformation.ChoiceDeductY_N3, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", loanInformation.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", loanInformation.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", loanInformation.DeductionAmount4, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N4", loanInformation.ChoiceDeductY_N4, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NET_DEDUCTION_AMOUNT", loanInformation.NetDeductionAmount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanInformation.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchLoanInformation(LoanInformation loanInformation)
        {
            string sp = "loanInformation_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALLMENT_DATE", loanInformation.FirstInstallmentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIRST_INSTALLMENT_DATE_NP", loanInformation.FirstInstallmentDate_Np, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE", loanInformation.MaturityDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURITY_DATE_NP", loanInformation.MaturityDateNp, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_OF_INSTALLMENT", loanInformation.NoOfInstallment, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSTALLMENT_AMT", loanInformation.InstallmentAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_PRIN_AMT", loanInformation.FixedPrinAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_INT_AMT", loanInformation.FixedIntAmt, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_CODE", loanInformation.Deduction1Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION1_DESC", loanInformation.Deduction1Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT1", loanInformation.DeductionAmount1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N1", loanInformation.ChoiceDeductY_N1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_CODE", loanInformation.Deduction2Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION2_DESC", loanInformation.Deduction2Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT2", loanInformation.DeductionAmount2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N2", loanInformation.ChoiceDeductY_N2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_CODE", loanInformation.Deduction3Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION3_DESC", loanInformation.Deduction3Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT3", loanInformation.DeductionAmount3, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N3", loanInformation.ChoiceDeductY_N3, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_CODE", loanInformation.Deduction4Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION4_DESC", loanInformation.Deduction4Desc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEDUCTION_AMOUNT4", loanInformation.DeductionAmount4, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHOICE_DEDUCT_Y_N4", loanInformation.ChoiceDeductY_N4, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NET_DEDUCTION_AMOUNT", loanInformation.NetDeductionAmount, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanInformation> lst = new List<LoanInformation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanInformation obj = new LoanInformation();
                    obj.FirstInstallmentDate = drow["FIRST_INSTALLMENT_DATE"].ToString();
                    obj.FirstInstallmentDate_Np = drow["FIRST_INSTALLMENT_DATE_NP"].ToString();
                    obj.MaturityDate = drow["MATURITY_DATE"].ToString();
                    obj.MaturityDateNp = drow["MATURITY_DATE_NP"].ToString();
                    obj.NoOfInstallment = drow["NO_OF_INSTALLMENT"].ToString();
                    obj.InstallmentAmt = drow["INSTALLMENT_AMT"].ToString();
                    obj.FixedPrinAmt = drow["FIXED_PRIN_AMT"].ToString();
                    obj.FixedIntAmt = drow["FIXED_INT_AMT"].ToString();
                    obj.Deduction1Code = drow["DEDUCTION1_CODE"].ToString();
                    obj.Deduction1Desc = drow["DEDUCTION1_DESC"].ToString();
                    obj.DeductionAmount1 = drow["DEDUCTION_AMOUNT1"].ToString();
                    obj.ChoiceDeductY_N1 = drow["CHOICE_DEDUCT_Y_N1"].ToString();
                    obj.Deduction2Code = drow["DEDUCTION2_CODE"].ToString();
                    obj.Deduction2Desc = drow["DEDUCTION2_DESC"].ToString();
                    obj.DeductionAmount2 = drow["DEDUCTION_AMOUNT2"].ToString();
                    obj.ChoiceDeductY_N2 = drow["CHOICE_DEDUCT_Y_N2"].ToString();
                    obj.Deduction3Code = drow["DEDUCTION3_CODE"].ToString();
                    obj.Deduction3Desc = drow["DEDUCTION3_DESC"].ToString();
                    obj.DeductionAmount3 = drow["DEDUCTION_AMOUNT3"].ToString();
                    obj.ChoiceDeductY_N3 = drow["CHOICE_DEDUCT_Y_N3"].ToString();
                    obj.Deduction4Code = drow["DEDUCTION4_CODE"].ToString();
                    obj.Deduction4Desc = drow["DEDUCTION4_DESC"].ToString();
                    obj.DeductionAmount4 = drow["DEDUCTION_AMOUNT4"].ToString();
                    obj.ChoiceDeductY_N4 = drow["CHOICE_DEDUCT_Y_N4"].ToString();
                    obj.NetDeductionAmount = drow["NET_DEDUCTION_AMOUNT"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanInformation()
        {
            string sp = "fn_loan_utility.p_loan_information";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanInformation> lst = new List<LoanInformation>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanInformation obj = new LoanInformation();
                    obj.FirstInstallmentDate = drow["FIRST_INSTALLMENT_DATE"].ToString();
                    obj.FirstInstallmentDate_Np = drow["FIRST_INSTALLMENT_DATE_NP"].ToString();
                    obj.MaturityDate = drow["MATURITY_DATE"].ToString();
                    obj.MaturityDateNp = drow["MATURITY_DATE_NP"].ToString();
                    obj.NoOfInstallment = drow["NO_OF_INSTALLMENT"].ToString();
                    obj.InstallmentAmt = drow["INSTALLMENT_AMT"].ToString();
                    obj.FixedPrinAmt = drow["FIXED_PRIN_AMT"].ToString();
                    obj.FixedIntAmt = drow["FIXED_INT_AMT"].ToString();
                    obj.Deduction1Code = drow["DEDUCTION1_CODE"].ToString();
                    obj.Deduction1Desc = drow["DEDUCTION1_DESC"].ToString();
                    obj.DeductionAmount1 = drow["DEDUCTION_AMOUNT1"].ToString();
                    obj.ChoiceDeductY_N1 = drow["CHOICE_DEDUCT_Y_N1"].ToString();
                    obj.Deduction2Code = drow["DEDUCTION2_CODE"].ToString();
                    obj.Deduction2Desc = drow["DEDUCTION2_DESC"].ToString();
                    obj.DeductionAmount2 = drow["DEDUCTION_AMOUNT2"].ToString();
                    obj.ChoiceDeductY_N2 = drow["CHOICE_DEDUCT_Y_N2"].ToString();
                    obj.Deduction3Code = drow["DEDUCTION3_CODE"].ToString();
                    obj.Deduction3Desc = drow["DEDUCTION3_DESC"].ToString();
                    obj.DeductionAmount3 = drow["DEDUCTION_AMOUNT3"].ToString();
                    obj.ChoiceDeductY_N3 = drow["CHOICE_DEDUCT_Y_N3"].ToString();
                    obj.Deduction4Code = drow["DEDUCTION4_CODE"].ToString();
                    obj.Deduction4Desc = drow["DEDUCTION4_DESC"].ToString();
                    obj.DeductionAmount4 = drow["DEDUCTION_AMOUNT4"].ToString();
                    obj.ChoiceDeductY_N4 = drow["CHOICE_DEDUCT_Y_N4"].ToString();
                    obj.NetDeductionAmount = drow["NET_DEDUCTION_AMOUNT"].ToString();

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
