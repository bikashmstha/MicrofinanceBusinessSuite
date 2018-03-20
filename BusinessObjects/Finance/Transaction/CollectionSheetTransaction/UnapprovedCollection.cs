using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class UnapprovedCollection : BusinessObject
    {
        public UnapprovedCollection() { }

        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string CollectionSheetNo { get; set; }
        public string EmployeeName { get; set; }
    }
}
