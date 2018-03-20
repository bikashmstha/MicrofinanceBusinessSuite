using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters.References
{
    public class MSReferenceCodeMaster:BusinessObject
    {
        public string RefMstCode { get; set; }
        public string RefMstName { get; set; }
        public string Active { get; set; }
       
    }
}
