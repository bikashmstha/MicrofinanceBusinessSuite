using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource.Transaction
{
    public class EmployeeEducation : BusinessObject
    {
        public EmployeeEducation() { }

        public string EmpId { get; set; }
        public string EducationLevel { get; set; }
        public string DegreeName { get; set; }
        public double PassedYear { get; set; }
        public double PassedNepaliYear { get; set; }
        public string PassedDivision { get; set; }
        public string SchoolCollegeName { get; set; }
        public string SchoolCollegeCountry { get; set; }
        public string UniversityName { get; set; }
        public string UnivCountryCode { get; set; }
        public string Username { get; set; }
        public string Date1 { get; set; }
        public string MarksObtained { get; set; }
        public string Subjects { get; set; }
        public string ApprovedFlag { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public string TranOfficeCode { get; set; }
        public string InsertUpdate { get; set; }
        public double OutSno { get; set; }
    }
}
