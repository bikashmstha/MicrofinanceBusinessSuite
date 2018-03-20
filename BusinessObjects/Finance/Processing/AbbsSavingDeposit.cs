using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class AbbsSavingDeposit : BusinessObject
    {
        public AbbsSavingDeposit() { }

        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double PenaltyAmount { get; set; }
        public double DepositNo { get; set; }
        public string SavingAccountNo { get; set; }
        public double DepositAmount { get; set; }
        public string AccountDesc { get; set; }
        public string MandatorySavingType { get; set; }
        public string SavTypeDesc { get; set; }
        public string FlagForPosting { get; set; }
    }
}
