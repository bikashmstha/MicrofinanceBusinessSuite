using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class HolidayList : BusinessObject
    {
        public string FiscalYear { get; set; }
        public string StartDateNep { get; set; }
        public string EndDateNep { get; set; }

       
    }
}
