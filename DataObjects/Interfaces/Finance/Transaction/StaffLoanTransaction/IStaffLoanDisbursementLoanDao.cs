﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanDisbursementLoanDao
    {


        object SaveStaffLoanDisbursementLoan(StaffLoanDisbursementLoan staffLoanDisbursementLoan);

        object SearchStaffLoanDisbursementLoan(StaffLoanDisbursementLoan staffLoanDisbursementLoan);



        object GetStaffLoanDisLoan(string OfficeCode, string EmpName);

    }
}
