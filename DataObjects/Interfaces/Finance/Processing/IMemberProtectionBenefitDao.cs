using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberProtectionBenefitDao
    {


        object SaveMemberProtectionBenefit(MemberProtectionBenefit memberProtectionBenefit);

        object SearchMemberProtectionBenefit(MemberProtectionBenefit memberProtectionBenefit);



        object GetMemProtectBenifit(string OfficeCode, string UserCode);

    }
}
