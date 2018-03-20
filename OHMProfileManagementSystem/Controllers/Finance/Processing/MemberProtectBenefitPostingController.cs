using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class MemberProtectBenefitPostingController : ControllerBase
    {
        private static IMemberProtectBenefitPostingDao memberProtectBenefitPostingDao = DataAccess.MemberProtectBenefitPostingDao;



        public object SaveMemberProtectBenefitPosting(List<MemberProtectBenefitPosting> memberProtectBenefitPosting)
        {
            return memberProtectBenefitPostingDao.SaveMemberProtectBenefitPosting(memberProtectBenefitPosting);
        }
        public object SearchMemberProtectBenefitPosting(MemberProtectBenefitPosting memberProtectBenefitPosting)
        {
            return memberProtectBenefitPostingDao.SearchMemberProtectBenefitPosting(memberProtectBenefitPosting);
        }
    }
}