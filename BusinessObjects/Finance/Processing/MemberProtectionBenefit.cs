using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class MemberProtectionBenefit : BusinessObject
    {
        public MemberProtectionBenefit() { }

        public string BenefitDate { get; set; }
        public string BenefitNo { get; set; }
        public double BenefitedAmount { get; set; }
        public string MemProtectionCode { get; set; }
        public string ClientName { get; set; }
        public string AccountDesc { get; set; }
        public string BenefitInfo { get; set; }
    }
}
