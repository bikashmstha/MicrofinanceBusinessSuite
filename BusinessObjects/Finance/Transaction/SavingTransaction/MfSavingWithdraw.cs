using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.SavingTransaction
{
    public class MfSavingWithdraw : BusinessObject
    {
        public MfSavingWithdraw() { }

        public string AcAdjustAbbs { get; set; }
        public string FiscalYear { get; set; }
        public double WithdrawalNo { get; set; }
        public string AccountNo { get; set; }
        public string WithdrawDate { get; set; }
        public double WithdrawAmount { get; set; }
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public string ContraAccount { get; set; }
        public double RepaymentNo { get; set; }
        public string Remarks { get; set; }
        public string CollectionSheetNo { get; set; }
        public string VoucherNo { get; set; }
        public string FlagForPosting { get; set; }
        public double ClosingCharge { get; set; }
        public string WithdrawType { get; set; }
        public string AccountClosed { get; set; }
        public string TranOfficeCode { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string LastChangeDate { get; set; }
        public string TransferDate { get; set; }
        public int HalfWayInt { get; set; }
        public double UnpostInterest { get; set; }
        public double PenaltyAmount { get; set; }
        public double TaxAmount { get; set; }
        public double OtherIncomeExpAmount { get; set; }
        public string OtherIncomeExpVoucherNo { get; set; }
        public string VoucherDate { get; set; }
        public string AcOfficeCode { get; set; }
        public string ValueDate { get; set; }
        public double ChargeAmount { get; set; }
        public string ChargeType { get; set; }
        public string ChargeSource { get; set; }
        public int ReferenceDepositNo { get; set; }
        public int ReferenceWithdrawalNo { get; set; }
        public string ChargeVoucherNo { get; set; }
        public string ChargeVoucherDate { get; set; }
        public string InterbranchVoucherNo { get; set; }
        public string InterbranchVoucherDate { get; set; }
        public string ChargeIbVoucherNo { get; set; }
        public string ChargeIbVoucherDate { get; set; }
        public double TdsTaxableInterestAmount { get; set; }
        public double MidTermBalance { get; set; }
        public double MidTermInterest { get; set; }
        public double MidTermTaxableAmount { get; set; }
        public double WaivedAmount { get; set; }
        public double AccurateInterest { get; set; }
        public string AccurateInterestVoucherNo { get; set; }
        public string TranAdjustAbbs { get; set; }

        public object MaxWithdrawAmount { get; set; }
    }
}
