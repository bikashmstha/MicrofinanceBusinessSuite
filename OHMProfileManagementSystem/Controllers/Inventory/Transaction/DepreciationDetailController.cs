using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;
namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class DepreciationDetailController : ControllerBase
    {
        private static IDepreciationDetailDao depreciationDetailDao = DataAccess.DepreciationDetailDao;



        public object SaveDepreciationDetail(DepreciationDetail depreciationDetail)
        {
            return depreciationDetailDao.SaveDepreciationDetail(depreciationDetail);
        }
        public object SearchDepreciationDetail(DepreciationDetail depreciationDetail)
        {
            return depreciationDetailDao.SearchDepreciationDetail(depreciationDetail);
        }

        public object GetDepreciationDetail(string AssetCode)
        {
            return depreciationDetailDao.GetDepreciationDetail(AssetCode);
        }

    }
}