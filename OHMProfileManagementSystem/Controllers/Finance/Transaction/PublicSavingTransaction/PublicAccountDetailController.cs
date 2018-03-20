using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicAccountDetailController : ControllerBase
    {
        private static IPublicAccountDetailDao publicAccountDetailDao = DataAccess.PublicAccountDetailDao;



        public object SavePublicAccountDetail(PublicAccountDetail publicAccountDetail)
        {
            return publicAccountDetailDao.SavePublicAccountDetail(publicAccountDetail);
        }
        public object SearchPublicAccountDetail(PublicAccountDetail publicAccountDetail)
        {
            return publicAccountDetailDao.SearchPublicAccountDetail(publicAccountDetail);
        }

        public object GetPubAccDetail(string OfficeCode, string ClientNo, string SavingAccountNo, string ClientName, string ProductClass, string FromDate, string ToDate)
        {
            return publicAccountDetailDao.GetPubAccDetail(OfficeCode, ClientNo, SavingAccountNo, ClientName, ProductClass, FromDate, ToDate);
        }

    }
}