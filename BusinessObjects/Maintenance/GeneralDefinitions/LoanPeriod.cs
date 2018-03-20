using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class LoanPeriod:BusinessObject
    {
        
        public string LoanPeriods { get; set; }
        public string LoanPeriodDesc { get; set; }
        public string LoanPeriodType { get; set; }
        public string LoanPeriodTypeDet { get; set; }
        public string Active { get; set; }
    }
}
