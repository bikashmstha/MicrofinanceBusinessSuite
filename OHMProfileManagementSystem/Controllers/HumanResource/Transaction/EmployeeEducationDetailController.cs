using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeEducationDetailController : ControllerBase
    {
        private static IEmployeeEducationDetailDao employeeEducationDetailDao = DataAccess.EmployeeEducationDetailDao;



        public object SaveEmployeeEducationDetail(EmployeeEducationDetail employeeEducationDetail)
        {
            return employeeEducationDetailDao.SaveEmployeeEducationDetail(employeeEducationDetail);
        }
        public object SearchEmployeeEducationDetail(EmployeeEducationDetail employeeEducationDetail)
        {
            return employeeEducationDetailDao.SearchEmployeeEducationDetail(employeeEducationDetail);
        }

        public object GetEmpEducationDetail(string EmpId)
        {
            return employeeEducationDetailDao.GetEmpEducationDetail(EmpId);
        }

    }
}