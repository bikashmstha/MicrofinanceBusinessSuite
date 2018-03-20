using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeAllowanceAmountController : ControllerBase
    {
        private static IEmployeeAllowanceAmountDao employeeAllowanceAmountDao = DataAccess.EmployeeAllowanceAmountDao;



        public object SaveEmployeeAllowanceAmount(EmployeeAllowanceAmount employeeAllowanceAmount)
        {
            return employeeAllowanceAmountDao.SaveEmployeeAllowanceAmount(employeeAllowanceAmount);
        }
        public object SearchEmployeeAllowanceAmount(EmployeeAllowanceAmount employeeAllowanceAmount)
        {
            return employeeAllowanceAmountDao.SearchEmployeeAllowanceAmount(employeeAllowanceAmount);
        }

        public object GetEmpAllowanceAmt(long Sno, string FiscalYear, string PostCode)
        {
            return employeeAllowanceAmountDao.GetEmpAllowanceAmt(Sno, FiscalYear, PostCode);
        }

    }
}