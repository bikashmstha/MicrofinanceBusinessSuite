using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoApprovalController : ControllerBase
    {
        private static IMemoApprovalDao memoApprovalDao = DataAccess.MemoApprovalDao;



        public object SaveMemoApproval(MemoApproval memoApproval)
        {
            return memoApprovalDao.SaveMemoApproval(memoApproval);
        }
        public object SearchMemoApproval(MemoApproval memoApproval)
        {
            return memoApprovalDao.SearchMemoApproval(memoApproval);
        }
    }
}