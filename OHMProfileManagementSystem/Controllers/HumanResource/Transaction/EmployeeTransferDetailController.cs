using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeeTransferDetailController : ControllerBase
    {
        private static IEmployeeTransferDetailDao employeeTransferDetailDao = DataAccess.EmployeeTransferDetailDao;



        public object SaveEmployeeTransferDetail(EmployeeTransferDetail employeeTransferDetail)
        {
            return employeeTransferDetailDao.SaveEmployeeTransferDetail(employeeTransferDetail);
        }
        public object SearchEmployeeTransferDetail(EmployeeTransferDetail employeeTransferDetail)
        {
            return employeeTransferDetailDao.SearchEmployeeTransferDetail(employeeTransferDetail);
        }

        public object GetEmpTransferDetail(string EmpId)
        {
            return employeeTransferDetailDao.GetEmpTransferDetail(EmpId);
        }

    }
}