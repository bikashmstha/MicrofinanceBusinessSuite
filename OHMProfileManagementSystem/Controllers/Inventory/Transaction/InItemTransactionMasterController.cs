using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class InItemTransactionMasterController : ControllerBase
    {
        private static IInItemTransactionMasterDao inItemTransactionMasterDao = DataAccess.InItemTransactionMasterDao;



        public object SaveInItemTransactionMaster(InItemTransactionMaster inItemTransactionMaster)
        {
            return inItemTransactionMasterDao.SaveInItemTransactionMaster(inItemTransactionMaster);
        }
        public object SearchInItemTransactionMaster(InItemTransactionMaster inItemTransactionMaster)
        {
            return inItemTransactionMasterDao.SearchInItemTransactionMaster(inItemTransactionMaster);
        }
    }
}