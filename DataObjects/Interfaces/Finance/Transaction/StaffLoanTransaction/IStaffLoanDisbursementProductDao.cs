using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanDisbursementProductDao
    {


        object SaveStaffLoanDisbursementProduct(StaffLoanDisbursementProduct staffLoanDisbursementProduct);

        object SearchStaffLoanDisbursementProduct(StaffLoanDisbursementProduct staffLoanDisbursementProduct);



        object GetStaffLoanDisProd(string ProductName);

    }
}
