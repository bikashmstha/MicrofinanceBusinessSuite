using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace BusinessObjects.Maintenance
{
    public class AccountSubCategory:BusinessObject
    {
 

        /*SUB_CATEGORY_NO    NUMBER(3),
  SUB_CATEGORY_DESC  VARCHAR2(60 BYTE),
  CATEGORY_NO        NUMBER(3),
  RATIONUM           NUMBER(3),
  DISPLAY_SEQ        NUMBER(6)*/

        public Int16 SubCategoryNo { get; set; }
        public string SubCategoryDesc { get; set; }
        public Int16 CategoryNo { get; set; }
        public string CategoryDesc { get; set; }
        public Int16 RatioNum { get; set; }
        public long DisplaySeq { get; set; }
        public string CategoryInitialDesc { get; set; }
    }
}
