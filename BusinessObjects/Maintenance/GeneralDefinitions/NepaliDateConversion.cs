using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class NepaliDateConversion:BusinessObject
    {
        
        public string FiscalYear { get; set; }
        public int NepaliYear { get; set; }
        public int MonthCode { get; set; }
        public int NoOfDays { get; set; }
        public string NepaliStartDate { get; set; }
        public string NepaliEndDate { get; set; }
        public string EnglishStartDate { get; set; }
        public string EnglishEndDate { get; set; }
        public int NepaliPeriod { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        
    }
}
