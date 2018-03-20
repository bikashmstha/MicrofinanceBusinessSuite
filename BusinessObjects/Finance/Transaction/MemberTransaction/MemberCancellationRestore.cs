using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction
{
    public class MemberCancellationRestore : BusinessObject
    {
        public MemberCancellationRestore() { }

        public string GroupCode { get; set; }
        public string ClientNo { get; set; }
        public string MembershipClosedDate { get; set; }
        public string TransType { get; set; }
        public string Active { get; set; }
        public string ReasonsForInactive { get; set; }
        public string TranOfficeCode { get; set; }

        public object ReasonForInactive { get; set; }
    }
}
