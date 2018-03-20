using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanRepayDetailController : ControllerBase
    {
        private static IStaffLoanRepayDetailDao staffLoanRepayDetailDao = DataAccess.StaffLoanRepayDetailDao;



        public object SaveStaffLoanRepayDetail(StaffLoanRepayDetail staffLoanRepayDetail)
        {
            return staffLoanRepayDetailDao.SaveStaffLoanRepayDetail(staffLoanRepayDetail);
        }
        public object SearchStaffLoanRepayDetail(StaffLoanRepayDetail staffLoanRepayDetail)
        {
            return staffLoanRepayDetailDao.SearchStaffLoanRepayDetail(staffLoanRepayDetail);
        }

        public object GetStaffLoanRepayDetail(string OfficeCode, long? RepaymentNo, string LoanDno, string ClientName, string FromDate, string ToDate)
        {
            return staffLoanRepayDetailDao.GetStaffLoanRepayDetail(OfficeCode, RepaymentNo, LoanDno, ClientName, FromDate, ToDate);
        }

    }
}