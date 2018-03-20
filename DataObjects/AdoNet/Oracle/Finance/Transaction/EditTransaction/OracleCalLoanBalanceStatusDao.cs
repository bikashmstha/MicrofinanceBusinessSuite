using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects.Interfaces.Common;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleCalLoanBalanceStatusDao : ICalLoanBalanceStatusDao
    {
        private static IDateDao dateDao = DataAccess.DateDao;
        public object GetCalLoanBalanceStatus(string OfficeCode, string LoanNo, string RepayDate)
        {
            string sp = "fn_loan_pkg.p_cal_loan_balance_status";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_LOAN_NO", LoanNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_REPAY_DATE", RepayDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PAST_PRIN_AMOUNT", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_CURR_PRIN_AMOUNT", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PAST_INT_AMOUNT", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_CURR_INT_AMOUNT", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PENALTY_AMOUNT", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_TOTAL_INSTALLMENT_AMOUNT", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PRINCIPAL_BALANCE", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_INTEREST_BALANCE", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PENALTY_BALANCE", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_TOTAL_BALANCE", null, OracleDbType.Double, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_result_message", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<CalLoanBalanceStatus> lst = new List<CalLoanBalanceStatus>();

                CalLoanBalanceStatus obj = new CalLoanBalanceStatus();
                obj.OfficeCode = OfficeCode;
                obj.LoanNo = LoanNo;
                obj.RepayDate = RepayDate;
                obj.RepayDateAD = dateDao.GetEngDate(RepayDate).ToString();
                obj.PastPr_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[3].Value.ToString()));
                obj.CurrPr_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[4].Value.ToString()));
                obj.PastT_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[5].Value.ToString()));
                obj.CurrT_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[6].Value.ToString()));
                obj.PenaltyAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[7].Value.ToString()));
                obj.TotalStallment_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[8].Value.ToString()));
                obj.PrcipalBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[9].Value.ToString()));
                obj.TerestBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[10].Value.ToString()));
                obj.PenaltyBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[11].Value.ToString()));
                obj.TotalBalance = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[12].Value.ToString()));
                obj.ResultCode = paramList[13].Value.ToString();
                obj.ResultMsg = paramList[14].Value.ToString();

                lst.Add(obj);

                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
    }
}


