using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Common
{
    public class Vdc:BusinessObject
    {
        public string VDCNPCode { get; set; }
        public string VDCNPDesc { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictDesc { get; set; }

    }
}
