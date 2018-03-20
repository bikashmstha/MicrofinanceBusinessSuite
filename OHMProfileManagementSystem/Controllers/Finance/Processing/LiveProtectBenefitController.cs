using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LiveProtectBenefitController : ControllerBase
    {
        private static ILiveProtectBenefitDao LiveProtectBenefitDao = DataAccess.LiveProtectBenefitDao;



        public object SaveLiveProtectBenefit(LiveProtectBenefit LiveProtectBenefit)
        {
            return LiveProtectBenefitDao.SaveLiveProtectBenefit(LiveProtectBenefit);
        }
        public object SearchLiveProtectBenefit(LiveProtectBenefit LiveProtectBenefit)
        {
            return LiveProtectBenefitDao.SearchLiveProtectBenefit(LiveProtectBenefit);
        }

        public object GetLiveProtectBenifit(string OfficeCode, string UserCode)
        {
            return LiveProtectBenefitDao.GetLiveProtectBenifit(OfficeCode, UserCode);
        }

    }
}