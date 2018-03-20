using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class EthnicityInformation : BusinessObject
    {
        public string EthnicityCode { get; set; }
        public string EthnicityDesc { get; set; }
        public string MastEthnicity { get; set; }
    }
}
