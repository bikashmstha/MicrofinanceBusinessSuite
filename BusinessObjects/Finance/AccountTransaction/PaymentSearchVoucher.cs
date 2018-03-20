﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class PaymentSearchVoucher : BusinessObject
    {
        public PaymentSearchVoucher() { }

        public string VoucherNo { get; set; }
        public string Particulars { get; set; }
        public double RowCount { get; set; }
    }
}