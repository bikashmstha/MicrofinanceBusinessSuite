using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource.Transaction;
using DataObjects;
using DataObjects.Interfaces.HumanResource;
namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Transaction
{
    public class EmployeePromotionController : ControllerBase
    {
        private static IEmployeePromotionDao employeePromotionDao = DataAccess.EmployeePromotionDao;



        public object SaveEmployeePromotion(EmployeePromotion employeePromotion)
        {
            return employeePromotionDao.SaveEmployeePromotion(employeePromotion);
        }
        public object SearchEmployeePromotion(EmployeePromotion employeePromotion)
        {
            return employeePromotionDao.SearchEmployeePromotion(employeePromotion);
        }
    }
}