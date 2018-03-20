using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class DamageLostDetailDetailController : ControllerBase
    {
        private static IDamageLostDetailDetailDao damageLostDetailDetailDao = DataAccess.DamageLostDetailDetailDao;



        public object SaveDamageLostDetailDetail(DamageLostDetailDetail damageLostDetailDetail)
        {
            return damageLostDetailDetailDao.SaveDamageLostDetailDetail(damageLostDetailDetail);
        }
        public object SearchDamageLostDetailDetail(DamageLostDetailDetail damageLostDetailDetail)
        {
            return damageLostDetailDetailDao.SearchDamageLostDetailDetail(damageLostDetailDetail);
        }

        public object GetDamageLostDtlDetail(string ReferenceNo)
        {
            return damageLostDetailDetailDao.GetDamageLostDtlDetail(ReferenceNo);
        }

    }
}