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
    public class OracleStaffLoanRepayLoanDao : IStaffLoanRepayLoanDao
    {
        public object SaveStaffLoanRepayLoan(StaffLoanRepayLoan staffLoanRepayLoan)
        {
            string sp = "staffLoanRepayLoan_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanRepayLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffLoanRepayLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", staffLoanRepayLoan.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanRepayLoan.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", staffLoanRepayLoan.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanRepayLoan.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", staffLoanRepayLoan.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanRepayLoan.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", staffLoanRepayLoan.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", staffLoanRepayLoan.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchStaffLoanRepayLoan(StaffLoanRepayLoan staffLoanRepayLoan)
        {
            string sp = "staffLoanRepayLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", staffLoanRepayLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", staffLoanRepayLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", staffLoanRepayLoan.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", staffLoanRepayLoan.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", staffLoanRepayLoan.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", staffLoanRepayLoan.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", staffLoanRepayLoan.LoanProductName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", staffLoanRepayLoan.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", staffLoanRepayLoan.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanRepayLoan> lst = new List<StaffLoanRepayLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanRepayLoan obj = new StaffLoanRepayLoan();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanProductName = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetStaffLoanRepayLoan(string OfficeCode, string ProductCode, string ClientName)
        {
            string sp = "fn_loan_utility_pkg.p_staff_loan_repay_loan_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_PRODUCT_CODE", ProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<StaffLoanRepayLoan> lst = new List<StaffLoanRepayLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    StaffLoanRepayLoan obj = new StaffLoanRepayLoan();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanProductName = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProductCode = drow["LOAN_PRODUCT_CODE"].ToString();
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
