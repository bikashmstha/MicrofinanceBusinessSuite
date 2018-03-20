using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycDetailController : ControllerBase
    {
        private static IEmployeeKycDetailDao employeeKycDetailDao = DataAccess.EmployeeKycDetailDao;

        public object SaveEmployeeKycDetail(EmployeeKycDetail employeeKycDetail)
        {
            return employeeKycDetailDao.SaveEmployeeKycDetail(employeeKycDetail);
        }
        public object SearchEmployeeKycDetail(EmployeeKycDetail employeeKycDetail)
        {
            return employeeKycDetailDao.SearchEmployeeKycDetail(employeeKycDetail);
        }

        public object GetEmpKycDetail(string OfficeCode, string ClientCode, string ClientName, string DateFrom, string DateTo)
        {
            return employeeKycDetailDao.GetEmpKycDetail(OfficeCode, ClientCode, ClientName, DateFrom, DateTo);
        }

    }
}