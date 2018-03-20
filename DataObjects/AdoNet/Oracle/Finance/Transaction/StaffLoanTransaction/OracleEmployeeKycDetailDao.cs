using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleEmployeeKycDetailDao : IEmployeeKycDetailDao
    {
        public object SaveEmployeeKycDetail(EmployeeKycDetail employeeKycDetail)
        {
            string sp = "employeeKycDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", employeeKycDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", employeeKycDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FNAME", employeeKycDetail.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LNAME", employeeKycDetail.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_TYPE", employeeKycDetail.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", employeeKycDetail.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_DATE", employeeKycDetail.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_DATE", employeeKycDetail.MemDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", employeeKycDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARITAL_STATUS", employeeKycDetail.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FATHER_NAME", employeeKycDetail.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", employeeKycDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BIRTH_YEAR", employeeKycDetail.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", employeeKycDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_RELATION", employeeKycDetail.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_TYPE", employeeKycDetail.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_NO", employeeKycDetail.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", employeeKycDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_CLOSE_DATE", employeeKycDetail.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTAL_ADDRESS", employeeKycDetail.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUPATION_CODE", employeeKycDetail.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUP_DESC", employeeKycDetail.OccupDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_BOY_CHILD", employeeKycDetail.NoBoyChild, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_GIRL_CHILD", employeeKycDetail.NoGirlChild, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DOB", employeeKycDetail.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHILDREN_NO", employeeKycDetail.ChildrenNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_CODE", employeeKycDetail.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_CODE", employeeKycDetail.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_DESC", employeeKycDetail.CasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", employeeKycDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", employeeKycDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchEmployeeKycDetail(EmployeeKycDetail employeeKycDetail)
        {
            string sp = "employeeKycDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", employeeKycDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", employeeKycDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FNAME", employeeKycDetail.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LNAME", employeeKycDetail.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_TYPE", employeeKycDetail.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", employeeKycDetail.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_DATE", employeeKycDetail.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_DATE", employeeKycDetail.MemDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", employeeKycDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARITAL_STATUS", employeeKycDetail.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FATHER_NAME", employeeKycDetail.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", employeeKycDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BIRTH_YEAR", employeeKycDetail.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", employeeKycDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_RELATION", employeeKycDetail.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_TYPE", employeeKycDetail.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_NO", employeeKycDetail.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", employeeKycDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_CLOSE_DATE", employeeKycDetail.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTAL_ADDRESS", employeeKycDetail.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUPATION_CODE", employeeKycDetail.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUP_DESC", employeeKycDetail.OccupDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_BOY_CHILD", employeeKycDetail.NoBoyChild, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_GIRL_CHILD", employeeKycDetail.NoGirlChild, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DOB", employeeKycDetail.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHILDREN_NO", employeeKycDetail.ChildrenNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_CODE", employeeKycDetail.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_CODE", employeeKycDetail.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_DESC", employeeKycDetail.CasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", employeeKycDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeKycDetail> lst = new List<EmployeeKycDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeKycDetail obj = new EmployeeKycDetail();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.Fname = drow["FNAME"].ToString();
                    obj.Lname = drow["LNAME"].ToString();
                    obj.MemberType = drow["MEMBER_TYPE"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.MembershipDate = drow["MEMBERSHIP_DATE"].ToString();
                    obj.MemDate = drow["MEM_DATE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.MaritalStatus = drow["MARITAL_STATUS"].ToString();
                    obj.FatherName = drow["FATHER_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.BirthYear = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BIRTH_YEAR"].ToString()));
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.NomineeRelation = drow["NOMINEE_RELATION"].ToString();
                    obj.IdDocumentType = drow["ID_DOCUMENT_TYPE"].ToString();
                    obj.IdDocumentNo = drow["ID_DOCUMENT_NO"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.MembershipCloseDate = drow["MEMBERSHIP_CLOSE_DATE"].ToString();
                    obj.PostalAddress = drow["POSTAL_ADDRESS"].ToString();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.OccupDesc = drow["OCCUP_DESC"].ToString();
                    obj.NoBoyChild = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_BOY_CHILD"].ToString()));
                    obj.NoGirlChild = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_GIRL_CHILD"].ToString()));
                    obj.Dob = drow["DOB"].ToString();
                    obj.ChildrenNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHILDREN_NO"].ToString()));
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.EducationCode = drow["EDUCATION_CODE"].ToString();
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmpKycDetail(string OfficeCode, string ClientCode, string ClientName, string DateFrom, string DateTo)
        {
            string sp = "hr_employee_pkg.p_emp_kyc_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_CODE", ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_CLIENT_NAME", ClientName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DATE_FROM", DateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_DATE_TO", DateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeKycDetail> lst = new List<EmployeeKycDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeKycDetail obj = new EmployeeKycDetail();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.Fname = drow["FNAME"].ToString();
                    obj.Lname = drow["LNAME"].ToString();
                    obj.MemberType = drow["MEMBER_TYPE"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.MembershipDate = drow["MEMBERSHIP_DATE"].ToString();
                    obj.MemDate = drow["MEM_DATE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.MaritalStatus = drow["MARITAL_STATUS"].ToString();
                    obj.FatherName = drow["FATHER_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.BirthYear = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BIRTH_YEAR"].ToString()));
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.NomineeRelation = drow["NOMINEE_RELATION"].ToString();
                    obj.IdDocumentType = drow["ID_DOCUMENT_TYPE"].ToString();
                    obj.IdDocumentNo = drow["ID_DOCUMENT_NO"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.MembershipCloseDate = drow["MEMBERSHIP_CLOSE_DATE"].ToString();
                    obj.PostalAddress = drow["POSTAL_ADDRESS"].ToString();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.OccupDesc = drow["OCCUP_DESC"].ToString();
                    obj.NoBoyChild = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_BOY_CHILD"].ToString()));
                    obj.NoGirlChild = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_GIRL_CHILD"].ToString()));
                    obj.Dob = drow["DOB"].ToString();
                    obj.ChildrenNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHILDREN_NO"].ToString()));
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.EducationCode = drow["EDUCATION_CODE"].ToString();
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();

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
