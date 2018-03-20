using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Transaction.LoanTransaction
{
    public class LnUtilizationDetail : BusinessObject
    {
        public LnUtilizationDetail() { }

        public string CenterCode { get; set; }
        public string LoanDno { get; set; }
        public string LoanNo { get; set; }
        public string ClientName { get; set; }
        public string LoanPurpose_Desc { get; set; }
        public string DisburseDate { get; set; }
        public double TotalLoan_Amount { get; set; }
        public string InspectionDate { get; set; }
        public string FieldRemarks { get; set; }
        public double UtilizationPc { get; set; }
        public string ManagerInspection_Date { get; set; }
        public double ManagerUtilization_Pc { get; set; }
        public string Remarks { get; set; }
    }
}
