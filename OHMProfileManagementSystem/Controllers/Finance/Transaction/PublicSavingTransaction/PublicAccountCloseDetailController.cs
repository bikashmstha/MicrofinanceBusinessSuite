using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountCloseDetailController : ControllerBase
    {
        private static IPublicAccountCloseDetailDao publicAccountCloseDetailDao = DataAccess.PublicAccountCloseDetailDao;



        public object SavePublicAccountCloseDetail(PublicAccountCloseDetail publicAccountCloseDetail)
        {
            return publicAccountCloseDetailDao.SavePublicAccountCloseDetail(publicAccountCloseDetail);
        }
        public object SearchPublicAccountCloseDetail(PublicAccountCloseDetail publicAccountCloseDetail)
        {
            return publicAccountCloseDetailDao.SearchPublicAccountCloseDetail(publicAccountCloseDetail);
        }

        public object GetPubAccCloseDetail(string OfficeCode, long? WithdrawalNo, string SavingAccountNo, string ClientName, string FromDate, string ToDate)
        {
            return publicAccountCloseDetailDao.GetPubAccCloseDetail(OfficeCode, WithdrawalNo, SavingAccountNo, ClientName, FromDate, ToDate);
        }

    }
}