using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Supervisor
{
    public class Department
    {
        public Department() { }

        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string ParentDeptCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}
