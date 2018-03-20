using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class Holiday:BusinessObject
    {
        //public HolidayList();

        public string FiscalYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        private List<HolidayDetails> _HolidayDetail = new List<HolidayDetails>();

        public List<HolidayDetails> HolidayDetails
        {
            get { return _HolidayDetail; }
            set { _HolidayDetail = value; }
        }
    }
}
