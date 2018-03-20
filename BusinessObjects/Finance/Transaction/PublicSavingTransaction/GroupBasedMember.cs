using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.PublicSavingTransaction
{
    public class GroupBasedMember : BusinessObject
    {
        public GroupBasedMember() { }

        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string ClientNo { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string PostalAddress { get; set; }
        public string Gender { get; set; }
        public string GrandFatherName { get; set; }
        public string EmployeeId { get; set; }
        public string EmpName { get; set; }
        public double RowCount { get; set; }
    }
}
