using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class MemberProtectionDeposit : BusinessObject
    {
        public MemberProtectionDeposit() { }

        public string MemProtectionCode { get; set; }
        public string ClientName { get; set; }
        public string DepositDate { get; set; }
        public double DepositAmount { get; set; }
        public double CurrentBalance { get; set; }
        public string ProDepositNo { get; set; }
        public string AccountDesc { get; set; }
    }
}
