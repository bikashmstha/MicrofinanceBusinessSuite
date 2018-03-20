using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class GoodReceiptReturnMasterDetailController : ControllerBase
    {
        private static IGoodReceiptReturnMasterDetailDao goodReceiptReturnMasterDetailDao = DataAccess.GoodReceiptReturnMasterDetailDao;



        public object SaveGoodReceiptReturnMasterDetail(GoodReceiptReturnMasterDetail goodReceiptReturnMasterDetail)
        {
            return goodReceiptReturnMasterDetailDao.SaveGoodReceiptReturnMasterDetail(goodReceiptReturnMasterDetail);
        }
        public object SearchGoodReceiptReturnMasterDetail(GoodReceiptReturnMasterDetail goodReceiptReturnMasterDetail)
        {
            return goodReceiptReturnMasterDetailDao.SearchGoodReceiptReturnMasterDetail(goodReceiptReturnMasterDetail);
        }

        public object GetGoodReceiptReturnMstDtl(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            return goodReceiptReturnMasterDetailDao.GetGoodReceiptReturnMstDtl(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
        }

    }
}