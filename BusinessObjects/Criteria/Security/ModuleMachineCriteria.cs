using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessObjects.Criteria
{
     
    public class ModuleMachineCriteria
    {
         
        //public ModuleMachineDto ObjModuleMachine { get; set; }

         
        public string  ApplicationId { get; set; }

         
        public string ModuleId { get; set; }


         
        public bool IncludeOrderStatistics { get; set; }
    }
}
