using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.StaffLoanTransaction
{
    public class LoanCollateral : BusinessObject
    {
        public LoanCollateral() { }

        public string FiscalYear { get; set; }
        public string LoanNo { get; set; }
        public string Collateral { get; set; }
        public string Venue { get; set; }
        public double CollateralValue { get; set; }
        public string ValulatorName { get; set; }
        public string CollateralImgPath { get; set; }
        public string TranOfficeCode { get; set; }
        public string TransferDate { get; set; }
        public string User1 { get; set; }
        public string Date1 { get; set; }
        public string InsertUpdate { get; set; }
        public double OutSno { get; set; }
    }
}
