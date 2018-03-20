using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Maintenance
{
    public class GLVoucherType:BusinessObject
    {
        /*TRAN_OFFICE_CODE  VARCHAR2(20 BYTE),
  VOUCHER_TYPE      VARCHAR2(5 BYTE),
  FISCAL_YEAR       VARCHAR2(9 BYTE),
  VOUCHER_NAME      VARCHAR2(100 BYTE),
  LAST_VOUCHER_NO   NUMBER,
  CREATED_ON        DATE,
  CREATED_BY        VARCHAR2(30 BYTE)*/

        public string TranOffCode { get; set; }
        public string VoucherType { get; set; }
        public string FiscalYear { get; set; }
        public string VoucherName { get; set; }
        public long LastVoucherNo { get; set; }
        

    }
}
