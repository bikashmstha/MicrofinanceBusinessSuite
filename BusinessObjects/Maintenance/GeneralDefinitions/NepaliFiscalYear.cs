using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class NepaliFiscalYear:BusinessObject
    {
        
        public string FiscalYear { get; set; }
        public string StartDate { get; set; }
        public string StartDateBS { get; set; }
        public string EndDate { get; set; }
        public string EndDateBS { get; set; }
        public long LastVoucherName { get; set; }
        
    }
}
