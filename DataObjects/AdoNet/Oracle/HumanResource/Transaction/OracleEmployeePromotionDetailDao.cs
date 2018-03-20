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
    public class OracleEmployeePromotionDetailDao : IEmployeePromotionDetailDao
    {
        public object SaveEmployeePromotionDetail(EmployeePromotionDetail employeePromotionDetail)
        {
            string sp = "employeePromotionDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeePromotionDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeePromotionDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE", employeePromotionDetail.PromotionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE_NEP", employeePromotionDetail.PromotionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_POST_CODE", employeePromotionDetail.OldPostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POST_CODE", employeePromotionDetail.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", employeePromotionDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_GRADE_NO", employeePromotionDetail.OldGradeNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_LEVEL_SNO", employeePromotionDetail.OldLevelSno, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_NO", employeePromotionDetail.GradeNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_VALUE", employeePromotionDetail.GradeValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LEVEL_SNO", employeePromotionDetail.LevelSno, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_TYPE", employeePromotionDetail.PromotionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeePromotionDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeePromotionDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeePromotionDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SERIAL_NO", employeePromotionDetail.SerialNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeePromotionDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeePromotionDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeePromotionDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchEmployeePromotionDetail(EmployeePromotionDetail employeePromotionDetail)
        {
            string sp = "employeePromotionDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeePromotionDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeePromotionDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE", employeePromotionDetail.PromotionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE_NEP", employeePromotionDetail.PromotionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_POST_CODE", employeePromotionDetail.OldPostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POST_CODE", employeePromotionDetail.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", employeePromotionDetail.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_GRADE_NO", employeePromotionDetail.OldGradeNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_LEVEL_SNO", employeePromotionDetail.OldLevelSno, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_NO", employeePromotionDetail.GradeNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_VALUE", employeePromotionDetail.GradeValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LEVEL_SNO", employeePromotionDetail.LevelSno, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_TYPE", employeePromotionDetail.PromotionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeePromotionDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeePromotionDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeePromotionDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SERIAL_NO", employeePromotionDetail.SerialNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeePromotionDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeePromotionDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeePromotionDetail> lst = new List<EmployeePromotionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeePromotionDetail obj = new EmployeePromotionDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.PromotionDate = drow["PROMOTION_DATE"].ToString();
                    obj.PromotionDateNep = drow["PROMOTION_DATE_NEP"].ToString();
                    obj.OldPostCode = drow["OLD_POST_CODE"].ToString();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.OldGradeNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OLD_GRADE_NO"].ToString()));
                    obj.OldLevelSno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OLD_LEVEL_SNO"].ToString()));
                    obj.GradeNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_NO"].ToString()));
                    obj.GradeValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_VALUE"].ToString()));
                    obj.LevelSno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LEVEL_SNO"].ToString()));
                    obj.PromotionType = drow["PROMOTION_TYPE"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.SerialNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SERIAL_NO"].ToString()));



                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmpPromotionDetail(string EmpId)
        {
            string sp = "hr_employee_utility_pkg.p_emp_promotion_detail";
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
                List<EmployeePromotionDetail> lst = new List<EmployeePromotionDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeePromotionDetail obj = new EmployeePromotionDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.PromotionDate = drow["PROMOTION_DATE"].ToString();
                    obj.PromotionDateNep = drow["PROMOTION_DATE_NEP"].ToString();
                    obj.OldPostCode = drow["OLD_POST_CODE"].ToString();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.OldGradeNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OLD_GRADE_NO"].ToString()));
                    obj.OldLevelSno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OLD_LEVEL_SNO"].ToString()));
                    obj.GradeNo = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_NO"].ToString()));
                    obj.GradeValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_VALUE"].ToString()));
                    obj.LevelSno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LEVEL_SNO"].ToString()));
                    obj.PromotionType = drow["PROMOTION_TYPE"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.SerialNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SERIAL_NO"].ToString()));



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
