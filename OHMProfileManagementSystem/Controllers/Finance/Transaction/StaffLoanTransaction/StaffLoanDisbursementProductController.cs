using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementProductController : ControllerBase
    {
        private static IStaffLoanDisbursementProductDao staffLoanDisbursementProductDao = DataAccess.StaffLoanDisbursementProductDao;



        public object SaveStaffLoanDisbursementProduct(StaffLoanDisbursementProduct staffLoanDisbursementProduct)
        {
            return staffLoanDisbursementProductDao.SaveStaffLoanDisbursementProduct(staffLoanDisbursementProduct);
        }
        public object SearchStaffLoanDisbursementProduct(StaffLoanDisbursementProduct staffLoanDisbursementProduct)
        {
            return staffLoanDisbursementProductDao.SearchStaffLoanDisbursementProduct(staffLoanDisbursementProduct);
        }

        public object GetStaffLoanDisProd(string ProductName)
        {
            return staffLoanDisbursementProductDao.GetStaffLoanDisProd(ProductName);
        }

    }
}