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
    public class OracleOfficeWiseHolidayDao:IOfficeWiseHolidayDao
    {
        public object Get(string offCode, string startDate, string endDate)
        {
            string sp = "MS_DAILY_DATE_PKG.p_office_holiday_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam("p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("p_startDate", startDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("p_FiscalYear", endDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam("v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<OfficeWiseHoliday> lst = new List<OfficeWiseHoliday>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OfficeWiseHoliday obj = new OfficeWiseHoliday();
                    obj.EnglishDate = drow["OFFICE_CODE"].ToString();
                    obj.EnglishDate = drow["ENGLISH_DATE"].ToString();
                    obj.NepaliDate = drow["NEPALI_DATE"].ToString();
                    obj.Holiday = drow["HOLIDAY"].ToString();
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

        public object Save(OfficeWiseHoliday officeWiseHoliday)
        {
            string sp = "MS_DAILY_DATE_PKG.P_DAILY_DATE_OFFICEWISE";
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
                paramList.Add(SqlHelper.GetOraParam(":p_office_Code", officeWiseHoliday.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_english_date", officeWiseHoliday.EnglishDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_nepali_date", officeWiseHoliday.NepaliDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_holiday", officeWiseHoliday.Holiday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_holiday_desc", officeWiseHoliday.HolidayDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_holiday", officeWiseHoliday.LoanHoliday, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_loan_holiday_desc", officeWiseHoliday.LoanHolidayDesc, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object Search(OfficeWiseHoliday officeWiseHoliday)
        {
            throw new NotImplementedException();
        }

        public object GetOfficeWiseHolidayShort(string offCode, string startDate, string endDate)
        {
            string sp = "MS_DAILY_DATE_PKG.p_office_holiday_list";
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
                List<OfficeWiseHoliday> lst = new List<OfficeWiseHoliday>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    OfficeWiseHoliday obj = new OfficeWiseHoliday();
                    obj.EnglishDate = drow["OFFICE_CODE"].ToString();
                    obj.EnglishDate = drow["ENGLISH_DATE"].ToString();
                    obj.NepaliDate = drow["NEPALI_DATE"].ToString();
                    obj.Holiday = drow["HOLIDAY"].ToString();
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


        
    }
}
