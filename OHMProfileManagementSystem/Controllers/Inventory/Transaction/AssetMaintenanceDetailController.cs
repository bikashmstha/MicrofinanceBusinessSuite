using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;
namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class AssetMaintenanceDetailController : ControllerBase
    {
        private static IAssetMaintenanceDetailDao assetMaintenanceDetailDao = DataAccess.AssetMaintenanceDetailDao;



        public object SaveAssetMaintenanceDetail(AssetMaintenanceDetail assetMaintenanceDetail)
        {
            return assetMaintenanceDetailDao.SaveAssetMaintenanceDetail(assetMaintenanceDetail);
        }
        public object SearchAssetMaintenanceDetail(AssetMaintenanceDetail assetMaintenanceDetail)
        {
            return assetMaintenanceDetailDao.SearchAssetMaintenanceDetail(assetMaintenanceDetail);
        }

        public object GetAssetMaintenanceDtl(string AssetCode)
        {
            return assetMaintenanceDetailDao.GetAssetMaintenanceDtl(AssetCode);
        }

    }
}