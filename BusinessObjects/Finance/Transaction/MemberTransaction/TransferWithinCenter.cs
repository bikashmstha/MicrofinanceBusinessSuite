using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction
{
    public class TransferWithinCenter : BusinessObject
    {
        public TransferWithinCenter() { }

        public string ClientNo { get; set; }
        public string OldGroupCode { get; set; }
        public string NewGroupCode { get; set; }
        public string UserName { get; set; }
        public string TranOfficeCode { get; set; }
        public string ClientCode { get; set; }
    }
}
