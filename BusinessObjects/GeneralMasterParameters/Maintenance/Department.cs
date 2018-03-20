using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class Department : BusinessObject
    {
        public Department() { }

        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string ParentDeptCode { get; set; }
        public string InstituteCode { get; set; }

        
    }
}
