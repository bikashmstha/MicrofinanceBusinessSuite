using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanDisbursementDao
    {


        object SaveStaffLoanDisbursement(StaffLoanDisbursement staffLoanDisbursement);
        
    }
}
