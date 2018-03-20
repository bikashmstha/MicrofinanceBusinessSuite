using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeTransferController : ControllerBase
    {
        private static IEmployeeTransferDao employeeTransferDao = DataAccess.EmployeeTransferDao;



        public object SaveEmployeeTransfer(EmployeeTransfer employeeTransfer)
        {
            return employeeTransferDao.SaveEmployeeTransfer(employeeTransfer);
        }
        public object SearchEmployeeTransfer(EmployeeTransfer employeeTransfer)
        {
            return employeeTransferDao.SearchEmployeeTransfer(employeeTransfer);
        }
    }
}