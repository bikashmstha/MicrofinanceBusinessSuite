using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanRepayLoanDao
    {


        object SaveStaffLoanRepayLoan(StaffLoanRepayLoan staffLoanRepayLoan);

        object SearchStaffLoanRepayLoan(StaffLoanRepayLoan staffLoanRepayLoan);



        object GetStaffLoanRepayLoan(string OfficeCode, string ProductCode, string ClientName);

    }
}
