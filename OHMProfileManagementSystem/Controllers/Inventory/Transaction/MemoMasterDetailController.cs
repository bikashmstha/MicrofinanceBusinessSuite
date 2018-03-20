using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoMasterDetailController : ControllerBase
    {
        private static IMemoMasterDetailDao memoMasterDetailDao = DataAccess.MemoMasterDetailDao;



        public object SaveMemoMasterDetail(MemoMasterDetail memoMasterDetail)
        {
            return memoMasterDetailDao.SaveMemoMasterDetail(memoMasterDetail);
        }
        public object SearchMemoMasterDetail(MemoMasterDetail memoMasterDetail)
        {
            return memoMasterDetailDao.SearchMemoMasterDetail(memoMasterDetail);
        }

        public object GetMemoMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            return memoMasterDetailDao.GetMemoMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
        }

    }
}