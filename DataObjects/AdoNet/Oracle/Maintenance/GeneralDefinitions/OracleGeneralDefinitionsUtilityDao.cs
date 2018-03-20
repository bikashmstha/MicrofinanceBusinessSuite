using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;
using DataObjects.Interfaces.Maintenance;
using Oracle.DataAccess.Client;
namespace DataObjects.AdoNet.Oracle.Maintenance
{
    public class OracleGeneralDefinitionsUtilityDao:IGeneralDefinitionsUtilityDao
    {
        private List<OracleParameter> PrepareParameterList(string fiscalYear)
        {
            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":P_FISCAL_YEAR", fiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[1].Size = 10;
            paramList[2].Size = 100;

            return paramList;

        }

        public OutMessage GenerateDateOfNepaliFiscalYear(string fiscalYear)
        {
            string SP = "MS_DAILY_DATE_PKG.p_populate_daily_date"; ;
            OutMessage oMsg = new OutMessage();
            
            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = PrepareParameterList(fiscalYear);

                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[1].Value.ToString();
                oMsg.OutResultMessage = paramList[2].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public OutMessage GenerateDateOfEnglishFiscalYear(string fiscalYear)
        {
            string SP = "MS_DAILY_DATE_PKG.P_GENERATE_DAILY_CALENDER"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(fiscalYear);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[1].Value.ToString();
                oMsg.OutResultMessage = paramList[2].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
