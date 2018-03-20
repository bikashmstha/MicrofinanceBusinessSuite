using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfAdditionalLoan : BusinessObject
    {
        public MfAdditionalLoan() { }

        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientDesc { get; set; }
        public string GroupName { get; set; }
        public string CenterName { get; set; }
        public string ClientNo { get; set; }
        public string LoanDate { get; set; }
        public string LoanDate_Bs { get; set; }
        public string LoanMaturity_Date { get; set; }
        public string LoanMaturity_Date_Bs { get; set; }
        public double LoanPeriod { get; set; }
        public string LoanPeriod_Type { get; set; }
        public double GraceDays { get; set; }
        public double InterestRate { get; set; }
        public int InstallmentPeriod { get; set; }
        public string InstallmentPeriod_Type { get; set; }
        public string EmployeeId { get; set; }
        public string LoanProduct_Code { get; set; }
        public string CenterCode { get; set; }
    }
}
