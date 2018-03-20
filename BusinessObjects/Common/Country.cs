using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Common
{
    public class Country : BusinessObject
    {
        public Country() { }

        public string CountryCode { get; set; }
        public string CountryDesc { get; set; }
        public string Nationality { get; set; }
        public string CibCode { get; set; }
    }
}
