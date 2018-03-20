using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
   
    public class OraclePublicClientDetailDao : IPublicClientDetailDao
    {
        public object SavePublicClientDetail(PublicClientDetail publicClientDetail)
        {
            string sp = "publicClientDetail_pkg.p_save";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicClientDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicClientDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FNAME", publicClientDetail.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LNAME", publicClientDetail.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_TYPE", publicClientDetail.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", publicClientDetail.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_DATE", publicClientDetail.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_DATE", publicClientDetail.MemDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", publicClientDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARITAL_STATUS", publicClientDetail.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FATHER_NAME", publicClientDetail.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", publicClientDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BIRTH_YEAR", publicClientDetail.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", publicClientDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_RELATION", publicClientDetail.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_TYPE", publicClientDetail.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_NO", publicClientDetail.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", publicClientDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_CLOSE_DATE", publicClientDetail.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTAL_ADDRESS", publicClientDetail.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GENDER", publicClientDetail.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUPATION_CODE", publicClientDetail.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUP_DESC", publicClientDetail.OccupDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", publicClientDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DOB", publicClientDetail.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TELEPHONE_NO", publicClientDetail.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MOBILE_NO", publicClientDetail.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FAX_NO", publicClientDetail.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", publicClientDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRAND_FATHER_NAME", publicClientDetail.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_Y_N", publicClientDetail.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_NAME", publicClientDetail.MinorName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_RELATION", publicClientDetail.MinorRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMAIL_ADDRESS", publicClientDetail.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", publicClientDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_LEFT", publicClientDetail.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_RIGHT", publicClientDetail.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_CODE", publicClientDetail.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_DESC", publicClientDetail.CasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_CLIENT_NO", publicClientDetail.RefClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", publicClientDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_action", publicClientDetail.Action, OracleDbType.Varchar2, ParameterDirection.Input));
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

        public object SearchPublicClientDetail(PublicClientDetail publicClientDetail)
        {
            string sp = "publicClientDetail_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_NO", publicClientDetail.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CLIENT_CODE", publicClientDetail.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FNAME", publicClientDetail.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_LNAME", publicClientDetail.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_TYPE", publicClientDetail.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBER_NAME", publicClientDetail.MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_DATE", publicClientDetail.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEM_DATE", publicClientDetail.MemDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ADDRESS", publicClientDetail.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MARITAL_STATUS", publicClientDetail.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FATHER_NAME", publicClientDetail.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_SPOUSE_NAME", publicClientDetail.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_BIRTH_YEAR", publicClientDetail.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_NAME", publicClientDetail.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_NOMINEE_RELATION", publicClientDetail.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_TYPE", publicClientDetail.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ID_DOCUMENT_NO", publicClientDetail.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMPLOYEE_ID", publicClientDetail.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MEMBERSHIP_CLOSE_DATE", publicClientDetail.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_POSTAL_ADDRESS", publicClientDetail.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GENDER", publicClientDetail.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUPATION_CODE", publicClientDetail.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_OCCUP_DESC", publicClientDetail.OccupDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_IMAGE_PATH", publicClientDetail.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_DOB", publicClientDetail.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_TELEPHONE_NO", publicClientDetail.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MOBILE_NO", publicClientDetail.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FAX_NO", publicClientDetail.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_JOINT_IMAGE_PATH", publicClientDetail.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_GRAND_FATHER_NAME", publicClientDetail.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_Y_N", publicClientDetail.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_NAME", publicClientDetail.MinorName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_MINOR_RELATION", publicClientDetail.MinorRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMAIL_ADDRESS", publicClientDetail.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_ACTIVE", publicClientDetail.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_LEFT", publicClientDetail.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_FINGER_PRINT_RIGHT", publicClientDetail.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_CODE", publicClientDetail.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_CASTE_DESC", publicClientDetail.CasteDesc, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_REF_CLIENT_NO", publicClientDetail.RefClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EMP_NAME", publicClientDetail.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicClientDetail> lst = new List<PublicClientDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicClientDetail obj = new PublicClientDetail();
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
                    obj.Gender = drow["GENDER"].ToString();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.OccupDesc = drow["OCCUP_DESC"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
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
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.FingerPrintLeft = drow["FINGER_PRINT_LEFT"].ToString();
                    obj.FingerPrintRight = drow["FINGER_PRINT_RIGHT"].ToString();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();
                    obj.RefClientNo = drow["REF_CLIENT_NO"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetPubClientDetail(string OfficeCode, string MemberCode, string MemberName, string MemDateFrom, string MemDateTo)
        {
            string sp = "fn_member_clients_pkg.p_pub_client_detail";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_MEMBER_CODE", MemberCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_MEMBER_NAME", MemberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_MEM_DATE_FROM", MemDateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_MEM_DATE_TO", MemDateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<PublicClientDetail> lst = new List<PublicClientDetail>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    PublicClientDetail obj = new PublicClientDetail();
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
                    obj.Gender = drow["GENDER"].ToString();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.OccupDesc = drow["OCCUP_DESC"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
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
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.FingerPrintLeft = drow["FINGER_PRINT_LEFT"].ToString();
                    obj.FingerPrintRight = drow["FINGER_PRINT_RIGHT"].ToString();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();
                    obj.RefClientNo = drow["REF_CLIENT_NO"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();

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
