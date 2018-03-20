using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.EditTransaction
{
    public class PublicSavingDeposit : BusinessObject
    {
        public PublicSavingDeposit() { }

        public string AccountNo { get; set; }
        public string DepositDate { get; set; }
        public double DepositAmount { get; set; }
        public string ContraAccount { get; set; }
        public string MandatorySavingType { get; set; }
        public double PenaltyAmount { get; set; }
        public double ChargeAmount { get; set; }
        public string ChargeType { get; set; }
        public string VoucherNo { get; set; }
        public string EmpId { get; set; }
        public string Remarks { get; set; }
        public string DepositBy { get; set; }
        public string TranOfficeCode { get; set; }
        public string AcOfficeCode { get; set; }
        public string ValueDate { get; set; }
        public string ChargeSource { get; set; }
        public string AdjustFromSaving { get; set; }
        public string AdjustAccountNo { get; set; }
        public string AdjustChequeNo { get; set; }
        public string User1 { get; set; }
        public string InsertUpdate { get; set; }
        public string OutFiscalYear { get; set; }
        public double OutPublicDeposit_No { get; set; }
    }
}
