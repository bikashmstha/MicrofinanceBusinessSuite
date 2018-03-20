using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.GeneralMasterParameters
{
    public class Group
    {
        public string FiscalYear { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string CenterCode { get; set; }
        public string GroupFormedDate { get; set; }
        public string GroupFormedBy { get; set; }
        public string TranOfficeCode { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string LastChangedDate { get; set; }
        public string TransferDate { get; set; }
        public string GrtPerformDate { get; set; }
        public string GrtPerformVal { get; set; }
        public string GrtPerformBy { get; set; }
        public string ThirdPartyData { get; set; }
        public string GroupClosedDate { get; set; }
        public string ActiveFlags { get; set; }
        public string GrpLeaderIndicator { get; set; }
        public string Action { get; set; }

        public string CenterName { get; set; }
    }
}
