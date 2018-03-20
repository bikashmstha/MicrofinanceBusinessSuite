using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace BusinessObjects.Maintenance
{
    public class AccountCategory:BusinessObject
    {
        /*
         *CATEGORY_NO        NUMBER(3),
  CATEGORY_DESC      VARCHAR2(60 BYTE),
  CATEGORY_INITIAL   CHAR(1 BYTE),
  TRAN_OFFICE_CODE   VARCHAR2(20 BYTE),
  CREATED_ON         DATE,
  CREATED_BY         VARCHAR2(30 BYTE),
  MODIFIED_ON        DATE,
  MODIFIED_BY        VARCHAR2(30 BYTE),
  LAST_CHANGED_DATE  DATE*/

        public Int16 CategoryNo { get; set; }
        public string CategoryDesc { get; set; }
        public string CategoryInitial { get; set; }
        public string CategoryInitialDet { get; set; }
        public string TranOfficeCode { get; set; }
        public string LastChangedDate { get; set; }
    }
}
