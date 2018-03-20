using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementController : ControllerBase
    {
        private static IStaffLoanDisbursementDao staffLoanDisbursementDao = DataAccess.StaffLoanDisbursementDao;



        public object SaveStaffLoanDisbursement(StaffLoanDisbursement staffLoanDisbursement)
        {
            return staffLoanDisbursementDao.SaveStaffLoanDisbursement(staffLoanDisbursement);
        }
        
    }
}