using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILiveProtectDepositDao
    {


        object SaveLiveProtectDeposit(LiveProtectDeposit LiveProtectDeposit);

        object SearchLiveProtectDeposit(LiveProtectDeposit LiveProtectDeposit);



        object GetLiveProtectDeposit(string OfficeCode, string UserCode);

    }
}
