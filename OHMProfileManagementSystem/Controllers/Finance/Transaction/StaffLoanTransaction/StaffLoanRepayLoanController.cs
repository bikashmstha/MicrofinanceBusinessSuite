using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanRepayLoanController : ControllerBase
    {
        private static IStaffLoanRepayLoanDao staffLoanRepayLoanDao = DataAccess.StaffLoanRepayLoanDao;



        public object SaveStaffLoanRepayLoan(StaffLoanRepayLoan staffLoanRepayLoan)
        {
            return staffLoanRepayLoanDao.SaveStaffLoanRepayLoan(staffLoanRepayLoan);
        }
        public object SearchStaffLoanRepayLoan(StaffLoanRepayLoan staffLoanRepayLoan)
        {
            return staffLoanRepayLoanDao.SearchStaffLoanRepayLoan(staffLoanRepayLoan);
        }

        public object GetStaffLoanRepayLoan(string OfficeCode, string ProductCode, string ClientName)
        {
            return staffLoanRepayLoanDao.GetStaffLoanRepayLoan(OfficeCode, ProductCode, ClientName);
        }

    }
}