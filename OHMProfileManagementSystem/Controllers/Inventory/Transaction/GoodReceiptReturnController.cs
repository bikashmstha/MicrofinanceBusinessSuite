using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptReturnController : ControllerBase
    {
        private static IGoodReceiptReturnDao goodReceiptReturnDao = DataAccess.GoodReceiptReturnDao;



        public object SaveGoodReceiptReturn(GoodReceiptReturn goodReceiptReturn)
        {
            return goodReceiptReturnDao.SaveGoodReceiptReturn(goodReceiptReturn);
        }
        public object SearchGoodReceiptReturn(GoodReceiptReturn goodReceiptReturn)
        {
            return goodReceiptReturnDao.SearchGoodReceiptReturn(goodReceiptReturn);
        }

        public object GetGoodReceiptReturn(string ReferenceNo)
        {
            return goodReceiptReturnDao.GetGoodReceiptReturn(ReferenceNo);
        }

    }
}