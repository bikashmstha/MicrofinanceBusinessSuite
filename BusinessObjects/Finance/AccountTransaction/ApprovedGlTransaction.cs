using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.AccountTransaction
{
    public class ApprovedGlTransaction : BusinessObject
    {
        public ApprovedGlTransaction() { }

        public string VoucherNo { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedDateBs { get; set; }
        public string ApprovedBy { get; set; }
    }
}
