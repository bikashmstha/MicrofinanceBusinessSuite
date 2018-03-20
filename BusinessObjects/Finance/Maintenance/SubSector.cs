using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class SubSector : BusinessObject
    {
        public SubSector() { }

        public string SubSectorCode { get; set; }
        public string SubSectorDesc { get; set; }
        public string LoanSectorCode { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
