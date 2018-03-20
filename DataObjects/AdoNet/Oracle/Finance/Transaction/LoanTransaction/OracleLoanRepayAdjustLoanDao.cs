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
    public class OracleLoanRepayAdjustLoanDao : ILoanRepayAdjustLoanDao
    {
        public object Get()
        {
            string sp = "loanRepayAdjustLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanRepayAdjustLoan> lst = new List<LoanRepayAdjustLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanRepayAdjustLoan obj = new LoanRepayAdjustLoan();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.IntCalc_Type = drow["INT_CALC_TYPE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LoanRepayAdjustLoan loanRepayAdjustLoan)
        {
            string sp = "loanRepayAdjustLoan_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanRepayAdjustLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", loanRepayAdjustLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", loanRepayAdjustLoan.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", loanRepayAdjustLoan.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", loanRepayAdjustLoan.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", loanRepayAdjustLoan.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", loanRepayAdjustLoan.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", loanRepayAdjustLoan.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", loanRepayAdjustLoan.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanRepayAdjustLoan.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", loanRepayAdjustLoan.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", loanRepayAdjustLoan.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_TYPE", loanRepayAdjustLoan.IntCalc_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", loanRepayAdjustLoan.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", loanRepayAdjustLoan.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(LoanRepayAdjustLoan loanRepayAdjustLoan)
        {
            string sp = "loanRepayAdjustLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", loanRepayAdjustLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", loanRepayAdjustLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", loanRepayAdjustLoan.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", loanRepayAdjustLoan.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", loanRepayAdjustLoan.TranOffice_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_VOUCHER_NO", loanRepayAdjustLoan.VoucherNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_CODE", loanRepayAdjustLoan.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CENTER_NAME", loanRepayAdjustLoan.CenterName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", loanRepayAdjustLoan.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", loanRepayAdjustLoan.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", loanRepayAdjustLoan.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", loanRepayAdjustLoan.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INT_CALC_TYPE", loanRepayAdjustLoan.IntCalc_Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", loanRepayAdjustLoan.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanRepayAdjustLoan> lst = new List<LoanRepayAdjustLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanRepayAdjustLoan obj = new LoanRepayAdjustLoan();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.IntCalc_Type = drow["INT_CALC_TYPE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanRepayAdjustLoan(string OfficeCode, string ClientName, string FromDate, string ToDate)
        {
            string sp = "fn_loan_utility_pkg.p_loan_repay_adjust_loan_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanRepayAdjustLoan> lst = new List<LoanRepayAdjustLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanRepayAdjustLoan obj = new LoanRepayAdjustLoan();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.TranOffice_Code = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.VoucherNo = drow["VOUCHER_NO"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.IntCalc_Type = drow["INT_CALC_TYPE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

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
