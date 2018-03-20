using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeeAllowanceDetail : BusinessObject
    {
        public EmployeeAllowanceDetail() { }

        public string EmpId { get; set; }
        public string FiscalYear { get; set; }
        public double Sno { get; set; }
        public double YearCode { get; set; }
        public double Amount { get; set; }
        public string ApprovedDate { get; set; }
        public string Approved { get; set; }
        public string AllowanceDateBs { get; set; }
        public string ApprovedDateBs { get; set; }
        public string AllowanceDate { get; set; }
    }
}
