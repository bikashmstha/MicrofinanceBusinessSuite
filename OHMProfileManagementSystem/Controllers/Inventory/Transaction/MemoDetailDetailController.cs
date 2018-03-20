using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoDetailDetailController : ControllerBase
    {
        private static IMemoDetailDetailDao memoDetailDetailDao = DataAccess.MemoDetailDetailDao;



        public object SaveMemoDetailDetail(MemoDetailDetail memoDetailDetail)
        {
            return memoDetailDetailDao.SaveMemoDetailDetail(memoDetailDetail);
        }
        public object SearchMemoDetailDetail(MemoDetailDetail memoDetailDetail)
        {
            return memoDetailDetailDao.SearchMemoDetailDetail(memoDetailDetail);
        }

        public object GetMemoDtlDetail(string ReferenceNo)
        {
            return memoDetailDetailDao.GetMemoDtlDetail(ReferenceNo);
        }

    }
}