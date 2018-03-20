using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoReturnDetailDetailController : ControllerBase
    {
        private static IMemoReturnDetailDetailDao memoReturnDetailDetailDao = DataAccess.MemoReturnDetailDetailDao;



        public object SaveMemoReturnDetailDetail(MemoReturnDetailDetail memoReturnDetailDetail)
        {
            return memoReturnDetailDetailDao.SaveMemoReturnDetailDetail(memoReturnDetailDetail);
        }
        public object SearchMemoReturnDetailDetail(MemoReturnDetailDetail memoReturnDetailDetail)
        {
            return memoReturnDetailDetailDao.SearchMemoReturnDetailDetail(memoReturnDetailDetail);
        }

        public object GetMemoReturnDetailDtl(string ReferenceNo)
        {
            return memoReturnDetailDetailDao.GetMemoReturnDetailDtl(ReferenceNo);
        }

    }
}