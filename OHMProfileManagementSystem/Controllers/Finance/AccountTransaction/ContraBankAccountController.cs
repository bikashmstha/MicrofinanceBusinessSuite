using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.AccountTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.AccountTransaction
{
    public class ContraBankAccountController : ControllerBase
    {
        private static IContraBankAccountDao contraBankAccountDao = DataAccess.ContraBankAccountDao;



        public object SaveContraBankAccount(ContraBankAccount contraBankAccount)
        {
            return contraBankAccountDao.SaveContraBankAccount(contraBankAccount);
        }
        public object SearchContraBankAccount(ContraBankAccount contraBankAccount)
        {
            return contraBankAccountDao.SearchContraBankAccount(contraBankAccount);
        }

        public object GetContraBnkAcc(string AccountDesc)
        {
            return contraBankAccountDao.GetContraBnkAcc(AccountDesc);
        }

    }
}