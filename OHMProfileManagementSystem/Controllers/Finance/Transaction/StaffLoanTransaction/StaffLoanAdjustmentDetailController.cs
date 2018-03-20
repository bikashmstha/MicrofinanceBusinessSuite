using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanAdjustmentDetailController : ControllerBase
    {
        private static IStaffLoanAdjustmentDetailDao staffLoanAdjustmentDetailDao = DataAccess.StaffLoanAdjustmentDetailDao;



        public object SaveStaffLoanAdjustmentDetail(StaffLoanAdjustmentDetail staffLoanAdjustmentDetail)
        {
            return staffLoanAdjustmentDetailDao.SaveStaffLoanAdjustmentDetail(staffLoanAdjustmentDetail);
        }
        public object SearchStaffLoanAdjustmentDetail(StaffLoanAdjustmentDetail staffLoanAdjustmentDetail)
        {
            return staffLoanAdjustmentDetailDao.SearchStaffLoanAdjustmentDetail(staffLoanAdjustmentDetail);
        }

        public object GetStaffLoanAdjDetail(string OfficeCode, string LoanNo, string ClientName, string FromDate, string ToDate)
        {
            return staffLoanAdjustmentDetailDao.GetStaffLoanAdjDetail(OfficeCode, LoanNo, ClientName, FromDate, ToDate);
        }

    }
}