using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class PublicClientDetail : BusinessObject
    {
        public PublicClientDetail() { }

        public string ClientNo { get; set; }
        public string ClientCode { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string MemberType { get; set; }
        public string MemberName { get; set; }
        public string MembershipDate { get; set; }
        public string MemDate { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public int BirthYear { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public string IdDocumentType { get; set; }
        public string IdDocumentNo { get; set; }
        public string EmployeeId { get; set; }
        public string MembershipCloseDate { get; set; }
        public string PostalAddress { get; set; }
        public string Gender { get; set; }
        public string OccupationCode { get; set; }
        public string OccupDesc { get; set; }
        public string ImagePath { get; set; }
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
        public string Active { get; set; }
        public string FingerPrintLeft { get; set; }
        public string FingerPrintRight { get; set; }
        public string CasteCode { get; set; }
        public string CasteDesc { get; set; }
        public string RefClientNo { get; set; }
        public string EmpName { get; set; }
    }
}
