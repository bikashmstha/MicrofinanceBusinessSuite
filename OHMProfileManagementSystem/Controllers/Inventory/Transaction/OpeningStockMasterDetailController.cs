using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class OpeningStockMasterDetailController : ControllerBase
    {
        private static IOpeningStockMasterDetailDao openingStockMasterDetailDao = DataAccess.OpeningStockMasterDetailDao;



        public object SaveOpeningStockMasterDetail(OpeningStockMasterDetail openingStockMasterDetail)
        {
            return openingStockMasterDetailDao.SaveOpeningStockMasterDetail(openingStockMasterDetail);
        }
        public object SearchOpeningStockMasterDetail(OpeningStockMasterDetail openingStockMasterDetail)
        {
            return openingStockMasterDetailDao.SearchOpeningStockMasterDetail(openingStockMasterDetail);
        }

        public object GetOpeningStockMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            return openingStockMasterDetailDao.GetOpeningStockMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
        }

    }
}