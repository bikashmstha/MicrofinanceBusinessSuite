using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class OpeningStockMasterDetail : BusinessObject
    {
        public OpeningStockMasterDetail() { }

        public string ReferenceNo { get; set; }
        public string FiscalYear { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierDesc { get; set; }
        public string LocationCode { get; set; }
        public string LocationDesc { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionDateNep { get; set; }
        public string Remarks { get; set; }
        public string TranOfficeCode { get; set; }
        public string InstituteName { get; set; }
    }
}
