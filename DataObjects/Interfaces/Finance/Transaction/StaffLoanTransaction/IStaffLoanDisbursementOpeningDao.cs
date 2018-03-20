using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanDisbursementOpeningDao
    {


        object SaveStaffLoanDisbursementOpening(StaffLoanDisbursementOpening staffLoanDisbursementOpening);

        object SearchStaffLoanDisbursementOpening(StaffLoanDisbursementOpening staffLoanDisbursementOpening);

    }
}
