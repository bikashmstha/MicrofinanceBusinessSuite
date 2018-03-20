using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.HumanResource.Transaction;
using DataObjects.Interfaces.HumanResource;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.HumanResource
{
    public class OracleEmployeeAllowanceDetailDao : IEmployeeAllowanceDetailDao
    {
        public object SaveEmployeeAllowanceDetail(EmployeeAllowanceDetail employeeAllowanceDetail)
        {
            string sp = "employeeAllowanceDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeAllowanceDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", employeeAllowanceDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeAllowanceDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_CODE", employeeAllowanceDetail.YearCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", employeeAllowanceDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeAllowanceDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED", employeeAllowanceDetail.Approved, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE_BS", employeeAllowanceDetail.AllowanceDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", employeeAllowanceDetail.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE", employeeAllowanceDetail.AllowanceDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeeAllowanceDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object SearchEmployeeAllowanceDetail(EmployeeAllowanceDetail employeeAllowanceDetail)
        {
            string sp = "employeeAllowanceDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeAllowanceDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", employeeAllowanceDetail.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeAllowanceDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_YEAR_CODE", employeeAllowanceDetail.YearCode, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", employeeAllowanceDetail.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeAllowanceDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED", employeeAllowanceDetail.Approved, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE_BS", employeeAllowanceDetail.AllowanceDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE_BS", employeeAllowanceDetail.ApprovedDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE", employeeAllowanceDetail.AllowanceDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeAllowanceDetail> lst = new List<EmployeeAllowanceDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeAllowanceDetail obj = new EmployeeAllowanceDetail();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.YearCode = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_CODE"].ToString()));
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.Approved = drow["APPROVED"].ToString();
                    obj.AllowanceDateBs = drow["ALLOWANCE_DATE_BS"].ToString();
                    obj.ApprovedDateBs = drow["APPROVED_DATE_BS"].ToString();
                    obj.AllowanceDate = drow["ALLOWANCE_DATE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmpAllowanceDetail(string EmpId, long? Sno, string FiscalYear)
        {
            string sp = "hr_employee_utility_pkg.p_emp_allowance_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_EMP_ID", EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_SNO", Sno, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_FISCAL_YEAR", FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeAllowanceDetail> lst = new List<EmployeeAllowanceDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeAllowanceDetail obj = new EmployeeAllowanceDetail();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.YearCode = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["YEAR_CODE"].ToString()));
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.Approved = drow["APPROVED"].ToString();
                    obj.AllowanceDateBs = drow["ALLOWANCE_DATE_BS"].ToString();
                    obj.ApprovedDateBs = drow["APPROVED_DATE_BS"].ToString();
                    obj.AllowanceDate = drow["ALLOWANCE_DATE"].ToString();

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
