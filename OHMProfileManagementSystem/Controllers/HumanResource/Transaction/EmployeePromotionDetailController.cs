using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeePromotionDetailController : ControllerBase
    {
        private static IEmployeePromotionDetailDao employeePromotionDetailDao = DataAccess.EmployeePromotionDetailDao;



        public object SaveEmployeePromotionDetail(EmployeePromotionDetail employeePromotionDetail)
        {
            return employeePromotionDetailDao.SaveEmployeePromotionDetail(employeePromotionDetail);
        }
        public object SearchEmployeePromotionDetail(EmployeePromotionDetail employeePromotionDetail)
        {
            return employeePromotionDetailDao.SearchEmployeePromotionDetail(employeePromotionDetail);
        }

        public object GetEmpPromotionDetail(string EmpId)
        {
            return employeePromotionDetailDao.GetEmpPromotionDetail(EmpId);
        }

    }
}