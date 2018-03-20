﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeeTrainingDetail : BusinessObject
    {
        public EmployeeTrainingDetail() { }

        public double Sno { get; set; }
        public string EmpId { get; set; }
        public string TrainingName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string TrainingDetail { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FromDateNep { get; set; }
        public string ToDateNep { get; set; }
        public string TrainingConductedBy { get; set; }
        public string TrainingRating { get; set; }
        public string Remarks { get; set; }
        public int TotalTrainingDays { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
    }
}
