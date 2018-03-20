using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeEducationController : ControllerBase
    {
        private static IEmployeeEducationDao employeeEducationDao = DataAccess.EmployeeEducationDao;



        public object SaveEmployeeEducation(EmployeeEducation employeeEducation)
        {
            return employeeEducationDao.SaveEmployeeEducation(employeeEducation);
        }
        public object SearchEmployeeEducation(EmployeeEducation employeeEducation)
        {
            return employeeEducationDao.SearchEmployeeEducation(employeeEducation);
        }
    }
}