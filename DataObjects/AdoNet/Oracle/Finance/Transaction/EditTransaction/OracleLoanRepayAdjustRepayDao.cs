using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleLoanRepayAdjustRepayDao : ILoanRepayAdjustRepayDao
    {



        public object GetLoanRepayAdjustRepay(string OfficeCode, string LoanNo, string LoanDno, string FromDate, string ToDate)
        {
            string sp = "fn_loan_utility_pkg.p_loan_repay_adjust_repay_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_NO", LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_DNO", LoanDno, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FROM_DATE", FromDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_TO_DATE", ToDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<LoanRepayAdjustRepay> lst = new List<LoanRepayAdjustRepay>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    LoanRepayAdjustRepay obj = new LoanRepayAdjustRepay();
                    obj.CollectionSheetNo = drow["COLLECTION_SHEET_NO"].ToString();
                    obj.RepaymentNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["REPAYMENT_NO"].ToString()));
                    obj.PaymentDateNep = drow["PAYMENT_DATE_NEP"].ToString();
                    obj.PaymentDate = drow["PAYMENT_DATE"].ToString();
                    obj.LoanDno = drow["LOAN_DNO"].ToString();
                    obj.TotalReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["TOTAL_RECEIVED"].ToString()));
                    obj.PrincipalReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PRINCIPAL_RECEIVED"].ToString()));
                    obj.InterestReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["INTEREST_RECEIVED"].ToString()));
                    obj.PenaltyReceived = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PENALTY_RECEIVED"].ToString()));
                    obj.ChequeNo = drow["CHEQUE_NO"].ToString();
                    obj.SavingAccountDno = drow["SAVING_ACCOUNT_DNO"].ToString();
                    obj.AdjustFromSaving = drow["ADJUST_FROM_SAVING"].ToString();
                    obj.SavingAccountNo = drow["SAVING_ACCOUNT_NO"].ToString();
                    obj.ContraAccount = drow["CONTRA_ACCOUNT"].ToString();
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
