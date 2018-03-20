using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessObjects.GeneralMasterParameters
{
    public class Module : BusinessObject
    {
        public Module() { }

        public string ModuleId { get; set; }
        public string ModuleDesc { get; set; }
        public int DisplaySeq { get; set; }
        public string Active { get; set; }
    }
}
