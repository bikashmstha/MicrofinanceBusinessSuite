using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class CollectionSheetPosting : BusinessObject
    {
        public CollectionSheetPosting() { }

        public string OfficeCode { get; set; }
        public string CollectionSheetNo { get; set; }
        public string CenterCode { get; set; }
        public string DataEntered { get; set; }
        public string User1 { get; set; }
        public string TransactionDate { get; set; }
    }
}
