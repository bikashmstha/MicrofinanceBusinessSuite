using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicSavingAccountOpenController : ControllerBase
    {
        private static IPublicSavingAccountOpenDao publicSavingAccountOpenDao = DataAccess.PublicSavingAccountOpenDao;



        public object SavePublicSavingAccountOpen(PublicSavingAccountOpen publicSavingAccountOpen)
        {
            return publicSavingAccountOpenDao.SavePublicSavingAccountOpen(publicSavingAccountOpen);
        }
        public object SearchPublicSavingAccountOpen(PublicSavingAccountOpen publicSavingAccountOpen)
        {
            return publicSavingAccountOpenDao.SearchPublicSavingAccountOpen(publicSavingAccountOpen);
        }



    }
}