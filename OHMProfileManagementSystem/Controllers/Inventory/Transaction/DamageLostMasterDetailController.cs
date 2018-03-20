using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class DamageLostMasterDetailController : ControllerBase
    {
        private static IDamageLostMasterDetailDao damageLostMasterDetailDao = DataAccess.DamageLostMasterDetailDao;



        public object SaveDamageLostMasterDetail(DamageLostMasterDetail damageLostMasterDetail)
        {
            return damageLostMasterDetailDao.SaveDamageLostMasterDetail(damageLostMasterDetail);
        }
        public object SearchDamageLostMasterDetail(DamageLostMasterDetail damageLostMasterDetail)
        {
            return damageLostMasterDetailDao.SearchDamageLostMasterDetail(damageLostMasterDetail);
        }

        public object GetDamageLostMstDetail(string OfficeCode, string ReferenceNo, string FiscalYear, string LocationCode, string FromDate, string ToDate)
        {
            return damageLostMasterDetailDao.GetDamageLostMstDetail(OfficeCode, ReferenceNo, FiscalYear, LocationCode, FromDate, ToDate);
        }

    }
}