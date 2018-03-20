using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Supervisor
{
    public class OfficeDepartment:BusinessObject
    {
        public OfficeDepartment() { }

        public string InstituteCode { get; set; }
        public string DeptCode { get; set; }
    }
}
