using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class LoanInstallmentPeriodMap:BusinessObject
    {
        

        public string InstallmentPeriod { get; set; }
        public string InstallmentPeriodType { get; set; }
        public string InstallmentPeriodTypeDet { get; set; }
        public string LoanPeriod { get; set; }
        public string LoanPeriodType { get; set; }
        public string LoanPeriodTypeDet { get; set; }
        public Int16 NoOfInstallment { get; set; }
        public string Active { get; set; }
    }
}
