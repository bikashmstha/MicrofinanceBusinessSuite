using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LoanUtilizationEntry : BusinessObject
    {
        public LoanUtilizationEntry() { }

        public string FiscalYear { get; set; }
        public string CenterCode { get; set; }
        public string LoanNo { get; set; }
        public string InspectionDate { get; set; }
        public double UtilizationPc { get; set; }
        public double ManagerUtilization_Pc { get; set; }
        public string Remarks { get; set; }
        public string ManagerInspection_Date { get; set; }
        public string FieldRemarks { get; set; }
        public string InsertUpdate { get; set; }
    }
}
