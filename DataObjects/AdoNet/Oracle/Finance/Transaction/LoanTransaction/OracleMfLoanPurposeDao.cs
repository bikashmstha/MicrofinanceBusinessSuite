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
    public class OracleMfLoanPurposeDao : IMfLoanPurposeDao
    {
        public object Get()
        {
            string sp = "mfLoanPurpose_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanPurpose> lst = new List<MfLoanPurpose>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanPurpose obj = new MfLoanPurpose();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();
                    obj.LoanPurposeDesc = drow["LoanPurposeDesc"].ToString();
                    obj.SubSectorCode = drow["SubSectorCode"].ToString();
                    obj.SubSectorDesc = drow["SubSectorDesc"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.MaxLoanAmount = double.Parse(drow["MaxLoanAmount"].ToString());
                    obj.MinLoanAmount = double.Parse(drow["MinLoanAmount"].ToString());
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(MfLoanPurpose mfLoanPurpose)
        {
            string sp = "mfLoanPurpose_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", mfLoanPurpose.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeDesc", mfLoanPurpose.LoanPurposeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SubSectorCode", mfLoanPurpose.SubSectorCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SubSectorDesc", mfLoanPurpose.SubSectorDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", mfLoanPurpose.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxLoanAmount", mfLoanPurpose.MaxLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinLoanAmount", mfLoanPurpose.MinLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfLoanPurpose.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", mfLoanPurpose.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(MfLoanPurpose mfLoanPurpose)
        {
            string sp = "mfLoanPurpose_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", mfLoanPurpose.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeDesc", mfLoanPurpose.LoanPurposeDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SubSectorCode", mfLoanPurpose.SubSectorCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SubSectorDesc", mfLoanPurpose.SubSectorDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", mfLoanPurpose.InterestRate, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxLoanAmount", mfLoanPurpose.MaxLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinLoanAmount", mfLoanPurpose.MinLoanAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_RowCount", mfLoanPurpose.RowCount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanPurpose> lst = new List<MfLoanPurpose>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanPurpose obj = new MfLoanPurpose();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();
                    obj.LoanPurposeDesc = drow["LoanPurposeDesc"].ToString();
                    obj.SubSectorCode = drow["SubSectorCode"].ToString();
                    obj.SubSectorDesc = drow["SubSectorDesc"].ToString();
                    obj.InterestRate = double.Parse(drow["InterestRate"].ToString());
                    obj.MaxLoanAmount = double.Parse(drow["MaxLoanAmount"].ToString());
                    obj.MinLoanAmount = double.Parse(drow["MinLoanAmount"].ToString());
                    obj.RowCount = double.Parse(drow["RowCount"].ToString());

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetLoanProduct(string productCode, string purposeName)
        {
            string sp = "fn_loan_pkg.p_mf_loan_product_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", productCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeDesc", purposeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<MfLoanPurpose> lst = new List<MfLoanPurpose>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    MfLoanPurpose obj = new MfLoanPurpose();
                    obj.LoanPurposeCode = drow["Loan_Purpose_Code"].ToString();
                    obj.LoanPurposeDesc = drow["Loan_Purpose_Desc"].ToString();
                    obj.SubSectorCode = drow["Sub_Sector_Code"].ToString();
                    obj.SubSectorDesc = drow["Sub_Sector_Desc"].ToString();
                    obj.InterestRate = double.Parse(drow["Interest_Rate"].ToString());
                    obj.MaxLoanAmount = double.Parse(drow["Max_Loan_Amount"].ToString());
                    obj.MinLoanAmount = double.Parse(drow["Min_Loan_Amount"].ToString());
                    obj.RowCount = double.Parse(drow["Row_Count"].ToString());

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
