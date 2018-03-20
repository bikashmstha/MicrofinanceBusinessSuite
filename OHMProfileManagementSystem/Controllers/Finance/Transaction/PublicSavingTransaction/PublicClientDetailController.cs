using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicClientDetailController : ControllerBase
    {
        private static IPublicClientDetailDao publicClientDetailDao = DataAccess.PublicClientDetailDao;



        public object SavePublicClientDetail(PublicClientDetail publicClientDetail)
        {
            return publicClientDetailDao.SavePublicClientDetail(publicClientDetail);
        }
        public object SearchPublicClientDetail(PublicClientDetail publicClientDetail)
        {
            return publicClientDetailDao.SearchPublicClientDetail(publicClientDetail);
        }

        public object GetPubClientDetail(string OfficeCode, string MemberCode, string MemberName, string MemDateFrom, string MemDateTo)
        {
            return publicClientDetailDao.GetPubClientDetail(OfficeCode, MemberCode, MemberName, MemDateFrom, MemDateTo);
        }

    }
}