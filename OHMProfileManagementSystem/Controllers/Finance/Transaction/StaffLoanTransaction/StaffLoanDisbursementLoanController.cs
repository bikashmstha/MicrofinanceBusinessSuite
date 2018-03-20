using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementLoanController : ControllerBase
    {
        private static IStaffLoanDisbursementLoanDao staffLoanDisbursementLoanDao = DataAccess.StaffLoanDisbursementLoanDao;



        public object SaveStaffLoanDisbursementLoan(StaffLoanDisbursementLoan staffLoanDisbursementLoan)
        {
            return staffLoanDisbursementLoanDao.SaveStaffLoanDisbursementLoan(staffLoanDisbursementLoan);
        }
        public object SearchStaffLoanDisbursementLoan(StaffLoanDisbursementLoan staffLoanDisbursementLoan)
        {
            return staffLoanDisbursementLoanDao.SearchStaffLoanDisbursementLoan(staffLoanDisbursementLoan);
        }

        public object GetStaffLoanDisLoan(string OfficeCode, string EmpName)
        {
            return staffLoanDisbursementLoanDao.GetStaffLoanDisLoan(OfficeCode, EmpName);
        }

    }
}