using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class MemberProtectionDepositController : ControllerBase
    {
        private static IMemberProtectionDepositDao memberProtectionDepositDao = DataAccess.MemberProtectionDepositDao;



        public object SaveMemberProtectionDeposit(MemberProtectionDeposit memberProtectionDeposit)
        {
            return memberProtectionDepositDao.SaveMemberProtectionDeposit(memberProtectionDeposit);
        }
        public object SearchMemberProtectionDeposit(MemberProtectionDeposit memberProtectionDeposit)
        {
            return memberProtectionDepositDao.SearchMemberProtectionDeposit(memberProtectionDeposit);
        }

        public object GetMemProtectDeposit(string OfficeCode, string UserCode)
        {
            return memberProtectionDepositDao.GetMemProtectDeposit(OfficeCode, UserCode);
        }

    }
}