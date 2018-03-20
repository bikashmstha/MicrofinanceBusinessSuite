﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class MfAdjustSaving : BusinessObject
    {
        public MfAdjustSaving() { }

        public string AccountNo { get; set; }
        public string SavingAccountNo { get; set; }
        public string ProductName { get; set; }
        public string SavingAccountHead { get; set; }
        public int AacountCode { get; set; }
        public string AccountDesc { get; set; }
        public double CurrentBalance { get; set; }
        public double RowCount { get; set; }
    }
}