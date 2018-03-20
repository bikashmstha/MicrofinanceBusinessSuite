using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class LiveProtectDeposit : BusinessObject
    {
        public LiveProtectDeposit() { }

        public string ProDepositNo { get; set; }
        public string LoanProtectionCode { get; set; }
        public string ClientName { get; set; }
        public double DepositAmount { get; set; }
        public double CurrentBalance { get; set; }
        public string AccountDesc { get; set; }
    }
}
