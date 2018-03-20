using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptReturnDetailController : ControllerBase
    {
        private static IGoodReceiptReturnDetailDao goodReceiptReturnDetailDao = DataAccess.GoodReceiptReturnDetailDao;



        public object SaveGoodReceiptReturnDetail(GoodReceiptReturnDetail goodReceiptReturnDetail)
        {
            return goodReceiptReturnDetailDao.SaveGoodReceiptReturnDetail(goodReceiptReturnDetail);
        }
        public object SearchGoodReceiptReturnDetail(GoodReceiptReturnDetail goodReceiptReturnDetail)
        {
            return goodReceiptReturnDetailDao.SearchGoodReceiptReturnDetail(goodReceiptReturnDetail);
        }

        public object GetGoodReceiptReturnDetail(string ReferenceNo)
        {
            return goodReceiptReturnDetailDao.GetGoodReceiptReturnDetail(ReferenceNo);
        }

    }
}