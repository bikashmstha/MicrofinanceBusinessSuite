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
    public class ApplicationCriteria : Criteria
    {
        public string ApplicationId { get; set; }

        private bool _IncludeModuleFuctions = false;
        public bool IncludeModuleFuctions { get { return _IncludeModuleFuctions; } set { _IncludeModuleFuctions =value ; } }

        private bool _IncludeRoles = false;
        public bool IncludeRoles { get { return _IncludeRoles; } set { _IncludeRoles = value; } }

        private bool _IncludeVerificationModule = false;
        public bool IncludeVerificationModule { get { return _IncludeVerificationModule; } set { _IncludeVerificationModule = value; } }
    }
}
