using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class VdcCoverageByOffice : BusinessObject
    {
        
        public VdcCoverageByOffice() { }

        public string InstituteCode { get; set; }
        public string VdcnpCode { get; set; }
        public string VdcnpName { get; set; }
        public string Remarks { get; set; }
    }
}
