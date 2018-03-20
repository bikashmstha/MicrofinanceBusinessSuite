using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptMasterDetailController : ControllerBase
    {
        private static IGoodReceiptMasterDetailDao goodReceiptMasterDetailDao = DataAccess.GoodReceiptMasterDetailDao;



        public object SaveGoodReceiptMasterDetail(GoodReceiptMasterDetail goodReceiptMasterDetail)
        {
            return goodReceiptMasterDetailDao.SaveGoodReceiptMasterDetail(goodReceiptMasterDetail);
        }
        public object SearchGoodReceiptMasterDetail(GoodReceiptMasterDetail goodReceiptMasterDetail)
        {
            return goodReceiptMasterDetailDao.SearchGoodReceiptMasterDetail(goodReceiptMasterDetail);
        }

        public object GetGoodReceiptMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            return goodReceiptMasterDetailDao.GetGoodReceiptMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
        }

    }
}