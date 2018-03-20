using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycInfo : BusinessObject
    {
        public EmployeeKycInfo() { }

        public string MembershipDate { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public double? BirthYear { get; set; }
        public double? NoBoyChild { get; set; }
        public double? NoGirlChild { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNo { get; set; }
        public string MemberType { get; set; }
        public string EmployeeId { get; set; }
        public string CasteCode { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string MembershipCloseDate { get; set; }
        public string PostalAddress { get; set; }
        public string Gender { get; set; }
        public string OccupationCode { get; set; }
        public string EducationCode { get; set; }
        public string Active { get; set; }
        public double? ChildrenNo { get; set; }
        public string ReasonForInactive { get; set; }
        public string ImagePath { get; set; }
        public string TranOfficeCode { get; set; }
        public double? FixedCollectionAmount { get; set; }
        public string ThirdPartyData { get; set; }
        public string Dob { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string JointImagePath { get; set; }
        public string GrandFatherName { get; set; }
        public string MinorYN { get; set; }
        public string MinorName { get; set; }
        public string MinorRelation { get; set; }
        public string EmailAddress { get; set; }
        public string FingerPrintLeft { get; set; }
        public string FingerPrintRight { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public string OutClientNo { get; set; }
        public string OutClientCode { get; set; }
    }
}
