using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class CallAbbsAdjustment : BusinessObject
    {
        public CallAbbsAdjustment() { }

        public string Date1 { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
