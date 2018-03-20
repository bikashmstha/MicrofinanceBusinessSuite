using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeeTransfer : BusinessObject
    {
        public EmployeeTransfer() { }

        public string EmpId { get; set; }
        public string TransferDate { get; set; }
        public string TransferDateNep { get; set; }
        public string FromOfficeCode { get; set; }
        public string FromDeptCode { get; set; }
        public string ToOfficeCode { get; set; }
        public string ToDeptCode { get; set; }
        public string Remarks { get; set; }
        public string JoinDate { get; set; }
        public string JoinDateBs { get; set; }
        public string FromDesignationCode { get; set; }
        public string ToDesignationCode { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public string InsertUpdate { get; set; }
        public string TranOfficeCode { get; set; }
        public double OutSno { get; set; }
    }
}
