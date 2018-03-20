using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class AccountGroupEntry : BusinessObject
    {
        public string GroupNo { get; set; }
        public string GroupName { get; set; }
        public string SubCategoryNo { get; set; }
        public string LType { get; set; }
        public string Type { get; set; }
        public string SNum { get; set; }
        public string DisplaySeq { get; set; }
        public string GroupCode { get; set; }
        public string ActiveFlag { get; set; }


    }
}

