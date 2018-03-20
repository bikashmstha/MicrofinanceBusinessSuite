using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Processing;
using DataObjects;
using DataObjects.Interfaces.Finance;
namespace MicrofinanceBusinessSuite.Controllers.Finance.Processing
{
    public class LiveProtectDepositController : ControllerBase
    {
        private static ILiveProtectDepositDao LiveProtectDepositDao = DataAccess.LiveProtectDepositDao;



        public object SaveLiveProtectDeposit(LiveProtectDeposit LiveProtectDeposit)
        {
            return LiveProtectDepositDao.SaveLiveProtectDeposit(LiveProtectDeposit);
        }
        public object SearchLiveProtectDeposit(LiveProtectDeposit LiveProtectDeposit)
        {
            return LiveProtectDepositDao.SearchLiveProtectDeposit(LiveProtectDeposit);
        }

        public object GetLiveProtectDeposit(string OfficeCode, string UserCode)
        {
            return LiveProtectDepositDao.GetLiveProtectDeposit(OfficeCode, UserCode);
        }

    }
}