using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Processing;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanRepaymentDao : ILoanRepaymentDao
    {
        public object SaveLoanRepayment(LoanRepayment loanRepayment)
        {
            string sp = "loanRepayment_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanRepayment.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", loanRepayment.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", loanRepayment.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", loanRepayment.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", loanRepayment.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", loanRepayment.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", loanRepayment.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_NO", loanRepayment.SavAcNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_DESC", loanRepayment.ContraAcDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", loanRepayment.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", loanRepayment.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanRepayment.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchLoanRepayment(LoanRepayment loanRepayment)
        {
            string sp = "loanRepayment_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanRepayment.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", loanRepayment.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", loanRepayment.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAID_AMOUNT", loanRepayment.PaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_PAID_AMOUNT", loanRepayment.PrincipalPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_PAID_AMOUNT", loanRepayment.InterestPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_PAID_AMOUNT", loanRepayment.PenaltyPaidAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SAV_AC_NO", loanRepayment.SavAcNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CONTRA_AC_DESC", loanRepayment.ContraAcDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHEQUE_NO", loanRepayment.ChequeNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", loanRepayment.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanRepayment> lst = new List<LoanRepayment>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanRepayment obj = new LoanRepayment();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                    obj.InterestPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                    obj.PenaltyPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                    obj.SavAcNo = drow["SAV_AC_NO"].ToString();
                    obj.ContraAcDesc = drow["CONTRA_AC_DESC"].ToString();
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanRepayment(string OfficeCode, string UserCode)
        {
            string sp = "transaction_approval_pkg.p_loan_repayment_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER_CODE", UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanRepayment> lst = new List<LoanRepayment>();
                for (int i = 0; i < 10; i++)
                {
                    LoanRepayment obj = new LoanRepayment();
                    obj.LoanNo = i.ToString();
                    obj.MemberName = i.ToString();
                    obj.LoanDno = i.ToString();
                    obj.PaidAmount = i;
                    obj.PrincipalPaidAmount = i;
                    obj.InterestPaidAmount = i;
                    obj.PenaltyPaidAmount = i;
                    obj.SavAcNo = i.ToString();
                    obj.ContraAcDesc = i.ToString();
                    obj.ChequeNo = i.ToString();
                    obj.RepaymentNo = i;

                    lst.Add(obj);
                }
                //foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                //{
                //    LoanRepayment obj = new LoanRepayment();
                //    obj.LoanNo = drow["LOAN_NO"].ToString();
                //    obj.MemberName = drow["MEMBER_NAME"].ToString();
                //    obj.LoanDno = drow["LOAN_DNO"].ToString();
                //    obj.PaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PAID_AMOUNT"].ToString()));
                //    obj.PrincipalPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_PAID_AMOUNT"].ToString()));
                //    obj.InterestPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_PAID_AMOUNT"].ToString()));
                //    obj.PenaltyPaidAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_PAID_AMOUNT"].ToString()));
                //    obj.SavAcNo = drow["SAV_AC_NO"].ToString();
                //    obj.ContraAcDesc = drow["CONTRA_AC_DESC"].ToString();
                //    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                //    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));

                //    lst.Add(obj);
                //}
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}
