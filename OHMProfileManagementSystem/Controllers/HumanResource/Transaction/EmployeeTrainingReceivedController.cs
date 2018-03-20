using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeTrainingReceivedController : ControllerBase
    {
        private static IEmployeeTrainingReceivedDao employeeTrainingReceivedDao = DataAccess.EmployeeTrainingReceivedDao;



        public object SaveEmployeeTrainingReceived(EmployeeTrainingReceived employeeTrainingReceived)
        {
            return employeeTrainingReceivedDao.SaveEmployeeTrainingReceived(employeeTrainingReceived);
        }
        public object SearchEmployeeTrainingReceived(EmployeeTrainingReceived employeeTrainingReceived)
        {
            return employeeTrainingReceivedDao.SearchEmployeeTrainingReceived(employeeTrainingReceived);
        }
    }
}