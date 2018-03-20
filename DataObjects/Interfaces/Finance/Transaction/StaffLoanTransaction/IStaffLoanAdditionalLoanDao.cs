using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanAdditionalLoanDao
    {


        object SaveStaffLoanAdditionalLoan(StaffLoanAdditionalLoan staffLoanAdditionalLoan);

        object SearchStaffLoanAdditionalLoan(StaffLoanAdditionalLoan staffLoanAdditionalLoan);



        object GetStaffLoanAddLoan(string OfficeCode, string ProductCode, string ClientName);

    }
}
