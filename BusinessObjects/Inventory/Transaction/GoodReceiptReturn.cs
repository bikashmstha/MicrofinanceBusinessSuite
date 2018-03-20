using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class GoodReceiptReturn : BusinessObject
    {
        public GoodReceiptReturn() { }

        public string ReferenceNo { get; set; }
        public string TransactionDate { get; set; }
        public string Remarks { get; set; }
        public string LocationCode { get; set; }
        public int SupplierCode { get; set; }
        public string TransactionDateBs { get; set; }
        public string SupplierDesc { get; set; }
        public string LocationDesc { get; set; }
    }
}
