using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Common
{
    public class District:BusinessObject
    {
        public string CIBCode { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictDesc { get; set; }
        public string ZoneCode { get; set; }

    }
}
