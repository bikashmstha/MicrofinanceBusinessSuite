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
    public class OracleEmployeePromotionDao : IEmployeePromotionDao
    {
        public object SaveEmployeePromotion(EmployeePromotion employeePromotion)
        {
            string sp = "hr_employee_pkg.p_hr_emp_promotions";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeePromotion.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE", employeePromotion.PromotionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE_NEP", employeePromotion.PromotionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_POST_CODE", employeePromotion.OldPostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POST_CODE", employeePromotion.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", employeePromotion.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_GRADE_NO", employeePromotion.OldGradeNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_LEVEL_SNO", employeePromotion.OldLevelSno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_NO", employeePromotion.GradeNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_VALUE", employeePromotion.GradeValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LEVEL_SNO", employeePromotion.LevelSno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_TYPE", employeePromotion.PromotionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeePromotion.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeePromotion.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeePromotion.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SERIAL_NO", employeePromotion.SerialNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeePromotion.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeePromotion.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", employeePromotion.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_SNO", employeePromotion.OutSno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeePromotion.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchEmployeePromotion(EmployeePromotion employeePromotion)
        {
            string sp = "employeePromotion_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeePromotion.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE", employeePromotion.PromotionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_DATE_NEP", employeePromotion.PromotionDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_POST_CODE", employeePromotion.OldPostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POST_CODE", employeePromotion.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REMARKS", employeePromotion.Remarks, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_GRADE_NO", employeePromotion.OldGradeNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OLD_LEVEL_SNO", employeePromotion.OldLevelSno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_NO", employeePromotion.GradeNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRADE_VALUE", employeePromotion.GradeValue, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LEVEL_SNO", employeePromotion.LevelSno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PROMOTION_TYPE", employeePromotion.PromotionType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeePromotion.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeePromotion.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeePromotion.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SERIAL_NO", employeePromotion.SerialNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeePromotion.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeePromotion.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", employeePromotion.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_SNO", employeePromotion.OutSno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeePromotion> lst = new List<EmployeePromotion>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeePromotion obj = new EmployeePromotion();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.PromotionDate = drow["PROMOTION_DATE"].ToString();
                    obj.PromotionDateNep = drow["PROMOTION_DATE_NEP"].ToString();
                    obj.OldPostCode = drow["OLD_POST_CODE"].ToString();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.Remarks = drow["REMARKS"].ToString();
                    obj.OldGradeNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OLD_GRADE_NO"].ToString()));
                    obj.OldLevelSno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OLD_LEVEL_SNO"].ToString()));
                    obj.GradeNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_NO"].ToString()));
                    obj.GradeValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_VALUE"].ToString()));
                    obj.LevelSno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LEVEL_SNO"].ToString()));
                    obj.PromotionType = drow["PROMOTION_TYPE"].ToString();
                    obj.ApprovedFlag = drow["APPROVED_FLAG"].ToString();
                    obj.ApprovedBy = drow["APPROVED_BY"].ToString();
                    obj.ApprovedDate = drow["APPROVED_DATE"].ToString();
                    obj.SerialNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SERIAL_NO"].ToString()));


                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutSno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["OUT_SNO"].ToString()));

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
