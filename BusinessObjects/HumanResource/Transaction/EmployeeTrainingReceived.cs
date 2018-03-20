using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeeTrainingReceived : BusinessObject
    {
        public EmployeeTrainingReceived() { }

        public string EmpId { get; set; }
        public string TrainingName { get; set; }
        public string CountryCode { get; set; }
        public string TrainingDetail { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FromDateNep { get; set; }
        public string ToDateNep { get; set; }
        public string TrainingConductedBy { get; set; }
        public string TrainingRating { get; set; }
        public string Remarks { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public string TranOfficeCode { get; set; }
        public string InsertUpdate { get; set; }
        public double OutSno { get; set; }
    }
}
