using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Transaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction
{
    public class MemberForCancellationController : ControllerBase
    {
        private static IMemberForCancellationDao memberforcancellationDao = DataAccess.MemberForCancellationDao;

        public object Get()
        {
            return memberforcancellationDao.Get();
        }

        public object Save(MemberForCancellation memberforcancellation)
        {
            return memberforcancellationDao.Save(memberforcancellation);
        }
        public object Search(MemberForCancellation memberforcancellation)
        {
            return memberforcancellationDao.Search(memberforcancellation);
        }
        public object GetMemberForCancelList(string offCode, string centerCode, string memberName, string clientNo)
        {
            return memberforcancellationDao.GetMemberForCancelList(offCode, centerCode, memberName, clientNo);
        }
    }
}