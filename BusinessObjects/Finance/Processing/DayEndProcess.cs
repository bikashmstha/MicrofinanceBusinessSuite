using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class DayEndProcess : BusinessObject
    {
        public DayEndProcess() { }

        public string Date1 { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
