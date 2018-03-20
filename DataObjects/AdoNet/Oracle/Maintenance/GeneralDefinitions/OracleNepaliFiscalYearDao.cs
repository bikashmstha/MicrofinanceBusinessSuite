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
    
    public class OracleNepaliFiscalYearDao:INepaliFiscalYearDao
    {
        private List<OracleParameter> PrepareParameterList(NepaliFiscalYear nepaliFiscalYear)
        {
           

            List<OracleParameter> paramList = new List<OracleParameter>();
            paramList.Add(SqlHelper.GetOraParam(":P_FISCAL_YEAR", nepaliFiscalYear.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_START_DATE", nepaliFiscalYear.StartDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_START_DATE_BS", nepaliFiscalYear.StartDateBS, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_END_DATE", nepaliFiscalYear.EndDate, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_END_DATE_BS", nepaliFiscalYear.EndDateBS, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_LAST_VOUCHER_SEQ_NO", nepaliFiscalYear.LastVoucherName, OracleDbType.Long, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_CREATED_ON", nepaliFiscalYear.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_CREATED_BY", nepaliFiscalYear.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", nepaliFiscalYear.Action, OracleDbType.Varchar2, ParameterDirection.Input));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
            paramList[9].Size = 10;
            paramList[10].Size = 100;

            return paramList;

        }
        public List<NepaliFiscalYear> GetNepaliFiscalYear()
        {
            try
            {
                string SP = "ms_general_definition_pkg.p_fiscal_year_detail";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));

                OracleConnection conn = new GetConnection().GetDbConn();
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<NepaliFiscalYear> lst = new List<NepaliFiscalYear>();


                NepaliFiscalYear obj;
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    obj = new NepaliFiscalYear();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();//APPLICATION_ID
                    obj.StartDate = drow["START_DATE"].ToString();//APPLICATION_DESCRIPTION
                    obj.StartDateBS = drow["START_DATE_NEP"].ToString();//APPLICATION_ID
                    obj.EndDate = drow["END_DATE"].ToString();//APPLICATION_DESCRIPTION
                    obj.EndDateBS = drow["END_DATE_NEP"].ToString();//APPLICATION_DESCRIPTION
                    obj.LastVoucherName = long.Parse(drow["LAST_VOUCHER_SEQ_NO"].ToString());//APPLICATION_DESCRIPTION
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

        public OutMessage SaveNepaliFiscalYear(NepaliFiscalYear nepaliFiscalYear)
        {
            string SP = "ms_general_definition_pkg.p_insert_update_fy_detail"; ;
            OutMessage oMsg = new OutMessage();

            List<OracleParameter> paramList = PrepareParameterList(nepaliFiscalYear);

            try
            {
                OracleConnection conn = new GetConnection().GetDbConn();
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, SP, paramList.ToArray());

                oMsg.OutResultCode = paramList[9].Value.ToString();
                oMsg.OutResultMessage = paramList[10].Value.ToString();

                return oMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
