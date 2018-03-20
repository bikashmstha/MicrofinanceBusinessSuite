using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Supervisor
{
    public class Employee : BusinessObject
    {
        public Employee() { }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Dob { get; set; }
        public string DobNepali { get; set; }
        public string Gender { get; set; }
        public string Married { get; set; }
        public string CitizenshipNo { get; set; }
        public string EmployeeType { get; set; }
        public string PostCode { get; set; }
        public string JoinDate { get; set; }
        public string JoinDateNep { get; set; }
        public string OfficeCode { get; set; }
        public string DeptCode { get; set; }
        public string ActiveFlag { get; set; }
        public string TemporaryAddress { get; set; }
        public string TemporaryDistrictCode { get; set; }
        public string TemporaryContactPhone { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentDistrictCode { get; set; }
        public string PermanentContactPhone { get; set; }
        public string EmailId { get; set; }
        public string ReligionCode { get; set; }
        public string CountryCode { get; set; }
        public string SpouseName { get; set; }
        public string SpouseOccupation { get; set; }
        public string Identification { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string GrandfatherName { get; set; }
        public int NoOfSon { get; set; }
        public int NoOfDaughter { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAddress { get; set; }
        public string NomineeDistrict { get; set; }
        public string Relation { get; set; }
        public string CurrentOfficeJoinDateNep { get; set; }
        public int LevelSno { get; set; }
        public int Grade { get; set; }
        public string FatherInlawName { get; set; }
        public string PfAccountNo { get; set; }
        public string InvestmentFundId { get; set; }
        public string CurrentOfficeJoinDate { get; set; }
        public string CitizenInvestmentTrustIdNo { get; set; }
        public string IdentityCardNo { get; set; }
        public string DesignationCode { get; set; }
        public string ProvisionDate { get; set; }
        public string ProvisionDateBs { get; set; }
        public string PermanentDate { get; set; }
        public string PermanentDateBs { get; set; }
        public string QuarterYN { get; set; }
        public string PfDate { get; set; }
        public string InchargeYN { get; set; }
        public string ImagePath { get; set; }
        public string EmployeeCode { get; set; }
        public string ThirdPartyData { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string NomineeIdIssueDistrictCode { get; set; }
        public string NomineeIdDocumentNo { get; set; }
        public string NomineeIdDocumentType { get; set; }
        public string Signature1 { get; set; }
        public string Signature2 { get; set; }
        public string NomineeImage { get; set; }
        public string NomineeSignature1 { get; set; }
        public string NomineeSignature2 { get; set; }
        public string IdIssueDistrictCode { get; set; }
        public string IdDocumentNo { get; set; }
        public string IdDocumentType { get; set; }
        public string TerminationDate { get; set; }
        public string TerminationReason { get; set; }
        public string CasteCode { get; set; }
        public string SalaryAccountNo { get; set; }
        public string HlpreAccountHeadCode { get; set; }

        public string SalaryAdvanceAccountHead { get; set; }
        public string ClientNo { get; set; }
        public int ProvidentFund { get; set; }
        public int HousingLoanAmt { get; set; }
        public double GradeValue { get; set; }
        public int OldGradeVal { get; set; }
        public string DisableYN { get; set; }
        public string PostName { get; set; }
        public string DeptName { get; set; }
        public string TemporaryDistrictName { get; set; }
        public string PermanentDistrictName { get; set; }
        public string NomineeDistrictName { get; set; }
        public string DesignationName { get; set; }
        public string CasteName { get; set; }
        public string HlpreAccountHeadDesc { get; set; }

        public string ImagePathName { get; set; }
        public string Signature1Name { get; set; }
        public string Signature2Name { get; set; }
        public string NomineeImageName { get; set; }
        public string NomineeSignature1Name { get; set; }
        public string NomineeSignature2Name { get; set; }
        public string OfficeName { get; set; }
        public string PostDesc { get; set; }
        public string OfficeDesc { get; set; }
        //public string EmpId { get; set; }
        //public string EmpName { get; set; }
        //public string Dob { get; set; }
        //public string DobNepali { get; set; }
        //public string Gender { get; set; }
        //public string Married { get; set; }
        //public string CitizenshipNo { get; set; }
        //public string EmployeeType { get; set; }
        //public string PostCode { get; set; }
        //public string JoinDate { get; set; }
        //public string JoinDateNep { get; set; }
        //public string OfficeCode { get; set; }
        //public string DeptCode { get; set; }
        //public string ActiveFlag { get; set; }
        //public string TemporaryAddress { get; set; }
        //public string TemporaryDistrictCode { get; set; }
        //public string TemporaryContactPhone { get; set; }
        //public string PermanentAddress { get; set; }
        //public string PermanentDistrictCode { get; set; }
        //public string PermanentContactPhone { get; set; }
        //public string EmailId { get; set; }
        //public string ReligionCode { get; set; }
        //public string CountryCode { get; set; }
        //public string SpouseName { get; set; }
        //public string SpouseOccupation { get; set; }
        //public string Identification { get; set; }
        //public string FatherName { get; set; }
        //public string MotherName { get; set; }
        //public string FatherOccupation { get; set; }
        //public string MotherOccupation { get; set; }
        //public string GrandfatherName { get; set; }
        //public int NoOfSon { get; set; }
        //public int NoOfDaughter { get; set; }
        //public string NomineeName { get; set; }
        //public string NomineeAddress { get; set; }
        //public string NomineeDistrict { get; set; }
        //public string Relation { get; set; }
        //public string CurrentOfficeJoinDateNep { get; set; }
        //public int LevelSno { get; set; }
        //public int Grade { get; set; }
        //public string FatherInlawName { get; set; }
        //public string PfAccountNo { get; set; }
        //public string InvestmentFundId { get; set; }
        //public string CurrentOfficeJoinDate { get; set; }
        //public string CitizenInvestmentTrustIdNo { get; set; }
        //public string IdentityCardNo { get; set; }
        //public string DesignationCode { get; set; }
        //public string ProvisionDate { get; set; }
        //public string ProvisionDateBs { get; set; }
        //public string PermanentDate { get; set; }
        //public string PermanentDateBs { get; set; }
        //public string QuarterYN { get; set; }
        //public string PfDate { get; set; }
        //public string InchargeYN { get; set; }
        //public string ImagePath { get; set; }
        //public string EmployeeCode { get; set; }
        //public string ThirdPartyData { get; set; }
        //public string Fname { get; set; }
        //public string Lname { get; set; }
        //public string NomineeIdIssueDistrictCode { get; set; }
        //public string NomineeIdDocumentNo { get; set; }
        //public string NomineeIdDocumentType { get; set; }
        //public string Signature1 { get; set; }
        //public string Signature2 { get; set; }
        //public string NomineeImage { get; set; }
        //public string NomineeSignature1 { get; set; }
        //public string NomineeSignature2 { get; set; }
        //public string IdIssueDistrictCode { get; set; }
        //public string IdDocumentNo { get; set; }
        //public string IdDocumentType { get; set; }
        //public string TerminationDate { get; set; }
        //public string TerminationReason { get; set; }
        //public string CasteCode { get; set; }
        //public string SalaryAccountNo { get; set; }
        //public string HlpreAccountHeadCode { get; set; }
        //public string SalaryAdvanceAccountHead { get; set; }
        //public string ClientNo { get; set; }
        //public int ProvidentFund { get; set; }
        //public int HousingLoanAmt { get; set; }
        //public double GradeValue { get; set; }
        //public int OldGradeVal { get; set; }
        //public string DisableYN { get; set; }

        //public string PostName { get; set; }

        //public string DeptName { get; set; }

        //public string TemporaryDistrictName { get; set; }

        //public string PermanentDistrictName { get; set; }

        //public string NomineeDistrictName { get; set; }

        //public string DesignationName { get; set; }

        //public string CasteName { get; set; }

        //public string HlpreAccountHeadDesc { get; set; }

        //public string OfficeName { get; set; }

        //public string PostDesc { get; set; }

        //public string OfficeDesc { get; set; }
    }
}
