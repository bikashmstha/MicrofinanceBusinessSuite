using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource
{
    public class Designation : BusinessObject
    {
        public Designation() { }

        public string DesignationCode { get; set; }
        public string DesignationDesc { get; set; }
        public string MgrDesignationCode { get; set; }
        public string PostCode { get; set; }
        public int SortOrder { get; set; }
        public string PerTrainee { get; set; }
    }
}
