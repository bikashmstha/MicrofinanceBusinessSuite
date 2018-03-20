using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.CollectionSheetTransaction
{
    public class SavingCollectionSheet : BusinessObject
    {
        public SavingCollectionSheet() { }

        public string CollectionDate { get; set; }
        public string ClientNo { get; set; }
        public string MonthlySavingACNo { get; set; }
        public string MonthlySavingRec { get; set; }
        public string MonthlySavingAdjustYN { get; set; }
        public string MonthlySavingAdjustNo { get; set; }
        public string MonthlySavingAdjustAmt { get; set; }
        public string SSFFundACNo { get; set; }
        public string SSFFundRec { get; set; }
        public string OpionalSavingACNo { get; set; }
        public string OptionalSavingWithdrawal { get; set; }
        public string PensionFundACNo { get; set; }
        public string PensionFundRec { get; set; }
        public string PensionFundAdjustYN { get; set; }
        public string PensionFundAdjustAmt { get; set; }
        public string ReceivedYN { get; set; }
        public string PresentYN { get; set; }
        public string BusinessAC { get; set; }
        public string BusinessReceived { get; set; }
        public string BusinessWithdraw { get; set; }
    }
}
