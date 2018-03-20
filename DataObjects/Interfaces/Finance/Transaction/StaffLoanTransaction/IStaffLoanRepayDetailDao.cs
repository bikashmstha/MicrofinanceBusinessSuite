using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanRepayDetailDao
    {


        object SaveStaffLoanRepayDetail(StaffLoanRepayDetail staffLoanRepayDetail);

        object SearchStaffLoanRepayDetail(StaffLoanRepayDetail staffLoanRepayDetail);



        object GetStaffLoanRepayDetail(string OfficeCode, long? RepaymentNo, string LoanDno, string ClientName, string FromDate, string ToDate);

    }
}
