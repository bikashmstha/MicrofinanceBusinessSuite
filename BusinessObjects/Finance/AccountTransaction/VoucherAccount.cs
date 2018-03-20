using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class VoucherAccount : BusinessObject
    {
        public VoucherAccount() { }

        public string AccountDesc { get; set; }
        public string AccountCode { get; set; }
        public double AccountNo { get; set; }
        public string CurrencyCode { get; set; }
        public string GroupName { get; set; }
        public double RowCount { get; set; }
    }
}
