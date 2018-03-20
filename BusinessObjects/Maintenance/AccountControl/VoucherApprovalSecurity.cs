using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace BusinessObjects.Maintenance
{
    public class VoucherApprovalSecurity:BusinessObject
    {
        /*USER_CODE            VARCHAR2(30 BYTE),
  VOUCHER_TYPE         VARCHAR2(2 BYTE),
  MAX_APPROVAL_AMOUNT  NUMBER(17,2),
  TRAN_OFFICE_CODE     VARCHAR2(20 BYTE)*/

        public string UserCode { get; set; }
        public string VoucherType { get; set; }
        public double MaxApprovalAmount { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
