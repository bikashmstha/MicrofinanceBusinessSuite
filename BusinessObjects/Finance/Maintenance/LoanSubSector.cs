using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class LoanSubSector : BusinessObject
    {
        public string LoanSubSectorCode { get; set; }
        public string LoanSubSectorDesc { get; set; }

        public string LoanSectorCode { get; set; }
        public string LoanSectorDesc { get; set; }



    }
}
