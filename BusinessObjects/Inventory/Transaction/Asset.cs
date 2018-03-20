using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class Asset : BusinessObject
    {
        public Asset() { }

        public string AssetCode { get; set; }
        public string AssetDesc { get; set; }
    }
}
