using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.HumanResource
{
    public class Post : BusinessObject
    {
        public Post() { }

        public string PostCode { get; set; }
        public string PostDesc { get; set; }
        public int PostLevel { get; set; }
        public string MgrPostCode { get; set; }
        public int MaxGrade { get; set; }
        public string MinQualification { get; set; }
        public int PostLevelCode { get; set; }
    }
}
