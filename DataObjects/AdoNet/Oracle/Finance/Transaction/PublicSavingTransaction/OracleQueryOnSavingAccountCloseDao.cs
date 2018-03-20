using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleQueryOnSavingAccountCloseDao : IQueryOnSavingAccountCloseDao
    {


        public object GetQueryOnSavingAcClose(string AccountNo, string SavingProductCode, string WithdrawDate, string Username)
        {
            string sp = "fn_saving_pkg.p_query_on_saving_ac_close";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_ACCOUNT_NO", AccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SAVING_PRODUCT_CODE", SavingProductCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_WITHDRAW_DATE", WithdrawDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USERNAME", Username, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PREMATURED_INT_RATIO", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_MID_TERM_CLOSING_TYPE", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_ACCOUNT_OPERATOR_TYPE", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_ACCOUNT_OPEN_DATE", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_MATURITY_DATE", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_AMOUNT_AT_MATURITY", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PRESENT_BALANCE_WITH_INT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_PRESENT_BAL_WITHOUT_INT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_MID_TERM_BAL_WITH_INT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_TDS_LIMIT_AMOUNT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_UNPOST_INTEREST", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_TAXABLE_UNPOST_INTEREST", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_TDS_ON_UNPOST_INTEREST", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECEIVED_INTEREST_AMOUNT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_MID_TERM_INT_AMT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_MID_TERM_TAXABLE_AMOUNT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_MID_TERM_TDS_AMOUNT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_TDS_DIFFERENCE", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_CLOSING_CHARGE", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_OTHER_INCOME", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_WITHDRAW_AMOUNT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_WAIVED_AMOUNT", null, OracleDbType.Long, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<QueryOnSavingAccountClose> lst = new List<QueryOnSavingAccountClose>();

                QueryOnSavingAccountClose obj = new QueryOnSavingAccountClose();
                obj.OutPrematuredInt_Ratio = paramList[4].Value.ToString();
                obj.OutMidTerm_Closing_Type = paramList[5].Value.ToString();
                obj.OutAccountOperator_Type = paramList[6].Value.ToString();
                obj.OutAccountOpen_Date = paramList[7].Value.ToString();
                obj.OutMaturityDate = paramList[8].Value.ToString();
                obj.OutAmountAt_Maturity = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[9].Value.ToString()));
                obj.OutPresentBalance_With_Int = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[10].Value.ToString()));
                obj.OutPresentBal_Without_Int = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[11].Value.ToString()));
                obj.OutMidTerm_Bal_With_Int = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[12].Value.ToString()));
                obj.OutTdsLimit_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[13].Value.ToString()));
                obj.OutUnpostInterest = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[14].Value.ToString()));
                obj.OutTaxableUnpost_Interest = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[15].Value.ToString()));
                obj.OutTdsOn_Unpost_Interest = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[16].Value.ToString()));
                obj.OutReceivedInterest_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[17].Value.ToString()));
                obj.OutMidTerm_Int_Amt = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[18].Value.ToString()));
                obj.OutMidTerm_Taxable_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[19].Value.ToString()));
                obj.OutMidTerm_Tds_Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[20].Value.ToString()));
                obj.OutTdsDifference = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[21].Value.ToString()));
                obj.OutClosingCharge = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[22].Value.ToString()));
                obj.OutOtherIncome = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[23].Value.ToString()));
                obj.OutWithdrawAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[24].Value.ToString()));
                obj.OutWaivedAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(paramList[25].Value.ToString()));
                lst.Add(obj);

                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

    }
}
