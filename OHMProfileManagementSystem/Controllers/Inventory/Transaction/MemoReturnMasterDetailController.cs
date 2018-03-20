using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoReturnMasterDetailController : ControllerBase
    {
        private static IMemoReturnMasterDetailDao memoReturnMasterDetailDao = DataAccess.MemoReturnMasterDetailDao;



        public object SaveMemoReturnMasterDetail(MemoReturnMasterDetail memoReturnMasterDetail)
        {
            return memoReturnMasterDetailDao.SaveMemoReturnMasterDetail(memoReturnMasterDetail);
        }
        public object SearchMemoReturnMasterDetail(MemoReturnMasterDetail memoReturnMasterDetail)
        {
            return memoReturnMasterDetailDao.SearchMemoReturnMasterDetail(memoReturnMasterDetail);
        }

        public object GetMemoReturnMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            return memoReturnMasterDetailDao.GetMemoReturnMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
        }

    }
}