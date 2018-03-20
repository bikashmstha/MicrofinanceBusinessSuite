using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class MemberForChequeController : ControllerBase
    {
        private static IMemberForChequeDao memberForChequeDao = DataAccess.MemberForChequeDao;

        public object Get()
        {
            return memberForChequeDao.Get();
        }

        public object Save(MemberForCheque memberForCheque)
        {
            return memberForChequeDao.Save(memberForCheque);
        }
        public object Search(MemberForCheque memberForCheque)
        {
            return memberForChequeDao.Search(memberForCheque);
        }
        public object GetMemberForCheque(String offCode, string centerCode, string memberName)
        {
            return memberForChequeDao.GetMemberForCheque(offCode,centerCode,memberName);
        }
    }
}