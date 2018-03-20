using BusinessObjects.GeneralMasterParameters;
using BusinessObjects.Security;
using DataObjects.Interfaces.GeneralMasterParameters;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataObjects.AdoNet.Oracle.GeneralMasterParameters
{
    public class OracleHolidayDetailsDao : IHolidayDetailsDao
    {
        public List<HolidayDetails> GetHolidayDetail(string FiscalYear)
        {
            try
            {
                User u = user as User;
                string SP = "MS_DAILY_DATE_PKG.p_get_holiday_list";

                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList.Add(SqlHelper.GetOraParam(":FiscalYear", null, OracleDbType.RefCursor, ParameterDirection.Output));

                DataSet ds = SqlHelper.ExecuteDataset(user, CommandType.StoredProcedure, SP, paramList.ToArray());
                List<HolidayDetails> lst = new List<HolidayDetails>();


                HolidayDetails obj;
                if(FiscalYear !=null)
                {
                    foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                    {
                        obj = new HolidayDetails();
                        obj.DateAD = drow["DateAD"].ToString();//APPLICATION_ID
                        obj.DateBS = drow["DateBS"].ToString();
                        obj.Holiday = drow["Holiday"].ToString();
                        obj.HolidayDsec = drow["HolidayDsc"].ToString();
                        obj.LoanHoliday = drow["LoanHoliday"].ToString();
                        obj.LoanHolidayDsc = drow["LoanHolidayDsc"].ToString();

                        lst.Add(obj);
                    }
                    return lst;
                }
                
                else
                    return new List<HolidayDetails>();
            }
            catch (Exception ex)
            {
                return new List<HolidayDetails>();

            }
        }
    }
}
