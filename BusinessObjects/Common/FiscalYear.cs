using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace BusinessObjects.Common
{
    public class FiscalYear:BusinessObject
    {
        /*FISCAL_YEAR          VARCHAR2(9 BYTE),
  START_DATE           DATE,
  START_DATE_NEP       VARCHAR2(10 BYTE),
  END_DATE             DATE,
  END_DATE_NEP         VARCHAR2(10 BYTE),
  LAST_VOUCHER_SEQ_NO  NUMBER,
  CREATED_ON           DATE,
  CREATED_BY           VARCHAR2(30 BYTE)*/
        public string  FiscalYearCode { get; set; }
        public string StartDate { get; set; }
        public string StartDateNep { get; set; }
        public string EndDate { get; set; }
        public string EndDateNep { get; set; }
        public long LastVoucherSeqNo { get; set; }

    }
}
