using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class Report:BusinessObject
    {
        public string ReportId { get; set; }
        public string ReportDesc { get; set; }
    }
}
