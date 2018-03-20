using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance
{
    public class MemberForCancellation : BusinessObject
    {
        public MemberForCancellation() { }

        public string MembershipCloseDate { get; set; }
        public string MemCloseDateBs { get; set; }
        public string MembershipDate { get; set; }
        public string MemDateBs { get; set; }
        public string ClientNo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string CenterName { get; set; }
        public string CenterCode { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public string ReasonForInactive { get; set; }
        public string Active { get; set; }
        public string TranOfficeCode { get; set; }
        public int RowCount { get; set; }
    }
}
