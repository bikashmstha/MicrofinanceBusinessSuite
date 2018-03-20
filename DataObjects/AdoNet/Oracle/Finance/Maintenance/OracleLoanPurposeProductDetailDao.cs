using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanPurposeProductDetailDao : ILoanPurposeProductDetailDao
    {
        public object Get()
        {
            string sp = "LoanPurposeProductDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanPurposeProductDetail> lst = new List<LoanPurposeProductDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanPurposeProductDetail obj = new LoanPurposeProductDetail();
                    obj.MinLoanAmount = int.Parse(drow["MinLoanAmount"].ToString());
                    obj.MaxLoanAmount = int.Parse(drow["MaxLoanAmount"].ToString());
                    obj.MinLoanTermMonths = int.Parse(drow["MinLoanTermMonths"].ToString());
                    obj.MaxLoanTermMonths = int.Parse(drow["MaxLoanTermMonths"].ToString());
                    obj.NoOfAccountOpen = int.Parse(drow["NoOfAccountOpen"].ToString());
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.Active = drow["Active"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.InterestRate = int.Parse(drow["InterestRate"].ToString());

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(LoanPurposeProductDetail LoanPurposeProductDetail)
        {
            string sp = "LoanPurposeProductDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MinLoanAmount", LoanPurposeProductDetail.MinLoanAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxLoanAmount", LoanPurposeProductDetail.MaxLoanAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinLoanTermMonths", LoanPurposeProductDetail.MinLoanTermMonths, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxLoanTermMonths", LoanPurposeProductDetail.MaxLoanTermMonths, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfAccountOpen", LoanPurposeProductDetail.NoOfAccountOpen, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", LoanPurposeProductDetail.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", LoanPurposeProductDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", LoanPurposeProductDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", LoanPurposeProductDetail.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", LoanPurposeProductDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", LoanPurposeProductDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", LoanPurposeProductDetail.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", LoanPurposeProductDetail.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", LoanPurposeProductDetail.InterestRate, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", LoanPurposeProductDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(LoanPurposeProductDetail LoanPurposeProductDetail)
        {
            string sp = "LoanPurposeProductDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MinLoanAmount", LoanPurposeProductDetail.MinLoanAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxLoanAmount", LoanPurposeProductDetail.MaxLoanAmount, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MinLoanTermMonths", LoanPurposeProductDetail.MinLoanTermMonths, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MaxLoanTermMonths", LoanPurposeProductDetail.MaxLoanTermMonths, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NoOfAccountOpen", LoanPurposeProductDetail.NoOfAccountOpen, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", LoanPurposeProductDetail.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Active", LoanPurposeProductDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanProductCode", LoanPurposeProductDetail.LoanProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LoanPurposeCode", LoanPurposeProductDetail.LoanPurposeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", LoanPurposeProductDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", LoanPurposeProductDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", LoanPurposeProductDetail.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", LoanPurposeProductDetail.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_InterestRate", LoanPurposeProductDetail.InterestRate, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanPurposeProductDetail> lst = new List<LoanPurposeProductDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanPurposeProductDetail obj = new LoanPurposeProductDetail();
                    obj.MinLoanAmount = int.Parse(drow["MinLoanAmount"].ToString());
                    obj.MaxLoanAmount = int.Parse(drow["MaxLoanAmount"].ToString());
                    obj.MinLoanTermMonths = int.Parse(drow["MinLoanTermMonths"].ToString());
                    obj.MaxLoanTermMonths = int.Parse(drow["MaxLoanTermMonths"].ToString());
                    obj.NoOfAccountOpen = int.Parse(drow["NoOfAccountOpen"].ToString());
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.Active = drow["Active"].ToString();
                    obj.LoanProductCode = drow["LoanProductCode"].ToString();
                    obj.LoanPurposeCode = drow["LoanPurposeCode"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.InterestRate = int.Parse(drow["InterestRate"].ToString());

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
