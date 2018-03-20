using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class CenterDetailsFromCode : BusinessObject
    {
        public CenterDetailsFromCode() { }

        public string CenterCode { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CollectionDay { get; set; }
        public string CollectionDate { get; set; }
        public string CollectionDateBS { get; set; }
    }
}
