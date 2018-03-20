using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanDisbursementDetailDao
    {


        object SaveStaffLoanDisbursementDetail(StaffLoanDisbursementDetail staffLoanDisbursementDetail);

        object SearchStaffLoanDisbursementDetail(StaffLoanDisbursementDetail staffLoanDisbursementDetail);



        object GetStaffLoanDisDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate);

    }
}
