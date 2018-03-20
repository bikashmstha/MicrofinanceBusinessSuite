using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class StaffLoanDisbursementClientController : ControllerBase
    {
        private static IStaffLoanDisbursementClientDao staffLoanDisbursementClientDao = DataAccess.StaffLoanDisbursementClientDao;



        public object SaveStaffLoanDisbursementClient(StaffLoanDisbursementClient staffLoanDisbursementClient)
        {
            return staffLoanDisbursementClientDao.SaveStaffLoanDisbursementClient(staffLoanDisbursementClient);
        }
        public object SearchStaffLoanDisbursementClient(StaffLoanDisbursementClient staffLoanDisbursementClient)
        {
            return staffLoanDisbursementClientDao.SearchStaffLoanDisbursementClient(staffLoanDisbursementClient);
        }

        public object GetStaffLoanDisClient(string OfficeCode, string ClientName)
        {
            return staffLoanDisbursementClientDao.GetStaffLoanDisClient(OfficeCode, ClientName);
        }

    }
}