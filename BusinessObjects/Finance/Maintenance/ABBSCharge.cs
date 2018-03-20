using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class ABBSCharge:BusinessObject
    {
        /*TRAN_OFFICE_CODE    VARCHAR2(20 BYTE),
  TO_OFFICE_CODE      VARCHAR2(20 BYTE),
  ABBS_TYPE           VARCHAR2(5 BYTE),
  ABBS_MIN_AMOUNT     NUMBER(32,2),
  ABBS_MAX_AMOUNT     NUMBER(32,2),
  ABBS_CHARGE_AMOUNT  NUMBER(32,2),
  ACTIVE_FLAG         VARCHAR2(1 BYTE)*/

        public string TranOfficeCode { get; set; }
        public string ToOfficeCode { get; set; }
        public string ABBSType { get; set; }
        public string ABBSTypeDesc { get; set; }
        public long ABBSMinAmount { get; set; }
        public long ABBSMaxAmount { get; set; }
        public long ABBSChargAmount { get; set; }
        public string Active { get; set; }
    }
}
