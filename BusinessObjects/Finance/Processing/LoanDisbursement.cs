﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Finance.Processing
{
    public class LoanDisbursement : BusinessObject
    {
        public LoanDisbursement() { }

        public string MemberName { get; set; }
        public string LoanNo { get; set; }
        public string LoanDno { get; set; }
        public string LoanProdDesc { get; set; }
        public string LoanPeriodDesc { get; set; }
        public double InterestRate { get; set; }
        public double Sno { get; set; }
        public double LoanAmount { get; set; }
        public double DeductionAmount { get; set; }
        public string ContraAcDesc { get; set; }
        public string FirstInstallDate { get; set; }
        public string DisburseType { get; set; }
    }
}