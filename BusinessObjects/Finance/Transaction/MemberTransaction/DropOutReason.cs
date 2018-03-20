using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction
{
    public class DropOutReasons : BusinessObject
    {
        public DropOutReasons() { }

        public string ReasonCode { get; set; }
        public string ReasonDesc { get; set; }
        public string ParentReasonCode { get; set; }
        public string ActiveFlag { get; set; }
    }
}
