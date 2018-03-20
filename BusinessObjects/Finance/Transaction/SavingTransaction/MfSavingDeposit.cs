using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class MfSavingDeposit : BusinessObject
    {
        public MfSavingDeposit() { }

        public string WithdrawOfficeCode { get; set; }
        public string ChargeIbVoucherDate { get; set; }
        public string ChargeIbVoucherNo { get; set; }
        public string TranAdjustAbbs { get; set; }
        public string AcAdjustAbbs { get; set; }
        public string FiscalYear { get; set; }
        public double DepositNo { get; set; }
        public string AccountNo { get; set; }
        public string DepositDate { get; set; }
        public double DepositAmount { get; set; }
        public string ContraAccount { get; set; }
        public string MandatorySavingType { get; set; }
        public string CollectionSheetNo { get; set; }
        public string VoucherNo { get; set; }
        public string Remarks { get; set; }
        public string ReferenceNo { get; set; }
        public string FlagForPosting { get; set; }
        public string EmpId { get; set; }
        public double WithdrawalNo { get; set; }
        public string AccountClosed { get; set; }
        public string TranOfficeCode { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string LastChangeDate { get; set; }
        public string TransferDate { get; set; }
        public string VoucherDate { get; set; }
        public string DepositBy { get; set; }
        public string AcOfficeCode { get; set; }
        public string ValueDate { get; set; }
        public double PenaltyAmount { get; set; }
        public string ChargeType { get; set; }
        public double ChargeAmount { get; set; }
        public string ChargeSource { get; set; }
        public string ChargeVoucherNo { get; set; }
        public string ChargeVoucherDate { get; set; }
        public string InterbranchVoucherNo { get; set; }
        public string InterbranchVoucherDate { get; set; }
        public string TransferSavingYN { get; set; }
        public string TransferAccountNo { get; set; }
        public string TransferChequeNo { get; set; }
    }
}
