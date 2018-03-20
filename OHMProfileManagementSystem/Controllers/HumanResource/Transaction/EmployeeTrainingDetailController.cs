using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeTrainingDetailController : ControllerBase
    {
        private static IEmployeeTrainingDetailDao employeeTrainingDetailDao = DataAccess.EmployeeTrainingDetailDao;



        public object SaveEmployeeTrainingDetail(EmployeeTrainingDetail employeeTrainingDetail)
        {
            return employeeTrainingDetailDao.SaveEmployeeTrainingDetail(employeeTrainingDetail);
        }
        public object SearchEmployeeTrainingDetail(EmployeeTrainingDetail employeeTrainingDetail)
        {
            return employeeTrainingDetailDao.SearchEmployeeTrainingDetail(employeeTrainingDetail);
        }

        public object GetEmpTrainingDetail(string EmpId)
        {
            return employeeTrainingDetailDao.GetEmpTrainingDetail(EmpId);
        }

    }
}