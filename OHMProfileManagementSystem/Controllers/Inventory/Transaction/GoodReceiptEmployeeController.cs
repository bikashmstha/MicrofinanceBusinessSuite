using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptEmployeeController : ControllerBase
    {
        private static IGoodReceiptEmployeeDao goodReceiptEmployeeDao = DataAccess.GoodReceiptEmployeeDao;



        public object SaveGoodReceiptEmployee(GoodReceiptEmployee goodReceiptEmployee)
        {
            return goodReceiptEmployeeDao.SaveGoodReceiptEmployee(goodReceiptEmployee);
        }
        public object SearchGoodReceiptEmployee(GoodReceiptEmployee goodReceiptEmployee)
        {
            return goodReceiptEmployeeDao.SearchGoodReceiptEmployee(goodReceiptEmployee);
        }

        public object GetGoodReceiptEmp()
        {
            return goodReceiptEmployeeDao.GetGoodReceiptEmp();
        }

    }
}