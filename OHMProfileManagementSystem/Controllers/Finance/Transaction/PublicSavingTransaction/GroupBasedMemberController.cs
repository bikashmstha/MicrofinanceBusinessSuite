using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class GroupBasedMemberController : ControllerBase
    {
        private static IGroupBasedMemberDao groupBasedMemberDao = DataAccess.GroupBasedMemberDao;



        public object SaveGroupBasedMember(GroupBasedMember groupBasedMember)
        {
            return groupBasedMemberDao.SaveGroupBasedMember(groupBasedMember);
        }
        public object SearchGroupBasedMember(GroupBasedMember groupBasedMember)
        {
            return groupBasedMemberDao.SearchGroupBasedMember(groupBasedMember);
        }

        public object GetGroupBasedMem(string OfficeCode, string ClientName)
        {
            return groupBasedMemberDao.GetGroupBasedMem(OfficeCode, ClientName);
        }

    }
}