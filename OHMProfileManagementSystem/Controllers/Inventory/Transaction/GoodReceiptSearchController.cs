using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptSearchController : ControllerBase
    {
        private static IGoodReceiptSearchDao goodReceiptSearchDao = DataAccess.GoodReceiptSearchDao;



        public object SaveGoodReceiptSearch(GoodReceiptSearch goodReceiptSearch)
        {
            return goodReceiptSearchDao.SaveGoodReceiptSearch(goodReceiptSearch);
        }
        public object SearchGoodReceiptSearch(GoodReceiptSearch goodReceiptSearch)
        {
            return goodReceiptSearchDao.SearchGoodReceiptSearch(goodReceiptSearch);
        }

        public object GetGoodReceiptSearch(string ReferenceNo)
        {
            return goodReceiptSearchDao.GetGoodReceiptSearch(ReferenceNo);
        }

    }
}