using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters.Maintenance
{
    public class Religion:BusinessObject
    {
        public Religion() { }

        public string ReligionCode { get; set; }
        public string ReligionDesc { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string CibCode { get; set; }
    }
}
