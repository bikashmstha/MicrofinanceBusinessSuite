using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class GoodReceiptSearch : BusinessObject
    {
        public GoodReceiptSearch() { }

        public string ReferenceNo { get; set; }
        public string TransactionDate { get; set; }
        public string Remarks { get; set; }
        public int SupplierCode { get; set; }
        public string TransactionDateBs { get; set; }
        public string SupplierDesc { get; set; }
    }
}
