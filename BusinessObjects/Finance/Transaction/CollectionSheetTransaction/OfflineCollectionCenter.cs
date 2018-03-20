using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class OfflineCollectionCenter : BusinessObject
    {
        public OfflineCollectionCenter() { }

        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string FirstCollectionDate { get; set; }
        public string CenterFundAmount { get; set; }
        public string CollectionSheetNo { get; set; }
        public string  CollectionDateBS { get; set; }
        public string DataEntered { get; set; }
    }
}
