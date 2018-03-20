using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptDetailDetailController : ControllerBase
    {
        private static IGoodReceiptDetailDetailDao goodReceiptDetailDetailDao = DataAccess.GoodReceiptDetailDetailDao;



        public object SaveGoodReceiptDetailDetail(GoodReceiptDetailDetail goodReceiptDetailDetail)
        {
            return goodReceiptDetailDetailDao.SaveGoodReceiptDetailDetail(goodReceiptDetailDetail);
        }
        public object SearchGoodReceiptDetailDetail(GoodReceiptDetailDetail goodReceiptDetailDetail)
        {
            return goodReceiptDetailDetailDao.SearchGoodReceiptDetailDetail(goodReceiptDetailDetail);
        }

        public object GetGoodReceiptDtlDetail(string ReferenceNo)
        {
            return goodReceiptDetailDetailDao.GetGoodReceiptDtlDetail(ReferenceNo);
        }

    }
}