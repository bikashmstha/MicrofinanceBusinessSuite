using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Security;
using Oracle.DataAccess.Client;
using System.Data;
using DataObjects.Interfaces.Common;
using BusinessObjects.Common;
using BusinessObjects;
namespace DataObjects.AdoNet.Oracle.Common
{
    public class OracleFiscalYearDao : IFiscalYearDao
    {

        public object Get(string fiscalYear)
        {
            string sp = "MS_DAILY_DATE_PKG.p_get_fiscal_year_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_fiscal_year", fiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FiscalYear> lst = new List<FiscalYear>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FiscalYear obj = new FiscalYear();
                    /*FISCAL_YEAR,
         TO_CHAR (START_DATE, 'DD-MON-YYYY') AS START_DATE,
         START_DATE_NEP,
         TO_CHAR (END_DATE, 'DD-MON-YYYY') AS END_DATE,
         END_DATE_NEP
                     * */
                    obj.FiscalYearCode = drow["FISCAL_YEAR"].ToString();
                    obj.StartDate = drow["START_DATE"].ToString();
                    obj.StartDateNep = drow["START_DATE_NEP"].ToString();
                    obj.EndDate = drow["END_DATE"].ToString();
                    obj.EndDateNep = drow["END_DATE_NEP"].ToString();
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }

        public object Save(FiscalYear fiscalYear)
        {
            throw new NotImplementedException();
        }

        public object Search(FiscalYear fiscalYear)
        {
            throw new NotImplementedException();
        }

        public object GetFiscalYearShort(string fiscalYear)
        {
            string sp = "MS_DAILY_DATE_PKG.p_get_fiscal_year_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_DistrictCode", fiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));


                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FiscalYear> lst = new List<FiscalYear>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FiscalYear obj = new FiscalYear();
                    obj.FiscalYearCode = drow["FISCAL_YEAR"].ToString();
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }

        public object GetLastFiscalYearList(string offCode)
        {
            string sp = "fiscal_year_pkg.p_last_fiscal_year_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_Office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));


                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FiscalYear> lst = new List<FiscalYear>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FiscalYear obj = new FiscalYear();
                    obj.FiscalYearCode = drow["FISCAL_YEAR"].ToString();
                    obj.FiscalYearCode = drow["END_DATE"].ToString();
                    obj.FiscalYearCode = drow["END_DATE_NEP"].ToString();
                    obj.Action = "U";

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }

        public object GetFiscalYear(string FiscalYear)
        {
            string sp = "fiscal_year_pkg.p_fiscal_year_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_FISCAL_YEAR", FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FiscalYear> lst = new List<FiscalYear>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FiscalYear obj = new FiscalYear();
                    obj.FiscalYearCode = drow["FISCAL_YEAR"].ToString();
                    obj.StartDate = drow["START_DATE"].ToString();
                    obj.StartDateNep = drow["START_DATE_NEP"].ToString();
                    obj.EndDate = drow["END_DATE"].ToString();
                    obj.EndDateNep = drow["END_DATE_NEP"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetFiscalYearByDate(string date)
        {
            string sp = "fiscal_year_pkg.f_fiscal_year";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_Date", date, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FiscalYear> lst = new List<FiscalYear>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FiscalYear obj = new FiscalYear();
                    obj.FiscalYearCode = drow["FISCAL_YEAR"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetNextFiscalYear(string FiscalYear)
        {
            string sp = "fiscal_year_pkg.p_next_fiscal_year";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_FISCAL_YEAR", FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<FiscalYear> lst = new List<FiscalYear>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    FiscalYear obj = new FiscalYear();
                    obj.FiscalYearCode = drow["FISCAL_YEAR"].ToString();
                    obj.StartDate = drow["START_DATE"].ToString();
                    obj.StartDateNep = drow["START_DATE_NEP"].ToString();

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





