using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class Member : BusinessObject
    {
        public Member() { }

        public string FiscalYear { get; set; }
        public string ClientNo { get; set; }
        public string ClientCode { get; set; }
        public string GroupCode { get; set; }
        public string MembershipDate { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public int? BirthYear { get; set; }
        public int? NoBoyChild { get; set; }
        public int? NoGirlChild { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNo { get; set; }
        public int? LoanYear { get; set; }
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
        public int? ChildrenNo { get; set; }
        public string FieldAssistantId { get; set; }
        public string ReasonForInactive { get; set; }
        public string Signature3 { get; set; }
        public string Signature2 { get; set; }
        public string Signature1 { get; set; }
        public string ImagePath { get; set; }
        public string TranOfficeCode { get; set; }
        public string LastChangeDate { get; set; }
        public string TransferDate { get; set; }
        public double? FixedCollectionAmount { get; set; }
        public string CenterCode { get; set; }
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
        public string IdIssueDistrictCode { get; set; }
        public string FatherInlawName { get; set; }
        public string HusbandName { get; set; }
        public string IdentityOwnBy { get; set; }
        public string ReasonCode { get; set; }
        public string RefClientNo { get; set; }
        public string MemIdentityIssueDate { get; set; }
        public string HusIdentityType { get; set; }
        public string HusIdentityNo { get; set; }
        public string HusIdentityIssueDistrict { get; set; }
        public string HusIdentityIssueDate { get; set; }
        public string Address1Type { get; set; }
        public string Address1Line2 { get; set; }
        public string Address1Line3 { get; set; }
        public string Address1District { get; set; }
        public string Address2Type { get; set; }
        public string Address2Line1 { get; set; }
        public string Address2Line2 { get; set; }
        public string Address2Line3 { get; set; }
        public string Address2District { get; set; }
        public string ReligionCode { get; set; }

        public string MemberCode { get; set; }
        public string GroupDesc { get; set; }
        public string MembershipDateFrom { get; set; }
        public string MembershipDateTo { get; set; }
        public string CenterName { get; set; }
        public string MemberName { get; set; }
        //{
        //    get
        //    { return this.Fname + " " + this.Lname; }
        //}

        public string CasteDesc { get; set; }
    }
}
