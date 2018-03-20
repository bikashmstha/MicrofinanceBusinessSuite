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
    public class OracleEmployeeLocalAllowanceDao : IEmployeeLocalAllowanceDao
    {
        public object SaveEmployeeLocalAllowance(EmployeeLocalAllowance employeeLocalAllowance)
        {
            string sp = "hr_local_allowance_pkg.p_emp_local_allowance";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeLocalAllowance.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", employeeLocalAllowance.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeLocalAllowance.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", employeeLocalAllowance.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeeLocalAllowance.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeLocalAllowance.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POST_CODE", employeeLocalAllowance.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE", employeeLocalAllowance.AllowanceDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED", employeeLocalAllowance.Approved, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE_BS", employeeLocalAllowance.AllowanceDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeeLocalAllowance.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchEmployeeLocalAllowance(EmployeeLocalAllowance employeeLocalAllowance)
        {
            string sp = "employeeLocalAllowance_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeLocalAllowance.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FISCAL_YEAR", employeeLocalAllowance.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeLocalAllowance.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_AMOUNT", employeeLocalAllowance.Amount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeeLocalAllowance.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeLocalAllowance.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POST_CODE", employeeLocalAllowance.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE", employeeLocalAllowance.AllowanceDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED", employeeLocalAllowance.Approved, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ALLOWANCE_DATE_BS", employeeLocalAllowance.AllowanceDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeLocalAllowance> lst = new List<EmployeeLocalAllowance>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeLocalAllowance obj = new EmployeeLocalAllowance();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.Amount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["AMOUNT"].ToString()));
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.AllowanceDate = drow["ALLOWANCE_DATE"].ToString();
                    obj.Approved = drow["APPROVED"].ToString();
                    obj.AllowanceDateBs = drow["ALLOWANCE_DATE_BS"].ToString();

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
