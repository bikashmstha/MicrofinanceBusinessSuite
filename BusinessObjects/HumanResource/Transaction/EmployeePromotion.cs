using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeePromotion : BusinessObject
    {
        public EmployeePromotion() { }

        public string EmpId { get; set; }
        public string PromotionDate { get; set; }
        public string PromotionDateNep { get; set; }
        public string OldPostCode { get; set; }
        public string PostCode { get; set; }
        public string Remarks { get; set; }
        public double OldGradeNo { get; set; }
        public double OldLevelSno { get; set; }
        public double GradeNo { get; set; }
        public double GradeValue { get; set; }
        public double LevelSno { get; set; }
        public string PromotionType { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public double SerialNo { get; set; }
        public string InsertUpdate { get; set; }
        public double OutSno { get; set; }
    }
}
