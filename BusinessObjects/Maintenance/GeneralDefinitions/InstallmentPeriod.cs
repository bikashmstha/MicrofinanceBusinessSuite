using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class InstallmentPeriod:BusinessObject
    {
        public string InstallmentPeriods { get; set; }
        public string InstallmentPeriodDesc { get; set; }
        public string InstallmentPeriodType { get; set; }
        public string InstallmentPeriodTypeDesc { get; set; }
        public string InstallmentType { get; set; }
        public string InstallmentTypeDesc { get; set; }
        public Int16 MaxGraceDays { get; set; }
        public string Active { get; set; }



    }
}
