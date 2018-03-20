using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class Particulars : BusinessObject
    {
        public Particulars() { }

        public string AccountDesc { get; set; }
        public string AccountCode { get; set; }
        public int AccountNo { get; set; }
        public string GroupName { get; set; }
        public double RowCount { get; set; }

        public string NarrationCode { get; set; }

        public string NarrationDesc { get; set; }
    }
}
