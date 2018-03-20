using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class WithdrawlPostingPublic : BusinessObject
    {
        public WithdrawlPostingPublic() { }

        public string OfficeCode { get; set; }
        public double WithdrawalNo { get; set; }
        public string Username { get; set; }
        public string TranDate { get; set; }
        public string OutSuccess { get; set; }
    }
}
