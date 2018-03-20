using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class DayBeginProcess : BusinessObject
    {
        public DayBeginProcess() { }

        public string TranOfficeCode { get; set; }
        public string Date { get; set; }
        public string EDate { get; set; }
        public string OutDayBeginDate { get; set; }
    }
}
