using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class Depreciation : BusinessObject
    {
        public Depreciation() { }

        public string User1 { get; set; }
        public string DeprToDate { get; set; }
        public string AssetCode { get; set; }
    }
}
