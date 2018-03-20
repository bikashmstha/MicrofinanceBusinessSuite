using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PubSavingDepositDetail : BusinessObject
    {
        public PubSavingDepositDetail() { }

        public double DepositNo { get; set; }
        public string AcOfficeCode { get; set; }
        public string DepositDate { get; set; }
        public string DepositDateBs { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double ChargeAmount { get; set; }
        public string ChargeType { get; set; }
        public double PenaltyAmount { get; set; }
        public string ValueDate { get; set; }
        public string SavingAccountNo { get; set; }
        public string AccountNo { get; set; }
        public string ContraAccount { get; set; }
        public double CurrentBalance { get; set; }
        public double DepositAmount { get; set; }
        public string Remarks { get; set; }
        public string VoucherNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ContraAcNo { get; set; }
        public string AccountDesc { get; set; }
        public string DepositBy { get; set; }
        public string ChargeSource { get; set; }
        public string ChargeVoucherNo { get; set; }
        public string ChargeVoucherDate { get; set; }
        public double RowCount { get; set; }
    }
}
