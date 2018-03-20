using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface ILiveProtectBenefitDao
    {


        object SaveLiveProtectBenefit(LiveProtectBenefit LiveProtectBenefit);

        object SearchLiveProtectBenefit(LiveProtectBenefit LiveProtectBenefit);



        object GetLiveProtectBenifit(string OfficeCode, string UserCode);

    }
}
