﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessObjects.Criteria
{
    /// <summary>
    /// Holds criteria for customer queries.
    /// </summary>
     
    public class ServiceExposedCriteria : Criteria
    {
         
        public string ServiceId { get; set; }
         
        public string FromDate { get; set; }
         
        public int SeqNo { get; set; }
         
        public bool IncludeOrderStatistics { get; set; }
    }
}
