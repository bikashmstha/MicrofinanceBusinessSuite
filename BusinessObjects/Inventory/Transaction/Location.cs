using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class Location : BusinessObject
    {
        public Location() { }

        public string LocationCode { get; set; }
        public string LocationDesc { get; set; }
    }
}
