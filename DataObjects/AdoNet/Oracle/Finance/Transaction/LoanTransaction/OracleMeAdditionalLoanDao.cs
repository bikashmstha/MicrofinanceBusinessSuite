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
    public class OracleMeAdditionalLoanDao : IMeAdditionalLoanDao
    {
        public object Get()
        {
            string sp = "meAdditionalLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeAdditionalLoan> lst = new List<MeAdditionalLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeAdditionalLoan obj = new MeAdditionalLoan();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.MatureDate = drow["MATURE_DATE"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MeAdditionalLoan meAdditionalLoan)
        {
            string sp = "meAdditionalLoan_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", meAdditionalLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", meAdditionalLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", meAdditionalLoan.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meAdditionalLoan.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", meAdditionalLoan.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURE_DATE", meAdditionalLoan.MatureDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", meAdditionalLoan.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MeAdditionalLoan meAdditionalLoan)
        {
            string sp = "meAdditionalLoan_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", meAdditionalLoan.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", meAdditionalLoan.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", meAdditionalLoan.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", meAdditionalLoan.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DATE", meAdditionalLoan.LoanDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MATURE_DATE", meAdditionalLoan.MatureDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeAdditionalLoan> lst = new List<MeAdditionalLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeAdditionalLoan obj = new MeAdditionalLoan();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.MatureDate = drow["MATURE_DATE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMeAdditionalLoan(string offCode, string productCode, string clientName)
        {
           string sp = "fn_loan_pkg.p_me_add_loan_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_product_code", productCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_client_name", clientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MeAdditionalLoan> lst = new List<MeAdditionalLoan>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MeAdditionalLoan obj = new MeAdditionalLoan();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.LoanDate = drow["LOAN_DATE"].ToString();
                    obj.MatureDate = drow["MATURE_DATE"].ToString();

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
