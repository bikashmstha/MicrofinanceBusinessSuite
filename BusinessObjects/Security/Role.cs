using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Security
{
    public class Role : BusinessObject
    {
        public Role() { }

        public string RoleCode { get; set; }
        public string RoleDesc { get; set; }
        public string TransferExceedAmountYN { get; set; }
        public string DefaultModule { get; set; }
    }
}
