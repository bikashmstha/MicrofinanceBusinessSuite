using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanRepaymentDao
    {


        object SaveStaffLoanRepayment(StaffLoanRepayment staffLoanRepayment);

        object SearchStaffLoanRepayment(StaffLoanRepayment staffLoanRepayment);

    }
}
