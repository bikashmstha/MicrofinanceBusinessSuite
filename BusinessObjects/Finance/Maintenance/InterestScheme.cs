using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class InterestScheme : BusinessObject
    {
        public InterestScheme() { }

        public string IntSchemeCode { get; set; }
        public string IntSchemeDesc { get; set; }
        public double RowCount { get; set; }
    }
}
