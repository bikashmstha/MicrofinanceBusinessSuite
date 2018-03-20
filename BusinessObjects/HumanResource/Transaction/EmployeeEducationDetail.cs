using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeeEducationDetail : BusinessObject
    {
        public EmployeeEducationDetail() { }

        public double Sno { get; set; }
        public string EmpId { get; set; }
        public string EducationLevel { get; set; }
        public string EducationDesc { get; set; }
        public string DegreeName { get; set; }
        public string PassedYear { get; set; }
        public int PassedNepaliYear { get; set; }
        public string PassedDivision { get; set; }
        public string PassedDivisionDesc { get; set; }
        public string SchoolCollegeName { get; set; }
        public string SchoolCollegeCountry { get; set; }
        public string UniversityName { get; set; }
        public string UnivCountryCode { get; set; }
        public string MarksObtained { get; set; }
        public string Subjects { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
    }
}
