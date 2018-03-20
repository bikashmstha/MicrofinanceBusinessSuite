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
    public class OracleNepaliDateConversionDao:INepaliDateConversionDao
    {
        private List<OracleParameter> PrepareParameterList(NepaliDateConversion nepaliDateConversion)
        {
           

            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":P_FISCAL_YEAR", nepaliDateConversion.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_MONTH_CODE", nepaliDateConversion.MonthCode, OracleDbType.Int16, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_ENGLISH_START_DATE", nepaliDateConversion.EnglishStartDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_START_DATE", nepaliDateConversion.NepaliStartDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_ENGLISH_END_DATE", nepaliDateConversion.EnglishEndDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_END_DATE", nepaliDateConversion.NepaliEndDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_YEAR", nepaliDateConversion.NepaliYear, OracleDbType.Int16, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_NEPALI_PERIOD", nepaliDateConversion.NepaliPeriod, OracleDbType.Int16, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_NO_OF_DAYS_IN_MONTH", nepaliDateConversion.NoOfDays, OracleDbType.Int16, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_CREATED_MODIFIED_ON", nepaliDateConversion.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_CREATED_MODIFIED_BY", nepaliDateConversion.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", nepaliDateConversion.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[12].Size = 10;
            paramList[13].Size = 100;

            return paramList;

        }
        public List<NepaliDateConversion> GetNepaliDateConversion()
        {
            try
            {
                string SP = "ms_general_definition_pkg.p_nep_date_conversion_detail";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<NepaliDateConversion> lst = new List<NepaliDateConversion>();


                NepaliDateConversion obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new NepaliDateConversion();

                    

                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();//APPLICATION_ID
                    obj.MonthCode = int.Parse(drow["MONTH_CODE"].ToString());//APPLICATION_DESCRIPTION
                    obj.EnglishStartDate = drow["ENGLISH_START_DATE"].ToString();//APPLICATION_ID
                    obj.NepaliStartDate = drow["NEPALI_START_DATE"].ToString();//APPLICATION_DESCRIPTION
                    obj.EnglishEndDate = drow["ENGLISH_END_DATE"].ToString();//APPLICATION_DESCRIPTION
                    obj.NepaliEndDate = drow["NEPALI_END_DATE"].ToString();//APPLICATION_ID
                    obj.NepaliYear = int.Parse(drow["NEPALI_YEAR"].ToString());//APPLICATION_DESCRIPTION
                    obj.NepaliPeriod = int.Parse(drow["NEPALI_PERIOD"].ToString());//APPLICATION_ID
                    obj.NoOfDays = int.Parse(drow["NO_OF_DAYS"].ToString());//APPLICATION_ID
                    obj.Action = "U";

                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public OutMessage SaveNepaliDateConversion(NepaliDateConversion nepaliDateConversion)
        {
            string SP = "ms_general_definition_pkg.p_nepalidateconversion"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(nepaliDateConversion);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[12].Value.ToString();
                oMsg.OutResultMessage = paramList[13].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
