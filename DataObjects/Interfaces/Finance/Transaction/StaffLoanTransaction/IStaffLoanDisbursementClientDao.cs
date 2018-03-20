using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanDisbursementClientDao
    {


        object SaveStaffLoanDisbursementClient(StaffLoanDisbursementClient staffLoanDisbursementClient);

        object SearchStaffLoanDisbursementClient(StaffLoanDisbursementClient staffLoanDisbursementClient);



        object GetStaffLoanDisClient(string OfficeCode, string ClientName);

    }
}
