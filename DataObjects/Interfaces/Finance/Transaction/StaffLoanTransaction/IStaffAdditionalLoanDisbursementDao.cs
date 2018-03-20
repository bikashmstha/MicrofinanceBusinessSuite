using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffAdditionalLoanDisbursementDao
    {


        object SaveStaffAdditionalLoanDisbursement(StaffAdditionalLoanDisbursement staffAdditionalLoanDisbursement);

        object SearchStaffAdditionalLoanDisbursement(StaffAdditionalLoanDisbursement staffAdditionalLoanDisbursement);



    }
}
