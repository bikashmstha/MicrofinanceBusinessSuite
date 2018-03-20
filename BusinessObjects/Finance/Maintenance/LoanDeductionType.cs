using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class LoanDeductionType : BusinessObject
    {
        public LoanDeductionType() { }

        public string DeductionTypeCode { get; set; }
        public string DeductionTypeDesc { get; set; }
        public string SavingAccountDeduction { get; set; }
        public string SavingProductCode { get; set; }
        public string ActiveFlag { get; set; }
        public string DeductionRelatedTo { get; set; }
        public int ChargeAmount { get; set; }
        public string NonExistSavingProductCode { get; set; }

        public string SavingProductDesc { get; set; }

        public string NonExistSavingProductDesc { get; set; }
    }
}
