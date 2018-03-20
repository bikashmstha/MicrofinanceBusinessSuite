using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class MemoReturnReferenceNoController : ControllerBase
    {
        private static IMemoReturnReferenceNoDao memoreturnReferenceNoDao = DataAccess.MemoReturnReferenceNoDao;



        public object SaveMemoReturnReferenceNo(MemoReturnReferenceNo memoreturnReferenceNo)
        {
            return memoreturnReferenceNoDao.SaveMemoReturnReferenceNo(memoreturnReferenceNo);
        }
        public object SearchMemoReturnReferenceNo(MemoReturnReferenceNo memoreturnReferenceNo)
        {
            return memoreturnReferenceNoDao.SearchMemoReturnReferenceNo(memoreturnReferenceNo);
        }

        public object GetMemoReturnRefNo(string ReferenceNo)
        {
            return memoreturnReferenceNoDao.GetMemoReturnRefNo(ReferenceNo);
        }

    }
}