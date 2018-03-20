using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PubSavingDepositDetailController : ControllerBase
    {
        private static IPubSavingDepositDetailDao pubSavingDepositDetailDao = DataAccess.PubSavingDepositDetailDao;



        public object SavePubSavingDepositDetail(PubSavingDepositDetail pubSavingDepositDetail)
        {
            return pubSavingDepositDetailDao.SavePubSavingDepositDetail(pubSavingDepositDetail);
        }
        public object SearchPubSavingDepositDetail(PubSavingDepositDetail pubSavingDepositDetail)
        {
            return pubSavingDepositDetailDao.SearchPubSavingDepositDetail(pubSavingDepositDetail);
        }

        public object GetPubSavDepoDetail(string OfficeCode, long? DepositNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            return pubSavingDepositDetailDao.GetPubSavDepoDetail(OfficeCode, DepositNo, SavingAccountNo, ClientName, FromDate, ToDate);
        }

    }
}