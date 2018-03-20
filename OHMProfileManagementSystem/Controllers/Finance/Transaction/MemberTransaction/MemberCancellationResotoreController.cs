using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction
{
    public class MemberCancellationRestoreController : ControllerBase
    {
        private static IMemberCancellationRestoreDao membercancellationrestoreDao = DataAccess.MemberCancellationRestoreDao;

        public object Get()
        {
            return membercancellationrestoreDao.Get();
        }

        public object Save(MemberCancellationRestore membercancellationrestore)
        {
            return membercancellationrestoreDao.Save(membercancellationrestore);
        }
        public object Search(MemberCancellationRestore membercancellationrestore)
        {
            return membercancellationrestoreDao.Search(membercancellationrestore);
        }
    }
}