using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class Sector : BusinessObject
    {
        public Sector() { }

        public string LoanSectorCode { get; set; }
        public string LoanSectorDesc { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public string LoanPurposeCode { get; set; }

        public string LoanPurposeDesc { get; set; }
    }
}
