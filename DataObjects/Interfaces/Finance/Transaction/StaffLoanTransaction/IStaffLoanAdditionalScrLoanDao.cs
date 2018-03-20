using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanAdditionalScrLoanDao
    {


        object SaveStaffLoanAdditionalScrLoan(StaffLoanAdditionalScrLoan staffLoanAdditionalScrLoan);

        object SearchStaffLoanAdditionalScrLoan(StaffLoanAdditionalScrLoan staffLoanAdditionalScrLoan);



        object GetStaffLoanAdjScrLoan(string OfficeCode, string EmpName);

    }
}
