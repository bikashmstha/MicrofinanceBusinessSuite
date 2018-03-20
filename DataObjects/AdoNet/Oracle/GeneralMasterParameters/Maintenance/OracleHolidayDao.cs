using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.GeneralMasterParameters.Maintenance;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleHolidayDao:IHolidayDao
    {
        public object Get(string startDate, string endDate)
        {
            string sp = "MS_DAILY_DATE_PKG.p_get_holiday_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam("p_startDate", startDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("p_FiscalYear", endDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Holiday> lst = new List<Holiday>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Holiday obj = new Holiday();
                    obj.EnglishDate = drow["ENGLISH_DATE"].ToString();
                    obj.NepaliDate = drow["NEPALI_DATE"].ToString();
                    obj.IsHoliday = drow["HOLIDAY"].ToString();
                    obj.HolidayDesc = drow["HOLIDAY_DESC"].ToString();
                    obj.LoanHoliday = drow["LOAN_HOLIDAY"].ToString();
                    obj.LoanHolidayDesc = drow["LOAN_HOLIDAY_DESC"].ToString();
                    
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Holiday holiday)
        {
            string sp = "MS_DAILY_DATE_PKG.P_UPDATE_DAILY_DATE";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                /*
                 * p_english_date        IN     MS_DAILY_DATE.english_date%TYPE,
                                  p_nepali_date         IN     MS_DAILY_DATE.nepali_date%TYPE,
                                  p_holiday             IN     MS_DAILY_DATE.holiday%TYPE,
                                  p_holiday_desc        IN     MS_DAILY_DATE.holiday_desc%TYPE,
                                  p_loan_holiday        IN     MS_DAILY_DATE.loan_holiday%TYPE,
                                  p_loan_holiday_desc   IN     MS_DAILY_DATE.loan_holiday_desc%TYPE,
                                  v_out_result_code        OUT VARCHAR2,
                                  v_out_result_msg         OUT VARCHAR2)
                 * */
                paramList.Add(SqlHelper.GetOraParam(":p_english_date", holiday.EnglishDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_nepali_date", holiday.NepaliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_holiday", holiday.IsHoliday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_holiday_desc", holiday.HolidayDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_holiday", holiday.LoanHoliday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_holiday_desc", holiday.LoanHolidayDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 10;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString();
                oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(Holiday holiday)
        {
            throw new NotImplementedException();
        }

        public object GetHolidayShort(string startDate, string endDate)
        {
            string sp = "MS_DAILY_DATE_PKG.p_get_holiday_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam("p_startDate", startDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("p_FiscalYear", endDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Religion> lst = new List<Religion>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Religion obj = new Religion();
                    obj.ReligionCode = drow["ENGLISH_DATE"].ToString();
                    obj.ReligionDesc = drow["RELIGION_DESC"].ToString();
                    //obj.CreatedBy = drow["CREATED_BY"].ToString();
                    //obj.CreatedOn = drow["CREATED_ON"].ToString();
                    obj.CibCode = drow["CIB_CODE"].ToString();
                    obj.Action = "U";

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
