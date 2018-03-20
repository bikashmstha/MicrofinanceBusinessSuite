using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementOpeningController : ControllerBase
    {
        private static IStaffLoanDisbursementOpeningDao staffLoanDisbursementOpeningDao = DataAccess.StaffLoanDisbursementOpeningDao;

        public object SaveStaffLoanDisbursementOpening(StaffLoanDisbursementOpening staffLoanDisbursementOpening)
        {
            return staffLoanDisbursementOpeningDao.SaveStaffLoanDisbursementOpening(staffLoanDisbursementOpening);
        }
        public object SearchStaffLoanDisbursementOpening(StaffLoanDisbursementOpening staffLoanDisbursementOpening)
        {
            return staffLoanDisbursementOpeningDao.SearchStaffLoanDisbursementOpening(staffLoanDisbursementOpening);
        }
    }
}