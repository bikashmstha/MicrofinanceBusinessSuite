using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycEmployeeController : ControllerBase
    {
        private static IEmployeeKycEmployeeDao employeeKycEmployeeDao = DataAccess.EmployeeKycEmployeeDao;



        public object SaveEmployeeKycEmployee(EmployeeKycEmployee employeeKycEmployee)
        {
            return employeeKycEmployeeDao.SaveEmployeeKycEmployee(employeeKycEmployee);
        }
        public object SearchEmployeeKycEmployee(EmployeeKycEmployee employeeKycEmployee)
        {
            return employeeKycEmployeeDao.SearchEmployeeKycEmployee(employeeKycEmployee);
        }

        public object GetEmpKycEmp(string OfficeCode, string EmpName)
        {
            return employeeKycEmployeeDao.GetEmpKycEmp(OfficeCode, EmpName);
        }

    }
}