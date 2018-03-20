using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoApprovalMasterDetailController : ControllerBase
    {
        private static IMemoApprovalMasterDetailDao memoApprovalMasterDetailDao = DataAccess.MemoApprovalMasterDetailDao;



        public object SaveMemoApprovalMasterDetail(MemoApprovalMasterDetail memoApprovalMasterDetail)
        {
            return memoApprovalMasterDetailDao.SaveMemoApprovalMasterDetail(memoApprovalMasterDetail);
        }
        public object SearchMemoApprovalMasterDetail(MemoApprovalMasterDetail memoApprovalMasterDetail)
        {
            return memoApprovalMasterDetailDao.SearchMemoApprovalMasterDetail(memoApprovalMasterDetail);
        }

        public object GetMemoApprovalMstDetail(string OfficeCode)
        {
            return memoApprovalMasterDetailDao.GetMemoApprovalMstDetail(OfficeCode);
        }

    }
}