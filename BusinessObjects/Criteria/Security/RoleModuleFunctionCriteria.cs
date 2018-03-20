using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BusinessObjects.Criteria
{
    
   public class RoleModuleFunctionCriteria:Criteria
   {
        
       public string ApplicationID { get; set; }
        
       public string RoleID { get; set; }
   }
}
