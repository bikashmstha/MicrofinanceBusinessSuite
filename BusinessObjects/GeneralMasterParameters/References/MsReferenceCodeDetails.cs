using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters.References
{
   public class MsReferenceCodeDetails:BusinessObject
    {

        public string RefMstCode { get; set; }
        public string RefDtlCode { get; set; }        
        public string RefDtlName { get; set; }
        public string DisplayOrder { get; set; }
        public string Active { get; set; }
        
    }
}
