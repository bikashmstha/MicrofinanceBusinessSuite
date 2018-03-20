using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class CollectionSheetMasterOffline : BusinessObject
    {
        public CollectionSheetMasterOffline() { }

        public string CollectionSheetNo { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string EmployeeId { get; set; }
        public string EmpName { get; set; }
        public double CenterFundAmount { get; set; }
        public string CenterFundAccount { get; set; }
        public string TranOfficeCode { get; set; }
    }
}
