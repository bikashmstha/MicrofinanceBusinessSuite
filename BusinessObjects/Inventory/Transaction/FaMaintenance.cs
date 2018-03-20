using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class FaMaintenance : BusinessObject
    {
        public FaMaintenance() { }

        public string AssetCode { get; set; }
        public string MaintDate { get; set; }
        public string Description { get; set; }
        public double MaintCost { get; set; }
        public string FiscalYear { get; set; }
        public string MaintAddedFlag { get; set; }
        public string MaintDateBs { get; set; }
        public string Username { get; set; }
        public string Date1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutMaintId { get; set; }
    }
}
