using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycEmployee : BusinessObject
    {
        public EmployeeKycEmployee() { }

        public string EmpId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string EmpName { get; set; }
        public string Married { get; set; }
        public string PermanentAddress { get; set; }
        public string SpouseName { get; set; }
        public string FatherName { get; set; }
        public string TemporaryAddress { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public double RowCount { get; set; }
    }
}
