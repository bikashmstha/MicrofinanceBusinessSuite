using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects.Interfaces.Common;
using Oracle.DataAccess.Client;
using System.Data;
using BusinessObjects;

namespace DataObjects.AdoNet.Oracle.Common
{
    public class OracleDateDao:IDateDao
    {
        public object GetNepDate(string engDate)
        {            
            string sql = "SELECT date_conversion_pkg.f_eng_to_nep_daily('" + engDate + "') FROM DUAL";

            OracleConnection conn = new OracleConnection();



            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

                DataTable tbl = new DataTable();
                tbl = (DataTable)ds.Tables[0];
                string date = tbl.Rows[0][0].ToString();

                oMsg.OutResultCode = String.IsNullOrEmpty(date) ? "FAILED" : "SUCCESS";
                oMsg.OutResultMessage = date;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultCode = "FAILED";
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
                
           
        }
        public  object GetEngDate(string nep_date)
        {

            string sql = "SELECT date_conversion_pkg.f_nep_to_eng_daily('" + nep_date +"') FROM DUAL";
              
                OracleConnection conn = new OracleConnection();

               

                OutMessage oMsg = new OutMessage();
                try
                {
                    conn = new GetConnection().GetDbConn();
                    DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);

                    DataTable tbl = new DataTable();
                    tbl = (DataTable)ds.Tables[0];
                    string date = tbl.Rows[0][0].ToString();

                    oMsg.OutResultCode = String.IsNullOrEmpty(date) ? "FAILED" : "SUCCESS";
                    oMsg.OutResultMessage = date;
                    return oMsg;
                }
                catch (Exception ex)
                {
                    oMsg.OutResultCode = "FAILED";
                    oMsg.OutResultMessage = ex.Message.ToString();
                    return oMsg;
                }
                finally { conn.Close(); }
                
           

        }

        public  string ParseOracleDate(string InputDate)
        {
            string date = string.Empty;
            if (string.IsNullOrEmpty(InputDate))
            {
                return date;
            }
            else
            {
                DateTime dt1 = Convert.ToDateTime(InputDate);
                // return dt1.ToString("dd-MMM-yyyy");
                return String.Format("{0:dd-MMM-yyyy}", dt1).ToUpper();              // 	17-Apr-2012
            }
        }

        public  DateTime ParseNormalDate(string InputDate)
        {
            DateTime dt = new DateTime();
            if (string.IsNullOrEmpty(InputDate.ToString()))
            {
                return dt;
            }
            else
            {
                DateTime dt1 = Convert.ToDateTime(InputDate);
                return dt1;
            }
        }

        

        
    }
}
