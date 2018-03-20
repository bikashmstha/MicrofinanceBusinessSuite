using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class DepartmentMap : BusinessObject
    {
        public DepartmentMap() { }

        public string InstituteCode { get; set; }
        public string DeptCode { get; set; }
    }
}
