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
     
    public class ServiceCriteria : Criteria
    {
         
        public int ServiceId { get; set; }

         
        public bool IncludeOrderStatistics { get; set; }
    }
}
