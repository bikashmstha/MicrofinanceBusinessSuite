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
    public class OracleEmployeeKycInfoDao : IEmployeeKycInfoDao
    {
        public object SaveEmployeeKycInfo(EmployeeKycInfo employeeKycInfo)
        {
            string sp = "fn_member_clients_pkg.p_staff_kyc_info";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_DATE", employeeKycInfo.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", employeeKycInfo.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARITAL_STATUS", employeeKycInfo.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FATHER_NAME", employeeKycInfo.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", employeeKycInfo.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BIRTH_YEAR", employeeKycInfo.BirthYear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_BOY_CHILD", employeeKycInfo.NoBoyChild, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_GIRL_CHILD", employeeKycInfo.NoGirlChild, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", employeeKycInfo.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_RELATION", employeeKycInfo.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_TYPE", employeeKycInfo.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_NO", employeeKycInfo.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_TYPE", employeeKycInfo.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", employeeKycInfo.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_CODE", employeeKycInfo.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FNAME", employeeKycInfo.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LNAME", employeeKycInfo.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_CLOSE_DATE", employeeKycInfo.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTAL_ADDRESS", employeeKycInfo.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GENDER", employeeKycInfo.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUPATION_CODE", employeeKycInfo.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_CODE", employeeKycInfo.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", employeeKycInfo.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHILDREN_NO", employeeKycInfo.ChildrenNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_INACTIVE", employeeKycInfo.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", employeeKycInfo.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", employeeKycInfo.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_AMOUNT", employeeKycInfo.FixedCollectionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_THIRD_PARTY_DATA", employeeKycInfo.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DOB", employeeKycInfo.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TELEPHONE_NO", employeeKycInfo.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MOBILE_NO", employeeKycInfo.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FAX_NO", employeeKycInfo.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", employeeKycInfo.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRAND_FATHER_NAME", employeeKycInfo.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_Y_N", employeeKycInfo.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_NAME", employeeKycInfo.MinorName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_RELATION", employeeKycInfo.MinorRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMAIL_ADDRESS", employeeKycInfo.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_LEFT", employeeKycInfo.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_RIGHT", employeeKycInfo.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", employeeKycInfo.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", employeeKycInfo.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", employeeKycInfo.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_CLIENT_NO", employeeKycInfo.OutClientNo, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_CLIENT_CODE", employeeKycInfo.OutClientCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                // paramList.Add(SqlHelper.GetOraParam(":p_action", employeeKycInfo.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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
        public object SearchEmployeeKycInfo(EmployeeKycInfo employeeKycInfo)
        {
            string sp = "employeeKycInfo_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_DATE", employeeKycInfo.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", employeeKycInfo.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARITAL_STATUS", employeeKycInfo.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FATHER_NAME", employeeKycInfo.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", employeeKycInfo.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BIRTH_YEAR", employeeKycInfo.BirthYear, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_BOY_CHILD", employeeKycInfo.NoBoyChild, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NO_GIRL_CHILD", employeeKycInfo.NoGirlChild, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", employeeKycInfo.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_RELATION", employeeKycInfo.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_TYPE", employeeKycInfo.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_NO", employeeKycInfo.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_TYPE", employeeKycInfo.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", employeeKycInfo.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_CODE", employeeKycInfo.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FNAME", employeeKycInfo.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LNAME", employeeKycInfo.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_CLOSE_DATE", employeeKycInfo.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTAL_ADDRESS", employeeKycInfo.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GENDER", employeeKycInfo.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUPATION_CODE", employeeKycInfo.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EDUCATION_CODE", employeeKycInfo.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", employeeKycInfo.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CHILDREN_NO", employeeKycInfo.ChildrenNo, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REASON_FOR_INACTIVE", employeeKycInfo.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", employeeKycInfo.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TRAN_OFFICE_CODE", employeeKycInfo.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FIXED_COLLECTION_AMOUNT", employeeKycInfo.FixedCollectionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_THIRD_PARTY_DATA", employeeKycInfo.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DOB", employeeKycInfo.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TELEPHONE_NO", employeeKycInfo.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MOBILE_NO", employeeKycInfo.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FAX_NO", employeeKycInfo.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", employeeKycInfo.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRAND_FATHER_NAME", employeeKycInfo.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_Y_N", employeeKycInfo.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_NAME", employeeKycInfo.MinorName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_RELATION", employeeKycInfo.MinorRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMAIL_ADDRESS", employeeKycInfo.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_LEFT", employeeKycInfo.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_RIGHT", employeeKycInfo.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_USER1", employeeKycInfo.User1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_INSERT_UPDATE", employeeKycInfo.InsertUpdate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_FISCAL_YEAR", employeeKycInfo.OutFiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_CLIENT_NO", employeeKycInfo.OutClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OUT_CLIENT_CODE", employeeKycInfo.OutClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<EmployeeKycInfo> lst = new List<EmployeeKycInfo>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    EmployeeKycInfo obj = new EmployeeKycInfo();
                    obj.MembershipDate = drow["MEMBERSHIP_DATE"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.MaritalStatus = drow["MARITAL_STATUS"].ToString();
                    obj.FatherName = drow["FATHER_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.BirthYear = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["BIRTH_YEAR"].ToString()));
                    obj.NoBoyChild = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_BOY_CHILD"].ToString()));
                    obj.NoGirlChild = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_GIRL_CHILD"].ToString()));
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.NomineeRelation = drow["NOMINEE_RELATION"].ToString();
                    obj.IdDocumentType = drow["ID_DOCUMENT_TYPE"].ToString();
                    obj.IdDocumentNo = drow["ID_DOCUMENT_NO"].ToString();
                    obj.MemberType = drow["MEMBER_TYPE"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.Fname = drow["FNAME"].ToString();
                    obj.Lname = drow["LNAME"].ToString();
                    obj.MembershipCloseDate = drow["MEMBERSHIP_CLOSE_DATE"].ToString();
                    obj.PostalAddress = drow["POSTAL_ADDRESS"].ToString();
                    obj.Gender = drow["GENDER"].ToString();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.EducationCode = drow["EDUCATION_CODE"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.ChildrenNo = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["CHILDREN_NO"].ToString()));
                    obj.ReasonForInactive = drow["REASON_FOR_INACTIVE"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();
                    obj.FixedCollectionAmount = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["FIXED_COLLECTION_AMOUNT"].ToString()));
                    obj.ThirdPartyData = drow["THIRD_PARTY_DATA"].ToString();
                    obj.Dob = drow["DOB"].ToString();
                    obj.TelephoneNo = drow["TELEPHONE_NO"].ToString();
                    obj.MobileNo = drow["MOBILE_NO"].ToString();
                    obj.FaxNo = drow["FAX_NO"].ToString();
                    obj.JointImagePath = drow["JOINT_IMAGE_PATH"].ToString();
                    obj.GrandFatherName = drow["GRAND_FATHER_NAME"].ToString();
                    obj.MinorYN = drow["MINOR_Y_N"].ToString();
                    obj.MinorName = drow["MINOR_NAME"].ToString();
                    obj.MinorRelation = drow["MINOR_RELATION"].ToString();
                    obj.EmailAddress = drow["EMAIL_ADDRESS"].ToString();
                    obj.FingerPrintLeft = drow["FINGER_PRINT_LEFT"].ToString();
                    obj.FingerPrintRight = drow["FINGER_PRINT_RIGHT"].ToString();
                    obj.User1 = drow["USER1"].ToString();
                    obj.InsertUpdate = drow["INSERT_UPDATE"].ToString();
                    obj.OutFiscalYear = drow["OUT_FISCAL_YEAR"].ToString();
                    obj.OutClientNo = drow["OUT_CLIENT_NO"].ToString();
                    obj.OutClientCode = drow["OUT_CLIENT_CODE"].ToString();

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
