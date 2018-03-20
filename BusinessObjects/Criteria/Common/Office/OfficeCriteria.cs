using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessObjects.Criteria
{
    /// <summary>
    /// Holds criteria for customer queries.
    /// </summary>
     
    public class OfficeCriteria:Criteria
    {

         
        public int? ParentId { get; set; }


         
        public int? OfficeCode { get; set; }


         
        public string OfficeType { get; set; }


         
        public bool WithApplication { get; set; }

         
        public bool IncludeOrderStatistics { get; set; }
    }
}
