using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class ClientSavingAccountController : ControllerBase
    {
        private static IClientSavingAccountDao clientSavingAccountDao = DataAccess.ClientSavingAccountDao;

        public object Get()
        {
            return clientSavingAccountDao.Get();
        }

        public object Save(ClientSavingAccount clientSavingAccount)
        {
            return clientSavingAccountDao.Save(clientSavingAccount);
        }
        public object Search(ClientSavingAccount clientSavingAccount)
        {
            return clientSavingAccountDao.Search(clientSavingAccount);
        }
        public object GetMemberAccountOpen(string offCode, string memberName)
        {
            return clientSavingAccountDao.GetMemberAccountOpen(offCode,memberName);
        }
        public object GetMemberAccountForCheque(string offCode, string clientNo)
        {
            return clientSavingAccountDao.GetMemberAccountForCheque(offCode, clientNo);
        }
    }
}