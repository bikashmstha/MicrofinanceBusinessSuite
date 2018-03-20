using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanRepaymentController : ControllerBase
    {
        private static IStaffLoanRepaymentDao staffLoanRepaymentDao = DataAccess.StaffLoanRepaymentDao;



        public object SaveStaffLoanRepayment(StaffLoanRepayment staffLoanRepayment)
        {
            return staffLoanRepaymentDao.SaveStaffLoanRepayment(staffLoanRepayment);
        }
        public object SearchStaffLoanRepayment(StaffLoanRepayment staffLoanRepayment)
        {
            return staffLoanRepaymentDao.SearchStaffLoanRepayment(staffLoanRepayment);
        }



    }
}