using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class PublicMemberController : ControllerBase
    {
        private static IPublicMemberDao publicMemberDao = DataAccess.PublicMemberDao;



        public object SavePublicMember(PublicMember publicMember)
        {
            return publicMemberDao.SavePublicMember(publicMember);
        }
        public object SearchPublicMember(PublicMember publicMember)
        {
            return publicMemberDao.SearchPublicMember(publicMember);
        }
    }
}