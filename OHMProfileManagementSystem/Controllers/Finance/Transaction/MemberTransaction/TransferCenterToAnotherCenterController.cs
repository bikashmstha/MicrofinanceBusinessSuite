using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction
{
    public class TransferCenterToAnotherCenterController : ControllerBase
    {
        private static ITransferCenterToAnotherCenterDao TransferCenterToAnotherCenterDao = DataAccess.TransferCenterToAnotherCenterDao;

        public object Get()
        {
            return TransferCenterToAnotherCenterDao.Get();
        }

        public object Save(TransferCenterToAnotherCenter TransferCenterToAnotherCenter)
        {
            return TransferCenterToAnotherCenterDao.Save(TransferCenterToAnotherCenter);
        }
        public object Search(TransferCenterToAnotherCenter TransferCenterToAnotherCenter)
        {
            return TransferCenterToAnotherCenterDao.Search(TransferCenterToAnotherCenter);
        }
    }
}