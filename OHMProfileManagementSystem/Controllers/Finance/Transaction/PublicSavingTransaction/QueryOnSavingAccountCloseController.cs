using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class QueryOnSavingAccountCloseController : ControllerBase
    {
        private static IQueryOnSavingAccountCloseDao queryOnSavingAccountCloseDao = DataAccess.QueryOnSavingAccountCloseDao;



        

        public object GetQueryOnSavingAcClose(string AccountNo, string SavingProductCode, string WithdrawDate, string Username)
        {
            return queryOnSavingAccountCloseDao.GetQueryOnSavingAcClose(AccountNo, SavingProductCode, WithdrawDate, Username);
        }

    }
}