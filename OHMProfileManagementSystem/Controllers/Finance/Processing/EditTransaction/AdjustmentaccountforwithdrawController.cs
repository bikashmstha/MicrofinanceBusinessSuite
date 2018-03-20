using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.EditTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.EditTransaction
{
    public class AdjustmentaccountforwithdrawController : ControllerBase
    {
        private static IAdjustmentaccountforwithdrawDao AdjustmentAccountForWithdrawDao = DataAccess.AdjustmentaccountforwithdrawDao;



        public object SaveAdjustmentaccountforwithdraw(Adjustmentaccountforwithdraw AdjustmentAccountForWithdraw)
        {
            return AdjustmentAccountForWithdrawDao.SaveAdjustmentaccountforwithdraw(AdjustmentAccountForWithdraw);
        }
        public object SearchAdjustmentaccountforwithdraw(Adjustmentaccountforwithdraw AdjustmentAccountForWithdraw)
        {
            return AdjustmentAccountForWithdrawDao.SearchAdjustmentaccountforwithdraw(AdjustmentAccountForWithdraw);
        }

        public object GetAdjAccForWithdraw(string OfficeCode, string ProductCode, string SavingAccountNo, string CenterCode)
        {
            return AdjustmentAccountForWithdrawDao.GetAdjAccForWithdraw(OfficeCode, ProductCode, SavingAccountNo, CenterCode);
        }

    }
}