using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class CompulsoryAccountsEntry : BusinessObject
    {
        public CompulsoryAccountsEntry() { }

        public string CompulsoryAccountCode { get; set; }
        public string CompulsoryAccountDesc { get; set; }
        public string ProductCode { get; set; }
        public string ProductType { get; set; }
        public string ActiveFlag { get; set; }

        public string ProductName { get; set; }
    }
}
