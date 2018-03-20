using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PublicSavingWithdrawProduct : BusinessObject
    {
        public PublicSavingWithdrawProduct() { }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductTypeCode { get; set; }
        public double PenaltyLateInstallment { get; set; }
        public double RowCount { get; set; }
    }
}
