using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class ApplicationSequenceGenerator:BusinessObject
    {
    
        /*
         * OFFICE_CODE   VARCHAR2(10 BYTE) CONSTRAINT APPL_SEQ_OFFICE_NN_1 NOT NULL,
  CONTEXT_CODE  VARCHAR2(30 BYTE) CONSTRAINT APPL_SEQ_OFFICE_NN_2 NOT NULL,
  NEXT_VALUE    NUMBER(10) CONSTRAINT APPL_SEQ_OFFICE_NN_3 NOT NULL,
  MASK_LENGTH   NUMBER(10) CONSTRAINT APPL_SEQ_OFFICE_NN_4 NOT NULL,
  CONTEXT_DESC  VARCHAR2(600 BYTE),
  CONTEXT_ID    NUMBER(5),
  CREATED_ON    DATE,
  MODIFIED_ON   DATE,
  CREATED_BY    VARCHAR2(30 BYTE),
  MODIFIED_BY   VARCHAR2(30 BYTE)*/

        public string OffCode { get; set; }
        public string ContextCode { get; set; }
        public long NextValue { get; set; }
        public long MaskLength { get; set; }
        public string ContextDesc { get; set; }
        public long ContextId { get; set; }
    }
}
