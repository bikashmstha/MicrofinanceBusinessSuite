using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.EditTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IAdjustmentaccountforwithdrawDao
    {


        object SaveAdjustmentaccountforwithdraw(Adjustmentaccountforwithdraw AdjustmentAccountForWithdraw);

        object SearchAdjustmentaccountforwithdraw(Adjustmentaccountforwithdraw AdjustmentAccountForWithdraw);



        object GetAdjAccForWithdraw(string OfficeCode, string ProductCode, string SavingAccountNo, string CenterCode);

    }
}
