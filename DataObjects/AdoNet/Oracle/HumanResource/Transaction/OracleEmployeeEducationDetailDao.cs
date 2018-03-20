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
    public class OracleEmployeeEducationDetailDao : IEmployeeEducationDetailDao
    {
        public object SaveEmployeeEducationDetail(EmployeeEducationDetail employeeEducationDetail)
        {
            string sp = "employeeEducationDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeEducationDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeEducationDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_LEVEL", employeeEducationDetail.EducationLevel, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_DESC", employeeEducationDetail.EducationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEGREE_NAME", employeeEducationDetail.DegreeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_YEAR", employeeEducationDetail.PassedYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_NEPALI_YEAR", employeeEducationDetail.PassedNepaliYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_DIVISION", employeeEducationDetail.PassedDivision, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_DIVISION_DESC", employeeEducationDetail.PassedDivisionDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHOOL_COLLEGE_NAME", employeeEducationDetail.SchoolCollegeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHOOL_COLLEGE_COUNTRY", employeeEducationDetail.SchoolCollegeCountry, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIVERSITY_NAME", employeeEducationDetail.UniversityName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIV_COUNTRY_CODE", employeeEducationDetail.UnivCountryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeeEducationDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeeEducationDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARKS_OBTAINED", employeeEducationDetail.MarksObtained, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUBJECTS", employeeEducationDetail.Subjects, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeeEducationDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeeEducationDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeEducationDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeeEducationDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchEmployeeEducationDetail(EmployeeEducationDetail employeeEducationDetail)
        {
            string sp = "employeeEducationDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_SNO", employeeEducationDetail.Sno, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_ID", employeeEducationDetail.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_LEVEL", employeeEducationDetail.EducationLevel, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_DESC", employeeEducationDetail.EducationDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DEGREE_NAME", employeeEducationDetail.DegreeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_YEAR", employeeEducationDetail.PassedYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_NEPALI_YEAR", employeeEducationDetail.PassedNepaliYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_DIVISION", employeeEducationDetail.PassedDivision, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PASSED_DIVISION_DESC", employeeEducationDetail.PassedDivisionDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHOOL_COLLEGE_NAME", employeeEducationDetail.SchoolCollegeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SCHOOL_COLLEGE_COUNTRY", employeeEducationDetail.SchoolCollegeCountry, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIVERSITY_NAME", employeeEducationDetail.UniversityName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_UNIV_COUNTRY_CODE", employeeEducationDetail.UnivCountryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_BY", employeeEducationDetail.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CREATED_ON", employeeEducationDetail.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARKS_OBTAINED", employeeEducationDetail.MarksObtained, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SUBJECTS", employeeEducationDetail.Subjects, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_FLAG", employeeEducationDetail.ApprovedFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_BY", employeeEducationDetail.ApprovedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_APPROVED_DATE", employeeEducationDetail.ApprovedDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeEducationDetail> lst = new List<EmployeeEducationDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeEducationDetail obj = new EmployeeEducationDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EducationLevel = drow["EDUCATION_LEVEL"].ToString();
                    obj.EducationDesc = drow["EDUCATION_DESC"].ToString();
                    obj.DegreeName = drow["DEGREE_NAME"].ToString();
                    obj.PassedYear = drow["PASSED_YEAR"].ToString();
                    obj.PassedNepaliYear = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PASSED_NEPALI_YEAR"].ToString()));
                    obj.PassedDivision = drow["PASSED_DIVISION"].ToString();
                    obj.PassedDivisionDesc = drow["PASSED_DIVISION_DESC"].ToString();
                    obj.SchoolCollegeName = drow["SCHOOL_COLLEGE_NAME"].ToString();
                    obj.SchoolCollegeCountry = drow["SCHOOL_COLLEGE_COUNTRY"].ToString();
                    obj.UniversityName = drow["UNIVERSITY_NAME"].ToString();
                    obj.UnivCountryCode = drow["UNIV_COUNTRY_CODE"].ToString();


                    obj.MarksObtained = drow["MARKS_OBTAINED"].ToString();
                    obj.Subjects = drow["SUBJECTS"].ToString();
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

        public object GetEmpEducationDetail(string EmpId)
        {
            string sp = "hr_employee_utility_pkg.p_emp_education_detail";
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
                List<EmployeeEducationDetail> lst = new List<EmployeeEducationDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeEducationDetail obj = new EmployeeEducationDetail();
                    obj.Sno = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["SNO"].ToString()));
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EducationLevel = drow["EDUCATION_LEVEL"].ToString();
                    obj.EducationDesc = drow["EDUCATION_DESC"].ToString();
                    obj.DegreeName = drow["DEGREE_NAME"].ToString();
                    obj.PassedYear = drow["PASSED_YEAR"].ToString();
                    obj.PassedNepaliYear = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PASSED_NEPALI_YEAR"].ToString()));
                    obj.PassedDivision = drow["PASSED_DIVISION"].ToString();
                    obj.PassedDivisionDesc = drow["PASSED_DIVISION_DESC"].ToString();
                    obj.SchoolCollegeName = drow["SCHOOL_COLLEGE_NAME"].ToString();
                    obj.SchoolCollegeCountry = drow["SCHOOL_COLLEGE_COUNTRY"].ToString();
                    obj.UniversityName = drow["UNIVERSITY_NAME"].ToString();
                    obj.UnivCountryCode = drow["UNIV_COUNTRY_CODE"].ToString();


                    obj.MarksObtained = drow["MARKS_OBTAINED"].ToString();
                    obj.Subjects = drow["SUBJECTS"].ToString();
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
