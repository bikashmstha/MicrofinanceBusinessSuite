using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycDetail : BusinessObject
    {
        public EmployeeKycDetail() { }

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
        public string OccupationCode { get; set; }
        public string OccupDesc { get; set; }
        public int NoBoyChild { get; set; }
        public int NoGirlChild { get; set; }
        public string Dob { get; set; }
        public double ChildrenNo { get; set; }
        public string CasteCode { get; set; }
        public string EducationCode { get; set; }
        public string CasteDesc { get; set; }
        public string Active { get; set; }
    }
}
