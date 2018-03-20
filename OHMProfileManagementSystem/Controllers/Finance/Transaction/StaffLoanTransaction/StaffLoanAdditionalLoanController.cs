using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanAdditionalLoanController : ControllerBase
    {
        private static IStaffLoanAdditionalLoanDao staffLoanAdditionalLoanDao = DataAccess.StaffLoanAdditionalLoanDao;



        public object SaveStaffLoanAdditionalLoan(StaffLoanAdditionalLoan staffLoanAdditionalLoan)
        {
            return staffLoanAdditionalLoanDao.SaveStaffLoanAdditionalLoan(staffLoanAdditionalLoan);
        }
        public object SearchStaffLoanAdditionalLoan(StaffLoanAdditionalLoan staffLoanAdditionalLoan)
        {
            return staffLoanAdditionalLoanDao.SearchStaffLoanAdditionalLoan(staffLoanAdditionalLoan);
        }

        public object GetStaffLoanAddLoan(string OfficeCode, string ProductCode, string ClientName)
        {
            return staffLoanAdditionalLoanDao.GetStaffLoanAddLoan(OfficeCode, ProductCode, ClientName);
        }

    }
}