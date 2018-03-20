using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class MemberProtectionDepositPostingController : ControllerBase
    {
        private static IMemberProtectionDepositPostingDao memberProtectionDepositPostingDao = DataAccess.MemberProtectionDepositPostingDao;



        public object SaveMemberProtectionDepositPosting(List<MemberProtectionDepositPosting> memberProtectionDepositPosting)
        {
            return memberProtectionDepositPostingDao.SaveMemberProtectionDepositPosting(memberProtectionDepositPosting);
        }
        public object SearchMemberProtectionDepositPosting(MemberProtectionDepositPosting memberProtectionDepositPosting)
        {
            return memberProtectionDepositPostingDao.SearchMemberProtectionDepositPosting(memberProtectionDepositPosting);
        }
    }
}