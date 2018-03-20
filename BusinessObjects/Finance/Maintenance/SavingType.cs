using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Maintenance
{
    public class SavingType : BusinessObject
    {
        public SavingType() { }

        public string ProductTypeCode { get; set; }
        public string ProductTypeDesc { get; set; }
        public string ProductCategoryCode { get; set; }
        public double RowCount { get; set; }
    }
}
