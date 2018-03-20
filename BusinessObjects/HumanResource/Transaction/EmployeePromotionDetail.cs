using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeePromotionDetail : BusinessObject
    {
        public EmployeePromotionDetail() { }

        public double Sno { get; set; }
        public string EmpId { get; set; }
        public string PromotionDate { get; set; }
        public string PromotionDateNep { get; set; }
        public string OldPostCode { get; set; }
        public string PostCode { get; set; }
        public string Remarks { get; set; }
        public int OldGradeNo { get; set; }
        public int OldLevelSno { get; set; }
        public int GradeNo { get; set; }
        public double GradeValue { get; set; }
        public int LevelSno { get; set; }
        public string PromotionType { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public double SerialNo { get; set; }
    }
}
