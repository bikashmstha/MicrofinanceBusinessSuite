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
    public class OracleLasLoanSearchDao : ILasLoanSearchDao
    {
        public object Get()
        {
            string sp = "lasLoanSearch_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LasLoanSearch> lst = new List<LasLoanSearch>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LasLoanSearch obj = new LasLoanSearch();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
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

        public object Save(LasLoanSearch lasLoanSearch)
        {
            string sp = "lasLoanSearch_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lasLoanSearch.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lasLoanSearch.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", lasLoanSearch.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", lasLoanSearch.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", lasLoanSearch.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", lasLoanSearch.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", lasLoanSearch.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", lasLoanSearch.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", lasLoanSearch.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LasLoanSearch lasLoanSearch)
        {
            string sp = "lasLoanSearch_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", lasLoanSearch.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_DNO", lasLoanSearch.LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_DESC", lasLoanSearch.ClientDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", lasLoanSearch.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", lasLoanSearch.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_NAME", lasLoanSearch.LoanProduct_Name, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_PRODUCT_CODE", lasLoanSearch.LoanProduct_Code, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ROW_COUNT", lasLoanSearch.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LasLoanSearch> lst = new List<LasLoanSearch>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LasLoanSearch obj = new LasLoanSearch();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
                    obj.RowCount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["ROW_COUNT"].ToString()));

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLasLoanSearch(string OfficeCode, string ClientName)
        {
            string sp = "fn_loan_pkg.p_las_loan_search_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LasLoanSearch> lst = new List<LasLoanSearch>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LasLoanSearch obj = new LasLoanSearch();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.ClientDesc = drow["CLIENT_DESC"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.LoanProduct_Name = drow["LOAN_PRODUCT_NAME"].ToString();
                    obj.LoanProduct_Code = drow["LOAN_PRODUCT_CODE"].ToString();
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
