using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class AssetMaintenanceDetail : BusinessObject
    {
        public AssetMaintenanceDetail() { }

        public int MaintId { get; set; }
        public string MaintDate { get; set; }
        public string MaintDateBs { get; set; }
        public double MaintCost { get; set; }
        public string MaintAddedFlag { get; set; }
        public string Description { get; set; }
        public string AssetCode { get; set; }
    }
}
