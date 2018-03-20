using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoApprovalDetailController : ControllerBase
    {
        private static IMemoApprovalDetailDao memoApprovalDetailDao = DataAccess.MemoApprovalDetailDao;



        public object SaveMemoApprovalDetail(MemoApprovalDetail memoApprovalDetail)
        {
            return memoApprovalDetailDao.SaveMemoApprovalDetail(memoApprovalDetail);
        }
        public object SearchMemoApprovalDetail(MemoApprovalDetail memoApprovalDetail)
        {
            return memoApprovalDetailDao.SearchMemoApprovalDetail(memoApprovalDetail);
        }

        public object GetMemoApprovalDtlDetail(string ReferenceNo)
        {
            return memoApprovalDetailDao.GetMemoApprovalDtlDetail(ReferenceNo);
        }

        

    }
}