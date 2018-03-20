using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class EmployeeCenterCollection : BusinessObject
    {
        public EmployeeCenterCollection() { }

        public string CollectionSheetNo { get; set; }
        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string DataEntered { get; set; }
        public string EmpName { get; set; }
        public string CollnDate { get; set; }
    }
}
