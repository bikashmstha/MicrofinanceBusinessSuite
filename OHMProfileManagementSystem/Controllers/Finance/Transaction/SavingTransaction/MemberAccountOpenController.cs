using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class MemberAccountOpenController : ControllerBase
    {
        private static IMemberAccountOpenDao memberAccountOpenDao = DataAccess.MemberAccountOpenDao;

        public object Get()
        {
            return memberAccountOpenDao.Get();
        }

        public object Save(MemberAccountOpen memberAccountOpen)
        {
            return memberAccountOpenDao.Save(memberAccountOpen);
        }
        public object Search(MemberAccountOpen memberAccountOpen)
        {
            return memberAccountOpenDao.Search(memberAccountOpen);
        }

        public object GetMemberAccount( string offCode, string memberName)
        {
            return memberAccountOpenDao.GetMemberAccount(offCode,memberName);
        }
    }
}