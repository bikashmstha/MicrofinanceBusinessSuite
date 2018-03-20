using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class PublicSavingWithdrawDetailController : ControllerBase
    {
        private static IPublicSavingWithdrawDetailDao publicSavingWithdrawDetailDao = DataAccess.PublicSavingWithdrawDetailDao;



        public object SavePublicSavingWithdrawDetail(PublicSavingWithdrawDetail publicSavingWithdrawDetail)
        {
            return publicSavingWithdrawDetailDao.SavePublicSavingWithdrawDetail(publicSavingWithdrawDetail);
        }
        public object SearchPublicSavingWithdrawDetail(PublicSavingWithdrawDetail publicSavingWithdrawDetail)
        {
            return publicSavingWithdrawDetailDao.SearchPublicSavingWithdrawDetail(publicSavingWithdrawDetail);
        }

        public object GetPubSavWithDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            return publicSavingWithdrawDetailDao.GetPubSavWithDetail(OfficeCode, WithdrawalNo, SavingAccountNo, ClientName, FromDate, ToDate);
        }

    }
}