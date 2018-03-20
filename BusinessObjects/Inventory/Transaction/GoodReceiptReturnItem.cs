using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class GoodReceiptReturnItem : BusinessObject
    {
        public GoodReceiptReturnItem() { }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double TransactionQuantity { get; set; }
        public double TransactionCost { get; set; }
        public string CostingType { get; set; }
    }
}
