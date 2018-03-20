using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class AssetItem : BusinessObject
    {
        public AssetItem() { }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double StockQuantity { get; set; }
        public string CostingType { get; set; }
        public string CategoryCode { get; set; }
    }
}
