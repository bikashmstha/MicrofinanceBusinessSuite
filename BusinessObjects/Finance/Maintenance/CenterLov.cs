using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class CenterLov : BusinessObject
    {
        public CenterLov() { }

        public String CenterCode { get; set; }
        public String CenterName { get; set; }
        public String InstituteCode { get; set; }
        public String InstituteName { get; set; }
        public String EmployeeId { get; set; }
        public String EmployeeName { get; set; }
    }
}
