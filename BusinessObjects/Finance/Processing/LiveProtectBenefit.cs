using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class LiveProtectBenefit : BusinessObject
    {
        public LiveProtectBenefit() { }

        public string BenefitDate { get; set; }
        public string BenefitNo { get; set; }
        public double BenefitedAmount { get; set; }
        public string LoanProtectionCode { get; set; }
        public string ClientName { get; set; }
        public string AccountDesc { get; set; }
        public string BenefitInfo { get; set; }
    }
}
