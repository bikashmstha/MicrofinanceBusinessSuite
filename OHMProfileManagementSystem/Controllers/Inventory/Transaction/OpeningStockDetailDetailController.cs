using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class OpeningStockDetailDetailController : ControllerBase
    {
        private static IOpeningStockDetailDetailDao openingStockDetailDetailDao = DataAccess.OpeningStockDetailDetailDao;



        public object SaveOpeningStockDetailDetail(OpeningStockDetailDetail openingStockDetailDetail)
        {
            return openingStockDetailDetailDao.SaveOpeningStockDetailDetail(openingStockDetailDetail);
        }
        public object SearchOpeningStockDetailDetail(OpeningStockDetailDetail openingStockDetailDetail)
        {
            return openingStockDetailDetailDao.SearchOpeningStockDetailDetail(openingStockDetailDetail);
        }

        public object GetOpeningStockDtlDetail(string ReferenceNo)
        {
            return openingStockDetailDetailDao.GetOpeningStockDtlDetail(ReferenceNo);
        }

    }
}