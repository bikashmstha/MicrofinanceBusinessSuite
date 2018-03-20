using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class MemberProtectionDepositPosting : BusinessObject
    {
        public MemberProtectionDepositPosting() { }

        public string OfficeCode { get; set; }
        public string TransactionDate { get; set; }
        public double ProDepositNo { get; set; }
        public string User1 { get; set; }
    }
}
