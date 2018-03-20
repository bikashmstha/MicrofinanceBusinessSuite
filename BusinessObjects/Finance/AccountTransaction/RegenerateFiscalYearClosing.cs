using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class RegenerateFiscalYearClosing : BusinessObject
    {
        public RegenerateFiscalYearClosing() { }

        public string OfficeCode { get; set; }
        public string NewFiscalYear { get; set; }
        public string OldFiscalYear { get; set; }
    }
}
