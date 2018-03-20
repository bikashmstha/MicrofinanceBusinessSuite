using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class OfficeWiseHoliday:BusinessObject
    {
        /*OFFICE_CODE        VARCHAR2(12 BYTE),
  ENGLISH_DATE       DATE,
  NEPALI_DATE        VARCHAR2(10 BYTE),
  HOLIDAY            CHAR(1 BYTE)               DEFAULT 'N',
  HOLIDAY_DESC       VARCHAR2(50 BYTE),
  LOAN_HOLIDAY       CHAR(1 BYTE),
  LOAN_HOLIDAY_DESC  VARCHAR2(50 BYTE)*/
        public string OfficeCode { get; set; }
        public string EnglishDate { get; set; }
        public string NepaliDate { get; set; }
        public string Holiday { get; set; }
        public string HolidayDesc { get; set; }
        public string LoanHoliday { get; set; }
        public string LoanHolidayDesc { get; set; }
    }
}
