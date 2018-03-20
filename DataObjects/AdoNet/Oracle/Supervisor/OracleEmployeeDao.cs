using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Supervisor;
using DataObjects.Interfaces.Supervisor;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Supervisor
{
    public class OracleEmployeeDao:IEmployeeDao
    {
        public object Get()
        {
            string sp = "hr_employee_pkg.p_employee_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EmpId"].ToString();
                    obj.EmpName = drow["EmpName"].ToString();
                    obj.Dob = drow["Dob"].ToString();
                    obj.DobNepali = drow["DobNepali"].ToString();
                    obj.Gender = drow["Gender"].ToString();
                    obj.Married = drow["Married"].ToString();
                    obj.CitizenshipNo = drow["CitizenshipNo"].ToString();
                    obj.EmployeeType = drow["EmployeeType"].ToString();
                    obj.PostCode = drow["PostCode"].ToString();
                    obj.JoinDate = drow["JoinDate"].ToString();
                    obj.JoinDateNep = drow["JoinDateNep"].ToString();
                    obj.OfficeCode = drow["OfficeCode"].ToString();
                    obj.DeptCode = drow["DeptCode"].ToString();
                    obj.ActiveFlag = drow["ActiveFlag"].ToString();
                    obj.TemporaryAddress = drow["TemporaryAddress"].ToString();
                    obj.TemporaryDistrictCode = drow["TemporaryDistrictCode"].ToString();
                    obj.TemporaryContactPhone = drow["TemporaryContactPhone"].ToString();
                    obj.PermanentAddress = drow["PermanentAddress"].ToString();
                    obj.PermanentDistrictCode = drow["PermanentDistrictCode"].ToString();
                    obj.PermanentContactPhone = drow["PermanentContactPhone"].ToString();
                    obj.EmailId = drow["EmailId"].ToString();
                    obj.ReligionCode = drow["ReligionCode"].ToString();
                    obj.CountryCode = drow["CountryCode"].ToString();
                    obj.SpouseName = drow["SpouseName"].ToString();
                    obj.SpouseOccupation = drow["SpouseOccupation"].ToString();
                    obj.Identification = drow["Identification"].ToString();
                    obj.FatherName = drow["FatherName"].ToString();
                    obj.MotherName = drow["MotherName"].ToString();
                    obj.FatherOccupation = drow["FatherOccupation"].ToString();
                    obj.MotherOccupation = drow["MotherOccupation"].ToString();
                    obj.GrandfatherName = drow["GrandfatherName"].ToString();
                    obj.NoOfSon = int.Parse(drow["NoOfSon"].ToString());
                    obj.NoOfDaughter = int.Parse(drow["NoOfDaughter"].ToString());
                    obj.NomineeName = drow["NomineeName"].ToString();
                    obj.NomineeAddress = drow["NomineeAddress"].ToString();
                    obj.NomineeDistrict = drow["NomineeDistrict"].ToString();
                    obj.Relation = drow["Relation"].ToString();
                    obj.CurrentOfficeJoinDateNep = drow["CurrentOfficeJoinDateNep"].ToString();
                    obj.LevelSno = int.Parse(drow["LevelSno"].ToString());
                    obj.Grade = int.Parse(drow["Grade"].ToString());
                    obj.FatherInlawName = drow["FatherInlawName"].ToString();
                    obj.PfAccountNo = drow["PfAccountNo"].ToString();
                    obj.InvestmentFundId = drow["InvestmentFundId"].ToString();
                    obj.CurrentOfficeJoinDate = drow["CurrentOfficeJoinDate"].ToString();
                    obj.CitizenInvestmentTrustIdNo = drow["CitizenInvestmentTrustIdNo"].ToString();
                    obj.IdentityCardNo = drow["IdentityCardNo"].ToString();
                    obj.DesignationCode = drow["DesignationCode"].ToString();
                    obj.ProvisionDate = drow["ProvisionDate"].ToString();
                    obj.ProvisionDateBs = drow["ProvisionDateBs"].ToString();
                    obj.PermanentDate = drow["PermanentDate"].ToString();
                    obj.PermanentDateBs = drow["PermanentDateBs"].ToString();
                    obj.QuarterYN = drow["QuarterYN"].ToString();
                    obj.PfDate = drow["PfDate"].ToString();
                    obj.InchargeYN = drow["InchargeYN"].ToString();


                    obj.ImagePath = drow["ImagePath"].ToString();
                    obj.EmployeeCode = drow["EmployeeCode"].ToString();
                    obj.ThirdPartyData = drow["ThirdPartyData"].ToString();
                    obj.Fname = drow["Fname"].ToString();
                    obj.Lname = drow["Lname"].ToString();
                    obj.NomineeIdIssueDistrictCode = drow["NomineeIdIssueDistrictCode"].ToString();
                    obj.NomineeIdDocumentNo = drow["NomineeIdDocumentNo"].ToString();
                    obj.NomineeIdDocumentType = drow["NomineeIdDocumentType"].ToString();
                    obj.Signature1 = drow["Signature1"].ToString();
                    obj.Signature2 = drow["Signature2"].ToString();
                    obj.NomineeImage = drow["NomineeImage"].ToString();
                    obj.NomineeSignature1 = drow["NomineeSignature1"].ToString();
                    obj.NomineeSignature2 = drow["NomineeSignature2"].ToString();
                    obj.IdIssueDistrictCode = drow["IdIssueDistrictCode"].ToString();
                    obj.IdDocumentNo = drow["IdDocumentNo"].ToString();
                    obj.IdDocumentType = drow["IdDocumentType"].ToString();
                    obj.TerminationDate = drow["TerminationDate"].ToString();
                    obj.TerminationReason = drow["TerminationReason"].ToString();
                    obj.CasteCode = drow["CasteCode"].ToString();
                    obj.SalaryAccountNo = drow["SalaryAccountNo"].ToString();
                    obj.HlpreAccountHeadCode = drow["HlpreAccountHeadCode"].ToString();
                    obj.SalaryAdvanceAccountHead = drow["SalaryAdvanceAccountHead"].ToString();
                    obj.ClientNo = drow["ClientNo"].ToString();
                    obj.ProvidentFund = int.Parse(drow["ProvidentFund"].ToString());
                    obj.HousingLoanAmt = int.Parse(drow["HousingLoanAmt"].ToString());
                    obj.GradeValue = int.Parse(drow["GradeValue"].ToString());
                    obj.OldGradeVal = int.Parse(drow["OldGradeVal"].ToString());
                    obj.DisableYN = drow["DisableYN"].ToString();

                    obj.Action = "U";
                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object Save(Employee employee)
        {
            string sp = "hr_employee_pkg.P_EMP_MASTER";
            OracleConnection conn = new OracleConnection();
            OracleTransaction tran = null;
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                tran = conn.BeginTransaction();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":P_EMP_ID", employee.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_EMP_NAME", employee.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_DOB", employee.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_GENDER", employee.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_MARRIED", employee.Married, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_CITIZENSHIP_NO", employee.CitizenshipNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_EMPLOYEE_TYPE", employee.EmployeeType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_POST_CODE", employee.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_JOIN_DATE", employee.JoinDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_OFFICE_CODE", employee.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_DEPT_CODE", employee.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_ACTIVE_FLAG", employee.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_TEMPORARY_ADDRESS", employee.TemporaryAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_TEMPORARY_DISTRICT_CODE", employee.TemporaryDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_TEMPORARY_CONTACT_PHONE", employee.TemporaryContactPhone, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PERMANENT_ADDRESS", employee.PermanentAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PERMANENT_DISTRICT_CODE", employee.PermanentDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PERMANENT_CONTACT_PHONE", employee.PermanentContactPhone, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_EMAIL_ID", employee.EmailId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_RELIGION_CODE", employee.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_COUNTRY_CODE", employee.CountryCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_SPOUSE_NAME", employee.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_SPOUSE_OCCUPATION", employee.SpouseOccupation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_IDENTIFICATION", employee.Identification, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_FATHER_NAME", employee.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_MOTHER_NAME", employee.MotherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_FATHER_OCCUPATION", employee.FatherOccupation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_MOTHER_OCCUPATION", employee.MotherOccupation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_GRANDFATHER_NAME", employee.GrandfatherName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NO_OF_SON", employee.NoOfSon, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NO_OF_DAUGHTER", employee.NoOfDaughter, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_NAME", employee.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_ADDRESS", employee.NomineeAddress, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_DISTRICT", employee.NomineeDistrict, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_RELATION", employee.Relation, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_LEVEL_SNO", employee.LevelSno, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_GRADE", employee.Grade, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_GRADE_VALUE", employee.GradeValue, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_FATHER_INLAW_NAME", employee.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PF_ACCOUNT_NO", employee.PfAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_INVESTMENT_FUND_ID", employee.InvestmentFundId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_CURRENT_OFFICE_JOIN_DATE", employee.CurrentOfficeJoinDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_CIT_ID_NO", employee.CitizenInvestmentTrustIdNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_IDENTITY_CARD_NO", employee.IdentityCardNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_DESIGNATION_CODE", employee.DesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PROVISION_DATE", employee.ProvisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PERMANENT_DATE", employee.PermanentDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_QUARTER_Y_N", employee.QuarterYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PF_DATE", employee.PfDate, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_INCHARGE_Y_N", employee.InchargeYN, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_IMAGE_PATH", employee.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_SIGNATURE1", employee.Signature1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_SIGNATURE2", employee.Signature2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_IMAGE", employee.NomineeImage, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_SIGNATURE1", employee.NomineeSignature1, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_SIGNATURE2", employee.NomineeSignature2, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_EMPLOYEE_CODE", employee.EmployeeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_ID_DOCUMENT_NO", employee.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_ID_ISSUE_DISTRICT_CODE", employee.IdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_ID_DOCUMENT_TYPE", employee.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_ID_ISSUE_DIST_CODE", employee.NomineeIdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_ID_DOCUMENT_NO", employee.NomineeIdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_NOMINEE_ID_DOCUMENT_TYPE", employee.NomineeIdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_CASTE_CODE", employee.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_SALARY_ACCOUNT_NO", employee.SalaryAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_HLPRE_ACCOUNT_HEAD_CODE", employee.HlpreAccountHeadCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_SALARY_ADVANCE_ACCOUNT_HEAD", employee.SalaryAdvanceAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_CLIENT_NO", employee.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_PROVIDENT_FUND", employee.ProvidentFund, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_HOUSING_LOAN_AMT", employee.HousingLoanAmt, OracleDbType.Long, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_USER", employee.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":P_INSERT_UPDATE", employee.Action, OracleDbType.Varchar2, ParameterDirection.Input));
                //v_out_emimage_name             
                //v_out_nominee_image_name         
                //v_out_emsignature1_name        
                //v_out_emsignature2_name        
                //v_out_nominee_signature1_name    
                //v_out_nominee_signature2_name 
                //paramList.Add(SqlHelper.GetOraParam(":v_out_emp_image_name", employee.ImagePathName, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100; 
                //paramList.Add(SqlHelper.GetOraParam(":v_out_nominee_image_name", employee.NomineeImageName, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100; 
                //paramList.Add(SqlHelper.GetOraParam(":v_out_emp_signature1_name", employee.Signature1Name, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100; 
                //paramList.Add(SqlHelper.GetOraParam(":v_out_emp_signature2_name", employee.Signature2Name, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100; 
                //paramList.Add(SqlHelper.GetOraParam(":v_out_nominee_signature1_name", employee.NomineeSignature1Name, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100; 
                //paramList.Add(SqlHelper.GetOraParam(":v_out_nominee_signature2_name", employee.NomineeSignature2Name, OracleDbType.Varchar2, ParameterDirection.Output));
                //paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":V_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                paramList.Add(SqlHelper.GetOraParam(":V_OUT_RESULT_MSG", null, OracleDbType.Varchar2, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
                tran.Commit();
                oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString();
                oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
                return oMsg;
            }
            catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        //public object Save(Employee employee)
        //{
        //    string sp = "employee_pkg.p_save";
        //    OracleConnection conn = new OracleConnection();
        //    OracleTransaction tran = null;
        //    OutMessage oMsg = new OutMessage();
        //    try
        //    {
        //        conn = new GetConnection().GetDbConn();
        //        tran = conn.BeginTransaction();
        //        List<OracleParameter> paramList = new List<OracleParameter>();
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmpId", employee.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmpName", employee.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Dob", employee.Dob, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_DobNepali", employee.DobNepali, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Gender", employee.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Married", employee.Married, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CitizenshipNo", employee.CitizenshipNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmployeeType", employee.EmployeeType, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PostCode", employee.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_JoinDate", employee.JoinDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_JoinDateNep", employee.JoinDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_OfficeCode", employee.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_DeptCode", employee.DeptCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ActiveFlag", employee.ActiveFlag, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_TemporaryAddress", employee.TemporaryAddress, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_TemporaryDistrictCode", employee.TemporaryDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_TemporaryContactPhone", employee.TemporaryContactPhone, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PermanentAddress", employee.PermanentAddress, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PermanentDistrictCode", employee.PermanentDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PermanentContactPhone", employee.PermanentContactPhone, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmailId", employee.EmailId, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ReligionCode", employee.ReligionCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CountryCode", employee.CountryCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_SpouseName", employee.SpouseName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_SpouseOccupation", employee.SpouseOccupation, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Identification", employee.Identification, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_FatherName", employee.FatherName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_MotherName", employee.MotherName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_FatherOccupation", employee.FatherOccupation, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_MotherOccupation", employee.MotherOccupation, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_GrandfatherName", employee.GrandfatherName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NoOfSon", employee.NoOfSon, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NoOfDaughter", employee.NoOfDaughter, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeName", employee.NomineeName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeAddress", employee.NomineeAddress, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeDistrict", employee.NomineeDistrict, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Relation", employee.Relation, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CurrentOfficeJoinDateNep", employee.CurrentOfficeJoinDateNep, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_LevelSno", employee.LevelSno, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Grade", employee.Grade, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_FatherInlawName", employee.FatherInlawName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PfAccountNo", employee.PfAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_InvestmentFundId", employee.InvestmentFundId, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CurrentOfficeJoinDate", employee.CurrentOfficeJoinDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CitizenInvestmentTrustIdNo", employee.CitizenInvestmentTrustIdNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_IdentityCardNo", employee.IdentityCardNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_DesignationCode", employee.DesignationCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ProvisionDate", employee.ProvisionDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ProvisionDateBs", employee.ProvisionDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PermanentDate", employee.PermanentDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PermanentDateBs", employee.PermanentDateBs, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_QuarterYN", employee.QuarterYN, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PfDate", employee.PfDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_InchargeYN", employee.InchargeYN, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CreatedBy", employee.CreatedBy, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CreatedOn", employee.CreatedOn, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ImagePath", employee.ImagePath, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmployeeCode", employee.EmployeeCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ThirdPartyData", employee.ThirdPartyData, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Fname", employee.Fname, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Lname", employee.Lname, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeIdIssueDistrictCode", employee.NomineeIdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeIdDocumentNo", employee.NomineeIdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeIdDocumentType", employee.NomineeIdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Signature1", employee.Signature1, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Signature2", employee.Signature2, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeImage", employee.NomineeImage, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeSignature1", employee.NomineeSignature1, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_NomineeSignature2", employee.NomineeSignature2, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_IdIssueDistrictCode", employee.IdIssueDistrictCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_IdDocumentNo", employee.IdDocumentNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_IdDocumentType", employee.IdDocumentType, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_TerminationDate", employee.TerminationDate, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_TerminationReason", employee.TerminationReason, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_CasteCode", employee.CasteCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_SalaryAccountNo", employee.SalaryAccountNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_HlpreAccountHeadCode", employee.HlpreAccountHeadCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_SalaryAdvanceAccountHead", employee.SalaryAdvanceAccountHead, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ClientNo", employee.ClientNo, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_ProvidentFund", employee.ProvidentFund, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_HousingLoanAmt", employee.HousingLoanAmt, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_GradeValue", employee.GradeValue, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_OldGradeVal", employee.OldGradeVal, OracleDbType.Int32, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_DisableYN", employee.DisableYN, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_action", employee.Action, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_CODE", null, OracleDbType.Varchar2, ParameterDirection.Output));
        //        paramList[paramList.Count - 1].Size = 20;
        //        paramList.Add(SqlHelper.GetOraParam(":P_OUT_RESULT_DESC", null, OracleDbType.Varchar2, ParameterDirection.Output));
        //        paramList[paramList.Count - 1].Size = 20;
        //        SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, sp, paramList.ToArray());
        //        tran.Commit();
        //        oMsg.OutResultCode = paramList[paramList.Count - 2].Value.ToString(); oMsg.OutResultMessage = paramList[paramList.Count - 1].Value.ToString();
        //        return oMsg;
        //    }
        //    catch (Exception ex) { tran.Rollback(); oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
        //    finally { conn.Close(); }
        //}

        //public object Search(Employee employee)
        //{
        //    string sp = "hr_employee_pkg.p_employee_detail_list";
        //    OracleConnection conn = new OracleConnection();
        //    OutMessage oMsg = new OutMessage();
        //    try
        //    {
        //        conn = new GetConnection().GetDbConn();
        //        List<OracleParameter> paramList = new List<OracleParameter>();
        //        paramList.Add(SqlHelper.GetOraParam(":p_OfficeCode", employee.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_PostCode", employee.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmpId", employee.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_EmpName", employee.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":p_Gender", employee.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
        //        paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
        //        DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
        //        List<Employee> lst = new List<Employee>();
        //        foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
        //        {
        //            Employee obj = new Employee();
        //            obj.EmpId = drow["EMP_ID"].ToString();
        //            obj.EmpName = drow["EMP_NAME"].ToString();
        //            obj.Dob = drow["DOB"].ToString();
        //            obj.DobNepali = drow["DOB_NEPALI"].ToString();
        //            obj.Gender = drow["GENDER"].ToString();
        //            obj.Married = drow["MARRIED"].ToString();
        //            obj.CitizenshipNo = drow["CITIZENSHIP_NO"].ToString();
        //            obj.EmployeeType = drow["EMPLOYEE_TYPE"].ToString();
        //            obj.PostCode = drow["POST_CODE"].ToString();
        //            obj.PostName = drow["POST_NAME"].ToString();
        //            obj.JoinDate = drow["JOIN_DATE"].ToString();
        //            obj.JoinDateNep = drow["JOIN_DATE_NEP"].ToString();
        //            obj.OfficeCode = drow["OFFICE_CODE"].ToString();
        //            obj.DeptCode = drow["DEPT_CODE"].ToString();
        //            obj.DeptName = drow["DEPART_NAME"].ToString();
        //            obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
        //            obj.TemporaryAddress = drow["TEMPORARY_ADDRESS"].ToString();
        //            obj.TemporaryDistrictCode = drow["TEMPORARY_DISTRICT_CODE"].ToString();
        //            obj.TemporaryDistrictName = drow["DIST_TEMP"].ToString();
        //            obj.TemporaryContactPhone = drow["TEMPORARY_CONTACT_PHONE"].ToString();
        //            obj.PermanentAddress = drow["PERMANENT_ADDRESS"].ToString();
        //            obj.PermanentDistrictCode = drow["PERMANENT_DISTRICT_CODE"].ToString();
        //            obj.PermanentDistrictName = drow["DIST_PERMA"].ToString();
        //            obj.PermanentContactPhone = drow["PERMANENT_CONTACT_PHONE"].ToString();
        //            obj.EmailId = drow["EMAIL_ID"].ToString();

        //            obj.ReligionCode = drow["RELIGION_CODE"].ToString();
        //            obj.CountryCode = drow["COUNTRY_CODE"].ToString();
        //            obj.SpouseName = drow["SPOUSE_NAME"].ToString();
        //            obj.SpouseOccupation = drow["SPOUSE_OCCUPATION"].ToString();
        //            obj.Identification = drow["IDENTIFICATION"].ToString();
        //            obj.FatherName = drow["FATHER_NAME"].ToString();
        //            obj.MotherName = drow["MOTHER_NAME"].ToString();
        //            obj.FatherOccupation = drow["FATHER_OCCUPATION"].ToString();
        //            obj.MotherOccupation = drow["MOTHER_OCCUPATION"].ToString();
        //            obj.GrandfatherName = drow["GRANDFATHER_NAME"].ToString();
        //            obj.NoOfSon = int.Parse(drow["NoOfSon"].ToString());
        //            obj.NoOfDaughter = int.Parse(drow["NO_OF_SON"].ToString());
        //            obj.NomineeName = drow["NO_OF_DAUGHTER"].ToString();
        //            obj.NomineeAddress = drow["NOMINEE_NAME"].ToString();
        //            obj.NomineeDistrict = drow["NOMINEE_ADDRESS"].ToString();
        //            obj.NomineeDistrictName = drow["DIST_NOMINEE"].ToString();

        //            obj.Relation = drow["Relation"].ToString();
        //            obj.CurrentOfficeJoinDateNep = drow["CURRENT_OFFICE_JOIN_DATE_NEP"].ToString();
        //            obj.LevelSno = int.Parse(drow["LEVEL_SNO"].ToString());
        //            obj.Grade = int.Parse(drow["GRADE"].ToString());
        //            obj.FatherInlawName = drow["FATHER_INLAW_NAME"].ToString();
        //            obj.PfAccountNo = drow["PF_ACCOUNT_NO"].ToString();
        //            obj.InvestmentFundId = drow["INVESTMENT_FUND_ID"].ToString();
        //            obj.CurrentOfficeJoinDate = drow["CURRENT_OFFICE_JOIN_DATE"].ToString();
        //            obj.CitizenInvestmentTrustIdNo = drow["CITIZEN_INVESTMENT_TRUST_ID_NO"].ToString();

        //            obj.IdentityCardNo = drow["IDENTITY_CARD_NO"].ToString();
        //            obj.DesignationCode = drow["DESIGNATION_CODE"].ToString();
        //            obj.DesignationName = drow["DESIGNATION_DESC"].ToString();
        //            obj.ProvisionDate = drow["PROVISION_DATE"].ToString();
        //            obj.ProvisionDateBs = drow["PROVISION_DATE_BS"].ToString();
        //            obj.PermanentDate = drow["PERMANENT_DATE"].ToString();
        //            obj.PermanentDateBs = drow["PERMANENT_DATE_BS"].ToString();
        //            obj.QuarterYN = drow["QUARTER_Y_N"].ToString();
        //            obj.PfDate = drow["PF_DATE"].ToString();
        //            obj.InchargeYN = drow["INCHARGE_Y_N"].ToString();


        //            obj.ImagePath = drow["IMAGE_PATH"].ToString();
        //            obj.EmployeeCode = drow["EMPLOYEE_CODE"].ToString();
        //            //obj.ThirdPartyData = drow["ThirdPartyData"].ToString(); //not returned from procedure
        //            obj.Fname = drow["Fname"].ToString();
        //            obj.Lname = drow["Lname"].ToString();
        //            obj.NomineeIdIssueDistrictCode = drow["NOMINEE_ID_ISSUE_DISTRICT_CODE"].ToString();
        //            obj.NomineeIdDocumentNo = drow["NOMINEE_ID_DOCUMENT_NO"].ToString();
        //            obj.NomineeIdDocumentType = drow["NOMINEE_ID_DOCUMENT_TYPE"].ToString();
        //            obj.Signature1 = drow["SIGNATURE1"].ToString();
        //            obj.Signature2 = drow["SIGNATURE2"].ToString();
        //            obj.NomineeImage = drow["NOMINEE_IMAGE"].ToString();
        //            obj.NomineeSignature1 = drow["NOMINEE_SIGNATURE1"].ToString();
        //            obj.NomineeSignature2 = drow["NOMINEE_SIGNATURE2"].ToString();
        //            obj.IdIssueDistrictCode = drow["ID_ISSUE_DISTRICT_CODE"].ToString();
        //            obj.IdDocumentNo = drow["ID_DOCUMENT_NO"].ToString();
        //            obj.IdDocumentType = drow["ID_DOCUMENT_TYPE"].ToString();
        //            // obj.TerminationDate = drow["TerminationDate"].ToString(); //not returned from procedure
        //            // obj.TerminationReason = drow["TerminationReason"].ToString(); //not returned from procedure
        //            obj.CasteCode = drow["CASTE_CODE"].ToString();
        //            obj.CasteName = drow["CASTE_NAME"].ToString();

        //            obj.SalaryAccountNo = drow["SALARY_ACCOUNT_NO"].ToString();
        //            obj.HlpreAccountHeadCode = drow["HLPRE_ACCOUNT_HEAD_CODE"].ToString();
        //            obj.HlpreAccountHeadDesc = drow["HLPRE_ACCOUNT_HEAD_DESC"].ToString();

        //            obj.SalaryAdvanceAccountHead = drow["SALARY_ADVANCE_ACCOUNT_HEAD"].ToString();
        //            obj.ClientNo = drow["CLIENT_NO"].ToString();
        //            obj.ProvidentFund = int.Parse(drow["PROVIDENT_FUND"].ToString());
        //            obj.HousingLoanAmt = int.Parse(drow["HOUSING_LOAN_AMT"].ToString());
        //            obj.GradeValue = int.Parse(drow["GRADE_VALUE"].ToString());
        //            // obj.OldGradeVal = int.Parse(drow["OldGradeVal"].ToString()); //not returned from procedure
        //            obj.DisableYN = drow["DisableYN"].ToString();

        //            lst.Add(obj);
        //        }
        //        oMsg.Result = lst;
        //        return oMsg;
        //    }
        //    catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
        //    finally { conn.Close(); }
        //}

        public object Search(Employee employee)
        {
            string sp = "hr_employee_pkg.p_employee_detail_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_OfficeCode", employee.OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_PostCode", employee.PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpId", employee.EmpId, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_EmpName", employee.EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_Gender", employee.Gender, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.Dob = drow["DOB"].ToString();
                    obj.DobNepali = drow["DOB_NEPALI"].ToString();
                    obj.Gender = drow["GENDER"].ToString();
                    obj.Married = drow["MARRIED"].ToString();
                    obj.CitizenshipNo = drow["CITIZENSHIP_NO"].ToString();
                    obj.EmployeeType = drow["EMPLOYEE_TYPE"].ToString();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.PostName = drow["POST_NAME"].ToString();
                    obj.JoinDate = drow["JOIN_DATE"].ToString();
                    obj.JoinDateNep = drow["JOIN_DATE_NEP"].ToString();
                    obj.OfficeCode = drow["OFFICE_CODE"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptName = drow["DEPART_NAME"].ToString();
                    obj.ActiveFlag = drow["ACTIVE_FLAG"].ToString();
                    obj.TemporaryAddress = drow["TEMPORARY_ADDRESS"].ToString();
                    obj.TemporaryDistrictCode = drow["TEMPORARY_DISTRICT_CODE"].ToString();
                    obj.TemporaryDistrictName = drow["DIST_TEMP"].ToString();
                    obj.TemporaryContactPhone = drow["TEMPORARY_CONTACT_PHONE"].ToString();
                    obj.PermanentAddress = drow["PERMANENT_ADDRESS"].ToString();
                    obj.PermanentDistrictCode = drow["PERMANENT_DISTRICT_CODE"].ToString();
                    obj.PermanentDistrictName = drow["DIST_PERMA"].ToString();
                    obj.PermanentContactPhone = drow["PERMANENT_CONTACT_PHONE"].ToString();
                    obj.EmailId = drow["EMAIL_ID"].ToString();

                    //obj.ReligionCode = drow["RELIGION_CODE"].ToString();
                    obj.CountryCode = drow["COUNTRY_CODE"].ToString();
                    obj.SpouseName = drow["SPOUSE_NAME"].ToString();
                    obj.SpouseOccupation = drow["SPOUSE_OCCUPATION"].ToString();
                    obj.Identification = drow["IDENTIFICATION"].ToString();
                    obj.FatherName = drow["FATHER_NAME"].ToString();
                    obj.MotherName = drow["MOTHER_NAME"].ToString();
                    obj.FatherOccupation = drow["FATHER_OCCUPATION"].ToString();
                    obj.MotherOccupation = drow["MOTHER_OCCUPATION"].ToString();
                    obj.GrandfatherName = drow["GRANDFATHER_NAME"].ToString();
                    obj.NoOfSon = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_SON"].ToString()));
                    obj.NoOfDaughter = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["NO_OF_DAUGHTER"].ToString()));
                    obj.NomineeName = drow["NOMINEE_NAME"].ToString();
                    obj.NomineeAddress = drow["NOMINEE_ADDRESS"].ToString();
                    obj.NomineeDistrict = drow["NOMINEE_DISTRICT"].ToString();
                    obj.NomineeDistrictName = drow["DIST_NOMINEE"].ToString();

                    obj.Relation = drow["Relation"].ToString();
                    obj.CurrentOfficeJoinDateNep = drow["CURRENT_OFFICE_JOIN_DATE_NEP"].ToString();
                    obj.LevelSno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LEVEL_SNO"].ToString()));
                    obj.Grade = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE"].ToString()));
                    obj.FatherInlawName = drow["FATHER_INLAW_NAME"].ToString();
                    obj.PfAccountNo = drow["PF_ACCOUNT_NO"].ToString();
                    obj.InvestmentFundId = drow["INVESTMENT_FUND_ID"].ToString();
                    obj.CurrentOfficeJoinDate = drow["CURRENT_OFFICE_JOIN_DATE"].ToString();
                    obj.CitizenInvestmentTrustIdNo = drow["CITIZEN_INVESTMENT_TRUST_ID_NO"].ToString();

                    obj.IdentityCardNo = drow["IDENTITY_CARD_NO"].ToString();
                    obj.DesignationCode = drow["DESIGNATION_CODE"].ToString();
                    obj.DesignationName = drow["DESIGNATION_DESC"].ToString();
                    obj.ProvisionDate = drow["PROVISION_DATE"].ToString();
                    obj.ProvisionDateBs = drow["PROVISION_DATE_BS"].ToString();
                    obj.PermanentDate = drow["PERMANENT_DATE"].ToString();
                    obj.PermanentDateBs = drow["PERMANENT_DATE_BS"].ToString();
                    obj.QuarterYN = drow["QUARTER_Y_N"].ToString();
                    obj.PfDate = drow["PF_DATE"].ToString();
                    obj.InchargeYN = drow["INCHARGE_Y_N"].ToString();


                    obj.ImagePath = drow["IMAGE_PATH"].ToString();
                    obj.EmployeeCode = drow["EMPLOYEE_CODE"].ToString();
                    //obj.ThirdPartyData = drow["ThirdPartyData"].ToString(); //not returned from procedure
                    //obj.Fname = drow["Fname"].ToString();
                    // obj.Lname = drow["Lname"].ToString();
                    obj.NomineeIdIssueDistrictCode = drow["NOMINEE_ID_ISSUE_DISTRICT_CODE"].ToString();
                    obj.NomineeIdDocumentNo = drow["NOMINEE_ID_DOCUMENT_NO"].ToString();
                    obj.NomineeIdDocumentType = drow["NOMINEE_ID_DOCUMENT_TYPE"].ToString();
                    obj.Signature1 = drow["SIGNATURE1"].ToString();
                    obj.Signature2 = drow["SIGNATURE2"].ToString();
                    obj.NomineeImage = drow["NOMINEE_IMAGE"].ToString();
                    obj.NomineeSignature1 = drow["NOMINEE_SIGNATURE1"].ToString();
                    obj.NomineeSignature2 = drow["NOMINEE_SIGNATURE2"].ToString();
                    obj.IdIssueDistrictCode = drow["ID_ISSUE_DISTRICT_CODE"].ToString();
                    // obj.IdDocumentNo = drow["ID_DOCUMENT_NO"].ToString();
                    obj.IdDocumentType = drow["ID_DOCUMENT_TYPE"].ToString();
                    // obj.TerminationDate = drow["TerminationDate"].ToString(); //not returned from procedure
                    // obj.TerminationReason = drow["TerminationReason"].ToString(); //not returned from procedure
                    obj.CasteCode = drow["CASTE_CODE"].ToString();
                    obj.CasteName = drow["CASTE_NAME"].ToString();

                    obj.SalaryAccountNo = drow["SALARY_ACCOUNT_NO"].ToString();
                    obj.HlpreAccountHeadCode = drow["HLPRE_ACCOUNT_HEAD_CODE"].ToString();
                    obj.HlpreAccountHeadDesc = drow["HLPRE_ACCOUNT_HEAD_DESC"].ToString();

                    obj.SalaryAdvanceAccountHead = drow["SALARY_ADVANCE_ACCOUNT_HEAD"].ToString();
                    obj.ClientNo = drow["CLIENT_NO"].ToString();
                    obj.ProvidentFund = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["PROVIDENT_FUND"].ToString()));
                    obj.HousingLoanAmt = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["HOUSING_LOAN_AMT"].ToString()));
                    obj.GradeValue = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_VALUE"].ToString()));
                    // obj.OldGradeVal = int.Parse(drow["OldGradeVal"].ToString()); //not returned from procedure
                    //obj.DisableYN = drow["DisableYN"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }
        public object GetEmployeeShort(string officeCode, string employeeName)
        {
            string sp = "MEMBER_TRANSFER_PKG.p_from_employee_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", officeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_emp_name", employeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.OfficeCode = drow[""].ToString();
                    
                    obj.Action = "U";



                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }

        public object GetToEmployeeShort(string employeeName)
        {
            string sp = "MEMBER_TRANSFER_PKG.p_to_employee_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_emp_name", employeeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.OfficeCode = drow[""].ToString();

                    obj.Action = "U";



                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }

        public object GetFieldAssistants(string officeCode, string empName)
        {
            string sp = "fn_center_pkg.p_field_assistant_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_office_code", officeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_emp_name", empName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":v_out_record", null, OracleDbType.RefCursor, ParameterDirection.Output));
                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.Action = "U";



                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex)
            {
                oMsg.OutResultMessage = ex.Message.ToString();
                return oMsg;
            }
            finally { conn.Close(); }
        }

        public object GetEmployee(string OfficeName, string UserCode, string EmpName)
        {
            string sp = "security_pkg.p_employee_lov_list";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_NAME", OfficeName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_USER_CODE", UserCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_EMP_NAME", EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.OfficeCode = drow["OFFICE_CODE"].ToString();
                    obj.OfficeName = drow["OFFICE_NAME"].ToString();

                    lst.Add(obj);
                }
                oMsg.Result = lst;
                return oMsg;
            }
            catch (Exception ex) { oMsg.OutResultMessage = ex.Message.ToString(); return oMsg; }
            finally { conn.Close(); }
        }

        public object GetEmployeeLov(string OfficeCode, string PostCode, string EmpName)
        {
            string sp = "hr_employee_utility_pkg.p_employee_lov";
            OracleConnection conn = new OracleConnection();
            OutMessage oMsg = new OutMessage();
            try
            {
                conn = new GetConnection().GetDbConn();
                List<OracleParameter> paramList = new List<OracleParameter>();
                paramList.Add(SqlHelper.GetOraParam(":p_P_OFFICE_CODE", OfficeCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_POST_CODE", PostCode, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_P_EMP_NAME", EmpName, OracleDbType.Varchar2, ParameterDirection.Input));
                paramList.Add(SqlHelper.GetOraParam(":p_V_OUT_RECORD", null, OracleDbType.RefCursor, ParameterDirection.Output));

                paramList[paramList.Count - 1].Size = 100;

                DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, sp, paramList.ToArray());
                List<Employee> lst = new List<Employee>();
                foreach (DataRow drow in ((DataTable)ds.Tables[0]).Rows)
                {
                    Employee obj = new Employee();
                    obj.EmpId = drow["EMP_ID"].ToString();
                    obj.EmpName = drow["EMP_NAME"].ToString();
                    obj.PostCode = drow["POST_CODE"].ToString();
                    obj.PostDesc = drow["POST_DESC"].ToString();
                    obj.OfficeCode = drow["OFFICE_CODE"].ToString();
                    obj.OfficeDesc = drow["OFFICE_DESC"].ToString();
                    obj.DeptCode = drow["DEPT_CODE"].ToString();
                    obj.DeptName = drow["DEPT_NAME"].ToString();
                    obj.DesignationCode = drow["DESIGNATION_CODE"].ToString();
                    obj.DesignationName = drow["DESIGNATION_NAME"].ToString();
                    obj.LevelSno = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["LEVEL_SNO"].ToString()));
                    obj.Grade = int.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE"].ToString()));
                    obj.GradeValue = double.Parse(OracleUtilityDao.ConvertNullToNumber(drow["GRADE_VALUE"].ToString()));
                    
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
