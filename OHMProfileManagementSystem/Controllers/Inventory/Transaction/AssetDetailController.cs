using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Inventory.Transaction;
using DataObjects;
using DataObjects.Interfaces.Inventory;

namespace MicrofinanceBusinessSuite.Controllers.Inventory.Transaction
{
    public class AssetDetailController : ControllerBase
    {
        private static IAssetDetailDao assetDetailDao = DataAccess.AssetDetailDao;



        public object SaveAssetDetail(AssetDetail assetDetail)
        {
            return assetDetailDao.SaveAssetDetail(assetDetail);
        }
        public object SearchAssetDetail(AssetDetail assetDetail)
        {
            return assetDetailDao.SearchAssetDetail(assetDetail);
        }

        public object GetAssetDetail(AssetDetail assetDetail)
        {
            return assetDetailDao.GetAssetDetail(assetDetail);
        }

    }
}