using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction;
using DataObjects;
using DataObjects.Interfaces.Finance;

namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.MemberTransaction
{
    public class DropOutReasonsController : ControllerBase
    {
        private static IDropOutReasonDao DropOutReasonsDao = DataAccess.DropOutReasonDao;

        public object Get()
        {
            return DropOutReasonsDao.Get();
        }

        public object Save(DropOutReasons DropOutReasons)
        {
            return DropOutReasonsDao.Save(DropOutReasons);
        }
        public object Search(DropOutReasons DropOutReasons)
        {
            return DropOutReasonsDao.Search(DropOutReasons);
        }
        public  object GetCDReason(string reasonDesc)
        {
            return DropOutReasonsDao.GetCDReason(reasonDesc);
        }
    }
}