using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanAdditionalScrLoanController : ControllerBase
    {
        private static IStaffLoanAdditionalScrLoanDao staffLoanAdditionalScrLoanDao = DataAccess.StaffLoanAdditionalScrLoanDao;



        public object SaveStaffLoanAdditionalScrLoan(StaffLoanAdditionalScrLoan staffLoanAdditionalScrLoan)
        {
            return staffLoanAdditionalScrLoanDao.SaveStaffLoanAdditionalScrLoan(staffLoanAdditionalScrLoan);
        }
        public object SearchStaffLoanAdditionalScrLoan(StaffLoanAdditionalScrLoan staffLoanAdditionalScrLoan)
        {
            return staffLoanAdditionalScrLoanDao.SearchStaffLoanAdditionalScrLoan(staffLoanAdditionalScrLoan);
        }

        public object GetStaffLoanAdjScrLoan(string OfficeCode, string EmpName)
        {
            return staffLoanAdditionalScrLoanDao.GetStaffLoanAdjScrLoan(OfficeCode, EmpName);
        }

    }
}