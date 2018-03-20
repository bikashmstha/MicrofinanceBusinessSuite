using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberProtectionDepositDao
    {


        object SaveMemberProtectionDeposit(MemberProtectionDeposit memberProtectionDeposit);

        object SearchMemberProtectionDeposit(MemberProtectionDeposit memberProtectionDeposit);



        object GetMemProtectDeposit(string OfficeCode, string UserCode);

    }
}
