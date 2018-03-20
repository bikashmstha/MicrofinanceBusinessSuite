using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class MenuEntry : BusinessObject
    {
        public string RowID { get; set; }
        public string FormID { get; set; }
        public string FormName { get; set; }
        public string WebFormName { get; set; }
        public string DisplayName { get; set; }
        public string TabID { get; set; }
        public string TabDesc { get; set; }
        public string ModuleID { get; set; }
        public string ModuleDesc { get; set; }
        public string ReportType { get; set; }
        public string RepoTypeDesc { get; set; }
        public string DisplaySeq { get; set; }
       
    }
}
