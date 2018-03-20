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
    public class OracleEmployeeTransferDetailDao : IEmployeeTransferDetailDao
    {
        public object SaveEmployeeTransferDetail(EmployeeTransferDetail employeeTransferDetail)
        {
            string sp = "employeeTransferDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeTransferDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeTransferDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE", employeeTransferDetail.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE_NEP", employeeTransferDetail.TransferDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_OFFICE_CODE", employeeTransferDetail.FromOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_OFFICE_NAME", employeeTransferDetail.FromOfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DEPT_CODE", employeeTransferDetail.FromDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DEPT_NAME", employeeTransferDetail.FromDeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_OFFICE_CODE", employeeTransferDetail.ToOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_OFFICE_NAME", employeeTransferDetail.ToOfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DEPT_CODE", employeeTransferDetail.ToDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DEPT_NAME", employeeTransferDetail.ToDeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", employeeTransferDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOIN_DATE", employeeTransferDetail.JoinDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOIN_DATE_BS", employeeTransferDetail.JoinDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DESIGNATION_CODE", employeeTransferDetail.FromDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DESIGNATION_DESC", employeeTransferDetail.FromDesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DESIGNATION_CODE", employeeTransferDetail.ToDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DESIGNATION_DESC", employeeTransferDetail.ToDesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeeTransferDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeeTransferDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeTransferDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeeTransferDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeeTransferDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeeTransferDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchEmployeeTransferDetail(EmployeeTransferDetail employeeTransferDetail)
        {
            string sp = "employeeTransferDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeTransferDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeTransferDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE", employeeTransferDetail.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRANSFER_DATE_NEP", employeeTransferDetail.TransferDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_OFFICE_CODE", employeeTransferDetail.FromOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_OFFICE_NAME", employeeTransferDetail.FromOfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DEPT_CODE", employeeTransferDetail.FromDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DEPT_NAME", employeeTransferDetail.FromDeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_OFFICE_CODE", employeeTransferDetail.ToOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_OFFICE_NAME", employeeTransferDetail.ToOfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DEPT_CODE", employeeTransferDetail.ToDeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DEPT_NAME", employeeTransferDetail.ToDeptName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", employeeTransferDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOIN_DATE", employeeTransferDetail.JoinDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOIN_DATE_BS", employeeTransferDetail.JoinDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DESIGNATION_CODE", employeeTransferDetail.FromDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FROM_DESIGNATION_DESC", employeeTransferDetail.FromDesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DESIGNATION_CODE", employeeTransferDetail.ToDesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TO_DESIGNATION_DESC", employeeTransferDetail.ToDesignationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeeTransferDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeeTransferDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeTransferDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeeTransferDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeeTransferDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeTransferDetail> lst = new List<EmployeeTransferDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeTransferDetail obj = new EmployeeTransferDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.TransferDate = drow["TRANSFER_DATE"].ToString();
                    obj.TransferDateNep = drow["TRANSFER_DATE_NEP"].ToString();
                    obj.FromOfficeCode = drow["FROM_OFFICE_CODE"].ToString();
                    obj.FromOfficeName = drow["FROM_OFFICE_NAME"].ToString();
                    obj.FromDeptCode = drow["FROM_DEPT_CODE"].ToString();
                    obj.FromDeptName = drow["FROM_DEPT_NAME"].ToString();
                    obj.ToOfficeCode = drow["TO_OFFICE_CODE"].ToString();
                    obj.ToOfficeName = drow["TO_OFFICE_NAME"].ToString();
                    obj.ToDeptCode = drow["TO_DEPT_CODE"].ToString();
                    obj.ToDeptName = drow["TO_DEPT_NAME"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.JoinDate = drow["JOIN_DATE"].ToString();
                    obj.JoinDateBs = drow["JOIN_DATE_BS"].ToString();
                    obj.FromDesignationCode = drow["FROM_DESIGNATION_CODE"].ToString();
                    obj.FromDesignationDesc = drow["FROM_DESIGNATION_DESC"].ToString();
                    obj.ToDesignationCode = drow["TO_DESIGNATION_CODE"].ToString();
                    obj.ToDesignationDesc = drow["TO_DESIGNATION_DESC"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();



                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmpTransferDetail(string EmpId)
        {
            string sp = "hr_employee_utility_pkg.p_emp_transfer_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_EMP_ID", EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeTransferDetail> lst = new List<EmployeeTransferDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeTransferDetail obj = new EmployeeTransferDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.TransferDate = drow["TRANSFER_DATE"].ToString();
                    obj.TransferDateNep = drow["TRANSFER_DATE_NEP"].ToString();
                    obj.FromOfficeCode = drow["FROM_OFFICE_CODE"].ToString();
                    obj.FromOfficeName = drow["FROM_OFFICE_NAME"].ToString();
                    obj.FromDeptCode = drow["FROM_DEPT_CODE"].ToString();
                    obj.FromDeptName = drow["FROM_DEPT_NAME"].ToString();
                    obj.ToOfficeCode = drow["TO_OFFICE_CODE"].ToString();
                    obj.ToOfficeName = drow["TO_OFFICE_NAME"].ToString();
                    obj.ToDeptCode = drow["TO_DEPT_CODE"].ToString();
                    obj.ToDeptName = drow["TO_DEPT_NAME"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.JoinDate = drow["JOIN_DATE"].ToString();
                    obj.JoinDateBs = drow["JOIN_DATE_BS"].ToString();
                    obj.FromDesignationCode = drow["FROM_DESIGNATION_CODE"].ToString();
                    obj.FromDesignationDesc = drow["FROM_DESIGNATION_DESC"].ToString();
                    obj.ToDesignationCode = drow["TO_DESIGNATION_CODE"].ToString();
                    obj.ToDesignationDesc = drow["TO_DESIGNATION_DESC"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();



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
