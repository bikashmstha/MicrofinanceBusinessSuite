using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IStaffLoanAdjustmentDetailDao
    {


        object SaveStaffLoanAdjustmentDetail(StaffLoanAdjustmentDetail staffLoanAdjustmentDetail);

        object SearchStaffLoanAdjustmentDetail(StaffLoanAdjustmentDetail staffLoanAdjustmentDetail);



        object GetStaffLoanAdjDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate);

    }
}
