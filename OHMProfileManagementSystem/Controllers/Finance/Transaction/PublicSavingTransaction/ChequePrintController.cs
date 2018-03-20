using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.PublicSavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.PublicSavingTransaction
{
    public class ChequePrintController:ControllerBase
    {
        private static IChequePrintDao chequeGenerateDetailDao = DataAccess.ChequePrintDao;

        public object GetNoOfChequePrint(string offCode, string savingProductCode)
        {
            return chequeGenerateDetailDao.GetNoOfChequePrint(offCode, savingProductCode);
        }

        public object GetAccountChequeList(string accountNo, int? fromChequeNo, int? toChequeNo)
        {
            return chequeGenerateDetailDao.GetAccountChequeList(accountNo, fromChequeNo, toChequeNo);

        }
    }
}