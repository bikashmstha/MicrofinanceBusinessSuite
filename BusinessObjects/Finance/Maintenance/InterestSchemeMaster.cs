using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class InterestSchemeMaster : BusinessObject
    {
        public InterestSchemeMaster() { }

        public string IntSchemeCode { get; set; }
        public string IntSchemeDesc { get; set; }
        public string SchemeFor { get; set; }
        public string EffectiveDate { get; set; }
        public string EffectiveDateBs { get; set; }
        public string ValidTill { get; set; }
        public string ValidTillBs { get; set; }
        public string CreatedOnBs { get; set; }
        public string SchemeForDesc { get; set; }
        public string ActiveFlag { get; set; }
    }
}
