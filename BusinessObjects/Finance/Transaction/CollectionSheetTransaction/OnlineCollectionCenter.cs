using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class OnlineCollectionCenter : BusinessObject
    {
        public OnlineCollectionCenter() { }

        public string CollectionDateBs { get; set; }
        public string DataEntered { get; set; }
        public int RowCount { get; set; }
        public string CenterCode { get; set; }
        public double CenterFundAmount { get; set; }
        public string CenterName { get; set; }
        public string CollectionSheetNo { get; set; }

        public string InstituteCode { get; set; }

        public string InstituteName { get; set; }

        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string CollectionDateAd { get; set; }
    }
}
