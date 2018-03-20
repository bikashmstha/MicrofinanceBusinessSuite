using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeAllowanceDetailController : ControllerBase
    {
        private static IEmployeeAllowanceDetailDao employeeAllowanceDetailDao = DataAccess.EmployeeAllowanceDetailDao;



        public object SaveEmployeeAllowanceDetail(EmployeeAllowanceDetail employeeAllowanceDetail)
        {
            return employeeAllowanceDetailDao.SaveEmployeeAllowanceDetail(employeeAllowanceDetail);
        }
        public object SearchEmployeeAllowanceDetail(EmployeeAllowanceDetail employeeAllowanceDetail)
        {
            return employeeAllowanceDetailDao.SearchEmployeeAllowanceDetail(employeeAllowanceDetail);
        }

        public object GetEmpAllowanceDetail(string EmpId, long? Sno, string FiscalYear)
        {
            return employeeAllowanceDetailDao.GetEmpAllowanceDetail(EmpId, Sno, FiscalYear);
        }

    }
}