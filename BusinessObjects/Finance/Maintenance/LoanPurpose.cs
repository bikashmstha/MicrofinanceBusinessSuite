using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class LoanPurpose:BusinessObject
    {
        public string LoanPurposeCode { get; set; }
        public string LoanPurposeDesc { get; set; }
        public string SubSectorCode { get; set; }
        public string SubSectorDesc { get; set; }
        
        
        public string CibCode { get; set; }
    }
}
