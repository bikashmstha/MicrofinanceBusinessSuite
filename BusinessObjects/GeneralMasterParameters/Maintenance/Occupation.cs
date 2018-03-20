using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class Occupation : BusinessObject
    {
        public string OccupationCode { get; set; }
        public string OccupationDesc { get; set; }
    }
}
