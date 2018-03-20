using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class DamageLostDetailDetail : BusinessObject
    {
        public DamageLostDetailDetail() { }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double TransactionQuantity { get; set; }
        public double TransactionCost { get; set; }
        public double RemainingQty { get; set; }
        public string UnitCode { get; set; }
        public string ExpiryDate { get; set; }
        public string OrderNo { get; set; }
        public string RemarksDtl { get; set; }
        public string InsertUpdateDtl { get; set; }
    }
}
