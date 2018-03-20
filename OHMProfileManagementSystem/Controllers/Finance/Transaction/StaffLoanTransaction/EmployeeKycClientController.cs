using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycClientController : ControllerBase
    {
        private static IEmployeeKycClientDao employeeKycClientDao = DataAccess.EmployeeKycClientDao;



        public object SaveEmployeeKycClient(EmployeeKycClient employeeKycClient)
        {
            return employeeKycClientDao.SaveEmployeeKycClient(employeeKycClient);
        }
        public object SearchEmployeeKycClient(EmployeeKycClient employeeKycClient)
        {
            return employeeKycClientDao.SearchEmployeeKycClient(employeeKycClient);
        }

        public object GetEmpKycClientSearch(string OfficeCode, string EmpName)
        {
            return employeeKycClientDao.GetEmpKycClientSearch(OfficeCode, EmpName);
        }

    }
}