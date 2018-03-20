using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementDetailController : ControllerBase
    {
        private static IStaffLoanDisbursementDetailDao staffLoanDisbursementDetailDao = DataAccess.StaffLoanDisbursementDetailDao;



        public object SaveStaffLoanDisbursementDetail(StaffLoanDisbursementDetail staffLoanDisbursementDetail)
        {
            return staffLoanDisbursementDetailDao.SaveStaffLoanDisbursementDetail(staffLoanDisbursementDetail);
        }
        public object SearchStaffLoanDisbursementDetail(StaffLoanDisbursementDetail staffLoanDisbursementDetail)
        {
            return staffLoanDisbursementDetailDao.SearchStaffLoanDisbursementDetail(staffLoanDisbursementDetail);
        }

        public object GetStaffLoanDisDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate)
        {
            return staffLoanDisbursementDetailDao.GetStaffLoanDisDetail(OfficeCode, LoanNo, ClientName, FromDate, ToDate);
        }

    }
}