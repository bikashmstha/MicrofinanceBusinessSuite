using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataObjects.Interfaces.Finance;
using BusinessObjects;
using BusinessObjects.Finance;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleMemberDao : IMemberDao
    {
        public object Get()
        {
            string sp = "member_pkg.p_get";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Member> lst = new List<Member>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Member obj = new Member();
                    obj.FiscalYear = drow["FiscalYear"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.ClientCode = drow["ClientCode"].ToString();
                    obj.GroupCode = drow["GroupCode"].ToString();
                    obj.MembershipDate = drow["MembershipDate"].ToString();
                    obj.Address = drow["Address"].ToString();
                    obj.MaritalStatus = drow["MaritalStatus"].ToString();
                    obj.FatherName = drow["FatherName"].ToString();
                    obj.SpouseName = drow["SpouseName"].ToString();
                    obj.BirthYear = int.Parse(drow["BirthYear"].ToString());
                    obj.NoBoyChild = int.Parse(drow["NoBoyChild"].ToString());
                    obj.NoGirlChild = int.Parse(drow["NoGirlChild"].ToString());
                    obj.NomineeName = drow["NomineeName"].ToString();
                    obj.NomineeRelation = drow["NomineeRelation"].ToString();
                    obj.IdDocumentType = drow["IdDocumentType"].ToString();
                    obj.IdDocumentNo = drow["IdDocumentNo"].ToString();
                    obj.LoanYear = int.Parse(drow["LoanYear"].ToString());
                    obj.MemberType = drow["MemberType"].ToString();
                    obj.EmployeeId = drow["EmployeeId"].ToString();
                    obj.CasteCode = drow["CasteCode"].ToString();
                    obj.Fname = drow["Fname"].ToString();
                    obj.Lname = drow["Lname"].ToString();
                    obj.MembershipCloseDate = drow["MembershipCloseDate"].ToString();
                    obj.PostalAddress = drow["PostalAddress"].ToString();
                    obj.Gender = drow["Gender"].ToString();
                    obj.OccupationCode = drow["OccupationCode"].ToString();
                    obj.EducationCode = drow["EducationCode"].ToString();
                    obj.Active = drow["Active"].ToString();
                    obj.ChildrenNo = int.Parse(drow["ChildrenNo"].ToString());
                    obj.FieldAssistantId = drow["FieldAssistantId"].ToString();
                    obj.ReasonForInactive = drow["ReasonForInactive"].ToString();
                    obj.Signature3 = drow["Signature3"].ToString();
                    obj.Signature2 = drow["Signature2"].ToString();
                    obj.Signature1 = drow["Signature1"].ToString();
                    obj.ImagePath = drow["ImagePath"].ToString();
                    obj.TranOfficeCode = drow["TranOfficeCode"].ToString();


                    obj.ModifiedOn = drow["ModifiedOn"].ToString();
                    obj.ModifiedBy = drow["ModifiedBy"].ToString();
                    obj.LastChangeDate = drow["LastChangeDate"].ToString();
                    obj.TransferDate = drow["TransferDate"].ToString();
                    obj.FixedCollectionAmount = int.Parse(drow["FixedCollectionAmount"].ToString());
                    obj.CenterCode = drow["CenterCode"].ToString();
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.Dob = drow["Dob"].ToString();
                    obj.TelephoneNo = drow["TelephoneNo"].ToString();
                    obj.MobileNo = drow["MobileNo"].ToString();
                    obj.FaxNo = drow["FaxNo"].ToString();
                    obj.JointImagePath = drow["JointImagePath"].ToString();
                    obj.GrandFatherName = drow["GrandFatherName"].ToString();
                    obj.MinorYN = drow["MinorYN"].ToString();
                    obj.MinorName = drow["MinorName"].ToString();
                    obj.MinorRelation = drow["MinorRelation"].ToString();
                    obj.EmailAddress = drow["EmailAddress"].ToString();
                    obj.FingerPrintLeft = drow["FingerPrintLeft"].ToString();
                    obj.FingerPrintRight = drow["FingerPrintRight"].ToString();
                    obj.IdIssueDistrictCode = drow["IdIssueDistrictCode"].ToString();
                    obj.FatherInlawName = drow["FatherInlawName"].ToString();
                    obj.HusbandName = drow["HusbandName"].ToString();
                    obj.IdentityOwnBy = drow["IdentityOwnBy"].ToString();
                    obj.ReasonCode = drow["ReasonCode"].ToString();
                    obj.RefClientNo = drow["RefClientNo"].ToString();
                    obj.MemIdentityIssueDate = drow["MemIdentityIssueDate"].ToString();
                    obj.HusIdentityType = drow["HusIdentityType"].ToString();
                    obj.HusIdentityNo = drow["HusIdentityNo"].ToString();
                    obj.HusIdentityIssueDistrict = drow["HusIdentityIssueDistrict"].ToString();
                    obj.HusIdentityIssueDate = drow["HusIdentityIssueDate"].ToString();
                    obj.Address1Type = drow["Address1Type"].ToString();
                    obj.Address1Line2 = drow["Address1Line2"].ToString();
                    obj.Address1Line3 = drow["Address1Line3"].ToString();
                    obj.Address1District = drow["Address1District"].ToString();
                    obj.Address2Type = drow["Address2Type"].ToString();
                    obj.Address2Line1 = drow["Address2Line1"].ToString();
                    obj.Address2Line2 = drow["Address2Line2"].ToString();
                    obj.Address2Line3 = drow["Address2Line3"].ToString();
                    obj.Address2District = drow["Address2District"].ToString();
                    obj.ReligionCode = drow["ReligionCode"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Save(Member member)
        {
            string sp = "fn_member_clients_pkg.p_mf_member";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_group_code", member.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_membership_date", member.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_address", member.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_marital_status", member.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_father_name", member.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_spouse_name", member.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_id_issue_district_code", member.IdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_no_boy_child", member.NoBoyChild, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_no_girl_child", member.NoGirlChild, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_nominee_name", member.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_nominee_relation", member.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_id_document_type", member.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_id_document_no", member.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_type", member.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_employee_id", member.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_caste_code", member.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_religion_code", member.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_fname", member.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_lname", member.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_membership_close_date", member.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_postal_address", member.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_gender", member.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_occupation_code", member.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_education_code", member.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_active", member.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_children_no", member.ChildrenNo, OracleDbType.Int32, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_reason_for_inactive", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_signature3", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_signature2", member.Signature2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_signature1", member.Signature1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_image_path", member.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_tran_office_code", member.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_fixed_collection_amount", member.FixedCollectionAmount, OracleDbType.Double, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_third_party_data", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_dob", member.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_telephone_no", member.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_mobile_no", member.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_fax_no", member.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_joint_image_path", member.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_grand_father_name", member.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_minor_y_n", member.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_minor_name", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_minor_relation", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_email_address", member.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_finger_print_left", member.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_finger_print_right", member.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_id_issue_district_code", member.IdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_father_inlaw_name", member.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_husband_name", member.HusbandName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_identity_own_by", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_reason_code", DBNull.Value, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_mem_id_issue_date", member.MemIdentityIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_hus_id_document_type", member.HusIdentityType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_hus_id_document_no", member.HusIdentityNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_hus_id_issue_district_code", member.HusIdentityIssueDistrict, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_hus_id_issue_date", member.HusIdentityIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_1_type", member.Address1Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_2_type", member.Address2Type, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address", member.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_1_line2", member.Address1Line2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_1_line3", member.Address1Line3, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_2_line1", member.Address2Line1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_2_line2", member.Address2Line2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_2_line3", member.Address2Line3, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_1_district_code", member.Address1District, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_address_2_district_code", member.Address2District, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_user", "", OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_insert_update", member.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_fiscal_year", member.FiscalYear, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_client_no",member.ClientNo, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 500;
                paramList.Add(SqlHelper.GetOraParam(":v_out_client_code", member.ClientCode, OracleDbType.Varchar2, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":v_out_loan_year", member.LoanYear, OracleDbType.Int32, ParameterDirection.InputOutput));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 500;
                //paramList.Add(SqlHelper.GetOraParam(":p_BirthYear", member.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MembershipCloseDate", member.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FieldAssistantId", member.FieldAssistantId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", member.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", member.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", member.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", member.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", member.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", member.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", member.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_RefClientNo", member.RefClientNo, OracleDbType.Varchar2, ParameterDirection.Input));


                #region fromCG
                //paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", member.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", member.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", member.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_GroupCode", member.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MembershipDate", member.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address", member.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MaritalStatus", member.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FatherName", member.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_SpouseName", member.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_BirthYear", member.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NoBoyChild", member.NoBoyChild, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NoGirlChild", member.NoGirlChild, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", member.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NomineeRelation", member.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdDocumentType", member.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdDocumentNo", member.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_LoanYear", member.LoanYear, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MemberType", member.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", member.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CasteCode", member.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Fname", member.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Lname", member.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MembershipCloseDate", member.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_PostalAddress", member.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Gender", member.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_OccupationCode", member.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EducationCode", member.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Active", member.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ChildrenNo", member.ChildrenNo, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FieldAssistantId", member.FieldAssistantId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ReasonForInactive", member.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Signature3", member.Signature3, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Signature2", member.Signature2, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Signature1", member.Signature1, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", member.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", member.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", member.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", member.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", member.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", member.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", member.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", member.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectionAmount", member.FixedCollectionAmount, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", member.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", member.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Dob", member.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TelephoneNo", member.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MobileNo", member.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FaxNo", member.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_JointImagePath", member.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_GrandFatherName", member.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MinorYN", member.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MinorName", member.MinorName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MinorRelation", member.MinorRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EmailAddress", member.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FingerPrintLeft", member.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FingerPrintRight", member.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdIssueDistrictCode", member.IdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FatherInlawName", member.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusbandName", member.HusbandName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdentityOwnBy", member.IdentityOwnBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ReasonCode", member.ReasonCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_RefClientNo", member.RefClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MemIdentityIssueDate", member.MemIdentityIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityType", member.HusIdentityType, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityNo", member.HusIdentityNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityIssueDistrict", member.HusIdentityIssueDistrict, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityIssueDate", member.HusIdentityIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1Type", member.Address1Type, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1Line2", member.Address1Line2, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1Line3", member.Address1Line3, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1District", member.Address1District, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Type", member.Address2Type, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Line1", member.Address2Line1, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Line2", member.Address2Line2, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Line3", member.Address2Line3, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2District", member.Address2District, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ReligionCode", member.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_action", member.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 20;
                //paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100;
                #endregion


                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object Search(Member member)
        {
            string sp = "fn_member_clients_pkg.p_member_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", member.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));           
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", member.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_code", member.MemberCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_id_document_type", member.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_id_document_no", member.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_telephone_no", member.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_mem_date_from", member.MembershipDateFrom, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_mem_date_to", member.MembershipDateTo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 500;

                #region CG
                //paramList.Add(SqlHelper.GetOraParam(":p_FiscalYear", member.FiscalYear, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", member.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ClientCode", member.ClientCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_GroupCode", member.GroupCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MembershipDate", member.MembershipDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address", member.Address, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MaritalStatus", member.MaritalStatus, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FatherName", member.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_SpouseName", member.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_BirthYear", member.BirthYear, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NoBoyChild", member.NoBoyChild, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NoGirlChild", member.NoGirlChild, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", member.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_NomineeRelation", member.NomineeRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdDocumentType", member.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdDocumentNo", member.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_LoanYear", member.LoanYear, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MemberType", member.MemberType, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EmployeeId", member.EmployeeId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CasteCode", member.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Fname", member.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Lname", member.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MembershipCloseDate", member.MembershipCloseDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_PostalAddress", member.PostalAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Gender", member.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_OccupationCode", member.OccupationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EducationCode", member.EducationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Active", member.Active, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ChildrenNo", member.ChildrenNo, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FieldAssistantId", member.FieldAssistantId, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ReasonForInactive", member.ReasonForInactive, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Signature3", member.Signature3, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Signature2", member.Signature2, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Signature1", member.Signature1, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", member.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TranOfficeCode", member.TranOfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", member.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", member.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedOn", member.ModifiedOn, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ModifiedBy", member.ModifiedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_LastChangeDate", member.LastChangeDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TransferDate", member.TransferDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FixedCollectionAmount", member.FixedCollectionAmount, OracleDbType.Int32, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_CenterCode", member.CenterCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", member.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Dob", member.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_TelephoneNo", member.TelephoneNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MobileNo", member.MobileNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FaxNo", member.FaxNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_JointImagePath", member.JointImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_GrandFatherName", member.GrandFatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MinorYN", member.MinorYN, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MinorName", member.MinorName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MinorRelation", member.MinorRelation, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_EmailAddress", member.EmailAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FingerPrintLeft", member.FingerPrintLeft, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FingerPrintRight", member.FingerPrintRight, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdIssueDistrictCode", member.IdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_FatherInlawName", member.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusbandName", member.HusbandName, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_IdentityOwnBy", member.IdentityOwnBy, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ReasonCode", member.ReasonCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_RefClientNo", member.RefClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_MemIdentityIssueDate", member.MemIdentityIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityType", member.HusIdentityType, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityNo", member.HusIdentityNo, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityIssueDistrict", member.HusIdentityIssueDistrict, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_HusIdentityIssueDate", member.HusIdentityIssueDate, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1Type", member.Address1Type, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1Line2", member.Address1Line2, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1Line3", member.Address1Line3, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address1District", member.Address1District, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Type", member.Address2Type, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Line1", member.Address2Line1, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Line2", member.Address2Line2, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2Line3", member.Address2Line3, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_Address2District", member.Address2District, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":p_ReligionCode", member.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                //paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                #endregion

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Member> lst = new List<Member>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Member obj = new Member();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.Fname = drow["FNAME"].ToString();
                    obj.Lname = drow["LNAME"].ToString();
                    obj.Address = drow["ADDRESS"].ToString();
                    obj.Active = drow["ACTIVE"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupDesc = drow["GROUP_DESC"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();


                    
                   // obj.FiscalYear = drow["FISCAL_YEAR"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    
                    obj.MembershipDate = drow["MEMBERSHIP_DATE"].ToString();
                    
                    obj.MaritalStatus = drow["MARITAL_STATUS"].ToString();
                    obj.FatherName = drow["FATHER_NAME"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    //obj.BirthYear = int.Parse(drow["BIRTH_YEAR"].ToString());

                    if (!string.IsNullOrEmpty( drow["NO_GIRL_CHILD"].ToString()))
                    obj.NoGirlChild = int.Parse(drow["NO_GIRL_CHILD"].ToString());

                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.NomineeRelation = drow["NOMINEE_RELATION"].ToString();
                    obj.IdDocumentType = drow["ID_DOCUMENT_TYPE"].ToString();
                    obj.IdDocumentNo = drow["ID_DOCUMENT_NO"].ToString();
                    if (!string.IsNullOrEmpty(drow["NO_BOY_CHILD"].ToString()))
                    obj.NoBoyChild = int.Parse(drow["NO_BOY_CHILD"].ToString());

                    if (!string.IsNullOrEmpty(drow["LOAN_YEAR"].ToString()))
                    obj.LoanYear = int.Parse(drow["LOAN_YEAR"].ToString());
                    obj.MemberCode = drow["CLIENT_CODE"].ToString();
                    obj.MemberType = drow["MEMBER_TYPE"].ToString();
                    obj.EmployeeId = drow["EMPLOYEE_ID"].ToString();
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.CasteDesc = drow["CASTE_DESC"].ToString();
                    obj.Fname = drow["FNAME"].ToString();
                    obj.Lname = drow["LNAME"].ToString();
                    obj.MembershipCloseDate = drow["MEMBERSHIP_CLOSE_DATE"].ToString();
                    obj.PostalAddress = drow["POSTAL_ADDRESS"].ToString();
                    obj.Gender = drow["GENDER"].ToString();
                    obj.OccupationCode = drow["OCCUPATION_CODE"].ToString();
                    obj.EducationCode = drow["EDUCATION_CODE"].ToString();

                    if (!string.IsNullOrEmpty(drow["CHILDREN_NO"].ToString()))
                    obj.ChildrenNo = int.Parse(drow["CHILDREN_NO"].ToString());

                    //obj.FieldAssistantId = drow["FIELD_ASSISTANT_ID"].ToString();
                    obj.ReasonForInactive = drow["REASON_FOR_INACTIVE"].ToString();
                    obj.Signature3 = drow["SIGNATURE3"].ToString();
                    obj.Signature2 = drow["SIGNATURE2"].ToString();
                    obj.Signature1 = drow["SIGNATURE1"].ToString();
                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.TranOfficeCode = drow["TRAN_OFFICE_CODE"].ToString();


                    obj.ModifiedOn = drow["MODIFIED_ON"].ToString();
                    obj.ModifiedBy = drow["MODIFIED_BY"].ToString();
                   // obj.LastChangeDate = drow["LAST_CHANGE_DATE"].ToString();
                   // obj.TransferDate = drow["TRANSFER_DATE"].ToString();

                    if (!string.IsNullOrEmpty(drow["FIXED_COLLECTION_AMOUNT"].ToString()))                    
                    obj.FixedCollectionAmount = double.Parse(drow["FIXED_COLLECTION_AMOUNT"].ToString());

                    //obj.ThirdPartyData = drow["THIRD_PARTY_DATA"].ToString();
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
                    obj.IdIssueDistrictCode = drow["ID_ISSUE_DISTRICT_CODE"].ToString();
                    obj.FatherInlawName = drow["FATHER_INLAW_NAME"].ToString();
                    obj.HusbandName = drow["HUSBAND_NAME"].ToString();
                    //obj.IdentityOwnBy = drow["IDENTITY_OWN_BY"].ToString();
                    //obj.ReasonCode = drow["REASON_CODE"].ToString();
                    //obj.RefClientNo = drow["ref_client_no"].ToString();
                    //obj.MemIdentityIssueDate = drow["mem_identity_issue_date"].ToString();
                    //obj.HusIdentityType = drow["hus_identity_type"].ToString();
                    //obj.HusIdentityNo = drow["hus_identity_no"].ToString();
                    //obj.HusIdentityIssueDistrict = drow["hus_identity_issue_district"].ToString();
                    //obj.HusIdentityIssueDate = drow["hus_identity_issue_date"].ToString();
                    //obj.Address1Type = drow["address_1_type"].ToString();
                    //obj.Address1Line2 = drow["address_1_line2"].ToString();
                    //obj.Address1Line3 = drow["address_1_line3"].ToString();
                    //obj.Address1District = drow["address_1_district"].ToString();
                    //obj.Address2Type = drow["address_2_type"].ToString();
                    //obj.Address2Line1 = drow["address_2_line1"].ToString();
                    //obj.Address2Line2 = drow["address_2_line2"].ToString();
                    //obj.Address2Line3 = drow["address_2_line3"].ToString();
                    //obj.Address2District = drow["address_2_district"].ToString();
                    //obj.ReligionCode = drow["religion_code"].ToString();
                    


                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetMemberList(string offCode, string centerCode, string memberName)
        {
            string sp = "fn_member_clients_pkg.p_member_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code",centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_name", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 500;



                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Member> lst = new List<Member>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Member obj = new Member();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupDesc = drow["GROUP_DESC"].ToString();

                                        
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }


        public object GetMemberForAccOpen(string offCode, string centerCode, string memberName)
        {
            string sp = "fn_member_clients_pkg.p_mem_ac_open_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try


            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_name", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 500;



                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Member> lst = new List<Member>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Member obj = new Member();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.MemberName = drow["NAME"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupDesc = drow["GROUP_DESC"].ToString();


                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetMemberLovList(string offCode, string centerCode, string memberName)
        {
            string sp = "fn_member_clients_pkg.p_member_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", offCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_center_code", centerCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_member_name", memberName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                paramList[paramList.Count - 1].Size = 500;



                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Member> lst = new List<Member>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Member obj = new Member();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ClientCode = drow["CLIENT_CODE"].ToString();
                    obj.MemberName = drow["MEMBER_NAME"].ToString();
                    obj.CenterCode = drow["CENTER_CODE"].ToString();
                    obj.CenterName = drow["CENTER_NAME"].ToString();
                    obj.GroupCode = drow["GROUP_CODE"].ToString();
                    obj.GroupDesc = drow["GROUP_NAME"].ToString();


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
