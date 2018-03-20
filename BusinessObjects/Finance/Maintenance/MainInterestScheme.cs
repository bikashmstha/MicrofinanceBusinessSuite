using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class MainInterestScheme : BusinessObject
    {
        public MainInterestScheme() { }

        public string IntSchemeCode { get; set; }
        public string IntSchemeDesc { get; set; }
        public string SchemeFor { get; set; }
        public string EffectiveDate { get; set; }
        public string ValidTill { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ActiveFlag { get; set; }
    }
}
