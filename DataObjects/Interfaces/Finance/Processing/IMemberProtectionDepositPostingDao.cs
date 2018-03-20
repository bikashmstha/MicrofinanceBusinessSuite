using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberProtectionDepositPostingDao
    {


        object SaveMemberProtectionDepositPosting(List<MemberProtectionDepositPosting> memberProtectionDepositPosting);

        object SearchMemberProtectionDepositPosting(MemberProtectionDepositPosting memberProtectionDepositPosting);

    }
}
