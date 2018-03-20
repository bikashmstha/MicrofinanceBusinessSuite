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
    public class OracleAdjustLoanIntPriPenNewDao : IAdjustLoanIntPriPenNewDao
    {
        public object Get()
        {
            string sp = "adjustLoanIntPriPenNew_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AdjustLoanIntPriPenNew> lst = new List<AdjustLoanIntPriPenNew>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AdjustLoanIntPriPenNew obj = new AdjustLoanIntPriPenNew();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.RepaymentY_N = drow["REPAYMENT_Y_N"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.CollectionSheet_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLECTION_SHEET_NO"].ToString()));
                    obj.InterestAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMT"].ToString()));
                    obj.PrincipalAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMT"].ToString()));
                    obj.PenaltyAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMT"].ToString()));
                    obj.NewInt_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NEW_INT_AMT"].ToString()));
                    obj.NewPri_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NEW_PRI_AMT"].ToString()));
                    obj.NewPen_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NEW_PEN_AMT"].ToString()));
                    obj.User1 = drow["USER1"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(AdjustLoanIntPriPenNew adjustLoanIntPriPenNew)
        {
            string sp = "fn_loan_pkg.p_adjust_loan_int_pri_pen_new";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", adjustLoanIntPriPenNew.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_Y_N", adjustLoanIntPriPenNew.RepaymentY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", adjustLoanIntPriPenNew.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", adjustLoanIntPriPenNew.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_SHEET_NO", adjustLoanIntPriPenNew.CollectionSheet_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMT", adjustLoanIntPriPenNew.InterestAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMT", adjustLoanIntPriPenNew.PrincipalAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMT", adjustLoanIntPriPenNew.PenaltyAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_INT_AMT", adjustLoanIntPriPenNew.NewInt_Amt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_PRI_AMT", adjustLoanIntPriPenNew.NewPri_Amt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_PEN_AMT", adjustLoanIntPriPenNew.NewPen_Amt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER", adjustLoanIntPriPenNew.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                // paramList.Add(SqlHelper.GetOraParam(":p_action", adjustLoanIntPriPenNew.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 20;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 200;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object Search(AdjustLoanIntPriPenNew adjustLoanIntPriPenNew)
        {
            string sp = "adjustLoanIntPriPenNew_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_LOAN_NO", adjustLoanIntPriPenNew.LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_Y_N", adjustLoanIntPriPenNew.RepaymentY_N, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REPAYMENT_NO", adjustLoanIntPriPenNew.RepaymentNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PAYMENT_DATE", adjustLoanIntPriPenNew.PaymentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_COLLECTION_SHEET_NO", adjustLoanIntPriPenNew.CollectionSheet_No, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INTEREST_AMT", adjustLoanIntPriPenNew.InterestAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PRINCIPAL_AMT", adjustLoanIntPriPenNew.PrincipalAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PENALTY_AMT", adjustLoanIntPriPenNew.PenaltyAmt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_INT_AMT", adjustLoanIntPriPenNew.NewInt_Amt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_PRI_AMT", adjustLoanIntPriPenNew.NewPri_Amt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NEW_PEN_AMT", adjustLoanIntPriPenNew.NewPen_Amt, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", adjustLoanIntPriPenNew.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<AdjustLoanIntPriPenNew> lst = new List<AdjustLoanIntPriPenNew>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    AdjustLoanIntPriPenNew obj = new AdjustLoanIntPriPenNew();
                    obj.LoanNo = drow["LOAN_NO"].ToString();
                    obj.RepaymentY_N = drow["REPAYMENT_Y_N"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.CollectionSheet_No = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["COLLECTION_SHEET_NO"].ToString()));
                    obj.InterestAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_AMT"].ToString()));
                    obj.PrincipalAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_AMT"].ToString()));
                    obj.PenaltyAmt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_AMT"].ToString()));
                    obj.NewInt_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NEW_INT_AMT"].ToString()));
                    obj.NewPri_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NEW_PRI_AMT"].ToString()));
                    obj.NewPen_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NEW_PEN_AMT"].ToString()));
                    obj.User1 = drow["USER1"].ToString();

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
