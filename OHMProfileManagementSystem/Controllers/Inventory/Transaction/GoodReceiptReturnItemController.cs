using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptReturnItemController : ControllerBase
    {
        private static IGoodReceiptReturnItemDao goodReceiptReturnItemDao = DataAccess.GoodReceiptReturnItemDao;



        public object SaveGoodReceiptReturnItem(GoodReceiptReturnItem goodReceiptReturnItem)
        {
            return goodReceiptReturnItemDao.SaveGoodReceiptReturnItem(goodReceiptReturnItem);
        }
        public object SearchGoodReceiptReturnItem(GoodReceiptReturnItem goodReceiptReturnItem)
        {
            return goodReceiptReturnItemDao.SearchGoodReceiptReturnItem(goodReceiptReturnItem);
        }

        public object GetGoodReceiptReturnItem(string ItemDesc, string ReferenceNo)
        {
            return goodReceiptReturnItemDao.GetGoodReceiptReturnItem(ItemDesc, ReferenceNo);
        }

    }
}