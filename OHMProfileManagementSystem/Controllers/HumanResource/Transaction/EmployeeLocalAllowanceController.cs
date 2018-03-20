using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeLocalAllowanceController : ControllerBase
    {
        private static IEmployeeLocalAllowanceDao employeeLocalAllowanceDao = DataAccess.EmployeeLocalAllowanceDao;



        public object SaveEmployeeLocalAllowance(EmployeeLocalAllowance employeeLocalAllowance)
        {
            return employeeLocalAllowanceDao.SaveEmployeeLocalAllowance(employeeLocalAllowance);
        }
        public object SearchEmployeeLocalAllowance(EmployeeLocalAllowance employeeLocalAllowance)
        {
            return employeeLocalAllowanceDao.SearchEmployeeLocalAllowance(employeeLocalAllowance);
        }
    }
}