using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.StaffLoanTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.StaffLoanTransaction
{
    public class EmployeeKycInfoController : ControllerBase
    {
        private static IEmployeeKycInfoDao employeeKycInfoDao = DataAccess.EmployeeKycInfoDao;



        public object SaveEmployeeKycInfo(EmployeeKycInfo employeeKycInfo)
        {
            return employeeKycInfoDao.SaveEmployeeKycInfo(employeeKycInfo);
        }
        public object SearchEmployeeKycInfo(EmployeeKycInfo employeeKycInfo)
        {
            return employeeKycInfoDao.SearchEmployeeKycInfo(employeeKycInfo);
        }
    }
}