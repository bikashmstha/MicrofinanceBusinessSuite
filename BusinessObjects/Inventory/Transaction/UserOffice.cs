using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Inventory.Transaction
{
    public class UserOffice : BusinessObject
    {
        public UserOffice() { }

        public string InstituteCode { get; set; }
        public string InstituteName { get; set; }
        public double RowCount { get; set; }
    }
}
