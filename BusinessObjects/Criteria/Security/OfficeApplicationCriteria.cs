using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessObjects.Criteria
{
     
    public class OfficeApplicationCriteria : Criteria
    {
         
        public int? OfficeCode { get; set; }
    }
}
