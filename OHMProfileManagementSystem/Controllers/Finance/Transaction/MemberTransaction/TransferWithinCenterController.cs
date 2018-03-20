using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction
{
    public class TransferWithinCenterController : ControllerBase
    {
        private static ITransferWithinCenterDao transferwithincenterDao = DataAccess.TransferWithinCenterDao;

        public object Get()
        {
            return transferwithincenterDao.Get();
        }

        public object Save(TransferWithinCenter transferwithincenter)
        {
            return transferwithincenterDao.Save(transferwithincenter);
        }
        public object Search(TransferWithinCenter transferwithincenter)
        {
            return transferwithincenterDao.Search(transferwithincenter);
        }
    }
}