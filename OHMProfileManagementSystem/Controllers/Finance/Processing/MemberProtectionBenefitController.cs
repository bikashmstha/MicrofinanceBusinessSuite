using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class MemberProtectionBenefitController : ControllerBase
    {
        private static IMemberProtectionBenefitDao memberProtectionBenefitDao = DataAccess.MemberProtectionBenefitDao;



        public object SaveMemberProtectionBenefit(MemberProtectionBenefit memberProtectionBenefit)
        {
            return memberProtectionBenefitDao.SaveMemberProtectionBenefit(memberProtectionBenefit);
        }
        public object SearchMemberProtectionBenefit(MemberProtectionBenefit memberProtectionBenefit)
        {
            return memberProtectionBenefitDao.SearchMemberProtectionBenefit(memberProtectionBenefit);
        }

        public object GetMemProtectBenifit(string OfficeCode, string UserCode)
        {
            return memberProtectionBenefitDao.GetMemProtectBenifit(OfficeCode, UserCode);
        }

    }
}