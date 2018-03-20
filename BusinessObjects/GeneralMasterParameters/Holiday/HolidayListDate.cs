using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class HolidayListDate : BusinessObject
    {
        public string EnglishDate {get;set;}
        public string NepaliDate {get;set;}
        public string Holiday {get;set;}
        public string HolidayDesc {get;set;}
        public string LoanHoliday {get;set;}
        public string LoanHolidayDesc {get;set;}

        private List<HolidayListDate> _HolidayDetail = new List<HolidayListDate>();

        public List<HolidayListDate> HolidayDetails
        {
            get { return _HolidayDetail; }
            set { _HolidayDetail = value; }
        }
    }
}
