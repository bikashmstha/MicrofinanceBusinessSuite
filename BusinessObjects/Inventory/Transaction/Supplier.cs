using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class Supplier : BusinessObject
    {
        public Supplier() { }

        public int SupplierCode { get; set; }
        public string SupplierDesc { get; set; }
    }
}
